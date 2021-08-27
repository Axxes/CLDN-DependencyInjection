# Dependency injection: Exercises

## Exercise 1

A console application using .NET Framework 4.8 is given. 

1. Split the core logic found in the 'Classes' folder from the current project into a shareable project.
2. Consume the core logic in the existing .NET Full Framework 
3. Consume the core logic in a seperate .NET Core project.
4. Add an abstraction layer for the core logic
5. Switch to dependency injection (Autofac or Microsoft DI)
6. Write unit tests
6.1. Make sure `Notifier.Email` is called with the correct arguments

## Exercise 2

A console application using .NET 5.0 is given.  Check the `DI.Exercises.2.Tests` class to inject your dependencies.
**Note**: FeedbackProcessor = Singleton, Notifier = Transient, FakeDatabase = Scoped

1. Create a hosted service called `FeedbackProcessor` , inheriting from `IFeedbackProcessor`
2. Create a new collection to which you can add `DI.Exercises.Shared.Models.Feedback`
3. Wait for three items to be added to the collection
4. Created a new `INotifier` for each item
5. Pass each item into its own Notifier
6. Make sure the `FeedbackProcessorTests.AssertNotifyCalledThreeTimesPerBatch` test works.
7. Implement FakeDatabase
8. A static concurrent list should suffise to store `Feedback`
9. Every `INotifier` has to pass on it's `Feedback` item to the `FakeDatabase` class. 

Write tests to:
1. Make sure `Feedback` is properly passed on to `FakeDatabase` from `Notifier`
2. Test the whole flow from Adding items to the Queue => Reading from the database

If done, extend the exercise by allowing the `FeedbackProcessor` to handle `DI.Exercises.Shared.Models.CheckIn` 

## Exercise 3

Free to fill in. Make a pluggable application, injecting multiple `IPlugin`'s, handling specific sets of data, using Autofac or custom reflection?