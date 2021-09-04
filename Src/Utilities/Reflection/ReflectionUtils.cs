using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Collections.Generic;

namespace CXUtils.Utilities.Reflection
{
    ///<summary> A simple reflection helper </summary>
    public class ReflectionUtils
    {
        #region MethodInfo

        ///<summary> Get's a method according to the method that is given </summary>
        public static MethodInfo GetMethodInfo<T>( Expression<Action<T>> exp )
        {
            return GetMethodInfo<Action<T>>( exp );
        }

        public static MethodInfo GetMethodInfo<T>( Expression<T> exp ) where T : Delegate
        {
            if ( !( exp.Body is MethodCallExpression member ) )
                throw new ArgumentException( "The given expression is not a method!" );

            return member.Method;
        }

        #endregion

        #region Attributes

        public static IEnumerable<MethodInfo> GetMethodsFromCallingAssemblyWithAttributesOf<T>( BindingFlags flags ) where T : Attribute
        {
            return
                from type in Assembly.GetCallingAssembly().GetTypes()
                from method in type.GetMethods( flags )
                from attribute in method.GetCustomAttributes<T>()
                select method;
        }

        #endregion
    }
}
