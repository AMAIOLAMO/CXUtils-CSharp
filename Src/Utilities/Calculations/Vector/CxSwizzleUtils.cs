using System;
using System.Diagnostics;

namespace CXUtils.Types.Utils
{
    public static class CxSwizzleUtils
    {
        #region Manual Function Swizzle

        #region Float2

        public static Float2 XX( this Float2 vector ) => new( vector.x, vector.x );
        public static Float2 XY( this Float2 vector ) => new( vector.x, vector.y );
        public static Float2 YX( this Float2 vector ) => new( vector.y, vector.x );
        public static Float2 YY( this Float2 vector ) => new( vector.y, vector.y );
        public static Float2 XX( this Float3 vector ) => new( vector.x, vector.x );
        public static Float2 XY( this Float3 vector ) => new( vector.x, vector.y );
        public static Float2 XZ( this Float3 vector ) => new( vector.x, vector.z );
        public static Float2 YX( this Float3 vector ) => new( vector.y, vector.x );
        public static Float2 YY( this Float3 vector ) => new( vector.y, vector.y );
        public static Float2 YZ( this Float3 vector ) => new( vector.y, vector.z );
        public static Float2 ZX( this Float3 vector ) => new( vector.z, vector.x );
        public static Float2 ZY( this Float3 vector ) => new( vector.z, vector.y );
        public static Float2 ZZ( this Float3 vector ) => new( vector.z, vector.z );

        public static Float2 XX( this Float4 vector ) => new( vector.x, vector.x );
        public static Float2 XY( this Float4 vector ) => new( vector.x, vector.y );
        public static Float2 XZ( this Float4 vector ) => new( vector.x, vector.z );
        public static Float2 XW( this Float4 vector ) => new( vector.x, vector.w );
        public static Float2 YX( this Float4 vector ) => new( vector.y, vector.x );
        public static Float2 YY( this Float4 vector ) => new( vector.y, vector.y );
        public static Float2 YZ( this Float4 vector ) => new( vector.y, vector.z );
        public static Float2 YW( this Float4 vector ) => new( vector.y, vector.w );
        public static Float2 ZX( this Float4 vector ) => new( vector.z, vector.x );
        public static Float2 ZY( this Float4 vector ) => new( vector.z, vector.y );
        public static Float2 ZZ( this Float4 vector ) => new( vector.z, vector.z );
        public static Float2 ZW( this Float4 vector ) => new( vector.z, vector.w );
        public static Float2 WX( this Float4 vector ) => new( vector.w, vector.x );
        public static Float2 WY( this Float4 vector ) => new( vector.w, vector.y );
        public static Float2 WZ( this Float4 vector ) => new( vector.w, vector.z );
        public static Float2 WW( this Float4 vector ) => new( vector.w, vector.w );

        #endregion

        #region Float3

        public static Float3 XXX( this Float2 vector ) => new( vector.x, vector.x, vector.x );
        public static Float3 XXY( this Float2 vector ) => new( vector.x, vector.x, vector.y );
        public static Float3 XYX( this Float2 vector ) => new( vector.x, vector.y, vector.x );
        public static Float3 XYY( this Float2 vector ) => new( vector.x, vector.y, vector.y );
        public static Float3 YXX( this Float2 vector ) => new( vector.y, vector.x, vector.x );
        public static Float3 YXY( this Float2 vector ) => new( vector.y, vector.x, vector.y );
        public static Float3 YYX( this Float2 vector ) => new( vector.y, vector.y, vector.x );
        public static Float3 YYY( this Float2 vector ) => new( vector.y, vector.y, vector.y );
        
        public static Float3 XXX( this Float3 vector ) => new( vector.x, vector.x, vector.x );
        public static Float3 XXY( this Float3 vector ) => new( vector.x, vector.x, vector.y );
        public static Float3 XXZ( this Float3 vector ) => new( vector.x, vector.x, vector.z );
        public static Float3 XYX( this Float3 vector ) => new( vector.x, vector.y, vector.x );
        public static Float3 XYY( this Float3 vector ) => new( vector.x, vector.y, vector.y );
        public static Float3 XYZ( this Float3 vector ) => new( vector.x, vector.y, vector.z );
        public static Float3 XZX( this Float3 vector ) => new( vector.x, vector.z, vector.x );
        public static Float3 XZY( this Float3 vector ) => new( vector.x, vector.z, vector.y );
        public static Float3 XZZ( this Float3 vector ) => new( vector.x, vector.z, vector.z );
        public static Float3 YXX( this Float3 vector ) => new( vector.y, vector.x, vector.x );
        public static Float3 YXY( this Float3 vector ) => new( vector.y, vector.x, vector.y );
        public static Float3 YXZ( this Float3 vector ) => new( vector.y, vector.x, vector.z );
        public static Float3 YYX( this Float3 vector ) => new( vector.y, vector.y, vector.x );
        public static Float3 YYY( this Float3 vector ) => new( vector.y, vector.y, vector.y );
        public static Float3 YYZ( this Float3 vector ) => new( vector.y, vector.y, vector.z );
        public static Float3 YZX( this Float3 vector ) => new( vector.y, vector.z, vector.x );
        public static Float3 YZY( this Float3 vector ) => new( vector.y, vector.z, vector.y );
        public static Float3 YZZ( this Float3 vector ) => new( vector.y, vector.z, vector.z );
        public static Float3 ZXX( this Float3 vector ) => new( vector.z, vector.x, vector.x );
        public static Float3 ZXY( this Float3 vector ) => new( vector.z, vector.x, vector.y );
        public static Float3 ZXZ( this Float3 vector ) => new( vector.z, vector.x, vector.z );
        public static Float3 ZYX( this Float3 vector ) => new( vector.z, vector.y, vector.x );
        public static Float3 ZYY( this Float3 vector ) => new( vector.z, vector.y, vector.y );
        public static Float3 ZYZ( this Float3 vector ) => new( vector.z, vector.y, vector.z );
        public static Float3 ZZX( this Float3 vector ) => new( vector.z, vector.z, vector.x );
        public static Float3 ZZY( this Float3 vector ) => new( vector.z, vector.z, vector.y );
        public static Float3 ZZZ( this Float3 vector ) => new( vector.z, vector.z, vector.z );

