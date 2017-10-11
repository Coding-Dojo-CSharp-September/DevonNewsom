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
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=mydb;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }

        public IEnumerable<Artist> FindAll()
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Artist>("SELECT * FROM artists");
            }
        }

        public void Add(Artist artist)
        {
            using(IDbConnection dbConnection = Connection)
            {

                string query = "INSERT INTO artists (name) VALUES (@Name)";
                dbConnection.Open();
                dbConnection.Execute(query, new {Name = artist.name});
            }
        }

        public Artist GetArtistById(int id)
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string query = @"SELECT * FROM artists WHERE id=@ID;
                                 SELECT * FROM albums WHERE artist_id=@ID;";
                using(SqlMapper.GridReader multi = dbConnection.QueryMultiple(query, new {ID=id}))
                {
                    Artist artist = multi.Read<Artist>().Single();
                    artist.albums = multi.Read<Album>().ToList();
                    return artist;
                }
            }
        }
    }
}