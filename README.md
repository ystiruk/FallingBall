# FallingBall

### Game goal is to keep the ball on the randomly rotating plane using keyboard.

### What's inside?

Game UI is made with ```Unity3D```, all scripts are written in ```C#```.

A small ```python``` server generates random numbers - angles the plane is rotating by.

Server and game communicate via sockets. Socket client is a C# .dll, used in Unity3D as an external library.
