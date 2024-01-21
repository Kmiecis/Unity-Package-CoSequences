using System;
using System.Collections;
using UnityEngine;

namespace Common.Coroutines.Segments
{
    [Serializable]
    public abstract class SpriteRendererSegment<T> : TimedSegment
    {
        public SpriteRenderer renderer;
        public T target;
    }
    
    [SegmentMenu("Color", SegmentPath.SpriteRenderer, SegmentGroup.Core)]
    public sealed class SpriteRendererColorSegment : SpriteRendererSegment<Color>
    {
        public override void OnAdded()
            => target = Color.white;

        public override IEnumerator CoExecute()
            => renderer.CoColor(target, duration, easer.Evaluate);
    }
    
    [SegmentMenu("Fade", SegmentPath.SpriteRenderer, SegmentGroup.Core)]
    public sealed class SpriteRendererFadeSegment : SpriteRendererSegment<float>
    {
        public override void OnValidate()
            => target = Mathf.Clamp(target, 0.0f, 1.0f);
    
        public override IEnumerator CoExecute()
            => renderer.CoFade(target, duration, easer.Evaluate);
    }
    
    [SegmentMenu("Gradient", SegmentPath.SpriteRenderer, SegmentGroup.Core)]
    public sealed class SpriteRendererGradientSegment : SpriteRendererSegment<Gradient>
    {
        public override IEnumerator CoExecute()
            => renderer.CoGradient(target, duration, easer.Evaluate);
    }
    
    [SegmentMenu("Size", SegmentPath.SpriteRenderer, SegmentGroup.Core)]
    public sealed class SpriteRendererSizeSegment : SpriteRendererSegment<Vector2>
    {
        public override IEnumerator CoExecute()
            => renderer.CoSize(target, duration, easer.Evaluate);
    }

    [SegmentMenu("SizeX", SegmentPath.SpriteRenderer, SegmentGroup.Core)]
    public sealed class SpriteRendererSizeXSegment : SpriteRendererSegment<float>
    {
        public override IEnumerator CoExecute()
            => renderer.CoSizeX(target, duration, easer.Evaluate);
    }
    
    [SegmentMenu("SizeY", SegmentPath.SpriteRenderer, SegmentGroup.Core)]
    public sealed class SpriteRendererSizeYSegment : SpriteRendererSegment<float>
    {
        public override IEnumerator CoExecute()
            => renderer.CoSizeY(target, duration, easer.Evaluate);
    }
}