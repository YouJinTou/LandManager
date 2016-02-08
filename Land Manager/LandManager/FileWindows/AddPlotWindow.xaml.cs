using LandData;
using LandData.Interfaces;
using LandModels;
using LandModels.Interfaces;
using System;
using System.Windows;

namespace LandManager.FileWindows
{
    public partial class AddPlotWindow : Window
    {
        private DatabaseInitializer dbInit;
        private IRepository repo;
        private IPlot plot;

        public AddPlotWindow()
        {
            InitializeComponent();

            this.dbInit = new DatabaseInitializer();
            this.repo = new LandRepository();
            this.plot = new Plot();

            PopulateFormFields();
        }

        private void PopulateFormFields()
        {
            addPurchaseDateDatePicker.SelectedDate = DateTime.Today;
            addAnnuitiyYearIntUpDown.Value = DateTime.Now.Year;

            var leaseholders = this.dbInit.LoadLeaseholders();

            foreach (var leaseholder in leaseholders)
            {
                addLeaseholderComboBox.Items.Add(leaseholder);
            }
        }

        private void addPlotSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            this.plot.District = addDistrictTextBox.Text;
            this.plot.Area = double.Parse(addAreaTextBox.Text);
            this.plot.TotalPrice = decimal.Parse(addTotalPriceTextBox.Text);
            this.plot.PricePerDecare = decimal.Parse(addPricePerDecareTextBox.Text);
            this.plot.PurchaseDate = DateTime.ParseExact(addPurchaseDateDatePicker.Text, "yyy-MM-dd", null);
            this.plot.Leaseholder = new Leaseholder() { Name = addLeaseholderComboBox.Text };

            this.repo.AddPlot(this.plot);

            this.Close();
        }

        private void addAnnuityButton_Click(object sender, RoutedEventArgs e)
        {
            var annuity = new Annuity()
            {
                Year = addAnnuitiyYearIntUpDown.Value.ToString(),
                Amount = decimal.Parse(addAnnuityAmountTextBox.Text)
            };

            this.plot.Annuities.Add(annuity);

            addAnnuitiyYearIntUpDown.Value--;
            addAnnuityAmountTextBox.Clear();
        }
    }
}
