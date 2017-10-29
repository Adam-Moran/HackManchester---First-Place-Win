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
    public class ScannedItem
    {
        public string Barcode { set; get; }
        public string Name { set; get; }
        public int image { set; get; }
    }
}