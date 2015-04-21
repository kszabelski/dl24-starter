using System;

namespace Chupacabra.PlayerCore.Service
{
    [Serializable]
    public class ServerException : Exception
    {
        public ServerException() { }
        public ServerException(string message) : base(message) { }
        public ServerException(string message, Exception inner) : base(message, inner) { }
        protected ServerException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }

        public ServerException(int errorCode, string errorMessage) :
            base(string.Format("Server returned {0}: {1}", errorCode, errorMessage))
        {
            this.ErrorCode = errorCode;
            this.ErrorMessage = errorMessage;
        }

        public int ErrorCode { get; protected set; }
        public string ErrorMessage { get; protected set; }
    }
}
