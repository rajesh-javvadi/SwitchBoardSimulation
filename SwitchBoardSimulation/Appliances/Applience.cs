
using Concerns;
using Contracts;

namespace SwitchBoardSimulation
{
    public class Applience : ApplianceBase
    {
        private string _name;
        public bool status;
        public Applience()
        {
            _name = "";
            status = false;
        }
        public override string GetStatus()
        {
            return status ? Constants.onStatus : Constants.offStatus;
        }
        public override void ChangeStatus()
        {
            status = !status;
        }
        public override string GetName()
        {
            return _name;
        }
        public override void SetName(string name)
        {
            this._name = name;
        }

        public override string ToString()
        {
            return $"{_name} {GetStatus()}";
        }

    }
}