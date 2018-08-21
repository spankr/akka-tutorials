using Akka.Actor;
using System;

namespace Tutorial.Akka01.SimpleActor
{
    public class HelloWorldActor : ReceiveActor
    {
        public HelloWorldActor()
        {
            Receive<string>(s => OnReceiveName(s));
        }

        /// <summary>
        /// Announce a 'hello world' message to the console 
        /// </summary>
        /// <param name="name">name to use in the announcement</param>
        private void OnReceiveName(string name)
        {
            Console.WriteLine($"Hello world from {name}!");
        }
    }
}
