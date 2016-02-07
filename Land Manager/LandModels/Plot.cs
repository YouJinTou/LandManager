using LandModels.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LandModels
{
    public class Plot
    {
        private int id;
        private string district;
        private double area;
        private decimal totalPrice;
        private decimal pricePerDecare;
        private DateTime purchaseDate;
        private ICollection<Annuity> annuities;
        private int leaseholderId;
        private IHolder leaseholder;

        public Plot(string district, double area, decimal totalPrice,
            decimal pricePerDecare, DateTime purchaseDate,
            IHolder leaseholder, int leaseholderId)
        {
            this.district = district;
            this.area = area;
            this.totalPrice = totalPrice;
            this.pricePerDecare = pricePerDecare;
            this.purchaseDate = purchaseDate;
            this.annuities = new SortedSet<Annuity>();
            this.leaseholder = leaseholder;
            this.leaseholderId = leaseholderId;
        }

        #region Properties
        [Key]
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

        [Required]
        [MinLength(2)]
        public string District
        {
            get { return this.district; }
            set { this.district = value; }
        }

        [Required]
        [Range(1, double.MaxValue)]
        public double Area
        {
            get { return this.area; }
            set { this.area = value; }
        }

        [Required]
        [Range(1, double.MaxValue)]
        public decimal TotalPrice
        {
            get { return this.totalPrice; }
            set { this.totalPrice = value; }
        }

        [Required]
        [Range(1, double.MaxValue)]
        public decimal PricePerDecare
        {
            get { return this.pricePerDecare; }
            set { this.pricePerDecare = value; }
        }

        [Required]
        public DateTime PurchaseDate
        {
            get { return this.purchaseDate; }
            set { this.purchaseDate = value; }
        }

        public virtual ICollection<Annuity> Annuities
        {
            get { return this.annuities; }
            set { this.annuities = value; }
        }

        [Required]
        [Range(1, int.MaxValue)]
        public int LeaseholderId
        {
            get { return this.leaseholderId; }
            set { this.leaseholderId = value; }
        }

        public virtual IHolder Leaseholder
        {
            get { return this.leaseholder; }
            set { this.leaseholder = value; }
        }
        #endregion
    }
}
