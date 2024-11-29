namespace Contracts
{
    public interface IApplianceServices
    {
        List<ApplianceBase> GetAppliancesFromDB();
        List<ApplianceBase> GetAppliancesFromUser();

    }
}
