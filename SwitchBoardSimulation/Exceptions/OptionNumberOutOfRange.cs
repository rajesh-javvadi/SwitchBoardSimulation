using Concerns;
namespace SwitchBoardSimulation
{
    public class OptionNumberOutOfRange : Exception
    {
        public override string Message
        {
            get
            {
                return Constants.optionNumberOutofRange;
            }
        }
    }
}

