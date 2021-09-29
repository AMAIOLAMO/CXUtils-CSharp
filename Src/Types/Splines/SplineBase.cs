using System.Collections.Generic;
using System.Diagnostics;
using CXUtils.Common;
using CXUtils.Debugging;
using CXUtils.Utilities;

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
            this.points = Guard.LengthLess( points, 3, nameof( points ) );
            
            SetLoop( isLoop );
        }

        protected SplineBase() => points = new List<T>();

        public bool IsLoop { get; private set; }

        public virtual T this[ int index ] => points[index];
        public int Count        => points.Count;
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

}
