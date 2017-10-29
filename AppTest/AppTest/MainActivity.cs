using System.Collections.Generic;
using Android.App;
using Android.Widget;
using Android.OS;
using AppTest.Model;
using ZXing.Mobile;
using Android.Content;
using Android.Graphics;
using Java.Security;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Android.Views.Animations;
using Newtonsoft.Json;

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
            FindViewById<TextView>(Resource.Id.hiddenField).SetHeight(0);
            Button qrReader = FindViewById<Button>(Resource.Id.qrReader);
            Button finished = FindViewById<Button>(Resource.Id.finished);
            //SetContentView(new Drawing(this));
            //Bitmap[] test = new Bitmap[1];
            //SetContentView(new Drawing(this));
            //SetContentView(new Drawing(this));
            //qrReader button
            //TranslateAnimation am = new TranslateAnimation(0,10,0,10);
            //am.Duration = 1000;
            //am.FillAfter = true;
            //ImageView im = FindViewById<ImageView>(Resource.Id.imageView1);
            //im.StartAnimation(am);
            qrReader.Click += async (sender, e) =>
            {
                //Set up barcode scanner
                MobileBarcodeScanner.Initialize(Application);
                var scanner = new MobileBarcodeScanner();
                var options = new MobileBarcodeScanningOptions
                {
                    TryHarder = true,
                    /*PossibleFormats = new List<ZXing.BarcodeFormat>
                    {
                        ZXing.BarcodeFormat.EAN_13, ZXing.BarcodeFormat.EAN_8
                    }*/
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
    }
}

