namespace SwitchBoardSimulation
{
    public static class NewInputAppliance // Extension method here
    {
        public static int GetTotalAppliances(this InputAppliances inputAppliance)
        {
            return inputAppliance.numberOfACs + inputAppliance.numberOfBulbs + inputAppliance.numberOfFans;
        }
    }
}