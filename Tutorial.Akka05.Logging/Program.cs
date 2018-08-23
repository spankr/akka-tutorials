using Akka.Actor;
using System;
using System.Threading;

namespace Tutorial.Akka05.LogExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Begin.");

            // Step 1. Create the actor system
            var actorSystem = ActorSystem.Create("MySystem");

            // Step 2. Add a named actor to the system
            var actorThatLogs = actorSystem.ActorOf(Props.Create(() => new ActorThatLogs()));

            // Step 3. Send a message to our actor (e.g. a name)
            actorThatLogs.Tell("Leroy Jenkins");

            Thread.Sleep(1000); // a delay to see our console output
            Console.WriteLine("Enter a key to exit");
            Console.ReadKey();

            // Step X. Shutdown the actor system gracefully
            //         Terminate is async so we wait for it to finish
            actorSystem.Terminate().Wait();
        }
    }
}
