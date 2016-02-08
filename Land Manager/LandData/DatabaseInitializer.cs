using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using LandModels;

namespace LandData
{
    public class DatabaseInitializer
    {
        private SQLiteConnection connection;
        private SQLiteCommand query;

        public DatabaseInitializer()
        {
            this.connection = new SQLiteConnection("data source=Land.sqlite");
            this.query = new SQLiteCommand(connection);
        }

        public ICollection<Leaseholder> LoadLeaseholders()
        {
            var leaseholders = new List<Leaseholder>();

            try
            {
                using (this.connection)
                {
                    this.connection.Open();

                    using (this.query = this.connection.CreateCommand())
                    {
                        this.query.CommandText = "SELECT Id, Name FROM Leaseholders";

                        SQLiteDataReader reader = this.query.ExecuteReader();
                        while (reader.Read())
                        {
                            leaseholders.Add(new Leaseholder()
                            {                                
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = Convert.ToString(reader["Name"])
                            });
                        }
                    }
                }
            }
            catch (Exception e)
            {

            }

            return leaseholders;
        }
    }
}
