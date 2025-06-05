namespace FinalProject
{
    public abstract class IdentifierFactory { public abstract Identifier CreateIdentifier(string input); }

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
}