using CXUtils.Types;

namespace CXUtils.Common
{
    /*
     * Note: this code is based on https://weber.itn.liu.se/~stegu/simplexnoise/simplexnoise.pdf
     * and http://www.itn.liu.se/~stegu/simplexnoise/SimplexNoise.java
     * I did not implemented this, I just converted this into C# and implemented further
    */

    /// <summary>
    ///     Gradient noise that is better and quicker than Perlin noise
    /// </summary>
    public static class SimplexNoise
    {
        /// <summary>
        ///     Returns a simplex noise between -1 to 1 using <paramref name="value"/>
        /// </summary>
        public static float Sample(Float2 value)
        {
            float n0, n1, n2;

            float s = (value.x + value.y) * F2;

            int i = (value.x + s).FloorInt();
            int j = (value.y + s).FloorInt();

            float t = (i + j) * G2;

            float X0 = i - t,
                  Y0 = j - t,
                  x0 = value.x - X0,
                  y0 = value.y - Y0;

            int i1, j1;
            if ( x0 > y0 ) (i1, j1) = (1, 0);
            else (j1, i1) = (1, 0);

            float x1 = x0 - i1 + G2,
                  y1 = y0 - j1 + G2,
                  x2 = x0 - 1f + 2f * G2,
                  y2 = y0 - 1f + 2f * G2;

            int ii = i & 255;
            int jj = j & 255;

            int gi0 = _permMod12[ii +      _perm[jj]     ];
            int gi1 = _permMod12[ii + i1 + _perm[jj + j1]];
            int gi2 = _permMod12[ii + 1  + _perm[jj + 1] ];

            float t0 = .5f - x0 * x0 - y0 * y0;
            if ( t0 < 0f ) n0 = 0f;
            else
            {
                t0 *= t0;
                n0 = t0 * t0 * _grad3[gi0].Dot(new Float2(x0, y0));
            }

            float t1 = .5f - x1 * x1 - y1 * y1;
            if ( t1 < 0f ) n1 = 0f;
            else
            {
                t1 *= t1;
                n1 = t1 * t1 * _grad3[gi1].Dot(new Float2(x1, y1));
            }
            float t2 = .5f - x2 * x2 - y2 * y2;
            if ( t2 < 0 ) n2 = 0f;
            else
            {
                t2 *= t2;
                n2 = t2 * t2 * _grad3[gi2].Dot(new Float2(x2, y2));
            }

            return 70f * (n0 + n1 + n2);
        }