        public static Float3 XXX( this Float4 vector ) => new( vector.x, vector.x, vector.x );
        public static Float3 XXY( this Float4 vector ) => new( vector.x, vector.x, vector.y );
        public static Float3 XXZ( this Float4 vector ) => new( vector.x, vector.x, vector.z );
        public static Float3 XXW( this Float4 vector ) => new( vector.x, vector.x, vector.w );
        public static Float3 XYX( this Float4 vector ) => new( vector.x, vector.y, vector.x );
        public static Float3 XYY( this Float4 vector ) => new( vector.x, vector.y, vector.y );
        public static Float3 XYZ( this Float4 vector ) => new( vector.x, vector.y, vector.z );
        public static Float3 XYW( this Float4 vector ) => new( vector.x, vector.y, vector.w );
        public static Float3 XZX( this Float4 vector ) => new( vector.x, vector.z, vector.x );
        public static Float3 XZY( this Float4 vector ) => new( vector.x, vector.z, vector.y );
        public static Float3 XZZ( this Float4 vector ) => new( vector.x, vector.z, vector.z );
        public static Float3 XZW( this Float4 vector ) => new( vector.x, vector.z, vector.w );
        public static Float3 XWX( this Float4 vector ) => new( vector.x, vector.w, vector.x );
        public static Float3 XWY( this Float4 vector ) => new( vector.x, vector.w, vector.y );
        public static Float3 XWZ( this Float4 vector ) => new( vector.x, vector.w, vector.z );
        public static Float3 XWW( this Float4 vector ) => new( vector.x, vector.w, vector.w );
        public static Float3 YXX( this Float4 vector ) => new( vector.y, vector.x, vector.x );
        public static Float3 YXY( this Float4 vector ) => new( vector.y, vector.x, vector.y );
        public static Float3 YXZ( this Float4 vector ) => new( vector.y, vector.x, vector.z );
        public static Float3 YXW( this Float4 vector ) => new( vector.y, vector.x, vector.w );
        public static Float3 YYX( this Float4 vector ) => new( vector.y, vector.y, vector.x );
        public static Float3 YYY( this Float4 vector ) => new( vector.y, vector.y, vector.y );
        public static Float3 YYZ( this Float4 vector ) => new( vector.y, vector.y, vector.z );
        public static Float3 YYW( this Float4 vector ) => new( vector.y, vector.y, vector.w );
        public static Float3 YZX( this Float4 vector ) => new( vector.y, vector.z, vector.x );
        public static Float3 YZY( this Float4 vector ) => new( vector.y, vector.z, vector.y );
        public static Float3 YZZ( this Float4 vector ) => new( vector.y, vector.z, vector.z );
        public static Float3 YZW( this Float4 vector ) => new( vector.y, vector.z, vector.w );
        public static Float3 YWX( this Float4 vector ) => new( vector.y, vector.w, vector.x );
        public static Float3 YWY( this Float4 vector ) => new( vector.y, vector.w, vector.y );
        public static Float3 YWZ( this Float4 vector ) => new( vector.y, vector.w, vector.z );
        public static Float3 YWW( this Float4 vector ) => new( vector.y, vector.w, vector.w );
        public static Float3 ZXX( this Float4 vector ) => new( vector.z, vector.x, vector.x );
        public static Float3 ZXY( this Float4 vector ) => new( vector.z, vector.x, vector.y );
        public static Float3 ZXZ( this Float4 vector ) => new( vector.z, vector.x, vector.z );
        public static Float3 ZXW( this Float4 vector ) => new( vector.z, vector.x, vector.w );
        public static Float3 ZYX( this Float4 vector ) => new( vector.z, vector.y, vector.x );
        public static Float3 ZYY( this Float4 vector ) => new( vector.z, vector.y, vector.y );
        public static Float3 ZYZ( this Float4 vector ) => new( vector.z, vector.y, vector.z );
        public static Float3 ZYW( this Float4 vector ) => new( vector.z, vector.y, vector.w );
        public static Float3 ZZX( this Float4 vector ) => new( vector.z, vector.z, vector.x );
        public static Float3 ZZY( this Float4 vector ) => new( vector.z, vector.z, vector.y );
        public static Float3 ZZZ( this Float4 vector ) => new( vector.z, vector.z, vector.z );
        public static Float3 ZZW( this Float4 vector ) => new( vector.z, vector.z, vector.w );
        public static Float3 ZWX( this Float4 vector ) => new( vector.z, vector.w, vector.x );
        public static Float3 ZWY( this Float4 vector ) => new( vector.z, vector.w, vector.y );
        public static Float3 ZWZ( this Float4 vector ) => new( vector.z, vector.w, vector.z );
        public static Float3 ZWW( this Float4 vector ) => new( vector.z, vector.w, vector.w );
        public static Float3 WXX( this Float4 vector ) => new( vector.w, vector.x, vector.x );
        public static Float3 WXY( this Float4 vector ) => new( vector.w, vector.x, vector.y );
        public static Float3 WXZ( this Float4 vector ) => new( vector.w, vector.x, vector.z );
        public static Float3 WXW( this Float4 vector ) => new( vector.w, vector.x, vector.w );
        public static Float3 WYX( this Float4 vector ) => new( vector.w, vector.y, vector.x );
        public static Float3 WYY( this Float4 vector ) => new( vector.w, vector.y, vector.y );
        public static Float3 WYZ( this Float4 vector ) => new( vector.w, vector.y, vector.z );
        public static Float3 WYW( this Float4 vector ) => new( vector.w, vector.y, vector.w );
        public static Float3 WZX( this Float4 vector ) => new( vector.w, vector.z, vector.x );
        public static Float3 WZY( this Float4 vector ) => new( vector.w, vector.z, vector.y );
        public static Float3 WZZ( this Float4 vector ) => new( vector.w, vector.z, vector.z );
        public static Float3 WZW( this Float4 vector ) => new( vector.w, vector.z, vector.w );
        public static Float3 WWX( this Float4 vector ) => new( vector.w, vector.w, vector.x );
        public static Float3 WWY( this Float4 vector ) => new( vector.w, vector.w, vector.y );
        public static Float3 WWZ( this Float4 vector ) => new( vector.w, vector.w, vector.z );
        public static Float3 WWW( this Float4 vector ) => new( vector.w, vector.w, vector.w );

        #endregion

        #region Float4

        public static Float4 XXXX( this Float2 vector ) => new( vector.x, vector.x, vector.x, vector.x );
        public static Float4 XXXY( this Float2 vector ) => new( vector.x, vector.x, vector.x, vector.y );
        public static Float4 XXYX( this Float2 vector ) => new( vector.x, vector.x, vector.y, vector.x );
        public static Float4 XXYY( this Float2 vector ) => new( vector.x, vector.x, vector.y, vector.y );
        public static Float4 XYXX( this Float2 vector ) => new( vector.x, vector.y, vector.x, vector.x );
        public static Float4 XYXY( this Float2 vector ) => new( vector.x, vector.y, vector.x, vector.y );
        public static Float4 XYYX( this Float2 vector ) => new( vector.x, vector.y, vector.y, vector.x );
        public static Float4 XYYY( this Float2 vector ) => new( vector.x, vector.y, vector.y, vector.y );
        public static Float4 YXXX( this Float2 vector ) => new( vector.y, vector.x, vector.x, vector.x );
        public static Float4 YXXY( this Float2 vector ) => new( vector.y, vector.x, vector.x, vector.y );
        public static Float4 YXYX( this Float2 vector ) => new( vector.y, vector.x, vector.y, vector.x );
        public static Float4 YXYY( this Float2 vector ) => new( vector.y, vector.x, vector.y, vector.y );
        public static Float4 YYXX( this Float2 vector ) => new( vector.y, vector.y, vector.x, vector.x );
        public static Float4 YYXY( this Float2 vector ) => new( vector.y, vector.y, vector.x, vector.y );
        public static Float4 YYYX( this Float2 vector ) => new( vector.y, vector.y, vector.y, vector.x );
        public static Float4 YYYY( this Float2 vector ) => new( vector.y, vector.y, vector.y, vector.y );

