using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CXUtils.Common
{
    /// <summary>
    ///    Vector extension methods
    /// </summary>
    public static class VectorUtils
    {
        #region Mapping Extensions

        /// <summary>
        ///     Maps a function to every axis of the <paramref name="vec2" />
        /// </summary>
        public static Vector2 MapVec( this ref Vector2 vec2, Func<float, float> mapFunc )
        {
            vec2.x = mapFunc( vec2.x );
            vec2.y = mapFunc( vec2.y );

            return vec2;
        }

        /// <summary>
        ///     Maps a function to every axis of the <paramref name="vec2" />
        /// </summary>
        public static Vector2Int MapVec( this ref Vector2Int vec2, Func<int, int> mapFunc )
        {
            vec2.x = mapFunc( vec2.x );
            vec2.y = mapFunc( vec2.y );

            return vec2;
        }


        /// <summary>
        ///     Maps a function to every axis of the <paramref name="vec3" />
        /// </summary>
        public static Vector3 MapVec( this ref Vector3 vec3, Func<float, float> mapFunc )
        {
            vec3.x = mapFunc( vec3.x );
            vec3.y = mapFunc( vec3.y );
            vec3.z = mapFunc( vec3.z );

            return vec3;
        }

        /// <summary>
        ///     Maps a function to every axis of the <paramref name="vec3" />
        /// </summary>
        public static Vector3Int MapVec( this ref Vector3Int vec3, Func<int, int> mapFunc )
        {
            vec3.x = mapFunc( vec3.x );
            vec3.y = mapFunc( vec3.y );
            vec3.z = mapFunc( vec3.z );

            return vec3;
        }


        /// <summary>
        ///     Maps a function to every axis of the <paramref name="vec4" />
        /// </summary>
        public static Vector4 MapVec( this ref Vector4 vec4, Func<float, float> mapFunc )
        {
            vec4.x = mapFunc( vec4.x );
            vec4.y = mapFunc( vec4.y );
            vec4.z = mapFunc( vec4.z );
            vec4.w = mapFunc( vec4.w );

            return vec4;
        }

        /// <summary>
        ///     Maps a function to every axis of the <paramref name="vec4" />
        /// </summary>
        public static Vector4 MapVec( this ref Vector4 vec4, Func<float, int> mapFunc )
        {
            vec4.x = mapFunc( vec4.x );
            vec4.y = mapFunc( vec4.y );
            vec4.z = mapFunc( vec4.z );
            vec4.w = mapFunc( vec4.w );

            return vec4;
        }

        #endregion

        #region Random

        /// <summary> Generates a random vector2 </summary>
        public static Vector2 RandomVec2( float min, float max )
        {
            return new Vector2( Random.Range( min, max ), Random.Range( min, max ) );
        }

        /// <summary> Generates a random vector2Int in a square </summary>
        public static Vector2Int RandomVec2Int( int min, int max )
        {
            return new Vector2Int( Random.Range( min, max ), Random.Range( min, max ) );
        }

        /// <summary>
        ///     Generates a random vector2 inside a circle
        /// </summary>
        public static Vector2 RandomVecCircle( float maxLength )
        {
            return Random.insideUnitCircle * maxLength;
        }

        /// <summary>
        ///     Generates a random vector2 inside a circle
        /// </summary>
        public static Vector2 RandomVec2InCircle( float min, float max )
        {
            return ( max - min ) * Random.insideUnitCircle + Vector2.one * min;
        }

        /// <summary> Generates a random vector3 </summary>
        public static Vector3 RandomVec3( float min, float max )
        {
            return new Vector3( Random.Range( min, max ), Random.Range( min, max ), Random.Range( min, max ) );
        }

        /// <summary> Generates a random vector3Int </summary>
        public static Vector3Int RandomVec3Int( int min, int max )
        {
            return new Vector3Int( Random.Range( min, max ), Random.Range( min, max ), Random.Range( min, max ) );
        }

        /// <summary>
        ///     Generates a random vector3 inside a Sphere
        /// </summary>
        public static Vector3 RandomVecSphere( float maxLength )
        {
            return Random.insideUnitSphere * maxLength;
        }

        /// <summary>
        ///     Generates a random vector3 inside a Sphere
        /// </summary>
        public static Vector3 RandomVec3InSphere( float min, float max )
        {
            return ( max - min ) * Random.insideUnitSphere + Vector3.one * min;
        }

        /// <summary> Generates a random vector4 </summary>
        public static Vector4 RandomVec4( float min, float max )
        {
            return new Vector4( Random.Range( min, max ), Random.Range( min, max ), Random.Range( min, max ), Random.Range( min, max ) );
        }

        /// <summary>
        ///     Generates a random vector4Int
        ///     <para>QUICK NOTE: there is no Vector4Int, so becareful of using it as an integer</para>
        /// </summary>
        public static Vector4 RandomVec4Int( int min, int max )
        {
            return new Vector4( Random.Range( min, max ), Random.Range( min, max ), Random.Range( min, max ), Random.Range( min, max ) );
        }

        /// <summary>
        ///     Generates a random direction based on the given direction
        ///     <para>QUICK NOTE: this method offsets the current vector</para>
        /// </summary>
        public static Vector3 RandomDirection( Vector3 direction )
        {
            //get's the original magnitude
            float originMagnitude = direction.magnitude;

            direction = direction.normalized;
            //adding a new direction on to the original direction
            direction += RandomVec3( 0f, 1f );
            direction.SetMagnitude( originMagnitude );

            return direction;
        }

        #endregion

        #region Rounding Extensions

        /// <summary>
        ///     Round the Given vector
        /// </summary>
        public static Vector2 Round( this Vector2 vec2 )
        {
            return vec2.MapVec( Mathf.Round );
        }

        /// <summary>
        ///     Round the Given vector
        /// </summary>
        public static Vector3 Round( this Vector3 vec3 )
        {
            return vec3.MapVec( Mathf.Round );
        }

        /// <summary>
        ///     Round the Given vector
        /// </summary>
        public static Vector4 Round( this Vector4 vec4 )
        {
            return vec4.MapVec( Mathf.Round );
        }

        /// <summary>
        ///     Round the Given vector to their int version
        /// </summary>
        public static Vector2Int GetRoundToInt( this Vector2 vec2 )
        {
            return new Vector2Int( Mathf.RoundToInt( vec2.x ), Mathf.RoundToInt( vec2.y ) );
        }

        /// <summary>
        ///     Round the Given vector to their int version
        ///     <para>Returns the new version, but does not override the original version</para>
        /// </summary>
        public static Vector3Int GetRoundToInt( this Vector3 vec3 )
        {
            return new Vector3Int( Mathf.RoundToInt( vec3.x ), Mathf.RoundToInt( vec3.y ), Mathf.RoundToInt( vec3.z ) );
        }

        /// <summary>
        ///     Round the Given vector to their int version
        ///     <para>Returns the new version, but does not override the original version</para>
        /// </summary>
        public static Vector4 GetRoundToInt( this Vector4 vec4 )
        {
            return vec4.MapVec( Mathf.RoundToInt );
        }

        #endregion

        #region Floor & Ceil Extensions

        //flooring
        public static Vector2 Floor( this Vector2 vec2 )
        {
            return vec2.MapVec( Mathf.Floor );
        }

        public static Vector3 Floor( this Vector3 vec3 )
        {
            return vec3.MapVec( Mathf.Floor );
        }

        public static Vector4 Floor( this Vector4 vec4 )
        {
            return vec4.MapVec( Mathf.Floor );
        }

        public static Vector2Int FloorToInt( this Vector2 vec2 )
        {
            return Vector2Int.FloorToInt( vec2 );
        }

        public static Vector3Int FloorToInt( this Vector3 vec3 )
        {
            return Vector3Int.FloorToInt( vec3 );
        }

        //ceiling
        public static Vector2 Ceil( this Vector2 vec2 )
        {
            return vec2.MapVec( Mathf.Ceil );
        }

        public static Vector3 Ceil( this Vector3 vec3 )
        {
            return vec3.MapVec( Mathf.Ceil );
        }

        public static Vector4 Ceil( this Vector4 vec4 )
        {
            return vec4.MapVec( Mathf.Ceil );
        }

        public static Vector2Int CeilToInt( this Vector2 vec2 )
        {
            return Vector2Int.CeilToInt( vec2 );
        }

        public static Vector3Int CeilToInt( this Vector3 vec3 )
        {
            return Vector3Int.CeilToInt( vec3 );
        }

        #endregion

        #region Vector Manipulation Extensions & Utils

        /// <summary>
        ///     Set's the magnitude / length of the <paramref name="vec" /> to the given length
        /// </summary>
        public static Vector3 SetMagnitude( this ref Vector3 vec, float len )
        {
            return vec = vec.normalized * len;
        }

        /// <summary>
        ///     Set's the magnitude / length of the <paramref name="vec" /> to the given length
        /// </summary>
        public static Vector2 SetMagnitude( this ref Vector2 vec, float len )
        {
            return vec = vec.normalized * len;
        }

        /// <summary>
        ///     Set's the magnitude / length of the <paramref name="vec" /> to the given length
        /// </summary>
        public static Vector4 SetMagnitude( this ref Vector4 vec, float len )
        {
            return vec = vec.normalized * len;
        }


        ///<summary> Clamps the vector by magnitude value </summary>
        public static Vector3 Clamp( Vector3 vec, float minLen, float maxLen )
        {
            return vec.magnitude > maxLen ? vec.SetMagnitude( maxLen ) : vec.magnitude < minLen ? vec.SetMagnitude( minLen ) : vec;
        }

        public static Vector2Int Mod( Vector2Int vec, int value )
        {
            return new Vector2Int( vec.x % value, vec.y % value );
        }

        public static void Mod( this ref Vector2Int vec, int value )
        {
            vec.MapVec( axis => axis % value );
        }

        #endregion
    }
}
