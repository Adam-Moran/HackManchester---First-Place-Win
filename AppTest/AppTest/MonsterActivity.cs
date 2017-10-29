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
        public Dictionary dictionary;
        public Monster monster;
        public ShoppingBasket shoppingBasket;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            shoppingBasket = new ShoppingBasket();
            dictionary = new Dictionary();
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Monster);
            TextView field = FindViewById<TextView>(Resource.Id.textView1);
            var barcodes = Intent.GetStringExtra("Barcodes");
            if (barcodes != "")
            {
                PopulateShoppingBasket(barcodes);
                monster = CreateMonster();
                SetContentView(new Drawing(this, monster.GetImages()));
            }
        }

        private Monster CreateMonster()
        {
            return new Monster(shoppingBasket);
        }

        private void PopulateShoppingBasket(string barcodes)
        {
            shoppingBasket.Seed = barcodes.Replace("*", "");
            var listStrLineElements = barcodes.Split('*').ToList();
            foreach (var item in listStrLineElements)
            {
                if (item != "")
                {
                    ScannedItem si = new ScannedItem { Barcode = item };
                    DictionaryItem dItem = (DictionaryItem)dictionary.productDictionary[si.Barcode];
                    si.Name = dItem.name;
                    si.image = dItem.image;
                    shoppingBasket.ScannedItems.Add(si);

                }
            }
        }
    }
}