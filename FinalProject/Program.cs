using System;
using System.Collections.Generic;

// Observer interface
public interface IIdentificationObserver
{
    void OnIdentification(string planet, string response);
}

// Concrete observers
public class LoggingObserver : IIdentificationObserver
{
    public void OnIdentification(string planet, string response)
    {
        Console.WriteLine($"[LOG] Identification attempt: {planet} -> {response}");
    }
}

public class WelcomeObserver : IIdentificationObserver
{
    public void OnIdentification(string planet, string response)
    {
        if (planet.ToLower() == "earth" || planet.ToLower() == "mars")
        {
            Console.WriteLine("Welcome to our cosmic identification system!");
        }
    }
}

// Subject interface
public interface IIdentificationSubject
{
    void Attach(IIdentificationObserver observer);
    void Detach(IIdentificationObserver observer);
    void NotifyObservers(string planet, string response);
}

// Modified Identifier to include subject behavior
public abstract class Identifier : IIdentificationSubject
{
    private List<IIdentificationObserver> _observers = new List<IIdentificationObserver>();
    protected string _planet;

    public Identifier(string planet)
    {
        _planet = planet;
    }

    public abstract string GetResponse();

    public void Attach(IIdentificationObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IIdentificationObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers(string planet, string response)
    {
        foreach (var observer in _observers)
        {
            observer.OnIdentification(planet, response);
        }
    }

    public string ProcessIdentification()
    {
        string response = GetResponse();
        NotifyObservers(_planet, response);
        return response;
    }
}

// Concrete products
public class EarthIdentifier : Identifier
{
    public EarthIdentifier() : base("earth") { }

    public override string GetResponse()
    {
        return "Hello, World!";
    }
}

public class MarsIdentifier : Identifier
{
    public MarsIdentifier() : base("mars") { }

    public override string GetResponse()
    {
        return "Welcome, Martian!";
    }
}

public class UnknownIdentifier : Identifier
{
    public UnknownIdentifier() : base("unknown") { }

    public override string GetResponse()
    {
        return "Buzz off!";
    }
}

// Creator (Factory)
public abstract class IdentifierFactory
{
    public abstract Identifier CreateIdentifier(string input);
}

// Concrete creator
public class PlanetIdentifierFactory : IdentifierFactory
{
    public override Identifier CreateIdentifier(string input)
    {
        return input.ToLower() switch
        {
            "earth" => new EarthIdentifier(),
            "mars" => new MarsIdentifier(),
            _ => new UnknownIdentifier()
        };
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create observers
        var logger = new LoggingObserver();
        var welcomer = new WelcomeObserver();

        Console.WriteLine("Please identify yourself.");
        string userInput = Console.ReadLine();
        
        // Using the factory to create the appropriate identifier
        IdentifierFactory factory = new PlanetIdentifierFactory();
        Identifier identifier = factory.CreateIdentifier(userInput);
        
        // Attach observers
        identifier.Attach(logger);
        identifier.Attach(welcomer);
        
        // Process identification (this will notify observers)
        Console.WriteLine(identifier.ProcessIdentification());
    }
}