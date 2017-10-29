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
            { "5015552601112", new DictionaryItem("Water", Resource.Drawable.water)},
            { "5000159500920", new DictionaryItem("M&M's", Resource.Drawable.mnm)},
            { "5000159503938", new DictionaryItem("Revels", Resource.Drawable.revels)},
            { "5000159458290", new DictionaryItem("Galaxy", Resource.Drawable.galaxy)},
            { "5020379129565", new DictionaryItem("Ginger Nuts", Resource.Drawable.gingernuts)},
            { "5054268158985", new DictionaryItem("Chocolate Cookies", Resource.Drawable.water)},
            { "5060292307909", new DictionaryItem("Star Wars Puffs", Resource.Drawable.starwars)},
            { "5054267000216", new DictionaryItem("Lucozade", Resource.Drawable.lucozade)},
            { "3329770056923", new DictionaryItem("Froobe", Resource.Drawable.froob)},
            { "5030765032904", new DictionaryItem("Caramel Chocolate", Resource.Drawable.caramel)},
            { "7613033591877", new DictionaryItem("Blue Ribbon", Resource.Drawable.blueriband)},
            { "Key1", new DictionaryItem("haribo", Resource.Drawable.haribobears)},
            { "7622210723512", new DictionaryItem("Chomp", Resource.Drawable.chomp)},
            { "8008440222008", new DictionaryItem("Peroni", Resource.Drawable.peroni)},
            { "5020379129541", new DictionaryItem("Fruit Shortcake", Resource.Drawable.water)},
            { "90162602", new DictionaryItem("Redbull", Resource.Drawable.redbull)},
            { "Key2", new DictionaryItem("Pasta", Resource.Drawable.pasta)},
            { "Key3", new DictionaryItem("Cereal", Resource.Drawable.Cereal)},
            { "Key4", new DictionaryItem("Name1", Resource.Drawable.water)},
        };
    }
}