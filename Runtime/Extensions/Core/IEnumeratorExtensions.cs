using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common.Coroutines
{
    public static partial class IEnumeratorExtensions
    {
        #region Then
        public static IEnumerator Then(this IEnumerator self, YieldInstruction yield)
        {
            return self.Then(UCoroutine.Yield(yield));
        }

        public static IEnumerator Then(this IEnumerator self, Coroutine coroutine)
        {
            return self.Then(UCoroutine.Yield(coroutine));
        }

        public static IEnumerator Then(this IEnumerator self, Action callback)
        {
            return self.Then(UCoroutine.Yield(callback));
        }

        public static IEnumerator<T> Then<T>(this IEnumerator<T> self, Func<T> provider)
        {
            return self.Then(UCoroutine.Yield(provider));
        }

        public static IEnumerator Then(this IEnumerator self, Func<IEnumerator> provider)
        {
            return self.Then(UCoroutine.Yield(provider));
        }

        public static IEnumerator<T> Then<T>(this IEnumerator<T> self, Func<IEnumerator<T>> provider)
        {
            return self.Then(UCoroutine.Yield(provider));
        }

        public static IEnumerator Then(this IEnumerator self, IEnumerator coroutine)
        {
            return UCoroutine.YieldSequentially(self, coroutine);
        }

        public static IEnumerator<T> Then<T>(this IEnumerator<T> self, IEnumerator<T> coroutine)
        {
            return UCoroutine.YieldSequentially(self, coroutine);
        }
        #endregion

        #region With
        public static IEnumerator With(this IEnumerator self, YieldInstruction yield)
        {
            return self.With(UCoroutine.Yield(yield));
        }

        public static IEnumerator With(this IEnumerator self, Coroutine coroutine)
        {
            return self.With(UCoroutine.Yield(coroutine));
        }

        public static IEnumerator With(this IEnumerator self, Action callback)
        {
            return self.With(UCoroutine.Yield(callback));
        }

        public static IEnumerator With(this IEnumerator self, Func<IEnumerator> provider)
        {
            return self.With(UCoroutine.Yield(provider));
        }

        public static IEnumerator With(this IEnumerator self, IEnumerator coroutine)
        {
            return UCoroutine.YieldParallel(self, coroutine);
        }
        #endregion

        #region Wait
        public static IEnumerator Wait(this IEnumerator self, float duration)
        {
            return self.Then(UCoroutine.YieldTime(duration));
        }

        public static IEnumerator WaitRealtime(this IEnumerator self, float duration)
        {
            return self.Then(UCoroutine.YieldRealtime(duration));
        }
        #endregion

        #region Into
        public static IEnumerator Into<T>(this IEnumerator<T> self, Action<T> consumer)
        {
            return UCoroutine.YieldInto(self, consumer);
        }

        public static IEnumerator<U> Into<T, U>(this IEnumerator<T> self, Func<T, U> parser)
        {
            return UCoroutine.YieldInto(self, parser);
        }
        #endregion

        #region While
        public static IEnumerator While(this IEnumerator self, Func<bool> verifier)
        {
            return UCoroutine.YieldWhile(self, verifier);
        }

        public static IEnumerator<T> While<T>(this IEnumerator<T> self, Func<bool> verifier)
        {
            return UCoroutine.YieldWhile(self, verifier);
        }
        #endregion

        public static Coroutine Start(this IEnumerator self, MonoBehaviour target)
        {
            if (target.isActiveAndEnabled)
                return target.StartCoroutine(self);
            return null;
        }
    }
}