        /// <inheritdoc cref="Sample(Float2)"/>
        public static float Sample(Float3 value)
        {
            float n0, n1, n2, n3;

            float s = (value.x + value.y + value.z) * F3;

            int i = MathUtils.FloorInt(value.x + s);
            int j = MathUtils.FloorInt(value.y + s);
            int k = MathUtils.FloorInt(value.z + s);

            float t = (i + j + k) * G3;

            float X0 = i - t;
            float Y0 = j - t;
            float Z0 = k - t;
            float x0 = value.x - X0;
            float y0 = value.y - Y0;
            float z0 = value.z - Z0;

            int i1, j1, k1;
            int i2, j2, k2;

            if ( x0 >= y0 )
            {
                if ( y0 >= z0 )
                { i1 = 1; j1 = 0; k1 = 0; i2 = 1; j2 = 1; k2 = 0; } // X Y Z order
                else if ( x0 >= z0 )
                { i1 = 1; j1 = 0; k1 = 0; i2 = 1; j2 = 0; k2 = 1; } // X Z Y order
                else
                { i1 = 0; j1 = 0; k1 = 1; i2 = 1; j2 = 0; k2 = 1; } // Z X Y order
            }
            else
            {
                if ( y0 < z0 )
                { i1 = 0; j1 = 0; k1 = 1; i2 = 0; j2 = 1; k2 = 1; } // Z Y X order
                else if ( x0 < z0 )
                { i1 = 0; j1 = 1; k1 = 0; i2 = 0; j2 = 1; k2 = 1; } // Y Z X order
                else
                { i1 = 0; j1 = 1; k1 = 0; i2 = 1; j2 = 1; k2 = 0; } // Y X Z order
            }

            float x1 = x0 - i1 + G3;
            float y1 = y0 - j1 + G3;
            float z1 = z0 - k1 + G3;
            float x2 = x0 - i2 + 2f * G3;
            float y2 = y0 - j2 + 2f * G3;
            float z2 = z0 - k2 + 2f * G3;
            float x3 = x0 - 1f + 3f * G3;
            float y3 = y0 - 1f + 3f * G3;
            float z3 = z0 - 1f + 3f * G3;

            int ii = i & 255;
            int jj = j & 255;
            int kk = k & 255;
            int gi0 = _permMod12[ii +      _perm[jj +      _perm[kk]]     ];
            int gi1 = _permMod12[ii + i1 + _perm[jj + j1 + _perm[kk + k1]]];
            int gi2 = _permMod12[ii + i2 + _perm[jj + j2 + _perm[kk + k2]]];
            int gi3 = _permMod12[ii + 1  + _perm[jj + 1  + _perm[kk + 1]] ];

            float t0 = .6f - x0 * x0 - y0 * y0 - z0 * z0;
            if ( t0 < 0f ) n0 = 0f;
            else
            {
                t0 *= t0;
                n0 = t0 * t0 * _grad3[gi0].Dot(new Float3(x0, y0, z0));
            }

            float t1 = .6f - x1 * x1 - y1 * y1 - z1 * z1;
            if ( t1 < 0f ) n1 = 0f;
            else
            {
                t1 *= t1;
                n1 = t1 * t1 * _grad3[gi1].Dot(new Float3(x1, y1, z1));
            }

            float t2 = .6f - x2 * x2 - y2 * y2 - z2 * z2;
            if ( t2 < 0f ) n2 = 0f;
            else
            {
                t2 *= t2;
                n2 = t2 * t2 * _grad3[gi2].Dot(new Float3(x2, y2, z2));
            }

            float t3 = .6f - x3 * x3 - y3 * y3 - z3 * z3;
            if ( t3 < 0f ) n3 = 0f;
            else
            {
                t3 *= t3;
                n3 = t3 * t3 * _grad3[gi3].Dot(new Float3(x3, y3, z3));
            }

            return 32f * (n0 + n1 + n2 + n3);
        }