        public static Float4 XXXX( this Float3 vector ) => new( vector.x, vector.x, vector.x, vector.x );
        public static Float4 XXXY( this Float3 vector ) => new( vector.x, vector.x, vector.x, vector.y );
        public static Float4 XXXZ( this Float3 vector ) => new( vector.x, vector.x, vector.x, vector.z );
        public static Float4 XXYX( this Float3 vector ) => new( vector.x, vector.x, vector.y, vector.x );
        public static Float4 XXYY( this Float3 vector ) => new( vector.x, vector.x, vector.y, vector.y );
        public static Float4 XXYZ( this Float3 vector ) => new( vector.x, vector.x, vector.y, vector.z );
        public static Float4 XXZX( this Float3 vector ) => new( vector.x, vector.x, vector.z, vector.x );
        public static Float4 XXZY( this Float3 vector ) => new( vector.x, vector.x, vector.z, vector.y );
        public static Float4 XXZZ( this Float3 vector ) => new( vector.x, vector.x, vector.z, vector.z );
        public static Float4 XYXX( this Float3 vector ) => new( vector.x, vector.y, vector.x, vector.x );
        public static Float4 XYXY( this Float3 vector ) => new( vector.x, vector.y, vector.x, vector.y );
        public static Float4 XYXZ( this Float3 vector ) => new( vector.x, vector.y, vector.x, vector.z );
        public static Float4 XYYX( this Float3 vector ) => new( vector.x, vector.y, vector.y, vector.x );
        public static Float4 XYYY( this Float3 vector ) => new( vector.x, vector.y, vector.y, vector.y );
        public static Float4 XYYZ( this Float3 vector ) => new( vector.x, vector.y, vector.y, vector.z );
        public static Float4 XYZX( this Float3 vector ) => new( vector.x, vector.y, vector.z, vector.x );
        public static Float4 XYZY( this Float3 vector ) => new( vector.x, vector.y, vector.z, vector.y );
        public static Float4 XYZZ( this Float3 vector ) => new( vector.x, vector.y, vector.z, vector.z );
        public static Float4 XZXX( this Float3 vector ) => new( vector.x, vector.z, vector.x, vector.x );
        public static Float4 XZXY( this Float3 vector ) => new( vector.x, vector.z, vector.x, vector.y );
        public static Float4 XZXZ( this Float3 vector ) => new( vector.x, vector.z, vector.x, vector.z );
        public static Float4 XZYX( this Float3 vector ) => new( vector.x, vector.z, vector.y, vector.x );
        public static Float4 XZYY( this Float3 vector ) => new( vector.x, vector.z, vector.y, vector.y );
        public static Float4 XZYZ( this Float3 vector ) => new( vector.x, vector.z, vector.y, vector.z );
        public static Float4 XZZX( this Float3 vector ) => new( vector.x, vector.z, vector.z, vector.x );
        public static Float4 XZZY( this Float3 vector ) => new( vector.x, vector.z, vector.z, vector.y );
        public static Float4 XZZZ( this Float3 vector ) => new( vector.x, vector.z, vector.z, vector.z );
        public static Float4 YXXX( this Float3 vector ) => new( vector.y, vector.x, vector.x, vector.x );
        public static Float4 YXXY( this Float3 vector ) => new( vector.y, vector.x, vector.x, vector.y );
        public static Float4 YXXZ( this Float3 vector ) => new( vector.y, vector.x, vector.x, vector.z );
        public static Float4 YXYX( this Float3 vector ) => new( vector.y, vector.x, vector.y, vector.x );
        public static Float4 YXYY( this Float3 vector ) => new( vector.y, vector.x, vector.y, vector.y );
        public static Float4 YXYZ( this Float3 vector ) => new( vector.y, vector.x, vector.y, vector.z );
        public static Float4 YXZX( this Float3 vector ) => new( vector.y, vector.x, vector.z, vector.x );
        public static Float4 YXZY( this Float3 vector ) => new( vector.y, vector.x, vector.z, vector.y );
        public static Float4 YXZZ( this Float3 vector ) => new( vector.y, vector.x, vector.z, vector.z );
        public static Float4 YYXX( this Float3 vector ) => new( vector.y, vector.y, vector.x, vector.x );
        public static Float4 YYXY( this Float3 vector ) => new( vector.y, vector.y, vector.x, vector.y );
        public static Float4 YYXZ( this Float3 vector ) => new( vector.y, vector.y, vector.x, vector.z );
        public static Float4 YYYX( this Float3 vector ) => new( vector.y, vector.y, vector.y, vector.x );
        public static Float4 YYYY( this Float3 vector ) => new( vector.y, vector.y, vector.y, vector.y );
        public static Float4 YYYZ( this Float3 vector ) => new( vector.y, vector.y, vector.y, vector.z );
        public static Float4 YYZX( this Float3 vector ) => new( vector.y, vector.y, vector.z, vector.x );
        public static Float4 YYZY( this Float3 vector ) => new( vector.y, vector.y, vector.z, vector.y );
        public static Float4 YYZZ( this Float3 vector ) => new( vector.y, vector.y, vector.z, vector.z );
        public static Float4 YZXX( this Float3 vector ) => new( vector.y, vector.z, vector.x, vector.x );
        public static Float4 YZXY( this Float3 vector ) => new( vector.y, vector.z, vector.x, vector.y );
        public static Float4 YZXZ( this Float3 vector ) => new( vector.y, vector.z, vector.x, vector.z );
        public static Float4 YZYX( this Float3 vector ) => new( vector.y, vector.z, vector.y, vector.x );
        public static Float4 YZYY( this Float3 vector ) => new( vector.y, vector.z, vector.y, vector.y );
        public static Float4 YZYZ( this Float3 vector ) => new( vector.y, vector.z, vector.y, vector.z );
        public static Float4 YZZX( this Float3 vector ) => new( vector.y, vector.z, vector.z, vector.x );
        public static Float4 YZZY( this Float3 vector ) => new( vector.y, vector.z, vector.z, vector.y );
        public static Float4 YZZZ( this Float3 vector ) => new( vector.y, vector.z, vector.z, vector.z );
        public static Float4 ZXXX( this Float3 vector ) => new( vector.z, vector.x, vector.x, vector.x );
        public static Float4 ZXXY( this Float3 vector ) => new( vector.z, vector.x, vector.x, vector.y );
        public static Float4 ZXXZ( this Float3 vector ) => new( vector.z, vector.x, vector.x, vector.z );
        public static Float4 ZXYX( this Float3 vector ) => new( vector.z, vector.x, vector.y, vector.x );
        public static Float4 ZXYY( this Float3 vector ) => new( vector.z, vector.x, vector.y, vector.y );
        public static Float4 ZXYZ( this Float3 vector ) => new( vector.z, vector.x, vector.y, vector.z );
        public static Float4 ZXZX( this Float3 vector ) => new( vector.z, vector.x, vector.z, vector.x );
        public static Float4 ZXZY( this Float3 vector ) => new( vector.z, vector.x, vector.z, vector.y );
        public static Float4 ZXZZ( this Float3 vector ) => new( vector.z, vector.x, vector.z, vector.z );
        public static Float4 ZYXX( this Float3 vector ) => new( vector.z, vector.y, vector.x, vector.x );
        public static Float4 ZYXY( this Float3 vector ) => new( vector.z, vector.y, vector.x, vector.y );
        public static Float4 ZYXZ( this Float3 vector ) => new( vector.z, vector.y, vector.x, vector.z );
        public static Float4 ZYYX( this Float3 vector ) => new( vector.z, vector.y, vector.y, vector.x );
        public static Float4 ZYYY( this Float3 vector ) => new( vector.z, vector.y, vector.y, vector.y );
        public static Float4 ZYYZ( this Float3 vector ) => new( vector.z, vector.y, vector.y, vector.z );
        public static Float4 ZYZX( this Float3 vector ) => new( vector.z, vector.y, vector.z, vector.x );
        public static Float4 ZYZY( this Float3 vector ) => new( vector.z, vector.y, vector.z, vector.y );
        public static Float4 ZYZZ( this Float3 vector ) => new( vector.z, vector.y, vector.z, vector.z );
        public static Float4 ZZXX( this Float3 vector ) => new( vector.z, vector.z, vector.x, vector.x );
        public static Float4 ZZXY( this Float3 vector ) => new( vector.z, vector.z, vector.x, vector.y );
        public static Float4 ZZXZ( this Float3 vector ) => new( vector.z, vector.z, vector.x, vector.z );
        public static Float4 ZZYX( this Float3 vector ) => new( vector.z, vector.z, vector.y, vector.x );
        public static Float4 ZZYY( this Float3 vector ) => new( vector.z, vector.z, vector.y, vector.y );
        public static Float4 ZZYZ( this Float3 vector ) => new( vector.z, vector.z, vector.y, vector.z );
        public static Float4 ZZZX( this Float3 vector ) => new( vector.z, vector.z, vector.z, vector.x );
        public static Float4 ZZZY( this Float3 vector ) => new( vector.z, vector.z, vector.z, vector.y );
        public static Float4 ZZZZ( this Float3 vector ) => new( vector.z, vector.z, vector.z, vector.z );

