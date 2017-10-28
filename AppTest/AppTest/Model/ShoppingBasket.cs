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
        public List<ScannedItem> scannedItems { get; set; }
        public DateTime ShoppingDate { get; set; }
        public string Seed { get; set; }

        public ShoppingBasket()
        {
            scannedItems = new List<ScannedItem>();
        }

        public void Add(ScannedItem si)
        {
            scannedItems.Add(si);
        }

    }
}