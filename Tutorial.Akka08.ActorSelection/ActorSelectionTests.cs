using System;
using Akka.Actor;
using Akka.TestKit.Xunit2;
using Xunit;

namespace Tutorial.Akka08.ActorSelection
{
    public class ActorSelectionTests : TestKit
    {
        /// <summary>
        /// Use ActorSelection to reference our actor
        /// </summary>
        [Fact(DisplayName = "Sending a message to an actor by actor selection")]
        public void UseActorSelectionToSendMessage()
        {
            // Setup
            var msgToSend = "Shirley Temple";
            Sys.ActorOf(Props.Create(() => new SampleActor()), "actor-under-test");

            // Action: user-created actors live under "/user"
            var selection = Sys.ActorSelection("user/actor-under-test");
            selection.Tell(msgToSend);

            // Result
            ExpectMsg<string>(m => m.Contains(msgToSend));
        }

        /// <summary>
        /// Use the actor directly to send our test message to our actor. 
        /// This is for comparison purposes.
        /// </summary>
        [Fact(DisplayName = "Sending a message to an actor using its IActorRef")]
        public void UseDirectActorToSendMessage()
        {
            // Setup
            var msgToSend = "Shirley Temple";
            var aut = Sys.ActorOf(Props.Create(() => new SampleActor()), "actor-under-test");

            // Action
            aut.Tell(msgToSend);

            // Result
            ExpectMsg<string>(m => m.Contains(msgToSend));
        }

        /// <summary>
        /// Just a simple actor that receives strings and responds back.
        /// </summary>
        public class SampleActor : ReceiveActor
        {
            public SampleActor()
            {
                Receive<string>(m =>
                {
                    Sender.Tell($"Received {m}");
                });
            }
        }
    }
}
