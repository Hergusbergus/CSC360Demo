using System;
using FinalProject;

class Program
{
    static void Main()
    {
        // Create observers
        var logger = new LoggingObserver();
        var welcomer = new WelcomeObserver();

        Console.WriteLine("Please identify yourself.");
        var userInput = Console.ReadLine() ?? "";
        
        // Using the factory to create the appropriate identifier
        var factory = new PlanetIdentifierFactory();
        var identifier = factory.CreateIdentifier(userInput);
        
        // Attach observers
        identifier.Attach(logger);
        identifier.Attach(welcomer);
        
        // Decorate the identifier (add timestamp and border)
        var decoratedIdentifier = new BorderDecorator(new TimestampDecorator(identifier));
        
        // Process identification (this will notify observers)
        Console.WriteLine(decoratedIdentifier.ProcessIdentification());
    }
}