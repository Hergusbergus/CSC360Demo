using System;

namespace FinalProject
{
    public abstract class IdentifierDecorator(Identifier identifier) : Identifier(identifier.PlanetName)
    {
        protected Identifier _innerIdentifier = identifier;

        public override string GetResponse() { return _innerIdentifier.GetResponse(); }
    }

    public class TimestampDecorator(Identifier identifier) : IdentifierDecorator(identifier)
    {
        public override string GetResponse()
        {
            var response = base.GetResponse();
            return $"[{DateTime.Now:HH:mm:ss}] {response}";
        }
    }

    public class BorderDecorator(Identifier identifier) : IdentifierDecorator(identifier)
    {
        public override string GetResponse()
        {
            var response = base.GetResponse();
            var border = new string('*', response.Length + 4);
            return $"{border}\n* {response} *\n{border}";
        }
    }
}