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
        private Rect headRect, bodyRect, leg1Rect, leg2Rect, arm1Rect, arm2Rect;

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
            headRect = new Rect(canvas.Width / 3, canvas.Height / 3, 2*(canvas.Width / 3), canvas.Height / 2);
            bodyRect = new Rect(canvas.Width / 4, canvas.Height / 2, canvas.Width / 2 + canvas.Width / 4, 2*(canvas.Height / 3));
            leg1Rect = new Rect(canvas.Width / 6, 2*(canvas.Height / 3), 2 * (canvas.Width / 6), canvas.Height);
            leg2Rect = new Rect(4*(canvas.Width / 6), 2 * (canvas.Height / 3), 5 * (canvas.Width / 6), canvas.Height);
            arm1Rect = new Rect(canvas.Width / 8, canvas.Height / 2, canvas.Width / 4, 2 * (canvas.Height / 3));
            arm2Rect = new Rect(6*(canvas.Width / 8), canvas.Height / 2, 7*(canvas.Width / 8), 2 * (canvas.Height / 3));

            Rect bg_rs = new Rect(0, 0, bg.Width, bg.Height);
            Rect bg_rd = new Rect(0, 0, canvas.Width, canvas.Height);

            Rect monst_rs = new Rect(0, 0, monster.Width, monster.Height);
            //Rect monst_rd = new Rect(canvas.Width/4, canvas.Height/2, canvas.Width / 2 + canvas.Width/4, canvas.Height);

            //draw background
            canvas.DrawBitmap(bg, bg_rs, bg_rd, paint);

            //draw head
            canvas.DrawBitmap(monster, monst_rs, headRect, paint);
            //draw body
            canvas.DrawBitmap(monster, monst_rs, bodyRect, paint);
            //draw legs
            canvas.DrawBitmap(monster, monst_rs, leg1Rect, paint);
            canvas.DrawBitmap(monster, monst_rs, leg2Rect, paint);
            //draw arms
            canvas.DrawBitmap(monster, monst_rs, arm1Rect, paint);
            canvas.DrawBitmap(monster, monst_rs, arm2Rect, paint);


            _shape.Draw(canvas);
        }

    }
}