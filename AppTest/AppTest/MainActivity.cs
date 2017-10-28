using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Android.OS;
using AppTest.Model;
using ZXing.Mobile;
using Android.Content;


namespace AppTest
{
    [Activity(Label = "AppTest", Theme = "@android:style/Theme.NoTitleBar", MainLauncher = true)]
    public class MainActivity : Activity
    {
        public List<ScannedItem> scannedItems;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Button qrReader = FindViewById<Button>(Resource.Id.qrReader);
            Button finished = FindViewById<Button>(Resource.Id.finished);

            qrReader.Click += async (sender, e) =>
            {
                MobileBarcodeScanner.Initialize(Application);
                var scanner = new MobileBarcodeScanner();
                var result = await scanner.Scan();
                if (result != null)
                {
                    var field = FindViewById<TextView>(Resource.Id.hiddenField).Text;
                    if (field == "")
                    {
                        FindViewById<TextView>(Resource.Id.hiddenField).Text = result.Text;
                    }
                    else
                    {
                        FindViewById<TextView>(Resource.Id.hiddenField).Text += "*" + result.Text;
                    }
                }
            };
            finished.Click += (sender, e) =>
            {
                var field = FindViewById<TextView>(Resource.Id.hiddenField).Text;
                var monster = new Intent(this, typeof(MonsterActivity));
                monster.PutExtra("Barcodes", field);
                StartActivity(monster);
            };
        }
    }
}

