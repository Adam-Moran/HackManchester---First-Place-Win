using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace AppTest
{
    class Drawing : View
    {
        private readonly ShapeDrawable _shape;
        private Bitmap bg;
        private Paint paint;
        public Drawing(Context context) : base(context)
        {
            bg = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.BackgroundSmall);
            paint = new Paint();
            paint.SetARGB(255, 200, 255, 0);
            paint.SetStyle(Paint.Style.Stroke);
            paint.StrokeWidth = 4;
            _shape = new ShapeDrawable(new OvalShape());
            _shape.Paint.Set(paint);

            _shape.SetBounds(20, 20, 300, 200);
        }

        protected override void OnDraw(Canvas canvas)
        {
            Rect rs = new Rect(0, 0, bg.Width, bg.Height);
            Rect rd= new Rect(0, 0, canvas.Width, canvas.Height);
            _shape.Draw(canvas);
            canvas.DrawBitmap(bg, rs, rd, new Paint());

        }

    }
}