using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CXUtils.Utilities.Reflection
{
    ///<summary> A simple reflection helper </summary>
    public class ReflectionUtils
    {

        #region Attributes

        public static IEnumerable<MethodInfo> GetMethodsFromCallingAssemblyWithAttributesOf<T>( BindingFlags flags ) where T : Attribute =>
            from type in Assembly.GetCallingAssembly().GetTypes()
            from method in type.GetMethods( flags )
            from attribute in method.GetCustomAttributes<T>()
            select method;

        #endregion

        #region MethodInfo

        #if NETCOREAPP2_0_OR_GREATER
        ///<summary> Get's a method according to the method that is given </summary>
        public static MethodInfo GetMethodInfo<T>( Expression<Action<T>> exp ) => GetMethodInfo<Action<T>>( exp );

        public static MethodInfo GetMethodInfo<T>( Expression<T> exp ) where T : Delegate
        {
            if ( exp.Body is not MethodCallExpression member )
                throw new ArgumentException( "The given expression is not a method!" );

            return member.Method;
        }
        #endif

        #endregion
    }
}
