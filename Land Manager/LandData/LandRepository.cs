using LandData.Interfaces;
using LandModels.Interfaces;
using System;
using System.Data.SQLite;
using System.IO;

namespace LandData
{
    public class LandRepository : IRepository
    {
        private SQLiteConnection connection;
        private SQLiteCommand query;

        public LandRepository()
        {
            this.connection = new SQLiteConnection("data source=Land.sqlite");
            this.query = new SQLiteCommand(connection);
        }

        public void AddPlot(IPlot plot)
        {
            try
            {
                using (this.connection)
                {
                    using (this.query)
                    {
                        this.connection.Open();

                        this.query.CommandText = @"INSERT INTO Plots (
[District], [Area], [TotalPrice], [PricePerDecare], [PurchaseDate], [Leaseholder]) 
VALUES (@Territory, @LandArea, @TotalPrice, @PricePerDecare, @PurchaseDate, @Leaseholder)";

                        this.query.Parameters.Add(new SQLiteParameter("@District") { Value = plot.District });
                        this.query.Parameters.Add(new SQLiteParameter("@Area") { Value = plot.Area });
                        this.query.Parameters.Add(new SQLiteParameter("@TotalPrice") { Value = plot.TotalPrice });
                        this.query.Parameters.Add(new SQLiteParameter("@PricePerDecare") { Value = plot.PricePerDecare });
                        this.query.Parameters.Add(new SQLiteParameter("@PurchaseDate") { Value = plot.PurchaseDate });
                        this.query.Parameters.Add(new SQLiteParameter("@Leaseholder") { Value = plot.Leaseholder.Name });

                        this.query.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                StreamWriter sw = new StreamWriter("log.txt");

                sw.Write(e);
            }
        }
    }
}
