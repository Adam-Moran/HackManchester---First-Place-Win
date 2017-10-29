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

namespace AppTest.Model
{
    public class ShoppingBasket
    {
        public List<ScannedItem> ScannedItems { get; set; }
        public DateTime ShoppingDate { get; set; }
        public string Seed { get; set; }
        public int Health;
        public int Attack;
        public ShoppingBasket()
        {
            Random rnd = new Random(Int32.Parse(Seed));
            Health = rnd.Next(70, 100);
            Attack = rnd.Next(20, 30);
            ScannedItems = new List<ScannedItem>();
            foreach (var product in ScannedItems)
            {
                Health += rnd.Next(0, 5);
                Attack += rnd.Next(0, 2);
            }
        }

        public ScannedItem Get(int i)
        {
            return ScannedItems.ElementAt(i);
        }

        public void Add(ScannedItem si)
        {
            ScannedItems.Add(si);
        }

    }
}