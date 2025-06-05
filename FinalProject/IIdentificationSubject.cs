namespace FinalProject
{
    public interface IIdentificationSubject
    {
        void Attach(IIdentificationObserver observer);
        void Detach(IIdentificationObserver observer);
        void NotifyObservers(string planet, string response);
    }
}