namespace Concerns
{
    public class Constants
    {
        public const string enterInputFans = "Enter Number of Fans: ";
        public const string enterInputACs = "Enter Number of AC's: ";
        public const string enterInputBulbs = "Enter Number of Bulbs: ";
        public const string onStatus = "ON";
        public const string offStatus = "OFF";
        public const string enterSwitchNumber = "Enter Switch Number: ";
        public const string switchMenu = "--------------------Switch Menu------------------------";
        public const string backOption = "2. Back";
        public const string formatExceptionMessage = "Enter Integer Only : ";
        public const string optionNumberOutofRange = "Option Number should be within the range";
        public const string exitString = "Enter -1 to Exit";
        public const string bulb = "Bulb ^";
        public const string ac = "AC @";
        public const string fan = "Fan ><";

        public const string loadFromDB = "Do you want to load switch data from database ? ";

        public const string confirmLoadFromDB = "Press 1 to Confirm";

        public const string confirmNewSwitchBoard = "Press 2 to New Switch Board";

        public const string doYouWannaTryAgain = "Do you wanna try again";

        public const string closeApplication = "Close application if don't want to ?";

        public const string tryAgainConfiramation = "Press 1 to Confirm";

        public const string connectionEstablishmentFailed = "Connection Establishment to Database is Failed";

        public const string pressOneOnlyToContinue = "If you wanna continue press 1 only";

        public const string optionOn = "1. Switch ";
        public static class Query
        {
            public const string getAllAppliances = $"select * from {Table.appliances}";

            public const string truncateTable = $"truncate table {Table.appliances}";

            public const string getCount = $"select count(*) from {Table.appliances} where name = ";

        }

        public static class Table
        {
            public const string appliances = "appliances";
        }

        public static class StoredProcedures
        {
            public const string InsertIntoAppliance = "sp_InsertIntoAppliance";

            public const string UpdateByStatus = "sp_UpdateByStatus";

            public const string GetStatusById = "sp_GetStatusById";

            public const string GetCountByName = "sp_GetApplianceCount";
        }

        public static class FilePath
        {
            public const string dbPath = "C:\\PravalTech\\Developer\\OneDrive - Praval\\Tasks\\SwitchBoard\\DataAccessLayer\\DataAccessLayer\\connectionStringDB.txt";
        }

    }
}
