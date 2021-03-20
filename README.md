# .NETPriorityQueue
 A custom priority queue implementation using a binary heap in C#. Written for a personal/club project. It (as far as I know) conforms to most .NET standards. Not thread-safe.

## Information
This code was converted from a java project into something that takes advantage of C#'s feature set and that is more architecturally sound. 
While the original java code was extensively tested for correctness, I have not (yet!) written a comprehensive test suite for this code. All of the algorithms and the logic behind them should be perfectly correct, however.  

## How to Use
Simply download or fork this repository and add `PriorityQueue.cs` to your project's solution. For Unity users, copy `PriorityQueue.cs` into the unity project's `Assets` folder. Usage instructions can be found in the code's documentation comments.

## Justification
For a Unity game project of mine, one of the algorithms I wanted to implement required the use of a priority queue; however, .NET does not provide a default implementation of one. The result is my very own attempt at writing an efficient, feature-complete, generic, and .NET compliant PriorityQueue<T> using C#. It's certainly not perfect, but I intend to improve it with time.
