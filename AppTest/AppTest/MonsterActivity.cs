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
    [Activity(Label = "AppTest", Theme = "@android:style/Theme.NoTitleBar", MainLauncher = false)]
    class MonsterActivity : Activity
    {
        public Dictionary dictionary;
        public Monster monster;
        public ShoppingBasket shoppingBasket;
        public int Health;
        public int Attack;
        public Random rnd;
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
                SetContentView(new Drawing(this, monster.GetImages(), Health,Attack));
            }
        }

        private Monster CreateMonster()
        {
            return new Monster(shoppingBasket);
        }

        private void PopulateShoppingBasket(string barcodes)
        {
            shoppingBasket.Seed = barcodes.Replace("*", "");
            if (shoppingBasket.Seed != null)
            {
                Random rnd = new Random(Int32.Parse(shoppingBasket.Seed.Substring(0,9)));
                Health = rnd.Next(70, 100);
                Attack = rnd.Next(20, 30);
                foreach (var product in shoppingBasket.ScannedItems)
                {
                   Health += rnd.Next(0, 5);
                   Attack += rnd.Next(0, 2);
                }
            }
            var listStrLineElements = barcodes.Split('*').ToList();
            foreach (var item in listStrLineElements)
            {
                if (item != "")
                {
                    ScannedItem si = new ScannedItem { Barcode = item };
                    if (dictionary.productDictionary.ContainsKey(si.Barcode))
                    {
                        DictionaryItem dItem = (DictionaryItem)dictionary.productDictionary[si.Barcode];
                        si.Name = dItem.name;
                        si.image = dItem.image;
                    } else
                    {
                        Random random = new Random();
                        string k = dictionary.productDictionary.Keys.ToList()[random.Next()%dictionary.productDictionary.Count];
                        DictionaryItem dItem = (DictionaryItem)dictionary.productDictionary[k];
                        si.Name = dItem.name;
                        si.image = dItem.image;
                    }
                    shoppingBasket.ScannedItems.Add(si);

                }
            }
        }
    }
}