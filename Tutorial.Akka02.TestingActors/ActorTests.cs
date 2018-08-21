using Akka.Actor;
using Akka.TestKit.Xunit2;
using Xunit;

namespace Tutorial.Akka02.TestingActors
{
    public class ActorTests : TestKit
    {
        /// <summary>
        /// Actor testing is synonomous with 'black-box testing'. Actor can be sent input and we can test for desired output.
        /// NOTE: Internal actor state cannot be evaluated!
        /// </summary>
        [Fact(DisplayName = "Expected response message for a handled message")]
        public void SendSomeRequestMessage_ReceiveSomeResponseMessage()
        {
            // Setup
            var aut = Sys.ActorOf(Props.Create(() => new RequestResponseActor()), "actor-under-test");

            // Action
            aut.Tell(new RequestResponseActor.SomeRequestMessage());

            // Result
            ExpectMsg<RequestResponseActor.SomeResponseMessage>();
        }

        /// <summary>
        /// Sometimes the desired result is to test that no response is returned.
        /// </summary>
        [Fact(DisplayName = "No response for an unhandled message")]
        public void SendString_NoResponse()
        {
            // Setup
            var aut = Sys.ActorOf(Props.Create(() => new RequestResponseActor()), "actor-under-test");

            // Action
            aut.Tell("test message");

            // Result
            ExpectNoMsg();
        }
    }
}
