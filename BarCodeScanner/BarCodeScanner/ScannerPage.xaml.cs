using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;

namespace BarCodeScanner
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScannerPage : ContentPage
    {
        public ScannerPage()
        {
            InitializeComponent();
        }


        private async void ZXingScannerView_OnOnScanResult(Result result)
        {

            // Stop analysis until we navigate away so we don't keep reading barcodes
            zxing.IsAnalyzing = false;

            // Show an alert
            await DisplayAlert("Scanned Barcode", result.Text, "OK");

            // Navigate away
            await Navigation.PopAsync();
        }

        private void Overlay_OnFlashButtonClicked(Button sender, EventArgs e)
        {
            zxing.IsTorchOn = !zxing.IsTorchOn;

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            zxing.IsScanning = true;
        }

        protected override void OnDisappearing()
        {
            zxing.IsScanning = false;

            base.OnDisappearing();
        }

    }
}