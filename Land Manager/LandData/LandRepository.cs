using LandData.Repositories;
using LandData.Repositories.Interfaces;
using LandModels.Interfaces;
using System;
using System.Data.SQLite;
using System.IO;

namespace LandData
{
    public class LandRepository : GenericRepository, IRepository<IPlot>
    {
        public LandRepository()
            :this (new SQLiteConnection())
        {
        }

        public LandRepository(SQLiteConnection connection)
            : base(connection)
        {
        }

        public void Add(IPlot plot)
        {
            try
            {
                using (base.connection)
                {
                    using (base.query)
                    {
                        base.connection.Open();

                        base.query.CommandText = @"INSERT INTO Plots (
[District], [Area], [TotalPrice], [PricePerDecare], [PurchaseDate], [Leaseholder]) 
VALUES (@Territory, @LandArea, @TotalPrice, @PricePerDecare, @PurchaseDate, @Leaseholder)";

                        base.query.Parameters.Add(new SQLiteParameter("@District") { Value = plot.District });
                        base.query.Parameters.Add(new SQLiteParameter("@Area") { Value = plot.Area });
                        base.query.Parameters.Add(new SQLiteParameter("@TotalPrice") { Value = plot.TotalPrice });
                        base.query.Parameters.Add(new SQLiteParameter("@PricePerDecare") { Value = plot.PricePerDecare });
                        base.query.Parameters.Add(new SQLiteParameter("@PurchaseDate") { Value = plot.PurchaseDate });
                        base.query.Parameters.Add(new SQLiteParameter("@Leaseholder") { Value = plot.Leaseholder.Name });
                        
                        base.query.ExecuteNonQuery();
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
