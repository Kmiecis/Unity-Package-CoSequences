using System;
using System.Linq;
using System.Reflection;
using Common.Coroutines;
using UnityEditor;
using UnityEngine;

namespace CommonEditor.Coroutines
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(CoSequence))]
    public class CoSequenceEditor : Editor
    {
        private readonly Type SubclassType = typeof(Segment);

        private CoSequence _target;
        private int _count;
        
        private void ShowAddMenu()
        {
            var menu = new GenericMenu();
            
            var added = 0;
            
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            for (int i = 0; i < assemblies.Length; ++i)
            {
                var assembly = assemblies[i];
                
                var types = assembly.FindTypes(t => t.IsSubclassOf(SubclassType) && !t.IsAbstract);
                
                if (types.Any())
                {
                    if (added > 0)
                    {
                        menu.AddSeparator(string.Empty);
                    }
                    added += 1;
                }
                
                foreach (var type in types)
                {
                    var attribute = type.GetCustomAttribute<SegmentMenuAttribute>();
                    var menuPath = attribute.GetMenuPathOrDefault("Custom");
                    var fileName = attribute.GetFileNameOrDefault(type.Name);

                    var path = $"{menuPath}/{fileName}";
                
                    menu.AddItem(new GUIContent(path), false, OnMenuAdd, type);
                }
            }
            
            menu.ShowAsContext();
        }

        private void OnMenuAdd(object type)
        {
            AddSegmentOfType((Type)type);
        }
        
        private void AddSegment(Segment instance)
        {
            _target.AddSegment(instance);

            _count = _target.SegmentCount;
        }

        private void AddSegmentOfType(Type type)
        {
            var instance = (Segment)Activator.CreateInstance(type);

            AddSegment(instance);
        }

        private void CheckSequenceChange()
        {
            var current = _target.SegmentCount;
            if (current > _count)
            {
                var added = _target.GetLastSegment();
                _target.RemoveLastSegment();

                if (added == null)
                {
                    ShowAddMenu();
                }
                else
                {
                    AddSegmentOfType(added.GetType());
                }
            }
            else
            {
                _count = current;
            }
        }
        
        private void OnEnable()
        {
            _target = (CoSequence)target;
            _count = _target.SegmentCount;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            CheckSequenceChange();
        }
    }
}