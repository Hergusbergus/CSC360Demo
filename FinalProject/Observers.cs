using System;

namespace FinalProject
{
    public interface IIdentificationObserver { void OnIdentification(string planet, string response); }

    public class LoggingObserver : IIdentificationObserver { public void OnIdentification(string planet, string response) { Console.WriteLine($"[LOG] Identification attempt: {planet} -> {response}"); } }

    public class WelcomeObserver : IIdentificationObserver { public void OnIdentification(string planet, string response) { if (planet.Equals("earth", StringComparison.CurrentCultureIgnoreCase) || planet.Equals("mars", StringComparison.CurrentCultureIgnoreCase)) Console.WriteLine("Welcome to our cosmic identification system!"); } }
}