using Akka.Actor;

namespace Tutorial.Akka03.Children.Actors
{
    /// <summary>
    /// Just an empty actor for demonstrating parent-child relationship in actors
    /// </summary>
    public class ChildActor : ReceiveActor
    {
        public ChildActor() { }
    }
}
