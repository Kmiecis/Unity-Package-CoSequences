using System;
using System.Collections;
using UnityEngine;

namespace Common.Coroutines.Segments
{
    [Serializable]
    public abstract class SpriteRendererSegment<T> : Segment
    {
        public SpriteRenderer renderer;
        public T target;
    }

    [Serializable]
    public abstract class SpriteRendererTimedSegment<T> : TimedSegment
    {
        public SpriteRenderer renderer;
        public T target;
    }

    [Serializable]
    public abstract class SpriteRendererBetweenSegment<T> : TimedSegment
    {
        public SpriteRenderer renderer;
        public T start;
        public T target;
    }

    #region Color
    [SegmentMenu("Towards", SegmentPath.SpriteRendererColor, SegmentGroup.Core)]
    public sealed class SpriteRendererColorSegment : SpriteRendererTimedSegment<Color>
    {
        public SpriteRendererColorSegment()
            => target = Color.white;

        public override IEnumerator Build()
            => renderer.CoColor(target, duration, easer.Evaluate);
    }

    [SegmentMenu("Set", SegmentPath.SpriteRendererColor, SegmentGroup.Core)]
    public sealed class SpriteRendererColorSetSegment : SpriteRendererSegment<Color>
    {
        public SpriteRendererColorSetSegment()
            => target = Color.white;

        public override IEnumerator Build()
            => renderer.CoColor(target);
    }

    [SegmentMenu("Between", SegmentPath.SpriteRendererColor, SegmentGroup.Core)]
    public sealed class SpriteRendererColorBetweenSegment : SpriteRendererBetweenSegment<Color>
    {
        public SpriteRendererColorBetweenSegment()
        {
            start = Color.white;
            target = Color.white;
        }

        public override IEnumerator Build()
            => renderer.CoColor(start, target, duration, easer.Evaluate);
    }
    #endregion

    #region Fade
    [SegmentMenu("Towards", SegmentPath.SpriteRendererFade, SegmentGroup.Core)]
    public sealed class SpriteRendererFadeSegment : SpriteRendererTimedSegment<float>
    {
        public override void OnValidate()
            => target = Mathf.Clamp(target, 0.0f, 1.0f);
    
        public override IEnumerator Build()
            => renderer.CoFade(target, duration, easer.Evaluate);
    }

    [SegmentMenu("Set", SegmentPath.SpriteRendererFade, SegmentGroup.Core)]
    public sealed class SpriteRendererFadeSetSegment : SpriteRendererSegment<float>
    {
        public override void OnValidate()
            => target = Mathf.Clamp(target, 0.0f, 1.0f);

        public override IEnumerator Build()
            => renderer.CoFade(target);
    }

    [SegmentMenu("Between", SegmentPath.SpriteRendererFade, SegmentGroup.Core)]
    public sealed class SpriteRendererFadeBetweenSegment : SpriteRendererBetweenSegment<float>
    {
        public override void OnValidate()
        {
            start = Mathf.Clamp(start, 0.0f, 1.0f);
            target = Mathf.Clamp(target, 0.0f, 1.0f);
        }

        public override IEnumerator Build()
            => renderer.CoFade(start, target, duration, easer.Evaluate);
    }
    #endregion

    #region Gradient
    [SegmentMenu("Gradient", SegmentPath.SpriteRenderer, SegmentGroup.Core)]
    public sealed class SpriteRendererGradientSegment : SpriteRendererTimedSegment<Gradient>
    {
        public override IEnumerator Build()
            => renderer.CoGradient(target, duration, easer.Evaluate);
    }
    #endregion

    #region Size
    [SegmentMenu("Set", SegmentPath.SpriteRendererSize, SegmentGroup.Core)]
    public sealed class SpriteRendererSizeSetSegment : SpriteRendererSegment<Vector2>
    {
        public override IEnumerator Build()
            => renderer.CoSize(target);
    }

    [SegmentMenu("Towards", SegmentPath.SpriteRendererSize, SegmentGroup.Core)]
    public sealed class SpriteRendererSizeSegment : SpriteRendererTimedSegment<Vector2>
    {
        public override IEnumerator Build()
            => renderer.CoSize(target, duration, easer.Evaluate);
    }

    [SegmentMenu("Towards X", SegmentPath.SpriteRendererSize, SegmentGroup.Core)]
    public sealed class SpriteRendererSizeXSegment : SpriteRendererTimedSegment<float>
    {
        public override IEnumerator Build()
            => renderer.CoSizeX(target, duration, easer.Evaluate);
    }
    
    [SegmentMenu("Towards Y", SegmentPath.SpriteRendererSize, SegmentGroup.Core)]
    public sealed class SpriteRendererSizeYSegment : SpriteRendererTimedSegment<float>
    {
        public override IEnumerator Build()
            => renderer.CoSizeY(target, duration, easer.Evaluate);
    }

    [SegmentMenu("Between", SegmentPath.SpriteRendererSize, SegmentGroup.Core)]
    public sealed class SpriteRendererSizeBetweenSegment : SpriteRendererBetweenSegment<Vector2>
    {
        public override IEnumerator Build()
            => renderer.CoSize(start, target, duration, easer.Evaluate);
    }

    [SegmentMenu("Between X", SegmentPath.SpriteRendererSize, SegmentGroup.Core)]
    public sealed class SpriteRendererSizeXBetweenSegment : SpriteRendererBetweenSegment<float>
    {
        public override IEnumerator Build()
            => renderer.CoSizeX(start, target, duration, easer.Evaluate);
    }

    [SegmentMenu("Between Y", SegmentPath.SpriteRendererSize, SegmentGroup.Core)]
    public sealed class SpriteRendererSizeYBetweenSegment : SpriteRendererBetweenSegment<float>
    {
        public override IEnumerator Build()
            => renderer.CoSizeY(start, target, duration, easer.Evaluate);
    }
    #endregion
}