        /// <inheritdoc cref="Sample(Float2)"/>
        public static float Sample(Float4 value)
        {
            float n0, n1, n2, n3, n4;

            float s = (value.x + value.y + value.z + value.w) * F4; // Factor for 4D skewing

            int i = MathUtils.FloorInt(value.x + s);
            int j = MathUtils.FloorInt(value.y + s);
            int k = MathUtils.FloorInt(value.z + s);
            int l = MathUtils.FloorInt(value.w + s);

            float t = (i + j + k + l) * G4;
            float X0 = i - t,
                  Y0 = j - t,
                  Z0 = k - t,
                  W0 = l - t,
                  x0 = value.x - X0,
                  y0 = value.y - Y0,
                  z0 = value.z - Z0,
                  w0 = value.w - W0;

            int rankx = 0,
                ranky = 0,
                rankz = 0,
                rankw = 0;

            if ( x0 > y0 ) ++rankx;
            else ++ranky;

            if ( x0 > z0 ) ++rankx;
            else ++rankz;

            if ( x0 > w0 ) ++rankx;
            else ++rankw;

            if ( y0 > z0 ) ++ranky;
            else ++rankz;

            if ( y0 > w0 ) ++ranky;
            else ++rankw;

            if ( z0 > w0 ) ++rankz;
            else ++rankw;

            int i1, j1, k1, l1;
            int i2, j2, k2, l2;
            int i3, j3, k3, l3;

            i1 = rankx >= 3 ? 1 : 0;
            j1 = ranky >= 3 ? 1 : 0;
            k1 = rankz >= 3 ? 1 : 0;
            l1 = rankw >= 3 ? 1 : 0;

            // Rank 2 denotes the second largest coordinate.

            i2 = rankx >= 2 ? 1 : 0;
            j2 = ranky >= 2 ? 1 : 0;
            k2 = rankz >= 2 ? 1 : 0;
            l2 = rankw >= 2 ? 1 : 0;

            // Rank 1 denotes the second smallest coordinate.

            i3 = rankx >= 1 ? 1 : 0;
            j3 = ranky >= 1 ? 1 : 0;
            k3 = rankz >= 1 ? 1 : 0;
            l3 = rankw >= 1 ? 1 : 0;

            float x1 = x0 - i1 + G4; // Offsets for second corner in (x,y,z,w) coords
            float y1 = y0 - j1 + G4;
            float z1 = z0 - k1 + G4;
            float w1 = w0 - l1 + G4;
            float x2 = x0 - i2 + 2f * G4; // Offsets for third corner in (x,y,z,w) coords
            float y2 = y0 - j2 + 2f * G4;
            float z2 = z0 - k2 + 2f * G4;
            float w2 = w0 - l2 + 2f * G4;
            float x3 = x0 - i3 + 3f * G4; // Offsets for fourth corner in (x,y,z,w) coords
            float y3 = y0 - j3 + 3f * G4;
            float z3 = z0 - k3 + 3f * G4;
            float w3 = w0 - l3 + 3f * G4;
            float x4 = x0 - 1f + 4f * G4; // Offsets for last corner in (x,y,z,w) coords
            float y4 = y0 - 1f + 4f * G4;
            float z4 = z0 - 1f + 4f * G4;
            float w4 = w0 - 1f + 4f * G4;

            // Work out the hashed gradient indices of the five simplex corners

            int ii = i & 255;
            int jj = j & 255;
            int kk = k & 255;
            int ll = l & 255;

            int gi0 = _perm[ii +      _perm[jj +      _perm[kk +      _perm[ll]     ]]] % 32;
            int gi1 = _perm[ii + i1 + _perm[jj + j1 + _perm[kk + k1 + _perm[ll + l1]]]] % 32;
            int gi2 = _perm[ii + i2 + _perm[jj + j2 + _perm[kk + k2 + _perm[ll + l2]]]] % 32;
            int gi3 = _perm[ii + i3 + _perm[jj + j3 + _perm[kk + k3 + _perm[ll + l3]]]] % 32;
            int gi4 = _perm[ii + 1  + _perm[jj + 1  + _perm[kk + 1  + _perm[ll + 1] ]]] % 32;

            // Calculate the contribution from the five corners
            float t0 = .6f - x0 * x0 - y0 * y0 - z0 * z0 - w0 * w0;
            if ( t0 < 0f ) n0 = 0f;
            else
            {
                t0 *= t0;
                n0 = t0 * t0 * _grad4[gi0].Dot(new Float4(x0, y0, z0, w0));
            }

            float t1 = .6f - x1 * x1 - y1 * y1 - z1 * z1 - w1 * w1;
            if ( t1 < 0f ) n1 = 0f;
            else
            {
                t1 *= t1;
                n1 = t1 * t1 * _grad4[gi1].Dot(new Float4(x1, y1, z1, w1));
            }

            float t2 = .6f - x2 * x2 - y2 * y2 - z2 * z2 - w2 * w2;
            if ( t2 < 0f ) n2 = 0f;
            else
            {
                t2 *= t2;
                n2 = t2 * t2 * _grad4[gi2].Dot(new Float4(x2, y2, z2, w2));
            }

            float t3 = .6f - x3 * x3 - y3 * y3 - z3 * z3 - w3 * w3;
            if ( t3 < 0f ) n3 = 0f;
            else
            {
                t3 *= t3;
                n3 = t3 * t3 * _grad4[gi3].Dot(new Float4(x3, y3, z3, w3));
            }

            float t4 = .6f - x4 * x4 - y4 * y4 - z4 * z4 - w4 * w4;
            if ( t4 < 0f ) n4 = 0f;
            else
            {
                t4 *= t4;
                n4 = t4 * t4 * _grad4[gi4].Dot(new Float4(x4, y4, z4, w4));
            }

            return 27f * (n0 + n1 + n2 + n3 + n4);
        }

        static SimplexNoise()
        {
            //calculate for permutations & permutations that mods wraps in 12
            for ( int i = 0; i < 512; ++i )
            {
                _perm[i] = _p[i & 255];
                _permMod12[i] = (short)(_perm[i] % 12);
            }
        }

        #region Lookup tables