        public static Float4 XXXX( this Float4 vector ) => new( vector.x, vector.x, vector.x, vector.x );
        public static Float4 XXXY( this Float4 vector ) => new( vector.x, vector.x, vector.x, vector.y );
        public static Float4 XXXZ( this Float4 vector ) => new( vector.x, vector.x, vector.x, vector.z );
        public static Float4 XXXW( this Float4 vector ) => new( vector.x, vector.x, vector.x, vector.w );
        public static Float4 XXYX( this Float4 vector ) => new( vector.x, vector.x, vector.y, vector.x );
        public static Float4 XXYY( this Float4 vector ) => new( vector.x, vector.x, vector.y, vector.y );
        public static Float4 XXYZ( this Float4 vector ) => new( vector.x, vector.x, vector.y, vector.z );
        public static Float4 XXYW( this Float4 vector ) => new( vector.x, vector.x, vector.y, vector.w );
        public static Float4 XXZX( this Float4 vector ) => new( vector.x, vector.x, vector.z, vector.x );
        public static Float4 XXZY( this Float4 vector ) => new( vector.x, vector.x, vector.z, vector.y );
        public static Float4 XXZZ( this Float4 vector ) => new( vector.x, vector.x, vector.z, vector.z );
        public static Float4 XXZW( this Float4 vector ) => new( vector.x, vector.x, vector.z, vector.w );
        public static Float4 XXWX( this Float4 vector ) => new( vector.x, vector.x, vector.w, vector.x );
        public static Float4 XXWY( this Float4 vector ) => new( vector.x, vector.x, vector.w, vector.y );
        public static Float4 XXWZ( this Float4 vector ) => new( vector.x, vector.x, vector.w, vector.z );
        public static Float4 XXWW( this Float4 vector ) => new( vector.x, vector.x, vector.w, vector.w );
        public static Float4 XYXX( this Float4 vector ) => new( vector.x, vector.y, vector.x, vector.x );
        public static Float4 XYXY( this Float4 vector ) => new( vector.x, vector.y, vector.x, vector.y );
        public static Float4 XYXZ( this Float4 vector ) => new( vector.x, vector.y, vector.x, vector.z );
        public static Float4 XYXW( this Float4 vector ) => new( vector.x, vector.y, vector.x, vector.w );
        public static Float4 XYYX( this Float4 vector ) => new( vector.x, vector.y, vector.y, vector.x );
        public static Float4 XYYY( this Float4 vector ) => new( vector.x, vector.y, vector.y, vector.y );
        public static Float4 XYYZ( this Float4 vector ) => new( vector.x, vector.y, vector.y, vector.z );
        public static Float4 XYYW( this Float4 vector ) => new( vector.x, vector.y, vector.y, vector.w );
        public static Float4 XYZX( this Float4 vector ) => new( vector.x, vector.y, vector.z, vector.x );
        public static Float4 XYZY( this Float4 vector ) => new( vector.x, vector.y, vector.z, vector.y );
        public static Float4 XYZZ( this Float4 vector ) => new( vector.x, vector.y, vector.z, vector.z );
        public static Float4 XYZW( this Float4 vector ) => new( vector.x, vector.y, vector.z, vector.w );
        public static Float4 XYWX( this Float4 vector ) => new( vector.x, vector.y, vector.w, vector.x );
        public static Float4 XYWY( this Float4 vector ) => new( vector.x, vector.y, vector.w, vector.y );
        public static Float4 XYWZ( this Float4 vector ) => new( vector.x, vector.y, vector.w, vector.z );
        public static Float4 XYWW( this Float4 vector ) => new( vector.x, vector.y, vector.w, vector.w );
        public static Float4 XZXX( this Float4 vector ) => new( vector.x, vector.z, vector.x, vector.x );
        public static Float4 XZXY( this Float4 vector ) => new( vector.x, vector.z, vector.x, vector.y );
        public static Float4 XZXZ( this Float4 vector ) => new( vector.x, vector.z, vector.x, vector.z );
        public static Float4 XZXW( this Float4 vector ) => new( vector.x, vector.z, vector.x, vector.w );
        public static Float4 XZYX( this Float4 vector ) => new( vector.x, vector.z, vector.y, vector.x );
        public static Float4 XZYY( this Float4 vector ) => new( vector.x, vector.z, vector.y, vector.y );
        public static Float4 XZYZ( this Float4 vector ) => new( vector.x, vector.z, vector.y, vector.z );
        public static Float4 XZYW( this Float4 vector ) => new( vector.x, vector.z, vector.y, vector.w );
        public static Float4 XZZX( this Float4 vector ) => new( vector.x, vector.z, vector.z, vector.x );
        public static Float4 XZZY( this Float4 vector ) => new( vector.x, vector.z, vector.z, vector.y );
        public static Float4 XZZZ( this Float4 vector ) => new( vector.x, vector.z, vector.z, vector.z );
        public static Float4 XZZW( this Float4 vector ) => new( vector.x, vector.z, vector.z, vector.w );
        public static Float4 XZWX( this Float4 vector ) => new( vector.x, vector.z, vector.w, vector.x );
        public static Float4 XZWY( this Float4 vector ) => new( vector.x, vector.z, vector.w, vector.y );
        public static Float4 XZWZ( this Float4 vector ) => new( vector.x, vector.z, vector.w, vector.z );
        public static Float4 XZWW( this Float4 vector ) => new( vector.x, vector.z, vector.w, vector.w );
        public static Float4 XWXX( this Float4 vector ) => new( vector.x, vector.w, vector.x, vector.x );
        public static Float4 XWXY( this Float4 vector ) => new( vector.x, vector.w, vector.x, vector.y );
        public static Float4 XWXZ( this Float4 vector ) => new( vector.x, vector.w, vector.x, vector.z );
        public static Float4 XWXW( this Float4 vector ) => new( vector.x, vector.w, vector.x, vector.w );
        public static Float4 XWYX( this Float4 vector ) => new( vector.x, vector.w, vector.y, vector.x );
        public static Float4 XWYY( this Float4 vector ) => new( vector.x, vector.w, vector.y, vector.y );
        public static Float4 XWYZ( this Float4 vector ) => new( vector.x, vector.w, vector.y, vector.z );
        public static Float4 XWYW( this Float4 vector ) => new( vector.x, vector.w, vector.y, vector.w );
        public static Float4 XWZX( this Float4 vector ) => new( vector.x, vector.w, vector.z, vector.x );
        public static Float4 XWZY( this Float4 vector ) => new( vector.x, vector.w, vector.z, vector.y );
        public static Float4 XWZZ( this Float4 vector ) => new( vector.x, vector.w, vector.z, vector.z );
        public static Float4 XWZW( this Float4 vector ) => new( vector.x, vector.w, vector.z, vector.w );
        public static Float4 XWWX( this Float4 vector ) => new( vector.x, vector.w, vector.w, vector.x );
        public static Float4 XWWY( this Float4 vector ) => new( vector.x, vector.w, vector.w, vector.y );
        public static Float4 XWWZ( this Float4 vector ) => new( vector.x, vector.w, vector.w, vector.z );
        public static Float4 XWWW( this Float4 vector ) => new( vector.x, vector.w, vector.w, vector.w );
        public static Float4 YXXX( this Float4 vector ) => new( vector.y, vector.x, vector.x, vector.x );
        public static Float4 YXXY( this Float4 vector ) => new( vector.y, vector.x, vector.x, vector.y );
        public static Float4 YXXZ( this Float4 vector ) => new( vector.y, vector.x, vector.x, vector.z );
        public static Float4 YXXW( this Float4 vector ) => new( vector.y, vector.x, vector.x, vector.w );
        public static Float4 YXYX( this Float4 vector ) => new( vector.y, vector.x, vector.y, vector.x );
        public static Float4 YXYY( this Float4 vector ) => new( vector.y, vector.x, vector.y, vector.y );
        public static Float4 YXYZ( this Float4 vector ) => new( vector.y, vector.x, vector.y, vector.z );
        public static Float4 YXYW( this Float4 vector ) => new( vector.y, vector.x, vector.y, vector.w );
        public static Float4 YXZX( this Float4 vector ) => new( vector.y, vector.x, vector.z, vector.x );
        public static Float4 YXZY( this Float4 vector ) => new( vector.y, vector.x, vector.z, vector.y );
        public static Float4 YXZZ( this Float4 vector ) => new( vector.y, vector.x, vector.z, vector.z );
        public static Float4 YXZW( this Float4 vector ) => new( vector.y, vector.x, vector.z, vector.w );
        public static Float4 YXWX( this Float4 vector ) => new( vector.y, vector.x, vector.w, vector.x );
        public static Float4 YXWY( this Float4 vector ) => new( vector.y, vector.x, vector.w, vector.y );
        public static Float4 YXWZ( this Float4 vector ) => new( vector.y, vector.x, vector.w, vector.z );
        public static Float4 YXWW( this Float4 vector ) => new( vector.y, vector.x, vector.w, vector.w );
        public static Float4 YYXX( this Float4 vector ) => new( vector.y, vector.y, vector.x, vector.x );
        public static Float4 YYXY( this Float4 vector ) => new( vector.y, vector.y, vector.x, vector.y );
        public static Float4 YYXZ( this Float4 vector ) => new( vector.y, vector.y, vector.x, vector.z );
        public static Float4 YYXW( this Float4 vector ) => new( vector.y, vector.y, vector.x, vector.w );
        public static Float4 YYYX( this Float4 vector ) => new( vector.y, vector.y, vector.y, vector.x );
        public static Float4 YYYY( this Float4 vector ) => new( vector.y, vector.y, vector.y, vector.y );
        public static Float4 YYYZ( this Float4 vector ) => new( vector.y, vector.y, vector.y, vector.z );
        public static Float4 YYYW( this Float4 vector ) => new( vector.y, vector.y, vector.y, vector.w );
        public static Float4 YYZX( this Float4 vector ) => new( vector.y, vector.y, vector.z, vector.x );
        public static Float4 YYZY( this Float4 vector ) => new( vector.y, vector.y, vector.z, vector.y );
        public static Float4 YYZZ( this Float4 vector ) => new( vector.y, vector.y, vector.z, vector.z );
        public static Float4 YYZW( this Float4 vector ) => new( vector.y, vector.y, vector.z, vector.w );
        public static Float4 YYWX( this Float4 vector ) => new( vector.y, vector.y, vector.w, vector.x );
        public static Float4 YYWY( this Float4 vector ) => new( vector.y, vector.y, vector.w, vector.y );
        public static Float4 YYWZ( this Float4 vector ) => new( vector.y, vector.y, vector.w, vector.z );
        public static Float4 YYWW( this Float4 vector ) => new( vector.y, vector.y, vector.w, vector.w );
        public static Float4 YZXX( this Float4 vector ) => new( vector.y, vector.z, vector.x, vector.x );
        public static Float4 YZXY( this Float4 vector ) => new( vector.y, vector.z, vector.x, vector.y );
        public static Float4 YZXZ( this Float4 vector ) => new( vector.y, vector.z, vector.x, vector.z );
        public static Float4 YZXW( this Float4 vector ) => new( vector.y, vector.z, vector.x, vector.w );
        public static Float4 YZYX( this Float4 vector ) => new( vector.y, vector.z, vector.y, vector.x );
        public static Float4 YZYY( this Float4 vector ) => new( vector.y, vector.z, vector.y, vector.y );
        public static Float4 YZYZ( this Float4 vector ) => new( vector.y, vector.z, vector.y, vector.z );
        public static Float4 YZYW( this Float4 vector ) => new( vector.y, vector.z, vector.y, vector.w );
        public static Float4 YZZX( this Float4 vector ) => new( vector.y, vector.z, vector.z, vector.x );
        public static Float4 YZZY( this Float4 vector ) => new( vector.y, vector.z, vector.z, vector.y );
        public static Float4 YZZZ( this Float4 vector ) => new( vector.y, vector.z, vector.z, vector.z );
        public static Float4 YZZW( this Float4 vector ) => new( vector.y, vector.z, vector.z, vector.w );
        public static Float4 YZWX( this Float4 vector ) => new( vector.y, vector.z, vector.w, vector.x );
        public static Float4 YZWY( this Float4 vector ) => new( vector.y, vector.z, vector.w, vector.y );
        public static Float4 YZWZ( this Float4 vector ) => new( vector.y, vector.z, vector.w, vector.z );
        public static Float4 YZWW( this Float4 vector ) => new( vector.y, vector.z, vector.w, vector.w );
        public static Float4 YWXX( this Float4 vector ) => new( vector.y, vector.w, vector.x, vector.x );
        public static Float4 YWXY( this Float4 vector ) => new( vector.y, vector.w, vector.x, vector.y );
        public static Float4 YWXZ( this Float4 vector ) => new( vector.y, vector.w, vector.x, vector.z );
        public static Float4 YWXW( this Float4 vector ) => new( vector.y, vector.w, vector.x, vector.w );
        public static Float4 YWYX( this Float4 vector ) => new( vector.y, vector.w, vector.y, vector.x );
        public static Float4 YWYY( this Float4 vector ) => new( vector.y, vector.w, vector.y, vector.y );
        public static Float4 YWYZ( this Float4 vector ) => new( vector.y, vector.w, vector.y, vector.z );
        public static Float4 YWYW( this Float4 vector ) => new( vector.y, vector.w, vector.y, vector.w );
        public static Float4 YWZX( this Float4 vector ) => new( vector.y, vector.w, vector.z, vector.x );
        public static Float4 YWZY( this Float4 vector ) => new( vector.y, vector.w, vector.z, vector.y );
        public static Float4 YWZZ( this Float4 vector ) => new( vector.y, vector.w, vector.z, vector.z );
        public static Float4 YWZW( this Float4 vector ) => new( vector.y, vector.w, vector.z, vector.w );
        public static Float4 YWWX( this Float4 vector ) => new( vector.y, vector.w, vector.w, vector.x );
        public static Float4 YWWY( this Float4 vector ) => new( vector.y, vector.w, vector.w, vector.y );
        public static Float4 YWWZ( this Float4 vector ) => new( vector.y, vector.w, vector.w, vector.z );
        public static Float4 YWWW( this Float4 vector ) => new( vector.y, vector.w, vector.w, vector.w );
        public static Float4 ZXXX( this Float4 vector ) => new( vector.z, vector.x, vector.x, vector.x );
        public static Float4 ZXXY( this Float4 vector ) => new( vector.z, vector.x, vector.x, vector.y );
        public static Float4 ZXXZ( this Float4 vector ) => new( vector.z, vector.x, vector.x, vector.z );
        public static Float4 ZXXW( this Float4 vector ) => new( vector.z, vector.x, vector.x, vector.w );
        public static Float4 ZXYX( this Float4 vector ) => new( vector.z, vector.x, vector.y, vector.x );
        public static Float4 ZXYY( this Float4 vector ) => new( vector.z, vector.x, vector.y, vector.y );
        public static Float4 ZXYZ( this Float4 vector ) => new( vector.z, vector.x, vector.y, vector.z );
        public static Float4 ZXYW( this Float4 vector ) => new( vector.z, vector.x, vector.y, vector.w );
        public static Float4 ZXZX( this Float4 vector ) => new( vector.z, vector.x, vector.z, vector.x );
        public static Float4 ZXZY( this Float4 vector ) => new( vector.z, vector.x, vector.z, vector.y );
        public static Float4 ZXZZ( this Float4 vector ) => new( vector.z, vector.x, vector.z, vector.z );
        public static Float4 ZXZW( this Float4 vector ) => new( vector.z, vector.x, vector.z, vector.w );
        public static Float4 ZXWX( this Float4 vector ) => new( vector.z, vector.x, vector.w, vector.x );
        public static Float4 ZXWY( this Float4 vector ) => new( vector.z, vector.x, vector.w, vector.y );
        public static Float4 ZXWZ( this Float4 vector ) => new( vector.z, vector.x, vector.w, vector.z );
        public static Float4 ZXWW( this Float4 vector ) => new( vector.z, vector.x, vector.w, vector.w );
        public static Float4 ZYXX( this Float4 vector ) => new( vector.z, vector.y, vector.x, vector.x );
        public static Float4 ZYXY( this Float4 vector ) => new( vector.z, vector.y, vector.x, vector.y );
        public static Float4 ZYXZ( this Float4 vector ) => new( vector.z, vector.y, vector.x, vector.z );
        public static Float4 ZYXW( this Float4 vector ) => new( vector.z, vector.y, vector.x, vector.w );
        public static Float4 ZYYX( this Float4 vector ) => new( vector.z, vector.y, vector.y, vector.x );
        public static Float4 ZYYY( this Float4 vector ) => new( vector.z, vector.y, vector.y, vector.y );
        public static Float4 ZYYZ( this Float4 vector ) => new( vector.z, vector.y, vector.y, vector.z );
        public static Float4 ZYYW( this Float4 vector ) => new( vector.z, vector.y, vector.y, vector.w );
        public static Float4 ZYZX( this Float4 vector ) => new( vector.z, vector.y, vector.z, vector.x );
        public static Float4 ZYZY( this Float4 vector ) => new( vector.z, vector.y, vector.z, vector.y );
        public static Float4 ZYZZ( this Float4 vector ) => new( vector.z, vector.y, vector.z, vector.z );
        public static Float4 ZYZW( this Float4 vector ) => new( vector.z, vector.y, vector.z, vector.w );
        public static Float4 ZYWX( this Float4 vector ) => new( vector.z, vector.y, vector.w, vector.x );
        public static Float4 ZYWY( this Float4 vector ) => new( vector.z, vector.y, vector.w, vector.y );
        public static Float4 ZYWZ( this Float4 vector ) => new( vector.z, vector.y, vector.w, vector.z );
        public static Float4 ZYWW( this Float4 vector ) => new( vector.z, vector.y, vector.w, vector.w );
        public static Float4 ZZXX( this Float4 vector ) => new( vector.z, vector.z, vector.x, vector.x );
        public static Float4 ZZXY( this Float4 vector ) => new( vector.z, vector.z, vector.x, vector.y );
        public static Float4 ZZXZ( this Float4 vector ) => new( vector.z, vector.z, vector.x, vector.z );
        public static Float4 ZZXW( this Float4 vector ) => new( vector.z, vector.z, vector.x, vector.w );
        public static Float4 ZZYX( this Float4 vector ) => new( vector.z, vector.z, vector.y, vector.x );
        public static Float4 ZZYY( this Float4 vector ) => new( vector.z, vector.z, vector.y, vector.y );
        public static Float4 ZZYZ( this Float4 vector ) => new( vector.z, vector.z, vector.y, vector.z );
        public static Float4 ZZYW( this Float4 vector ) => new( vector.z, vector.z, vector.y, vector.w );
        public static Float4 ZZZX( this Float4 vector ) => new( vector.z, vector.z, vector.z, vector.x );
        public static Float4 ZZZY( this Float4 vector ) => new( vector.z, vector.z, vector.z, vector.y );
        public static Float4 ZZZZ( this Float4 vector ) => new( vector.z, vector.z, vector.z, vector.z );
        public static Float4 ZZZW( this Float4 vector ) => new( vector.z, vector.z, vector.z, vector.w );
        public static Float4 ZZWX( this Float4 vector ) => new( vector.z, vector.z, vector.w, vector.x );
        public static Float4 ZZWY( this Float4 vector ) => new( vector.z, vector.z, vector.w, vector.y );
        public static Float4 ZZWZ( this Float4 vector ) => new( vector.z, vector.z, vector.w, vector.z );
        public static Float4 ZZWW( this Float4 vector ) => new( vector.z, vector.z, vector.w, vector.w );
        public static Float4 ZWXX( this Float4 vector ) => new( vector.z, vector.w, vector.x, vector.x );
        public static Float4 ZWXY( this Float4 vector ) => new( vector.z, vector.w, vector.x, vector.y );
        public static Float4 ZWXZ( this Float4 vector ) => new( vector.z, vector.w, vector.x, vector.z );
        public static Float4 ZWXW( this Float4 vector ) => new( vector.z, vector.w, vector.x, vector.w );
        public static Float4 ZWYX( this Float4 vector ) => new( vector.z, vector.w, vector.y, vector.x );
        public static Float4 ZWYY( this Float4 vector ) => new( vector.z, vector.w, vector.y, vector.y );
        public static Float4 ZWYZ( this Float4 vector ) => new( vector.z, vector.w, vector.y, vector.z );
        public static Float4 ZWYW( this Float4 vector ) => new( vector.z, vector.w, vector.y, vector.w );
        public static Float4 ZWZX( this Float4 vector ) => new( vector.z, vector.w, vector.z, vector.x );
        public static Float4 ZWZY( this Float4 vector ) => new( vector.z, vector.w, vector.z, vector.y );
        public static Float4 ZWZZ( this Float4 vector ) => new( vector.z, vector.w, vector.z, vector.z );
        public static Float4 ZWZW( this Float4 vector ) => new( vector.z, vector.w, vector.z, vector.w );
        public static Float4 ZWWX( this Float4 vector ) => new( vector.z, vector.w, vector.w, vector.x );
        public static Float4 ZWWY( this Float4 vector ) => new( vector.z, vector.w, vector.w, vector.y );
        public static Float4 ZWWZ( this Float4 vector ) => new( vector.z, vector.w, vector.w, vector.z );
        public static Float4 ZWWW( this Float4 vector ) => new( vector.z, vector.w, vector.w, vector.w );
        public static Float4 WXXX( this Float4 vector ) => new( vector.w, vector.x, vector.x, vector.x );
        public static Float4 WXXY( this Float4 vector ) => new( vector.w, vector.x, vector.x, vector.y );
        public static Float4 WXXZ( this Float4 vector ) => new( vector.w, vector.x, vector.x, vector.z );
        public static Float4 WXXW( this Float4 vector ) => new( vector.w, vector.x, vector.x, vector.w );
        public static Float4 WXYX( this Float4 vector ) => new( vector.w, vector.x, vector.y, vector.x );
        public static Float4 WXYY( this Float4 vector ) => new( vector.w, vector.x, vector.y, vector.y );
        public static Float4 WXYZ( this Float4 vector ) => new( vector.w, vector.x, vector.y, vector.z );
        public static Float4 WXYW( this Float4 vector ) => new( vector.w, vector.x, vector.y, vector.w );
        public static Float4 WXZX( this Float4 vector ) => new( vector.w, vector.x, vector.z, vector.x );
        public static Float4 WXZY( this Float4 vector ) => new( vector.w, vector.x, vector.z, vector.y );
        public static Float4 WXZZ( this Float4 vector ) => new( vector.w, vector.x, vector.z, vector.z );
        public static Float4 WXZW( this Float4 vector ) => new( vector.w, vector.x, vector.z, vector.w );
        public static Float4 WXWX( this Float4 vector ) => new( vector.w, vector.x, vector.w, vector.x );
        public static Float4 WXWY( this Float4 vector ) => new( vector.w, vector.x, vector.w, vector.y );
        public static Float4 WXWZ( this Float4 vector ) => new( vector.w, vector.x, vector.w, vector.z );
        public static Float4 WXWW( this Float4 vector ) => new( vector.w, vector.x, vector.w, vector.w );
        public static Float4 WYXX( this Float4 vector ) => new( vector.w, vector.y, vector.x, vector.x );
        public static Float4 WYXY( this Float4 vector ) => new( vector.w, vector.y, vector.x, vector.y );
        public static Float4 WYXZ( this Float4 vector ) => new( vector.w, vector.y, vector.x, vector.z );
        public static Float4 WYXW( this Float4 vector ) => new( vector.w, vector.y, vector.x, vector.w );
        public static Float4 WYYX( this Float4 vector ) => new( vector.w, vector.y, vector.y, vector.x );
        public static Float4 WYYY( this Float4 vector ) => new( vector.w, vector.y, vector.y, vector.y );
        public static Float4 WYYZ( this Float4 vector ) => new( vector.w, vector.y, vector.y, vector.z );
        public static Float4 WYYW( this Float4 vector ) => new( vector.w, vector.y, vector.y, vector.w );
        public static Float4 WYZX( this Float4 vector ) => new( vector.w, vector.y, vector.z, vector.x );
        public static Float4 WYZY( this Float4 vector ) => new( vector.w, vector.y, vector.z, vector.y );
        public static Float4 WYZZ( this Float4 vector ) => new( vector.w, vector.y, vector.z, vector.z );
        public static Float4 WYZW( this Float4 vector ) => new( vector.w, vector.y, vector.z, vector.w );
        public static Float4 WYWX( this Float4 vector ) => new( vector.w, vector.y, vector.w, vector.x );
        public static Float4 WYWY( this Float4 vector ) => new( vector.w, vector.y, vector.w, vector.y );
        public static Float4 WYWZ( this Float4 vector ) => new( vector.w, vector.y, vector.w, vector.z );
        public static Float4 WYWW( this Float4 vector ) => new( vector.w, vector.y, vector.w, vector.w );
        public static Float4 WZXX( this Float4 vector ) => new( vector.w, vector.z, vector.x, vector.x );
        public static Float4 WZXY( this Float4 vector ) => new( vector.w, vector.z, vector.x, vector.y );
        public static Float4 WZXZ( this Float4 vector ) => new( vector.w, vector.z, vector.x, vector.z );
        public static Float4 WZXW( this Float4 vector ) => new( vector.w, vector.z, vector.x, vector.w );
        public static Float4 WZYX( this Float4 vector ) => new( vector.w, vector.z, vector.y, vector.x );
        public static Float4 WZYY( this Float4 vector ) => new( vector.w, vector.z, vector.y, vector.y );
        public static Float4 WZYZ( this Float4 vector ) => new( vector.w, vector.z, vector.y, vector.z );
        public static Float4 WZYW( this Float4 vector ) => new( vector.w, vector.z, vector.y, vector.w );
        public static Float4 WZZX( this Float4 vector ) => new( vector.w, vector.z, vector.z, vector.x );
        public static Float4 WZZY( this Float4 vector ) => new( vector.w, vector.z, vector.z, vector.y );
        public static Float4 WZZZ( this Float4 vector ) => new( vector.w, vector.z, vector.z, vector.z );
        public static Float4 WZZW( this Float4 vector ) => new( vector.w, vector.z, vector.z, vector.w );
        public static Float4 WZWX( this Float4 vector ) => new( vector.w, vector.z, vector.w, vector.x );
        public static Float4 WZWY( this Float4 vector ) => new( vector.w, vector.z, vector.w, vector.y );
        public static Float4 WZWZ( this Float4 vector ) => new( vector.w, vector.z, vector.w, vector.z );
        public static Float4 WZWW( this Float4 vector ) => new( vector.w, vector.z, vector.w, vector.w );
        public static Float4 WWXX( this Float4 vector ) => new( vector.w, vector.w, vector.x, vector.x );
        public static Float4 WWXY( this Float4 vector ) => new( vector.w, vector.w, vector.x, vector.y );
        public static Float4 WWXZ( this Float4 vector ) => new( vector.w, vector.w, vector.x, vector.z );
        public static Float4 WWXW( this Float4 vector ) => new( vector.w, vector.w, vector.x, vector.w );
        public static Float4 WWYX( this Float4 vector ) => new( vector.w, vector.w, vector.y, vector.x );
        public static Float4 WWYY( this Float4 vector ) => new( vector.w, vector.w, vector.y, vector.y );
        public static Float4 WWYZ( this Float4 vector ) => new( vector.w, vector.w, vector.y, vector.z );
        public static Float4 WWYW( this Float4 vector ) => new( vector.w, vector.w, vector.y, vector.w );
        public static Float4 WWZX( this Float4 vector ) => new( vector.w, vector.w, vector.z, vector.x );
        public static Float4 WWZY( this Float4 vector ) => new( vector.w, vector.w, vector.z, vector.y );
        public static Float4 WWZZ( this Float4 vector ) => new( vector.w, vector.w, vector.z, vector.z );
        public static Float4 WWZW( this Float4 vector ) => new( vector.w, vector.w, vector.z, vector.w );
        public static Float4 WWWX( this Float4 vector ) => new( vector.w, vector.w, vector.w, vector.x );
        public static Float4 WWWY( this Float4 vector ) => new( vector.w, vector.w, vector.w, vector.y );
        public static Float4 WWWZ( this Float4 vector ) => new( vector.w, vector.w, vector.w, vector.z );
        public static Float4 WWWW( this Float4 vector ) => new( vector.w, vector.w, vector.w, vector.w );

