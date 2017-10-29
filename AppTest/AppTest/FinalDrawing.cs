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
            //Draw Legs
            canvas.DrawBitmap(pBitmap, DrawBodyPart(BitmapFactory.DecodeResource(Resources, Resource.Drawable.BackgroundSmall), 0.2f, 0.5f, canvas.Width / 4, 3 * (canvas.Height / 4), 5), null);
            canvas.DrawBitmap(pBitmap, DrawBodyPart(BitmapFactory.DecodeResource(Resources, Resource.Drawable.BackgroundSmall), 0.2f, 0.5f, canvas.Width / 2, 3*(canvas.Height / 4), -5), null);
            //Draw Arms
            canvas.DrawBitmap(pBitmap, DrawBodyPart(BitmapFactory.DecodeResource(Resources, Resource.Drawable.BackgroundSmall), 0.2f, 0.8f, canvas.Width / 8, canvas.Height / 3, 5), null);
            canvas.DrawBitmap(pBitmap, DrawBodyPart(BitmapFactory.DecodeResource(Resources, Resource.Drawable.BackgroundSmall), 0.2f, 0.8f, 3 * (canvas.Width / 4), canvas.Height / 3, -5), null);

            //Draw Body
            canvas.DrawBitmap(pBitmap, DrawBodyPart(BitmapFactory.DecodeResource(Resources, Resource.Drawable.BackgroundSmall), 1, 1, canvas.Width /8, canvas.Height /3, 0), null);

            //canvas.DrawBitmap(pBitmap, DrawBodyPart(BitmapFactory.DecodeResource(Resources, Resource.Drawable.BackgroundSmall), 0.5f, 1, 1.8f, 1.7f, -5), null);
            //canvas.DrawBitmap(pBitmap, DrawBodyPart(BitmapFactory.DecodeResource(Resources, Resource.Drawable.BackgroundSmall), 0.5f, 1, 3.6f, 1.7f, 5), null);
            /*bodyRects[0] = new Rect(canvas.Width / 4, canvas.Height / 2, 3 * (canvas.Width / 8), canvas.Height);
            bodyRects[1] = new Rect(5 * (canvas.Width / 8), canvas.Height / 2, 3 * (canvas.Width / 4), canvas.Height);
            bodyRects[2] = new Rect(canvas.Width / 4, canvas.Height / 4, canvas.Width / 2 + canvas.Width / 4, 2 * (canvas.Height / 3));
            bodyRects[3] = new Rect(canvas.Width / 3, canvas.Height / 8, 2 * (canvas.Width / 3), 5 * (canvas.Height / 16));
            bodyRects[4] = new Rect(canvas.Width / 8, canvas.Height / 4, canvas.Width / 4, 2 * (canvas.Height / 3));
            bodyRects[5] = new Rect(6 * (canvas.Width / 8), canvas.Height / 4, 7 * (canvas.Width / 8), 2 * (canvas.Height / 3));
            bodyRects[6] = new Rect(canvas.Width / 3, canvas.Height / 8, 2 * (canvas.Width / 3), 5 * (canvas.Height / 16));*/
        }

        public Matrix DrawBodyPart(Bitmap image, float sizeX, float sizeY,float xOffset, float yOffset, int rotate)
        {
            Matrix matrix = new Matrix();
            float vw = Width;
            float vh = Height;
            matrix.PostScale(sizeX, sizeY);
            matrix.PostTranslate(xOffset, yOffset);
            matrix.PostRotate(rotate);
            return matrix;
        }

    }
}
