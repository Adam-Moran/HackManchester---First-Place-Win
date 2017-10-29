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

namespace AppTest
{
    public class DictionaryItem
    {
        public string name;
        public int image;
        public DictionaryItem(string nm, int img)
        {
            name = nm; image = img;
        }
    }
    public class Dictionary
    {
        public Dictionary<string, object> productDictionary = new Dictionary<string, object>
        {
            { "510555260112", new DictionaryItem("Water", Resource.Drawable.water) },
            { "5000159500920", new DictionaryItem("M&M's", Resource.Drawable.water)},
            { "5000159503938", new DictionaryItem("Revels", Resource.Drawable.water)},
            { "5000159458290", new DictionaryItem("Galaxy", Resource.Drawable.water)},
            { "5020379129565", new DictionaryItem("Ginger Nuts", Resource.Drawable.water)},
            { "5054268158985", new DictionaryItem("Chocolate Cookies", Resource.Drawable.water)},
            { "5060292307909", new DictionaryItem("Star Wars Puffs", Resource.Drawable.water)},
            { "5054267000216", new DictionaryItem("Lucozade", Resource.Drawable.water)},
            { "3329770056923", new DictionaryItem("Froobe", Resource.Drawable.water)},
            { "5030765032904", new DictionaryItem("Caramel Chocolate", Resource.Drawable.water)},
            { "7613033591877", new DictionaryItem("Blue Ribbon", Resource.Drawable.water)},
            { "Key1", new DictionaryItem("haribo", Resource.Drawable.haribobears)},
            { "7622210723512", new DictionaryItem("Chomp", Resource.Drawable.water)},
            { "8008440222008", new DictionaryItem("Peroni", Resource.Drawable.water)},
            { "5020379129541", new DictionaryItem("Fruit Shortcake", Resource.Drawable.water)},
            //{ "Key1", new DictionaryItem("Redbull", Resource.Drawable.redbull)},
            //{ "Key1", new DictionaryItem("Pasta", Resource.Drawable.pasta)},
            //{ "Key1", new DictionaryItem("Cereal", Resource.Drawable.Cereal)},
            //{ "Key1", new DictionaryItem("Name1", Resource.Drawable.water)},
        };
    }
}