using Akka.Actor;
using System;
using System.Threading;

namespace Tutorial.Akka01.SimpleActor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Begin.");

            // Step 1. Create the actor system
            var actorSystem = ActorSystem.Create("MySystem");
            Console.WriteLine($"Actor System '{actorSystem.Name}' created.");

            // Step 2. Add a named actor to the system
            var helloWorldActor = actorSystem.ActorOf(Props.Create(() => new HelloWorldActor()), "hello-world-actor");
            Console.WriteLine($"Actor '{helloWorldActor.Path.Name}' created.");

            // Step 3. Send a message to our actor (e.g. a name)
            Console.WriteLine("Sending message to actor.");
            helloWorldActor.Tell("Leroy Jenkins");

            Thread.Sleep(1000); // a delay to see our console output
            Console.WriteLine("Enter a key to exit");
            Console.ReadKey();

            // Step X. Shutdown the actor system gracefully
            //         Terminate is async so we wait for it to finish
            actorSystem.Terminate().Wait();

        }
    }
}