        #endregion

        #endregion

        #region Slow Swizzle

        public static object Swizz( this Float2 vector, string swizzle )
        {
            AssertSwizzleLength( swizzle.Length );

            float[] values = new float[swizzle.Length];

            for ( int i = 0; i < swizzle.Length; ++i )
            {
                char loweredLetter = char.ToLower( swizzle[i] );

                switch ( loweredLetter )
                {
                    case 'x':
                        values[i] = vector[0];
                        continue;
                    case 'y':
                        values[i] = vector[1];
                        continue;

                    default: throw new ArgumentOutOfRangeException();
                }
            }

            switch ( swizzle.Length )
            {
                case 1: return values[0];
                case 2: return new Float2( values[0], values[1] );
                case 3: return new Float3( values[0], values[1], values[3] );
                case 4: return new Float4( values[0], values[1], values[2], values[3] );

                default: throw new ArgumentOutOfRangeException( nameof( swizzle ), swizzle, "The swizzle assigned is invalid!" );
            }
        }

        public static object Swizz( this Float3 vector, string swizzle )
        {
            AssertSwizzleLength( swizzle.Length );

            float[] values = new float[swizzle.Length];

            for ( int i = 0; i < swizzle.Length; ++i )
            {
                char loweredLetter = char.ToLower( swizzle[i] );

                switch ( loweredLetter )
                {
                    case 'x':
                        values[i] = vector[0];
                        continue;
                    case 'y':
                        values[i] = vector[1];
                        continue;
                    case 'z':
                        values[i] = vector[1];
                        continue;

                    default: throw new ArgumentOutOfRangeException();
                }
            }

