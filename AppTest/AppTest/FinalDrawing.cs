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
    public class FinalDrawing : View
    {
        private Bitmap pBitmap;
        public Bitmap[] bodyParts;
        public FinalDrawing(Context context, Bitmap[] bodyparts ,int rotate) : base(context)
        {
            bodyParts = bodyparts;
            pDegrees = rotate;
            pBitmap = BitmapFactory.DecodeResource(Resources, Resource.Drawable.BackgroundSmall);
            var paint = new Paint();
            paint.SetARGB(255, 200, 255, 0);
            paint.SetStyle(Paint.Style.Stroke);
            paint.StrokeWidth = 4;
        }
        public float pOffsetX;
        public float pOffsetY;
        public float pScale = 1.0f;
        public int pDegrees = 45;
        public float xoffset;
        public float yoffset;

        protected override void OnDraw(Canvas canvas)
        {
            canvas.DrawBitmap(pBitmap, DrawBodyPart(BitmapFactory.DecodeResource(Resources, Resource.Drawable.BackgroundSmall), 2f, 1f, 6.5f, 4.6f, 0), null);
            canvas.DrawBitmap(pBitmap, DrawBodyPart(BitmapFactory.DecodeResource(Resources, Resource.Drawable.BackgroundSmall), 0.5f, 1, 1.8f, 1.7f, -5), null);
            canvas.DrawBitmap(pBitmap, DrawBodyPart(BitmapFactory.DecodeResource(Resources, Resource.Drawable.BackgroundSmall), 0.5f, 1, 3.6f, 1.7f, 5), null);
        }

        public Matrix DrawBodyPart(Bitmap image, float sizeX, float sizeY,float xOffset, float yOffset, int rotate)
        {
            var outline = new Path();
            RectF rectF = new RectF();
            outline.ComputeBounds(rectF, true);
            Matrix matrix = new Matrix();
            //canvas.Width / 3, canvas.Height / 8, 2 * (canvas.Width / 3), 5 * (canvas.Height / 16)
            float vw = this.Width;
            float vh = this.Height;
            float bw = vw / sizeX;
            float bh = vh / sizeY;
            float hvw = vw / 2;
            float hvh = vh / 2;
            float s1x = vw / bw;
            float s1y = vh / bh;
            matrix.PostScale(s1x, s1y);
            matrix.PostTranslate(-hvw, -hvh);
            float offsetX = pOffsetX, offsetY = pOffsetY;
            offsetX += hvw + (this.Width / xOffset);
            offsetY += hvh + (this.Height / yOffset);
            matrix.PostTranslate(offsetX, offsetY);
            matrix.PostRotate(rotate);
            return matrix;
        }

    }
}
