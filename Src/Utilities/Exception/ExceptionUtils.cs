using System;

namespace CXUtils.Common
{
    /// <summary>
    ///     A utility for throwing / handling exceptions
    /// </summary>
    public static class ExceptionUtils
    {
        //Process
        const string NOT_ACCESSIBLE              = "The code here is been accessed but it should not be accessed.";
        const string ENUM_NOT_IMPLEMENTED        = "The enum case is not implemented.";
        const string POSSIBILITY_NOT_IMPLEMENTED = "The possibility here is not implemented.";
        const string NOT_RELEASED                = "The memory here is not released.";

        //Value
        const string VALUE_INVALID        = "The value that is been modified is Invalid.";
        const string VALUE_OUT_OF_RANGE   = "The value is out of range.";
        const string VALUE_LENGTH_INVALID = "The given length is invalid.";
        const string VALUE_ELEMENT_EMPTY  = "The given collection has no elements.";
        const string VALUE_LENGTH_ZERO    = "The given Length shouldn't be empty";

        /// <summary>
        ///     The code logic is not accessible here.
        /// </summary>
        public static Exception NotAccessible => new Exception( NOT_ACCESSIBLE );

        /// <summary>
        ///     The memory here is not released.
        /// </summary>
        public static Exception MemoryNotReleased => new Exception( NOT_RELEASED );

        /// <summary>
        ///     The enum is not implemented.
        /// </summary>
        public static NotImplementedException EnumNotImplemented => new NotImplementedException( ENUM_NOT_IMPLEMENTED );
        public static NotImplementedException PossibilityNotImplemented => new NotImplementedException( POSSIBILITY_NOT_IMPLEMENTED );

        /// <summary>
        ///     The value is invalid.
        /// </summary>
        public static Exception InvalidValue => new Exception( VALUE_INVALID );

        public static Exception OutOfRange => new Exception( VALUE_OUT_OF_RANGE );
        /// <summary>
        ///     The value is out of range.
        /// </summary>
        public static Exception InvalidLength => new Exception( VALUE_LENGTH_INVALID );
        public static Exception ElementEmpty => new Exception( VALUE_ELEMENT_EMPTY );
        public static Exception LengthZero   => new Exception( VALUE_LENGTH_ZERO );

        public static Exception Get( string valueName, object value, InvalidReason reason, string detail = default ) =>
            throw new Exception( $"{valueName} of value {value} is invalid. [Reason: {reason}] {detail}" ); // valueName + " of value: " + value + " is invalid. [ Reason: " + GetReasonString( reason ) + " ] " + detail );

        public static Exception Get( string valueName, InvalidReason reason, string detail = default ) =>
            throw new Exception( $"{valueName} is invalid. [Reason: {reason}] {detail}"  );

        static string GetReasonString( InvalidReason reason )
        {
            switch ( reason )
            {
                case InvalidReason.InvalidValue:    return VALUE_INVALID;
                case InvalidReason.ValueOutOfRange: return VALUE_OUT_OF_RANGE;
                case InvalidReason.LengthInvalid:   return VALUE_LENGTH_INVALID;
                case InvalidReason.ElementEmpty:    return VALUE_ELEMENT_EMPTY;
                case InvalidReason.LengthZero:      return VALUE_LENGTH_ZERO;

                default: throw PossibilityNotImplemented;
            }
        }
    }

    public enum InvalidReason
    {
        InvalidValue, ValueOutOfRange, LengthInvalid, ElementEmpty, LengthZero
    }
}
