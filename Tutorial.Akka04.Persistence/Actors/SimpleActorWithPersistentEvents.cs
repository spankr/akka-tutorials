using System;
using Akka.Actor;
using Akka.Persistence;
using Tutorial.Akka04.Persistence.Messages;

namespace Tutorial.Akka04.Persistence.Actors
{
    /// <summary>
    /// Simple actor with persistent events.
    /// <see cref="https://getakka.net/articles/persistence/architecture.html"/>
    /// </summary>
    public class SimpleActorWithPersistentEvents : ReceivePersistentActor
    {

        public SimpleActorWithPersistentEvents()
        {
            // Persistent actors used 'Command' instead of 'Receive'
            Command<GetSomeValueMessage>(_ => OnReceiveGetSomeValueMessage());
            Command<SetSomeValueMessage>(m => OnReceiveSetSomeValueMessage(m));
            Recover<ValueAssignedEvent>(evt => OnRecoverValueAssignedEvent(evt));
        }

        public override string PersistenceId => "some-unique-id";
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
            // Whenever internal state of an actor changes, we should persist that
            // as an event so actor recovery can replay those events to put the actor
            // in the correct state.
            Persist(new ValueAssignedEvent(m.Value), evt =>
            {
                _heldValue = m.Value;
            });
        }

        /// <summary>
        /// Recovery of an event should only modify internal state.
        /// </summary>
        /// <param name="evt">the event we are recovering</param>
        private void OnRecoverValueAssignedEvent(ValueAssignedEvent evt)
        {
            _heldValue = evt.NewValue;
        }

        #region Event Definitions
        /// <summary>
        /// Events should be immutable
        /// </summary>
        public class ValueAssignedEvent
        {
            public string NewValue { get; }
            public ValueAssignedEvent(string newValue)
            {
                NewValue = newValue;
            }
        }
        #endregion
    }
}
