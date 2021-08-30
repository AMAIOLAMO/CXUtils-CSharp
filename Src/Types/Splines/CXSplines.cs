using System.Collections.Generic;
using System.Diagnostics;

namespace CXUtils.Types
{
    /// <summary>
    ///     The base of all spline classes<br />
    ///     DO NOT INHERIT THIS CLASS UNLESS YOU KNOW WHAT YOU ARE DOING
    /// </summary>
    public abstract class SplineBase<T>
    {
        protected readonly List<T> points;
        protected SplineBase( List<T> points, bool isLoop = false )
        {
            Debug.Assert( points.Count > 3, nameof( points ) + " must have at least 4 points to create a spline!" );

            this.points = points;
            SetLoop( isLoop );
        }

        protected SplineBase() => points = new List<T>();

        public bool IsLoop { get; private set; }

        public virtual T this[ int index ] => points[index];
        public int Count => points.Count;
        public int SegmentCount => points.Count / 3;

        public void SetLoop( bool isLoop )
        {
            if ( IsLoop == isLoop ) return;

            //else changed
            IsLoop = isLoop;

            DoLoopChanged();
        }

        public void ToggleLoop()
        {
            IsLoop = !IsLoop;

            DoLoopChanged();
        }

        public T[] GetSegmentRaw( int segmentIndex )
        {
            int firstIndex = SplineUtils.SegmentIndexToPointIndex( segmentIndex );

            /*In row:      anchor,             control,                control,                anchor*/
            return new[] { points[firstIndex], points[firstIndex + 1], points[firstIndex + 2], points[LoopIndex( firstIndex + 3 )] };
        }

        public virtual void RemoveAnchor( int anchorIndex )
        {
            Debug.Assert( SplineUtils.IsAnchor( anchorIndex ), nameof( anchorIndex ) + " cannot be a control point!" );

            //if segment count is equal to 2 or if segment is smaller or equal than 1 when it's looped then deletion is not possible
            if ( SegmentCount <= 2 && ( IsLoop || SegmentCount <= 1 ) ) return;

            if ( anchorIndex == 0 )
            {
                if ( IsLoop ) points[points.Count - 1] = points[2];

                points.RemoveRange( 0, 3 );
                return;
            }
            //else
            if ( anchorIndex == points.Count - 1 && !IsLoop )
            {
                points.RemoveRange( anchorIndex - 2, 3 );
                return;
            }
            //else
            points.RemoveRange( anchorIndex - 1, 3 );
        }

        public abstract void InsertAnchor( T anchor, int segmentIndex );


        /// <summary>
        ///     Moves a point in the spline statically (which means it doesn't affect other points)
        /// </summary>
        public virtual void MoveStatic( int pointIndex, T position ) => points[pointIndex] = position;


        //if we got negative values, this will wrap values around and if over values then we can wrap around to 0 again
        protected int LoopIndex( int pointIndex ) => ( pointIndex + points.Count ) % points.Count;

        protected abstract void DoLoopChanged();
        public abstract void PushAnchor( T anchor );
    }

    public static class SplineUtils
    {
        /// <summary>
        ///     Is this index a control point?
        /// </summary>
        public static bool IsControl( int pointIndex ) => pointIndex % 3 != 0;

        /// <summary>
        ///     Is this index an anchor point?
        /// </summary>
        public static bool IsAnchor( int pointIndex ) => pointIndex % 3 == 0;

        /// <summary>
        ///     Converts segment index to point index
        /// </summary>
        public static int SegmentIndexToPointIndex( int segmentIndex ) => segmentIndex * 3;

        /// <summary>
        ///     Converts point index to segment index
        /// </summary>
        public static int PointIndexToSegmentIndex( int pointIndex ) => pointIndex / 3;
    }

    /// <summary>
    ///     A class that handles all spline calculations
    /// </summary>
    public sealed class Spline2D : SplineBase<Float2>
    {
        public Spline2D( List<Float2> points, bool isLoop = false ) : base( points, isLoop ) { }

        public Spline2D( Float2 center, bool isLoop = false )
        {
            points.Add( center + Float2.NegX );
            points.Add( center + ( Float2.NegX + Float2.PosY ).Halve );
            points.Add( center + ( Float2.PosX + Float2.NegY ).Halve );
            points.Add( center + Float2.PosX );

            SetLoop( isLoop );
        }

        public CubicBezier2D GetSegment( int i ) => new CubicBezier2D( GetSegmentRaw( i ) );

        public override void PushAnchor( Float2 anchor )
        {
            points.Add( points[points.Count - 1] * 2f - points[points.Count - 2] ); // last control point's other side control point
            points.Add( ( points[points.Count - 1] + anchor ).Halve ); // the new anchor's new control point
            points.Add( anchor ); // finally the new anchor
        }

        /// <summary>
        ///     Moves a point in the spline but move the controls also
        /// </summary>
        public void MoveDynamic( int pointIndex, Float2 position )
        {
            var delta = position - points[pointIndex];
            points[pointIndex] = position;

            if ( SplineUtils.IsAnchor( pointIndex ) )
            {
                if ( pointIndex + 1 < points.Count || IsLoop ) points[LoopIndex( pointIndex + 1 )] += delta;
                if ( pointIndex - 1 >= 0 || IsLoop ) points[LoopIndex( pointIndex - 1 )] += delta;
            }
            else
            {
                bool nextAnchor = SplineUtils.IsAnchor( pointIndex + 1 );

                int mirroredControlIndex = nextAnchor ? pointIndex + 2 : pointIndex - 2;
                int anchorIndex = nextAnchor ? pointIndex + 1 : pointIndex - 1;

                if ( ( mirroredControlIndex < 0 || mirroredControlIndex >= points.Count ) && !IsLoop ) return;

                ( anchorIndex, mirroredControlIndex ) = ( LoopIndex( anchorIndex ), LoopIndex( mirroredControlIndex ) );

                float originalDistance = ( points[anchorIndex] - points[mirroredControlIndex] ).Magnitude;
                var direction = ( points[anchorIndex] - position ).Normalized;

                points[mirroredControlIndex] = points[anchorIndex] + direction * originalDistance;
            }
        }

        public override void InsertAnchor( Float2 anchor, int segmentIndex ) =>
            points.InsertRange( segmentIndex * 3 + 2, new[] { anchor + Float2.NegX, anchor, anchor + Float2.PosX } );

        protected override void DoLoopChanged()
        {
            if ( IsLoop )
            {
                points.Add( points[points.Count - 1] * 2f - points[points.Count - 2] ); // last control point's other side control point
                points.Add( points[0] * 2f - points[1] ); // first control point's other side control point
                return;
            }

            //remove the last two control points (which is the loop control point)
            points.RemoveRange( points.Count - 2, 2 );
        }
    }
}
