Management are starting to apply Darwinian principles to the Remote Control Car project (TODO cross-ref-tba). The developers have been split into two teams, _Red_ and _Blue_, and are tasked with improving the design independently of each other. They don't need to concern themselves with design decisions of the other team.

You have been asked to take a look at the code and see how you can best combine the two efforts for testing purposes.

## 1. Find a more appropriate way of isolating the code of the two teams

Please use `namespaces` to better express the intention of the code.

Currently, important types like `Motor` and `Telemetry`, not to mention `RemoteControlCar` itself, are nested within an enclosing static class, `<Color>RemoteControlCarTeam`. The only purpose of the enclosing class is to allow types with the same name to coexist in the program. That is better expressed by using a namespace. You will see in the next exercise that, for these purposes, a `namespace` has advantages over a `static class`.

## 2. Simplify the naming system

Whilst management are adamant that the teams should be called `RedRemoteControlCarTeam` and `BlueRemoteControlCarTeam` in the definitions, the names are rather cumbersome when referencing the teams. Find a way to use the shorter identifiers `Red` and `Blue` when building the cars.
