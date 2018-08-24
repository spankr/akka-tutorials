using System;
using Akka.Actor;
using Akka.TestKit.Xunit2;
using Xunit;

namespace Tutorial.Akka07.ForwardingMessages
{
    public class ForwardingTests : TestKit
    {
        [Fact(DisplayName = "Demonstrate forwarding messages by bouncing messages back")]
        public void BouncingMessagesBackToSender()
        {
            var msgToSend = "My message";

            // Setup
            var aut = Sys.ActorOf(Props.Create(() => new BouncebackActor()), "bounce-back-router");

            // Action: Send a message to the bounceback actor
            aut.Tell(msgToSend);

            // Result: We should receive a message and it should appear to come from ourself.
            var response = ExpectMsgFrom<string>(TestActor);
            Assert.Equal(msgToSend, response);
        }

        /// <summary>
        /// Having a test that demonstrates how a testkit test can handle its "Self" might
        /// be helpful.
        /// </summary>
        [Fact(DisplayName = "Equivalent test by directly sending message to self")]
        public void SendMessageToSelf()
        {
            var msgToSend = "My message";

            // Setup
            var aut = TestActor; // actors have "Self", testkit tests has "TestActor"

            // Action: Send a message to the TestActor(Self) that represents the test case
            aut.Tell(msgToSend);

            // Result: We should receive a message and it should appear to come from ourself.
            var response = ExpectMsgFrom<string>(TestActor);
            Assert.Equal(msgToSend, response);
        }


        /// <summary>
        /// An actor that will forward any messages back to the sender
        /// </summary>
        public class BouncebackActor : ReceiveActor
        {
            public BouncebackActor()
            {

                // Any message we receive, we shall forward back to the sender
                ReceiveAny(m =>
                {
                    Sender.Forward(m);
                });

                /* 
                 * NOTE: No Receive() calls can go here. 
                 * If ReceiveAny() is used it has to be the last method in the list
                 * as it catches everything that makes it this far.
                */
            }
        }
    }
}
