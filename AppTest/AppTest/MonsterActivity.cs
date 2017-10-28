using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppTest.Model;

namespace AppTest
{
    [Activity(Label = "AppTest", MainLauncher = false)]
    class MonsterActivity : Activity
    {
        public ShoppingBasket shoppingBasket;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            shoppingBasket = new ShoppingBasket();
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Monster);
            TextView field = FindViewById<TextView>(Resource.Id.textView1);
            var barcodes = Intent.GetStringExtra("Barcodes");
            PopulateShoppingBasket(barcodes);
            CreateMonster();
        }

        private void CreateMonster()
        {
            throw new NotImplementedException();
        }

        private void PopulateShoppingBasket(string barcodes)
        {
            var listStrLineElements = barcodes.Split('*').ToList();
            foreach (var item in listStrLineElements)
            {
                ScannedItem si = new ScannedItem{Barcode = item};
                shoppingBasket.ScannedItems.Add(si);
            }
        }
    }
}