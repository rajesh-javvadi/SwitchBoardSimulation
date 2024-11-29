using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using Concerns;
using DataAccessLayer;
using SwitchBoardSimulation;

namespace SwitchBoardSimulation
{
    public class DisplaySwitchBoard
    {
        private List<ApplianceBase> appliances;

        private ApplianceServices repoServices;
        public DisplaySwitchBoard()
        {
            repoServices = new ApplianceServices();
            appliances = repoServices.GetAppliancesFromDB();
        }

        public void SimulateSwitch()
        {
            if (appliances.Count == 0)
            {
                appliances = repoServices.GetAppliancesFromUser();
            }
            else
            {

                Console.WriteLine(Constants.loadFromDB);
                Console.WriteLine(Constants.confirmLoadFromDB);
                Console.WriteLine(Constants.confirmNewSwitchBoard);
                int option = Convert.ToInt32(Console.ReadLine());

                while(true)
                {
                    try
                    {
                        
                        if (option == (int)SelectableOption.DBOption)
                        {
                            appliances = repoServices.GetAppliancesFromDB();
                            break;
                        }
                        else if(option == (int)SelectableOption.NewSwitchBoard)
                        {
                            break;
                        }
                        else
                        {
                            throw new OptionNumberOutOfRange();
                        }
                    }
                    catch
                    {
                        Console.WriteLine(Constants.optionNumberOutofRange);
                        option = Convert.ToInt32(Console.ReadLine());
                    }
                }

                if (option == 2)
                {
                    appliances = repoServices.GetAppliancesFromUser();
                }
                DisplayMenu();
                SwitchOperations();
            }
        }
        void DisplayMenu()
        {
            Console.WriteLine(Constants.switchMenu);
            for (int i = 0; i < appliances.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {appliances[i]}");
            }
        }

        void SwitchOperations()
        {
            do
            {
                Console.WriteLine();
                Console.WriteLine(Constants.enterSwitchNumber);
                Console.WriteLine(Constants.exitString);
                int switchNumber;
                ValidateSwitch(out switchNumber);
                if (switchNumber == -1) break;
                string status = appliances[switchNumber - 1].GetStatus() == Constants.onStatus ? Constants.offStatus : Constants.onStatus;
                Console.WriteLine(Constants.optionOn + appliances[switchNumber - 1].GetName() + " " + switchNumber + " " + status);
                Console.WriteLine(Constants.backOption);
                SelectSwitch(switchNumber);
                DisplayMenu();

            } while (true);
        }
        void ValidateSwitch(out int switchNumber)
        {
            while (true)
            {
                try
                {
                    switchNumber = Convert.ToInt32(Console.ReadLine());
                    if (switchNumber == -1) return;
                    if (switchNumber > appliances.Count || switchNumber < 0)
                    {
                        throw new OptionNumberOutOfRange();
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine(Constants.formatExceptionMessage);
                }
                catch (OptionNumberOutOfRange str)
                {
                    Console.WriteLine(str.Message);
                }
            }
        }
        void SelectSwitch(int switchNumber)
        {
            while (true)
            {
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    if (choice > 2)
                    {
                        throw new OptionNumberOutOfRange();
                    }
                    if (choice == 1)
                    {
                        appliances[switchNumber - 1].ChangeStatus();
                        ApplianceOperations.UpdateStatusById(appliances[switchNumber - 1].GetStatus(), switchNumber);
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine(Constants.formatExceptionMessage);
                }
                catch (OptionNumberOutOfRange str)
                {
                    Console.WriteLine(str.Message);
                }
            }
        }
    }
}
