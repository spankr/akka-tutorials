using Akka.Actor;
using Akka.TestKit.Xunit2;
using Tutorial.Akka03.Children.Actors;
using Xunit;

namespace Tutorial.Akka03.Children
{
    public class ChildrenTests : TestKit
    {
        [Fact(DisplayName ="A newly created parent actor should have no children")]
        public void CreateParentActor()
        {
            // Setup
            var aut = Sys.ActorOf(Props.Create(() => new ParentActor()), "the-parent-actor");

            // Action
            aut.Tell(new ParentActor.ListChildrenMessage());

            // Result
            ExpectMsg<ParentActor.ListChildrenResponse>(m => m.Names.Count == 0);
        }

        [Fact(DisplayName ="Creating a child actor should appear under the parent actor's children")]
        public void CreateOneChildActor()
        {
            var expectedChildName = "Child-X";
            // Setup
            var aut = Sys.ActorOf(Props.Create(() => new ParentActor()), "the-parent-actor");

            // Action: Create a child actor
            aut.Tell(new ParentActor.CreateChildMessage(expectedChildName));

            // Result: No response expected for a create child message
            ExpectNoMsg();

            // Action: List existing children
            aut.Tell(new ParentActor.ListChildrenMessage());

            // Result
            var response = ExpectMsg<ParentActor.ListChildrenResponse>();
            Assert.Single(response.Names);
            Assert.Contains(expectedChildName, response.Names);
        }
    }
}
