namespace MvcApplication2.Models
{
    public class ConnectionInformation : IConnectionInformation
    {
        public string ConnectString
        {
            get { return @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\projects\MvcApplication2\MvcApplication2\App_Data\Data.mdf;Integrated Security=True;User Instance=True"; }
        }
    }
}