            switch ( swizzle.Length )
            {
                case 1: return values[0];
                case 2: return new Float2( values[0], values[1] );
                case 3: return new Float3( values[0], values[1], values[3] );
                case 4: return new Float4( values[0], values[1], values[2], values[3] );

                default: throw new ArgumentOutOfRangeException( nameof( swizzle ), swizzle, "the given swizzle has an invalid value!" );
            }
        }

        public static object Swizz( this Float4 vector, string swizzle )
        {
            AssertSwizzleLength( swizzle.Length );

            float[] values = new float[swizzle.Length];

            for ( int i = 0; i < swizzle.Length; ++i )
            {
                char loweredLetter = char.ToLower( swizzle[i] );

                switch ( loweredLetter )
                {
                    case 'x':
                        values[i] = vector[0];
                        continue;
                    case 'y':
                        values[i] = vector[1];
                        continue;
                    case 'z':
                        values[i] = vector[2];
                        continue;
                    case 'w':
                        values[i] = vector[3];
                        continue;

                    default: throw new ArgumentOutOfRangeException();
                }
            }

            switch ( swizzle.Length )
            {
                case 1: return values[0];
                case 2: return new Float2( values[0], values[1] );
                case 3: return new Float3( values[0], values[1], values[3] );
                case 4: return new Float4( values[0], values[1], values[2], values[3] );

                default: throw new ArgumentOutOfRangeException();
            }
        }

