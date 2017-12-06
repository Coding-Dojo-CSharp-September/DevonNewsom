using Dapper;
using MySql.Data.MySqlClient;
using LectureDapper.Models;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace LectureDapper.Models
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
            get { return new MySqlConnection(connectionString); }
        }

        public List<Artist> GetAllArtists()
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Artist>("SELECT * FROM artists").ToList();
            }
        }

        public Artist GetArtistById(int artist_id)
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                string query = "SELECT * FROM artists WHERE id = @ID";
                return dbConnection.Query<Artist>(query, new {ID=artist_id}).SingleOrDefault();
            }
        }

        public void CreateArtist(Artist artist)
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();

                string query = "INSERT INTO artists (name) VALUES (@name)";

                dbConnection.Execute(query, artist);
            }
        }

        public bool ArtistNameIsUnique(string artistName)
        {
            using(IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();

                string query = "SELECT id FROM artists WHERE name = @Name";
                List<Artist> artists = dbConnection.Query<Artist>(query, new {Name=artistName}).ToList();
                return artists.Count() < 1;
            }
        }
    }
}