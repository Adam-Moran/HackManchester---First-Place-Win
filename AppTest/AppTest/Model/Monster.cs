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
    public class Monster
    {
        public MonsterHead MonsterHeader { get; set; }
        public MonsterTorso MonsterTorse { get; set; }
        public MonsterArm MonsterArmOne { get; set; }
        public MonsterArm MonsterArmTwo { get; set; }
        public MonsterLeg MonsterLegOne { get; set; }
        public MonsterLeg MonsterLegTwo { get; set; }
    }
}