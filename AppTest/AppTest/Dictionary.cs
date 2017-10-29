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
    class Dictionary
    {
        public Dictionary<string, object> productDictionary = new Dictionary<string, object>
        {
            { "510555260112", new {name = "Water", image = Resource.Drawable.water}},
            { "5000159500920", new {name = "M&M's", image = Resource.Drawable.mnm}},
            { "5000159503938", new {name = "Revels", image = Resource.Drawable.revels}},
            { "5000159458290", new {name = "Galaxy", image = Resource.Drawable.galaxy}},
            { "5020379129565", new {name = "Ginger Nuts", image = Resource.Drawable.gingernuts}},
            { "5054268158985", new {name = "Chocolate Cookies", image = Resource.Drawable.Cookies}},
            { "5060292307909", new {name = "Star Wars Puffs", image = Resource.Drawable.starwars}},
            { "5054267000216", new {name = "Lucozade", image = Resource.Drawable.lucozade}},
            { "3329770056923", new {name = "Froobe", image = Resource.Drawable.water}},
            { "5030765032904", new {name = "Caramel Chocolate", image = Resource.Drawable.water}},
            { "7613033591877", new {name = "Blue Ribbon", image = Resource.Drawable.water}},
            { "Key1", new {name = "haribo", image = Resource.Drawable.haribobears}},
            { "7622210723512", new {name = "Chomp", image = Resource.Drawable.water}},
            { "8008440222008", new {name = "Peroni", image = Resource.Drawable.water}},
            { "5020379129541", new {name = "Fruit Shortcake", image = Resource.Drawable.water}},
            { "Key1", new {name = "Redbull", image = Resource.Drawable.redbull}},
            { "Key1", new {name = "Pasta", image = Resource.Drawable.pasta}},
            { "Key1", new {name = "Cereal", image = Resource.Drawable.Cereal}},
            { "Key1", new {name = "Name1", image = Resource.Drawable.water}},
        };
    }
}