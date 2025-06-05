using System;
using System.Collections.Generic;

namespace FinalProject
{
    public abstract class Identifier(string planet) : IIdentificationSubject
    {
        private readonly List<IIdentificationObserver> _observers = [];
        protected string _planet = planet;

        public string PlanetName => _planet;

        public abstract string GetResponse();

        public void Attach(IIdentificationObserver observer) { _observers.Add(observer); }

        public void Detach(IIdentificationObserver observer) { _observers.Remove(observer); }

        public void NotifyObservers(string planet, string response) { foreach (var observer in _observers) observer.OnIdentification(planet, response); }

        public string ProcessIdentification()
        {
            var response = GetResponse();
            NotifyObservers(_planet, response);
            return response;
        }
    }

    public class EarthIdentifier : Identifier
    {
        public EarthIdentifier() : base("earth") { }

        public override string GetResponse() { return "Hello, World!"; }
    }

    public class MarsIdentifier : Identifier
    {
        public MarsIdentifier() : base("mars") { }

        public override string GetResponse() { return "Welcome, Martian!"; }
    }

    public class UnknownIdentifier : Identifier
    {
        public UnknownIdentifier() : base("unknown") { }

        public override string GetResponse() { return "Buzz off!"; }
    }
}