        public static object Swizz( this Int2 vector, string swizzle )
        {
            AssertSwizzleLength( swizzle.Length );

            int[] values = new int[swizzle.Length];

            for ( int i = 0; i < swizzle.Length; ++i )
            {
                char loweredLetter = char.ToLower( swizzle[i] );

                switch ( loweredLetter )
                {
                    case 'x':
                        values[i] = vector[0];
                        continue;
                    case 'y':
                        values[i] = vector[1];
                        continue;

                    default: throw new ArgumentOutOfRangeException();
                }
            }

            switch ( swizzle.Length )
            {
                case 1: return values[0];
                case 2: return new Int2( values[0], values[1] );
                case 3: return new Int3( values[0], values[1], values[3] );
                case 4: return new Int4( values[0], values[1], values[2], values[3] );

                default: throw new ArgumentOutOfRangeException();
            }
        }

        public static object Swizz( this Int3 vector, string swizzle )
        {
            AssertSwizzleLength( swizzle.Length );

            int[] values = new int[swizzle.Length];

            for ( int i = 0; i < swizzle.Length; ++i )
            {
                char loweredLetter = char.ToLower( swizzle[i] );

                switch ( loweredLetter )
                {
                    case 'x':
                        values[i] = vector[0];
                        continue;
                    case 'y':
                        values[i] = vector[1];
                        continue;
                    case 'z':
                        values[i] = vector[1];
                        continue;

                    default: throw new ArgumentOutOfRangeException();
                }
            }

