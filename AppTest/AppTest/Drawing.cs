using Android.Content;
using Android.Graphics;
using Android.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using RandomNameGeneratorLibrary;

namespace AppTest
{
    class Drawing : View
    {
        private int LEG1 = 0, LEG2 = 1, BODY = 2, HEAD = 3, ARM1 = 4, ARM2 = 5, EYE1 = 6, SHOULDERS = 7, EYE2 = 8;
        private bool[] armUp;
        private Bitmap bg;
        private Bitmap eye;
        private Bitmap eye2;
        private Bitmap hp, ap;
        private Bitmap[] bodyParts;
        private Bitmap map;
        private Paint paint;
        public Paint text;
        private Rect[] bodyRects, bodySourceRects;
        private int armLength;
        public int Health;
        public int Attack;

        public Drawing(Context context, Bitmap[] bP,int health, int attack) : base(context)
        {
            hp = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.health);
            ap = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.attack);
            Health = health;
            Attack = attack;
            text = new Paint();
            Random random = new Random();
            armUp = new bool[2];
            armUp[0] = ((random.Next() % 2 == 1) ? true : false);
            armUp[1] = ((random.Next() % 2 == 1) ? true : false);
            bodyParts = bP;
            bodySourceRects = new Rect[9];
            bodyRects = new Rect[9];
            bg = random.Next() % 2 ==1 ? BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.BackgroundSmall) : BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.Background2Small);
            int facenum = random.Next() % 5;
            armLength = random.Next() % 100;
            eye = eye2 = RandomEye(facenum, context);
            paint = new Paint();
            map = (BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.paper));
        }

        public Bitmap RandomEye(int facenum,Context context)
        {
            switch (facenum)
            {
                case 0:
                    return BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.eyes);
                    break;
                case 1:
                    return BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.eyes2);
                    break;
                case 2:
                    return BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.eyes3);
                    break;
                case 3:
                    return BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.eyes2);
                    break;
            }
            return BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.eyes);

        }

        protected override void OnDraw(Canvas canvas)
        {
            Rect apRect = new Rect(canvas.Width / 10, 100, 50, 50);
            Rect hpRect = new Rect(canvas.Width / 10, 150, 50, 50);
            bodyRects[LEG1] = new Rect(canvas.Width / 4, canvas.Height / 2, 3*(canvas.Width / 8), canvas.Height);
            bodyRects[LEG2] = new Rect(5*(canvas.Width / 8), canvas.Height /2 , 3*(canvas.Width / 4), canvas.Height);
            bodyRects[BODY] = new Rect(canvas.Width / 4, canvas.Height / 4, canvas.Width / 2 + canvas.Width / 4, 2 * (canvas.Height / 3));
            bodyRects[HEAD] = new Rect(canvas.Width / 3, canvas.Height / 8, 2 * (canvas.Width / 3), 5 * (canvas.Height / 16));
            if(armUp[0])
                bodyRects[ARM1] = new Rect(canvas.Width / 8, canvas.Height / 4, canvas.Width / 4, (2 * (canvas.Height / 3)) - armLength);
            else
                bodyRects[ARM1] = new Rect(canvas.Width / 8, armLength, canvas.Width / 4, 3 * (canvas.Height / 8));
            if (armUp[1])
                bodyRects[ARM2] = new Rect(6 * (canvas.Width / 8), canvas.Height / 4, 7 * (canvas.Width / 8), (2 * (canvas.Height / 3)) - armLength);
            else
                bodyRects[ARM2] = new Rect(6 * (canvas.Width / 8), armLength, 7 * (canvas.Width / 8), 3*(canvas.Height / 8));
            bodyRects[EYE1] = new Rect(3*(canvas.Width / 8), canvas.Height / 7, 5 * (canvas.Width / 8), 5 * (canvas.Height / 22));
            bodyRects[SHOULDERS] = new Rect(canvas.Width / 8, canvas.Height / 4, 7 * (canvas.Width / 8), 3*(canvas.Height / 8));
            //bodyRects[EYE2] = new Rect(canvas.Width / 2, canvas.Height / 7, 5 * (canvas.Width / 8)  ,5 * (canvas.Height / 22));
            Rect bg_rs = new Rect(0, 0, bg.Width, bg.Height);
            Rect bg_rd = new Rect(0, 0, canvas.Width, canvas.Height);
            List<Bitmap> list = new List<Bitmap>();
            //draw background
            canvas.DrawBitmap(bg, bg_rs, bg_rd, paint);
            list.Add(bg);
            //Shoulders
            canvas.DrawBitmap(bodyParts[BODY], bodySourceRects[SHOULDERS], bodyRects[SHOULDERS], paint);
            list.Add(bodyParts[BODY]);
            //draw monster body parts
            for (int i = 0; i<6; i++)
            {
                canvas.DrawBitmap(bodyParts[i], bodySourceRects[i], bodyRects[i], paint);
                list.Add(bodyParts[i]);
            }
            canvas.DrawBitmap(eye, bodySourceRects[6], bodyRects[6], paint);
            // canvas.DrawBitmap(eye2, bodySourceRects[8], bodyRects[8], paint);
            list.Add(eye);
            var personGenerator = new PersonNameGenerator();
            var name = personGenerator.GenerateRandomFirstAndLastName();
            text.TextSize = canvas.Width/13;
            text.Color = Color.Black;
            canvas.DrawText(Health.ToString(), (canvas.Width / 20) + 100, canvas.Height/16 + text.TextSize * 1, text);
            canvas.DrawText(Attack.ToString(), (canvas.Width / 20) + 100, canvas.Height/16 + text.TextSize* 3, text);
            canvas.DrawBitmap(hp, canvas.Width / 20, canvas.Height / 16, paint);
            canvas.DrawBitmap(ap, canvas.Width / 20, canvas.Height / 16 + text.TextSize * 2, paint);
            canvas.DrawText(name, canvas.Width / 20, 50, text);
            
            /*Paint green = new Paint
            {
                AntiAlias = true,
                Color = Color.Rgb(0x99, 0xcc, 0),
            };
            green.SetStyle(Paint.Style.FillAndStroke);

            Paint red = new Paint
            {
                AntiAlias = true,
                Color = Color.Rgb(0xff, 0x44, 0x44)
            };
            red.SetStyle(Paint.Style.FillAndStroke);*/

            //float middle = canvas.Width * 0.25f;
            //canvas.DrawPaint(red);
            //canvas.DrawRect(0, 0, middle, canvas.Height, green);
            var background = new Rect(-50, -200, canvas.Width + 50, canvas.Height / 10);
            canvas.DrawBitmap(map, null, background, paint);

            text.FakeBoldText = true;

            canvas.DrawText("HP: " + Health, canvas.Width / 16, 110, text);
            canvas.DrawText("AP: " + Attack, (float)(canvas.Width / 1.35f), 110, text);
            canvas.DrawText(name, canvas.Width / 4.2f, 225, text);
        }

        
    }
}