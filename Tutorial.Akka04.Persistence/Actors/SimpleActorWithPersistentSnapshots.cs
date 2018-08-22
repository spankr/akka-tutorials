using System;
using Akka.Actor;
using Akka.Persistence;
using Tutorial.Akka04.Persistence.Messages;

namespace Tutorial.Akka04.Persistence.Actors
{
    /// <summary>
    /// Simple actor with persistent snapshots.
    /// <see cref="https://getakka.net/articles/persistence/architecture.html"/>
    /// </summary>
    public class SimpleActorWithPersistentSnapshots : ReceivePersistentActor
    {
        public SimpleActorWithPersistentSnapshots()
        {
            // Persistent actors used 'Command' instead of 'Receive'
            Command<GetSomeValueMessage>(_ => OnReceiveGetSomeValueMessage());
            Command<SetSomeValueMessage>(m => OnReceiveSetSomeValueMessage(m));

            Command<SaveSnapshotSuccess>(_ => { /* do nothing */ });
            Command<SaveSnapshotFailure>(_ => { /* do nothing */ });
            Recover<SnapshotOffer>(offer => OnRecoverSnapshotOffer(offer));
        }

        public override string PersistenceId => "some-unique-id-x";
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
            // Whenever internal state of an actor changes, we will save a snapshot.
            // Normally, actors will use a combination of events and snapshots for persistence.
            // We are exclusively using snapshots as an example.
            // see: https://getakka.net/articles/persistence/snapshots.html

            _heldValue = m.Value;
            SaveSnapshot(_heldValue);
        }

        /// <summary>
        /// When we are asked to recover from a snapshot, it should be our state object.
        /// </summary>
        /// <param name="offer">Offer.</param>
        private void OnRecoverSnapshotOffer(SnapshotOffer offer)
        {
            _heldValue = offer.Snapshot as string;
        }
    }
}
