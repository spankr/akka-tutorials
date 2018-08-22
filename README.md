# Actor Examples using Akka.NET

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

## Logging

  TBD

## Asking Messages

  TBD

## Forwarding Messages

  TBD

## ActorSelection

  TBD

[1]: https://github.com/akkadotnet/akka.net/issues/1532 "Termination"
[2]: https://petabridge.com/blog/how-to-unit-test-akkadotnet-actors-akka-testkit/ "Unit Testing with TestKit"
[3]: https://petabridge.com/blog/how-actors-recover-from-failure-hierarchy-and-supervision/ "Actor Hierarchy and Supervision"
[4]: https://getakka.net/api/Akka.Dispatch.SysMsg.Watch.html "Watching actors"
[persistence]: https://getakka.net/articles/persistence/architecture.html
[Events]: https://getakka.net/articles/persistence/event-sourcing.html
[Snapshots]: https://getakka.net/articles/persistence/snapshots.html
[xUnit]: https://xunit.github.io/ "xUnit.net Testing"