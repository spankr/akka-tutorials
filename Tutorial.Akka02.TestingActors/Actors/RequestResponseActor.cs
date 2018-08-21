using Akka.Actor;

namespace Tutorial.Akka02.TestingActors
{
    /// <summary>
    /// This actor is written to receive some request message and then respond with some response message.
    /// </summary>
    public class RequestResponseActor : ReceiveActor
    {
        public RequestResponseActor()
        {
            Receive<SomeRequestMessage>(m => OnReceiveSomeRequestMessage(m));
        }

        private void OnReceiveSomeRequestMessage(SomeRequestMessage m)
        {
            Sender.Tell(new SomeResponseMessage());
        }

        #region Messages
        public class SomeRequestMessage { }
        public class SomeResponseMessage { }
        #endregion
    }
}
