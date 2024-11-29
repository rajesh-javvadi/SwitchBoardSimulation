
using Concerns;

namespace SwitchBoardSimulation
{
    public class Fan : Applience
    {
        public Fan()
        {
            SetName(Constants.fan);
        }
        public override void SetName(string name)
        {
            base.SetName(name);
        }
    }
}