using DataAccessLayer;
using Microsoft.Data.SqlClient;
using Concerns;
using Contracts;

namespace SwitchBoardSimulation
{
    class Program
    {
        static void Main()
        {

            DisplaySwitchBoard applianceServices = new DisplaySwitchBoard();

            applianceServices.SimulateSwitch();
        }
    }
}