            switch ( swizzle.Length )
            {
                case 1: return values[0];
                case 2: return new Int2( values[0], values[1] );
                case 3: return new Int3( values[0], values[1], values[3] );
                case 4: return new Int4( values[0], values[1], values[2], values[3] );

                default: throw new ArgumentOutOfRangeException();
            }
        }

        public static object Swizz( this Int4 vector, string swizzle )
        {
            AssertSwizzleLength( swizzle.Length );

            int[] values = new int[swizzle.Length];

            for ( int i = 0; i < swizzle.Length; ++i )
            {
                char loweredLetter = char.ToLower( swizzle[i] );

                switch ( loweredLetter )
                {
                    case 'x':
                        values[i] = vector[0];
                        continue;
                    case 'y':
                        values[i] = vector[1];
                        continue;
                    case 'z':
                        values[i] = vector[2];
                        continue;
                    case 'w':
                        values[i] = vector[3];
                        continue;

                    default: throw new ArgumentOutOfRangeException();
                }
            }

            switch ( swizzle.Length )
            {
                case 1: return values[0];
                case 2: return new Int2( values[0], values[1] );
                case 3: return new Int3( values[0], values[1], values[3] );
                case 4: return new Int4( values[0], values[1], values[2], values[3] );

                default: throw new ArgumentOutOfRangeException();
            }
        }

        static void AssertSwizzleLength( int length ) => Debug.Assert( length > 4 || length == 0, "invalid swizzle length!" );

        #endregion
    }
}
