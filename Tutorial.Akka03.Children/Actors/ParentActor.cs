using Akka.Actor;
using System.Collections.Generic;
using System.Linq;

namespace Tutorial.Akka03.Children.Actors
{
    public class ParentActor: ReceiveActor
    {
        public ParentActor()
        {
            Receive<CreateChildMessage>(m => OnReceiveCreateChildMessage(m));
            Receive<ListChildrenMessage>(_ => OnReceiveListChildrenMessage());
        }

        private void OnReceiveCreateChildMessage(CreateChildMessage m)
        {
            // Create a ChildActor and it will be within the context of this parent actor
            Context.ActorOf(Props.Create(() => new ChildActor()), m.Name);
        }

        private void OnReceiveListChildrenMessage()
        {
            Sender.Tell(new ListChildrenResponse(Context.GetChildren().Select(c => c.Path.Name)));
        }

        // REMINDER: Messages should be immutable!
        #region Messages
        public class CreateChildMessage
        {
            public string Name { get; }
            public CreateChildMessage(string name)
            {
                Name = name;
            }
        }

        public class ListChildrenMessage { }
        public class ListChildrenResponse
        {
            public List<string> Names { get; } = new List<string>();

            public ListChildrenResponse(IEnumerable<string> names)
            {
                Names.AddRange(names);
            }
        }
        #endregion
    }
}
