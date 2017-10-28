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
        private Bitmap monster;
        private Paint paint;
        public Drawing(Context context) : base(context)
        {
            bg = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.BackgroundSmall);
            monster = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.beans);

            //configure Paint
            paint = new Paint();
            paint.SetARGB(255, 200, 255, 0);
            paint.SetStyle(Paint.Style.Stroke);
            paint.StrokeWidth = 4;

            //Squid's Oval stuff
            _shape = new ShapeDrawable(new OvalShape());
            _shape.Paint.Set(paint);
            _shape.SetBounds(20, 20, 300, 200);


        }

        protected override void OnDraw(Canvas canvas)
        {
            Rect bg_rs = new Rect(0, 0, bg.Width, bg.Height);
            Rect bg_rd = new Rect(0, 0, canvas.Width, canvas.Height);

            Rect monst_rs = new Rect(0, 0, monster.Width, monster.Height);
            Rect monst_rd = new Rect(canvas.Width/4, canvas.Height/2, canvas.Width / 2 + canvas.Width/4, canvas.Height);

            //draw background
            canvas.DrawBitmap(bg, bg_rs, bg_rd, paint);

            //draw monster
            canvas.DrawBitmap(monster, monst_rs, monst_rd, paint);
            _shape.Draw(canvas);
        }

    }
}