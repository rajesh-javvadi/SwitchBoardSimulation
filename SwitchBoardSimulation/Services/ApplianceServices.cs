using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using DataAccessLayer;
using Concerns;
namespace SwitchBoardSimulation
{
    public class ApplianceServices : IApplianceServices
    {

        private List<ApplianceBase> _appliances;
        public ApplianceServices()
        {
            _appliances = new List<ApplianceBase>();
        }

        public List<ApplianceBase> GetAppliancesFromDB()
        {
            SwitchData switchData = new SwitchData();

            initilizeAppliances(switchData.GetApplianceCount(Constants.fan), switchData.GetApplianceCount(Constants.ac), switchData.GetApplianceCount(Constants.bulb));

            for(int i=0;i<_appliances.Count;i++)
            {
                String status = ApplianceOperations.GetStatusById(i + 1);
                if (!_appliances[i].GetStatus().Equals(status))
                {
                    _appliances[i].ChangeStatus();
                }
            }

            return _appliances;
        }

        public List<ApplianceBase> GetAppliancesFromUser()
        {
            InputAppliances switchData = new InputAppliances();

            _appliances = new List<ApplianceBase>();

            initilizeAppliances(switchData.numberOfFans, switchData.numberOfACs, switchData.numberOfBulbs);

            ApplianceOperations.TruncateApplianceData();

            for(int i=0;i<_appliances.Count;i++)
            {
                ApplianceOperations.InsertAppliances(_appliances[i].GetName());
            }

            return _appliances;
        }

        void initilizeAppliances(int numberOfFans,int numberOfACs, int numberOfBulbs)
        {
            for(int i = 0;i<numberOfFans;i++)
            {
                _appliances.Add(new Fan());
            }
            for(int i=0;i<numberOfACs;i++)
            {
                _appliances.Add(new AC());
            }
            for(int i=0;i<numberOfBulbs;i++)
            {
                _appliances.Add(new  Bulb());
            }
        }

        public bool TableHasRows()
        {
            return ApplianceOperations.CheckTableHasRows();
        }

    }
}
