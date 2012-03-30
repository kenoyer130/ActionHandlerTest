namespace MvcDataAccess
{
    public class ConnectionInformation : IConnectionInformation
    {
        public string ConnectString
        {
            get { return @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\projects\MvcApplication2\mvc4\MvcWeb\App_Data\Data.mdf;Integrated Security=True;User Instance=True"; }
        }
    }
}