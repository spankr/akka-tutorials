using System;
using Akka.Actor;
using Tutorial.Akka04.Persistence.Messages;

namespace Tutorial.Akka04.Persistence.Actors
{
    public class SimpleActor : ReceiveActor
    {

        public SimpleActor()
        {
            Receive<GetSomeValueMessage>(_ => OnReceiveGetSomeValueMessage());
            Receive<SetSomeValueMessage>(m => OnReceiveSetSomeValueMessage(m));
        }

        private string _heldValue = "";

        /// <summary>
        /// The sender would like to know what our internal value is.
        /// </summary>
        private void OnReceiveGetSomeValueMessage()
        {
            Sender.Tell(_heldValue);
        }

        /// <summary>
        /// The sender wants to assign our internal value.
        /// </summary>
        /// <param name="m">M.</param>
        private void OnReceiveSetSomeValueMessage(SetSomeValueMessage m)
        {
            _heldValue = m.Value;
        }
    }
}
