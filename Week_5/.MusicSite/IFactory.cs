using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;

namespace MusicSite.Models
{
   public class ArtistFactory
   {
       private string connectionString;
       public ArtistFactory()
       {
           connectionString = "server=localhost;userid=root;password=root;port=3306;database=dotnet;SslMode=None";
       }
       internal IDbConnection Connection
       {
           get{return new MySqlConnection(connectionString);}
       }
       public IEnumerable<Artist> FindAll()
       {
           using(IDbConnection dbConnection = Connection)
           {
               dbConnection.Open();
               return dbConnection.Query<Artist>("SELECT * FROM artists");
           }
       }
   }

}