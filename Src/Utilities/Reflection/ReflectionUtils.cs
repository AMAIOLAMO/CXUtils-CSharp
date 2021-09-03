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
    }
}
