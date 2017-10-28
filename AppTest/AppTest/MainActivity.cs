using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Android.OS;
using AppTest.Model;
using ZXing.Mobile;

namespace AppTest
{
    [Activity(Label = "AppTest", MainLauncher = true)]
    public class MainActivity : Activity
    {
        public List<ScannedItem> scannedItems;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            MobileBarcodeScanner.Initialize(Application);
            Button qrReader = FindViewById<Button>(Resource.Id.rqReader);
            qrReader.Click += async (sender, e) => {
                var scanner = new ZXing.Mobile.MobileBarcodeScanner();
                var result = await scanner.Scan();
                ScannedItem si = new ScannedItem{Barcode = result.Text};
                scannedItems.Add(si);
            };
        }

    }
}

