using System;

// Abstract product
public abstract class Identifier
{
    public abstract string GetResponse();
}

// Concrete products
public class EarthIdentifier : Identifier
{
    public override string GetResponse()
    {
        return "Hello, World!";
    }
}

public class MarsIdentifier : Identifier
{
    public override string GetResponse()
    {
        return "Welcome, Martian!";
    }
}

public class UnknownIdentifier : Identifier
{
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
        Console.WriteLine("Please identify yourself.");
        string userInput = Console.ReadLine();
        
        // Using the factory to create the appropriate identifier
        IdentifierFactory factory = new PlanetIdentifierFactory();
        Identifier identifier = factory.CreateIdentifier(userInput);
        
        Console.WriteLine(identifier.GetResponse());
    }
}