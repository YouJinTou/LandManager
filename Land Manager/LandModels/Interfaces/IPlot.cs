using System;
using System.Collections.Generic;

namespace LandModels.Interfaces
{
    public interface IPlot
    {
        string District { get; set; }
        double Area { get; set; }
        decimal TotalPrice { get; set; }
        decimal PricePerDecare { get; set; }
        DateTime PurchaseDate { get; set; }
        ICollection<Annuity> Annuities { get; set; }
        int LeaseholderId { get; set; }
        IHolder Leaseholder { get; set; }
    }
}
