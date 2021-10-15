using Infra.Models;
using Newtonsoft.Json;
using System.IO;

namespace Infra.Data
{
    public class ConnectionBuilder
    {
        public static string GetConnectionString()
        {
            DatabaseConnection data = JsonConvert.DeserializeObject<DatabaseConnection>(File.ReadAllText("./Configurations/Database.json"));
            return $"Server={data.HOST};Port={data.PORT};Database={data.DB};Uid={data.USER};Pwd={data.PASSWORD};ConvertZeroDateTime=True";
        }
    }
}
