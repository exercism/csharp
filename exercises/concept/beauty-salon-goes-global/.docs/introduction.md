The concept of _time_ is dealt with in .NET using the `DateTime` struct. There are routines to convert between local time and UTC. Arithmetic can be performed with the help of `TimeSpan`.

The `TimeZoneInfo` class provides routines for handling the differences between time zones. The `TimeZoneInfo` class also contains methods that facilitate dealing with daylight saving time.

The `CultureInfo` class supports locale dependent date time formats.

To support cross-platform coding the `RuntimeInformation` class allows you to detect which operating system your code is executing on, Linux, Windows or OSX.
