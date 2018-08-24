# Actor Examples using Akka.NET

These examples are intended to be "empirical" examples of some of the logic in the [actor pattern], 
using the Akka.NET open-source library. 
If you are new to Akka.NET and the actor system, I strongly recommend:

 * The [Akka.Net Bootcamp][bootcamp] by Petabridge.
 * The [Official Akka.NET Professional Code Samples][samples].
 
Petabridge is the team that created (and maintain!) all of the akka.NET libraries. They can also be found on [Akka.NET Gitter][gitter] where they help support the community.

## Tutorial.Akka01.SimpleActor

> Provides a minimalist actor system as a 'Hello World' announcement.
  * Actor system creation
  * Actor creation
  * Sending messages to actors using ```Tell()```
  * [Actor system termination][1]

## Tutorial.Akka02.TestingActors

> Provides a minimal example of [testing an actor][2] for message handling and response.
  * Basic request-response actor model
  * Example of expecting no response
  * [xUnit]

## Tutorial.Akka03.Children

> Minimal example of actors and the parent-child relationship.
  * More reading: [Actor Hierarchy][3]

## Tutorial.Akka04.Persistence

> Example actors with tests that demonstrate the basics of actor [persistence].
  * [Events]
  * [Snapshots]
  * New: [Watching][4] for actor termination

## Tutorial.Akka05.LogExample

> Example of creating a logger within an actor and using it.
  * **NOTE:** Default log level within the actor system is **Info**. Configuration is required to display debug level logs.

## Tutorial.Akka06.AskingMessages

> Test cases demonstrating the difference between ```Ask()``` and ```Tell()```.

## Tutorial.Akka07.ForwardingMessages

> Demonstrate ```Forward()``` and how it preserves the original **Sender** on the message, making
router actors effectively "invisible" in the flow of the message.
  * New: [ReceiveAny]
  * New: [TestActor]
  * New: ExpectMsgFrom

## ActorSelection

  TBD

[1]: https://github.com/akkadotnet/akka.net/issues/1532 "Termination"
[2]: https://petabridge.com/blog/how-to-unit-test-akkadotnet-actors-akka-testkit/ "Unit Testing with TestKit"
[3]: https://petabridge.com/blog/how-actors-recover-from-failure-hierarchy-and-supervision/ "Actor Hierarchy and Supervision"
[4]: https://getakka.net/api/Akka.Dispatch.SysMsg.Watch.html "Watching actors"
[TestActor]: https://petabridge.com/blog/how-to-unit-test-akkadotnet-actors-akka-testkit/#the-testactor "The TestActor"
[ReceiveAny]: https://getakka.net/articles/actors/receive-actor-api.html#receiveany "ReceiveAny Documentation"
[actor pattern]: https://en.wikipedia.org/wiki/Actor_model "Actor Pattern on Wikipedia"
[bootcamp]: https://petabridge.com/bootcamp/ "Akka.NET Bootcamp by Petabridge"
[samples]: https://github.com/petabridge/akkadotnet-code-samples "Akka.NET Professional Code Samples"
[gitter]: https://gitter.im/akkadotnet/akka.net "akkadotnet on Gitter"
[persistence]: https://getakka.net/articles/persistence/architecture.html
[Events]: https://getakka.net/articles/persistence/event-sourcing.html
[Snapshots]: https://getakka.net/articles/persistence/snapshots.html
[xUnit]: https://xunit.github.io/ "xUnit.net Testing"