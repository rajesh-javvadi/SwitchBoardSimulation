using Concerns;
namespace SwitchBoardSimulation
{
    public sealed class InputAppliances 
    {
        public int numberOfFans;
        public int numberOfBulbs;
        public int numberOfACs;

        public InputAppliances()
        {
            numberOfFans = GetInput(0, Constants.enterInputFans);
            numberOfACs = GetInput(0, Constants.enterInputACs);
            numberOfBulbs = GetInput(0, Constants.enterInputBulbs);
        }

        public int GetInput(int input, string message)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine(message);
                    input = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine(Constants.formatExceptionMessage);
                }
            }
            return input;
        }

    }
}