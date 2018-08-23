using Akka.Actor;
using Akka.Event;

namespace Tutorial.Akka05.LogExample
{
    public class ActorThatLogs : ReceiveActor
    {
        public ActorThatLogs()
        {
            Receive<string>(m => OnReceiveMessage(m));
        }

        // Akka.net has a built-in logging feature
        private readonly ILoggingAdapter _log = Logging.GetLogger(Context);

        private void OnReceiveMessage(string m)
        {
            _log.Info($"{Self.Path.Name} received a message of '{m}'");
        }

    }
}
