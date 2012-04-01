using System.Configuration;
namespace MvcDataAccess
{
    public class ConnectionInformation : IConnectionInformation
    {
        public string ConnectString
        {
            get { return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; }
        }
    }
}