        static readonly Float4[] _grad3 =
        {
            new Float4(1f, 1f    ), new Float4(-1f, 1f    ), new Float4(1f, -1f    ), new Float4(-1f, -1f    ),
            new Float4(1f, 0f, 1f), new Float4(-1f, 0f, 1f), new Float4(1f, 0f, -1f), new Float4(-1f, 0f, -1f),
            new Float4(0f, 1f, 1f), new Float4(0f, -1f, 1f), new Float4(0f, 1f, -1f), new Float4(0f, -1f, -1f),
        };

        static readonly Float4[] _grad4 =
        {
            new Float4(0f, 1f, 1f, 1f ), new Float4(0f, 1f, 1f, -1f ), new Float4(0f, 1f, -1f, 1f ), new Float4(0f, 1f, -1f, -1f ),
            new Float4(0f, -1f, 1f, 1f), new Float4(0f, -1f, 1f, -1f), new Float4(0f, -1f, -1f, 1f), new Float4(0f, -1f, -1f, -1f),
            new Float4(1f, 0f, 1f, 1f ), new Float4(1f, 0f, 1f, -1f ), new Float4(1f, 0f, -1f, 1f ), new Float4(1f, 0f, -1f, -1f ),
            new Float4(-1f, 0f, 1f, 1f), new Float4(-1f, 0f, 1f, -1f), new Float4(-1f, 0f, -1f, 1f), new Float4(-1f, 0f, -1f, -1f),
            new Float4(1f, 1f, 0f, 1f ), new Float4(1f, 1f, 0f, -1f ), new Float4(1f, -1f, 0f, 1f ), new Float4(1f, -1f, 0f, -1f ),
            new Float4(-1f, 1f, 0f, 1f), new Float4(-1f, 1f, 0f, -1f), new Float4(-1f, -1f, 0f, 1f), new Float4(-1f, -1f, 0f, -1f),
            new Float4(1f, 1f, 1f     ), new Float4(1f, 1f, -1f     ), new Float4(1f, -1f, 1f     ), new Float4(1f, -1f, -1f     ),
            new Float4(-1f, 1f, 1f    ), new Float4(-1f, 1f, -1f    ), new Float4(-1f, -1f, 1f    ), new Float4(-1f, -1f, -1f    )
        };

        static readonly short[] _p =
        {
            151,160,137,91,90,15,
            131,13,201,95,96,53,194,233,7,225,140,36,103,30,69,142,8,99,37,240,21,10,23,
            190, 6,148,247,120,234,75,0,26,197,62,94,252,219,203,117,35,11,32,57,177,33,
            88,237,149,56,87,174,20,125,136,171,168, 68,175,74,165,71,134,139,48,27,166,
            77,146,158,231,83,111,229,122,60,211,133,230,220,105,92,41,55,46,245,40,244,
            102,143,54, 65,25,63,161, 1,216,80,73,209,76,132,187,208, 89,18,169,200,196,
            135,130,116,188,159,86,164,100,109,198,173,186, 3,64,52,217,226,250,124,123,
            5,202,38,147,118,126,255,82,85,212,207,206,59,227,47,16,58,17,182,189,28,42,
            223,183,170,213,119,248,152, 2,44,154,163, 70,221,153,101,155,167, 43,172,9,
            129,22,39,253, 19,98,108,110,79,113,224,232,178,185, 112,104,218,246,97,228,
            251,34,242,193,238,210,144,12,191,179,162,241, 81,51,145,235,249,14,239,107,
            49,192,214, 31,181,199,106,157,184, 84,204,176,115,121,50,45,127, 4,150,254,
            138,236,205,93,222,114,67,29,24,72,243,141,128,195,78,66,215,61,156,180
        };

        // Skewing and unskewing factors for 2, 3, and 4 dimensions
        const float SQRT_3 = 1.732050807568877293527446341505f,
                    SQRT_5 = 2.236067977499789696409173668731f;

        const float F2 = .5f * (SQRT_3 - 1f);
        const float G2 = (3f - SQRT_3) / 6f;
        const float F3 = 1f / 3f;
        const float G3 = 1f / 6f;
        const float F4 = (SQRT_5 - 1f) * .25f;
        const float G4 = (5f - SQRT_5) * .05f;

        private static readonly short[] _perm      = new short[512],
                                        _permMod12 = new short[512];

        #endregion
    }
}