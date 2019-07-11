## Exceptions

In software sometimes things don't go as planned. Maybe the database you want to read from isn't available. Maybe that list you want to add something to wasn't instantiated.

Here's simple Calculator class...

```csharp
public class Calculator
{
    public int Divide(int a, int b)
    {
        return a / b;
    }
    // ...other methods (e.g. Add(), Subtract(), Multiply())...
}
```

...let's suppose another programmer tries doing something mischievous with it, such as...

```csharp
Calculator calculator = new Calculator();
int answer = calculator.Divide(42, 0);
Console.WriteLine($"The answer is {answer}");
```

When the code is run, we'll see something like this:

```
Unhandled Exception: System.DivideByZeroException: Attempted to divide by zero.
   at Example.Calculator.Divide(Int32 a, Int32 b) in /home/tgwtg/programming/nss/Example/Program.cs:line 11
   at Example.Program.Main(String[] args) in /home/tgwtg/programming/nss/Example/Program.cs:line 20
```

Since dividing by zero is a no-no, our code has _thrown an **exception**_.

An exception is thrown when something abnormal happens in a program. You might say it happens in "exceptional circumstances".

## Try/Catch

Fortunately, C# gives us a tool for handling exceptions. We can `try` code that might throw an exception and `catch` an exception that is thrown.

We could rewrite the code above to `try` calling `Divide()` and `catch` the exception.

```csharp
try
{
    Calculator calculator = new Calculator();
    int answer = calculator.Divide(42, 0);
    Console.WriteLine($"The answer is {answer}");
}
catch (DivideByZeroException ex)
{
    Console.WriteLine("Something went wrong!");
}
```

When we run this code we see this message in the Console

```
Something went wrong!
```

## Exceptions Stop Normal Program Execution

Take another look at the example above. notice the line after the call to `Divide()`

```csharp
Console.WriteLine($"The answer is {answer}");
```

This line is never executed.

Why? Because the line above it resulted in an exception. When an exception occurs, the program has moved into an "exceptional state". C# knows something has gone wrong, but it doesn't know what to do about it. It won't just keep going as if nothing bad happened because that might lead to even worse things.

So what does C# do? It stops running the code at the place where the exception occurred and starts looking for a `try/catch` block to handle the exception. If it finds a `try/catch` block, it will run the code in the `catch` block. If it doesn't, it will end the program and display an error message that describes the exception.

## Error Messages and Stacktraces

Now let's take another look at the error message we saw earlier.

```
Unhandled Exception: System.DivideByZeroException: Attempted to divide by zero.
   at Example.Calculator.Divide(Int32 a, Int32 b) in /home/tgwtg/programming/nss/Example/Program.cs:line 11
   at Example.Program.Main(String[] args) in /home/tgwtg/programming/nss/Example/Program.cs:line 20
```

You'll notice that this error gives you quite a lot of information.

The first line tells you the name of the exception, `System.DivideByZeroException`, and also gives you a brief description of the error, `Attempted to divide by zero.`

The next few lines help you find where the error occurred in your code. This is known as a _stacktrace_. The topmost line tells you the method, file and line number where the exception was thrown. In our case, it tells us the exception was thrown in the `Example.Calculator.Divide` method. The next line tells you where in your code the `Divide` method was called.

## Handle _Expected Exceptions_

An _expected exception_ is one that you can anticipate happening - it's something that you know _might_ happen.

For example the following code makes no sense.

```csharp
try
{
    List<int> intList = new List<int>();
    intList.Add(42);
}
catch (DivideByZeroException ex)
{
    Console.WriteLine("Adding to a list will never divide by zero");
}
```

The important thing to remember is that `try/catch` blocks are not band-aids to wrap around code that isn't behaving. You should only handle Exceptions that you know may happen AND that you know how to handle.
