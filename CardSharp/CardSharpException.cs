using System;
using System.Runtime.Serialization;

namespace CardSharp {
    class CardSharpException : Exception {
        public CardSharpException() {
        }

        public CardSharpException(string message) : base(message) {
        }

        public CardSharpException(string message, Exception innerException) : base(message, innerException) {
        }

        protected CardSharpException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}
