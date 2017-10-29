using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Android.OS;
using AppTest.Model;
using ZXing.Mobile;
using Android.Content;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AppTest
{
    [Activity(Label = "AppTest", Theme = "@android:style/Theme.NoTitleBar", MainLauncher = true)]
    public class MainActivity : Activity
    {
        public List<ScannedItem> scannedItems;
        private HttpClient client;

        public MainActivity()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Button qrReader = FindViewById<Button>(Resource.Id.qrReader);
            Button finished = FindViewById<Button>(Resource.Id.finished);
            //SetContentView(new Drawing(this));
            var a = GetDepts();
            //qrReader button
            qrReader.Click += async (sender, e) =>
            {
                //Set up barcode scanner
                MobileBarcodeScanner.Initialize(Application);
                var scanner = new MobileBarcodeScanner();
                var options = new MobileBarcodeScanningOptions
                {
                    TryHarder = true,
                    PossibleFormats = new List<ZXing.BarcodeFormat>
                    {
                        ZXing.BarcodeFormat.EAN_13
                    }
                };

                scanner.TopText = "Align red line with barcode";

                //wait for scan
                var result = await scanner.Scan(options);

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

            //finish shopping button
            finished.Click += (sender, e) =>
            {
                var field = FindViewById<TextView>(Resource.Id.hiddenField).Text;
                if (field != "")
                {
                    var monster = new Intent(this, typeof(MonsterActivity));
                    monster.PutExtra("Barcodes", field);
                    StartActivity(monster);
                }
            };
        }
        public async Task<string[]> GetDepts()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://<ipAddress:port>/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var text = FindViewById<TextView>(Resource.Id.textView1);
                var a = await client.GetAsync("/api/dept");
                text.Text = "test";
                return null;
            }
        }
    }
}

