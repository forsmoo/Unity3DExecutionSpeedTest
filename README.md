# Unity3DExecutionSpeedTest
A simple speed test for unity3d c# method invocations

I thought it would be interesting to see how expensive method calls are in comparison to eachother so here’s a profiler session comparing a few different ways to call methods. I’m still using 5.4.0f3 though, so I’m not sure how this compares to newer versions.

Test cases
*Invoke a method with integer input, increase it and return the result
*Invoke a method with two referenced types and read from one of them and update the other with that value. Return a bool
*Invoke a method with a value type as input and return a struct value type from the input

Interestingly the struct method is slower than the referenced type. I was under the assumption it would push args to the stack and avoid the heap and making it faster.

The different implementations that can be seen in the profiler session:
* ReflectedMethodInvoker
  * This one would obviously be slower than any others. In addition it will engage the GC.
* FuncMethodInvoker
  * Using Func<> pointer
* VirtualMethodInvoker
  * Uses an abstract class implementation
* InterfaceMethodInvoker
  * Simply uses a method from an interface
* UnsealedClassMethodInvoker
  * A simple class
* SealedClassMethodInvoker
  * Same as virtual method invoker but sealed
* ReflectedClassMethodInvoker
  * This is simple class reflected type and instantiated by Activation.
* StaticMethodClassInvoker
  * Methods are implemented in a static class
* InlineMethodInvoker - This one has inlined 
  * This is implemented manually inline since there is no inline keyword in c#

When profiling in the editor you can’t see much difference between the implementations, except for the reflection and inline method. So in order to test it you have to build it and attach the profiler. I went from 5000 iterations each update to 100 000 to get about the same execution time of 0.05ms in the inline case. I don’t know if this is the new awesome IL2CPP kicking in, or just compilator optimizations.
