using System;

namespace Chupacabra.PlayerCore.Service
{
    [Serializable]
    public class CommandsLimitReachedException : Exception
    {
        public CommandsLimitReachedException(int time, int errorCode, string errorMessage) :
            base(string.Format("Server returned {0}: {1}", errorCode, errorMessage))
        {
            this.TimeTillNextTurn = time;
            this.ErrorCode = errorCode;
            this.ErrorMessage = errorMessage;
        }

        public CommandsLimitReachedException() { }
        public CommandsLimitReachedException(string message) : base(message) { }
        public CommandsLimitReachedException(string message, Exception inner) : base(message, inner) { }
        protected CommandsLimitReachedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }

        public int TimeTillNextTurn { get; private set; }

        public int ErrorCode { get; protected set; }
        public string ErrorMessage { get; protected set; }
    }
}
