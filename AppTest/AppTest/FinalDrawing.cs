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
    class FinalDrawing : View
    {
        private readonly ShapeDrawable _shape;
        private Bitmap pBitmap;

        public FinalDrawing(Context context, Bitmap bm, int rotate) : base(context)
        {
            pDegrees = rotate;
            pBitmap = bm;
            var paint = new Paint();
            paint.SetARGB(255, 200, 255, 0);
            paint.SetStyle(Paint.Style.Stroke);
            paint.StrokeWidth = 4;
            _shape = new ShapeDrawable(new OvalShape());
            _shape.Paint.Set(paint);
            _shape.SetBounds(20, 20, 300, 200);
        }

        public float pOffsetX;
        public float pOffsetY;
        public float pScale = 1.0f;
        public int pDegrees = 45;

        protected override void OnDraw(Canvas canvas)
        {
            //pBitmap = ;
            var outline = new Path();

            RectF rectF = new RectF();
            outline.ComputeBounds(rectF, true);
            Matrix matrix = new Matrix();
            float vw = this.Width;
            float vh = this.Height;
            float hvw = vw / 2;
            float hvh = vh / 2;
            float bw = (float)pBitmap.Width;
            float bh = (float)pBitmap.Height;
            float s1x = vw / bw;
            float s1y = vh / bh;
            float s1 = (s1x < s1y) ? s1x : s1y;
            matrix.PostScale(s1, s1);
            matrix.PostTranslate(-hvw, -hvh);
            int rotation = pDegrees;
            matrix.PostRotate(rotation);
            float offsetX = pOffsetX, offsetY = pOffsetY;
            if (pScale != 1.0f)
            {
                matrix.PostScale(pScale, pScale);
                float sx = (0.0f + pScale) * vw / 2;
                float sy = (0.0f + pScale) * vh / 2;
                offsetX += sx;
                offsetY += sy;
            }
            else
            {
                offsetX += hvw;
                offsetY += hvh;
            }

            matrix.PostTranslate(offsetX, offsetY);
            canvas.DrawBitmap(pBitmap, matrix, null);
        }

    }
}
