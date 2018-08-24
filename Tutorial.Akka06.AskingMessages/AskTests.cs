using System;
using System.Threading.Tasks;
using Akka.Actor;
using Akka.TestKit.Xunit2;
using Xunit;

namespace Tutorial.Akka06.AskingMessages
{
    public class AskTests : TestKit
    {
        /// <summary>
        /// Use Ask() instead of Tell() on an actor to wait for a response.
        /// </summary>
        [Theory(DisplayName = "Perform an Ask() on an actor, expecting a immediate response")]
        [InlineData("wango")]
        [InlineData("Beverly Jones")]
        [InlineData("tango")]
        public async Task PerformTestUsingAsk(string msgToSend)
        {
            // Setup
            var aut = Sys.ActorOf(Props.Create(() => new SimpleActor()), "actor-under-test");

            // Action
            var response = await aut.Ask<string>(msgToSend);

            // Result
            Assert.Equal($"Replying to {msgToSend}", response);
        }

        /// <summary>
        /// We will run the same test logic as before except this time we will use normal Tell().
        /// </summary>
        /// <param name="msgToSend">Message to send.</param>
        [Theory(DisplayName = "Perform a Tell() to an actor")]
        [InlineData("wango")]
        [InlineData("Beverly Jones")]
        [InlineData("tango")]
        public void PerformTestUsingTell(string msgToSend)
        {
            // Setup
            var aut = Sys.ActorOf(Props.Create(() => new SimpleActor()), "actor-under-test");

            // Action
            aut.Tell(msgToSend);

            // Result
            var response = ExpectMsg<string>();
            Assert.Equal($"Replying to {msgToSend}", response);

        }

        /// <summary>
        /// A simple actor that replies to string messages with a string response.
        /// </summary>
        public class SimpleActor : ReceiveActor
        {
            public SimpleActor()
            {
                Receive<string>(s =>
                {
                    // Send a response back to the message sender 
                    Sender.Tell($"Replying to {s}");
                });
            }
        }
    }
}
