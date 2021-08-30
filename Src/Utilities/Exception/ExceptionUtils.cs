using System;

namespace CXUtils.Common
{
    /// <summary>
    ///     A utility for handling Exceptions
    /// </summary>
    public static class ExceptionUtils
    {
        public enum InvalidType
        {
            InvalidValue, ValueOutOfRange
        }

        //Error
        const string ERROR_NOT_ACCESSIBLE = "The code here is been accessed but it should not be accessed!";
        const string ERROR_ENUM_NOT_IMPLEMENTED = "The enum case is not implemented!";

        //Invalid
        const string INVALID_VALUE_INVALID = "The value that is been modified is Invalid!",
            INVALID_VALUE_OUT_OF_RANGE = "The value is out of range!";

        public static class Invalid
        {
            /// <summary>
            ///     Invalid type: The value is invalid.
            /// </summary>
            public static Exception InvalidValue => new Exception(INVALID_VALUE_INVALID);
            /// <summary>
            ///     Invalid type: The value is out of range.
            /// </summary>
            public static Exception ValueOutOfRange => new Exception(INVALID_VALUE_OUT_OF_RANGE);

            /// <summary>
            /// Get's a <see cref="InvalidType"/> exception
            /// </summary>
            public static Exception Get(string valueName, InvalidType type, string invalidReason = null)
            {
                string resultInvalidReason = invalidReason == null ? null : " reason: " + invalidReason;

                switch ( type )
                {
                    case InvalidType.InvalidValue: return new Exception("The value: " + valueName + " is an invalid value!" + resultInvalidReason);

                    case InvalidType.ValueOutOfRange: return new Exception("The value: " + valueName + " is out of range!" + resultInvalidReason);

                    default: throw Error.NotAccessible;
                }
            }
        }

        public static class Error
        {
            /// <summary>
            ///     Error type: The code logic is not accessible here.
            /// </summary>
            public static Exception NotAccessible => new Exception(ERROR_NOT_ACCESSIBLE);

            /// <summary>
            ///     Error type: The enum is not implemented.
            /// </summary>
            public static Exception EnumActionNotImplemented => new NotImplementedException(ERROR_ENUM_NOT_IMPLEMENTED);
        }
    }
}
