using System;
using Akka.Actor;
using Akka.TestKit.Xunit2;
using Tutorial.Akka04.Persistence.Actors;
using Tutorial.Akka04.Persistence.Messages;
using Xunit;

namespace Tutorial.Akka04.Persistence
{
    /// <summary>
    /// Tests that demonstrate persistent actors
    /// <see cref="https://getakka.net/articles/persistence/architecture.html"/>
    /// </summary>
    public class PersistenceTests : TestKit
    {
        private readonly string EXPECTED_NEW_VALUE = "Bob was here";

        [Fact(DisplayName = "Examine actor behavior that is not persistent")]
        public void NonPersistentBehavior()
        {
            // Setup
            var aut = Sys.ActorOf(Props.Create(() => new SimpleActor()), "actor-under-test");

            // Action: Check for default
            aut.Tell(new GetSomeValueMessage());

            // Result
            ExpectMsg<string>(m => m == "");

            aut.Tell(new SetSomeValueMessage(EXPECTED_NEW_VALUE));
            ExpectNoMsg();

            // Action: Check for new value
            aut.Tell(new GetSomeValueMessage());

            // Result
            ExpectMsg<string>(m => m == EXPECTED_NEW_VALUE);

            // Let's stop our actor
            Watch(aut);
            Sys.Stop(aut);

            // Result: Our actor should have ended.
            ExpectTerminated(aut);

            // Recreate our actor
            aut = Sys.ActorOf(Props.Create(() => new SimpleActor()), "actor-under-test");

            // Action: Check for internal value
            aut.Tell(new GetSomeValueMessage());

            // Result: Non-persistent actor should have the default
            ExpectMsg<string>(m => m == "");
        }


        [Fact(DisplayName = "Examine actor behavior that is persistent with events")]
        public void PersistentEventsBehavior()
        {
            // Setup
            var aut = Sys.ActorOf(Props.Create(() => new SimpleActorWithPersistentEvents()), "actor-under-test");

            // Action: Check for default
            aut.Tell(new GetSomeValueMessage());

            // Result
            ExpectMsg<string>(m => m == "");

            aut.Tell(new SetSomeValueMessage(EXPECTED_NEW_VALUE));
            ExpectNoMsg();

            // Action: Check for new value
            aut.Tell(new GetSomeValueMessage());

            // Result
            ExpectMsg<string>(m => m == EXPECTED_NEW_VALUE);

            // Let's stop our actor
            Watch(aut);
            Sys.Stop(aut);

            // Result: Our actor should have ended.
            ExpectTerminated(aut);

            // Recreate our actor
            aut = Sys.ActorOf(Props.Create(() => new SimpleActorWithPersistentEvents()), "actor-under-test");

            // Action: Check for internal value
            aut.Tell(new GetSomeValueMessage());

            // Result: Persistent actor should have remembered the last
            ExpectMsg<string>(m => m == EXPECTED_NEW_VALUE);
        }

        [Fact(DisplayName = "Examine actor behavior that is persistent with snapshots")]
        public void PersistentSnapshotsBehavior()
        {
            // Setup
            var aut = Sys.ActorOf(Props.Create(() => new SimpleActorWithPersistentSnapshots()), "actor-under-test");

            // Action: Check for default
            aut.Tell(new GetSomeValueMessage());

            // Result
            ExpectMsg<string>(m => m == "");

            aut.Tell(new SetSomeValueMessage(EXPECTED_NEW_VALUE));
            ExpectNoMsg();

            // Action: Check for new value
            aut.Tell(new GetSomeValueMessage());

            // Result
            ExpectMsg<string>(m => m == EXPECTED_NEW_VALUE);

            // Let's stop our actor
            Watch(aut);
            Sys.Stop(aut);

            // Result: Our actor should have ended.
            ExpectTerminated(aut);

            // Recreate our actor
            aut = Sys.ActorOf(Props.Create(() => new SimpleActorWithPersistentSnapshots()), "actor-under-test");

            // Action: Check for internal value
            aut.Tell(new GetSomeValueMessage());

            // Result: Persistent actor should have remembered the last
            ExpectMsg<string>(m => m == EXPECTED_NEW_VALUE);
        }

        /// <summary>
        /// Persistence requires storage in some type of database. We are using the in-memory version.
        /// </summary>
        public PersistenceTests() : base(
@"akka.persistence.snapshot-store.plugin = ""akka.persistence.snapshot-store.inmem""
akka.persistence {
    journal {
        plugin = ""akka.persistence.journal.inmem""
        inmem {
            class = ""Akka.Persistence.Journal.MemoryJournal, Akka.Persistence""
            plugin-dispatcher = ""akka.actor.default-dispatcher""
        }
    }
    snapshot-store {
        plugin = ""akka.persistence.snapshot-store.inmem""
        inmem {
            class = ""Akka.Persistence.Snapshot.MemorySnapshotStore, Akka.Persistence""
            plugin-dispatcher = ""akka.actor.default-dispatcher""
        }
    }
}")
        { }
    }
}
