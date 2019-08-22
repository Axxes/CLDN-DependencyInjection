# Dependency injection: Exercises

## Exercise 1

A console application using .NET Framework 4.8 is given. 

1. Split the core logic found in the 'Classes' folder from the current project into a shareable project.
2. Consume the core logic in the existing .NET Full Framework 
3. Consume the core logic in a seperate .NET Core project.
4. Add an abstraction layer for the core logic
5. Switch to dependency injection (Autofac or Microsoft DI)
6. Write unit tests
6.1. Make sure CheckInProcessor.CheckIn is called with the correct object
6.2. Make sure Notifier.Email is called with the correct arguments

## Exercise 2

A console application using .NET Core 2.2 is given.  Check the `DI.Exercises.2.Tests` class to inject your dependencies.

1. Create a hosted service called `FeedbackProcessor` , inheriting from `IFeedbackProcessor`
1.1. Create a new collection to which you can add `DI.Exercises.Shared.Models.Feedback`
1.2. Wait for three items to be added to the collection
1.3. Created a new `INotifier` for each item
1.4. Pass each item into its own Notifier

Write tests to:
1. Make sure 
