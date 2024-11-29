namespace Contracts
{
    public abstract class ApplianceBase
    {
        public abstract string GetStatus();
        public abstract void ChangeStatus();
        public abstract string GetName();
        public abstract void SetName(string name);
    }
}

