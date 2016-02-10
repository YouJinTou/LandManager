using System.Data.SQLite;

namespace LandData.Repositories
{
    public class GenericRepository
    {
        protected readonly SQLiteConnection connection;
        protected readonly SQLiteCommand query;

        public GenericRepository(SQLiteConnection connection)
        {
            this.connection = new SQLiteConnection("data source=Land.sqlite");
            this.query = new SQLiteCommand(connection);
        }
    }
}
