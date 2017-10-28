using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace AppTest
{
    [Activity(Label = "AppTest", MainLauncher = false)]
    class MonsterActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Monster);
            TextView field = FindViewById<TextView>(Resource.Id.textView1);
            field.Text = Intent.GetStringExtra("Barcodes") ?? "Data not available";
        }
    }
}