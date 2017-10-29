using Android.Content;
using Android.Graphics;
using System;
using Xamarin.Forms;
using View = Android.Views.View;

namespace AppTest
{
    class Drawing : View
    {
        private int LEG1 = 0, LEG2 = 1, HEAD = 2, BODY = 3, ARM1 = 4, ARM2 = 5, FACE = 6;
        private Bitmap bg;
        private Bitmap face;
        private Bitmap[] bodyParts;
        private Paint paint;
        private Rect[] bodyRects, bodySourceRects;
        private Label label;

        public Drawing(Context context, Bitmap[] bP) : base(context)
        {
            Random random = new Random();
            bodyParts = bP;
            bodySourceRects = new Rect[7];
            bodyRects = new Rect[7];
            bg = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.BackgroundSmall);
            int facenum = random.Next() % 5;
            switch(facenum)
            {
                case 0:
                    face = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.e2);
                    break;
                case 1:
                    face = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.e3);
                    break;
                case 2:
                    face = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.e4);
                    break;
                case 3:
                    face = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.e5);
                    break;
                case 4:
                    face = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.e6);
                    break;
            }
            paint = new Paint();
        }

        protected override void OnDraw(Canvas canvas)
        {
            bodyRects[LEG1] = new Rect(canvas.Width / 4, canvas.Height / 2, 3*(canvas.Width / 8), canvas.Height);
            bodyRects[LEG2] = new Rect(5*(canvas.Width / 8), canvas.Height /2 , 3*(canvas.Width / 4), canvas.Height);
            bodyRects[HEAD] = new Rect(canvas.Width / 4, canvas.Height / 4, canvas.Width / 2 + canvas.Width / 4, 2 * (canvas.Height / 3));
            bodyRects[BODY] = new Rect(canvas.Width / 3, canvas.Height / 8, 2 * (canvas.Width / 3), 5 * (canvas.Height / 16));
            bodyRects[ARM1] = new Rect(canvas.Width / 8, canvas.Height / 4, canvas.Width / 4, 2 * (canvas.Height / 3));
            bodyRects[ARM2] = new Rect(6 * (canvas.Width / 8), canvas.Height / 4, 7 * (canvas.Width / 8), 2 * (canvas.Height / 3));
            bodyRects[FACE] = new Rect(canvas.Width / 3, canvas.Height / 8, 2 * (canvas.Width / 3), 5 * (canvas.Height / 16));

            Rect bg_rs = new Rect(0, 0, bg.Width, bg.Height);
            Rect bg_rd = new Rect(0, 0, canvas.Width, canvas.Height);

            //draw background
            canvas.DrawBitmap(bg, bg_rs, bg_rd, paint);

            //draw monster body parts
            for(int i = 0; i<6; i++)
            {
                canvas.DrawBitmap(bodyParts[i], bodySourceRects[i], bodyRects[i], paint);
            }
            canvas.DrawBitmap(face, bodySourceRects[6], bodyRects[6], paint);
            canvas.DrawText("Test",50,50,50,50,paint);
        }
    }
}