﻿using Android.Content;
using Android.Graphics;
using Android.Views;
using System;

namespace AppTest
{
    class Drawing : View
    {
        private int LEG1 = 0, LEG2 = 1, BODY = 2, HEAD = 3, ARM1 = 4, ARM2 = 5, FACE = 6, SHOULDERS = 7;
        private Bitmap bg;
        private Bitmap face;
        private Bitmap[] bodyParts;
        private Paint paint;
        public Paint text;
        private Rect[] bodyRects, bodySourceRects;
        private int armLength;

        public Drawing(Context context, Bitmap[] bP) : base(context)
        {
            Random random = new Random();
            bodyParts = bP;
            bodySourceRects = new Rect[8];
            bodyRects = new Rect[8];
            bg = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.BackgroundSmall);
            int facenum = random.Next() % 5;
            armLength = random.Next() % 100;
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
            bodyRects[BODY] = new Rect(canvas.Width / 4, canvas.Height / 4, canvas.Width / 2 + canvas.Width / 4, 2 * (canvas.Height / 3));
            bodyRects[HEAD] = new Rect(canvas.Width / 3, canvas.Height / 8, 2 * (canvas.Width / 3), 5 * (canvas.Height / 16));
            bodyRects[ARM1] = new Rect(canvas.Width / 8, canvas.Height / 4, canvas.Width / 4, (2 * (canvas.Height / 3))-armLength);
            bodyRects[ARM2] = new Rect(6 * (canvas.Width / 8), canvas.Height / 4, 7 * (canvas.Width / 8), (2 * (canvas.Height / 3))-armLength);
            bodyRects[FACE] = new Rect(canvas.Width / 3, canvas.Height / 8, 2 * (canvas.Width / 3), 5 * (canvas.Height / 16));
            bodyRects[SHOULDERS] = new Rect(canvas.Width / 8, canvas.Height / 4, 7 * (canvas.Width / 8), 3*(canvas.Height / 8));

            Rect bg_rs = new Rect(0, 0, bg.Width, bg.Height);
            Rect bg_rd = new Rect(0, 0, canvas.Width, canvas.Height);

            //draw background
            canvas.DrawBitmap(bg, bg_rs, bg_rd, paint);

            //Shoulders
            canvas.DrawBitmap(bodyParts[BODY], bodySourceRects[SHOULDERS], bodyRects[SHOULDERS], paint);

            //draw monster body parts
            for (int i = 0; i<6; i++)
            {
                canvas.DrawBitmap(bodyParts[i], bodySourceRects[i], bodyRects[i], paint);
            }
            canvas.DrawBitmap(face, bodySourceRects[6], bodyRects[6], paint);
            text.TextSize = 7;
            canvas.DrawText("test",50,100,text);
        }
    }
}