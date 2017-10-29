using Android.Content;
using Android.Graphics;
using Android.Views;
using System;
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
        private Bitmap[] bodyParts;
        private Paint paint;
        public Paint text;
        private Rect[] bodyRects, bodySourceRects;
        private int armLength;
        public int Health;
        public int Attack;

        public Drawing(Context context, Bitmap[] bP,int health, int attack) : base(context)
        {
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
            bg = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.BackgroundSmall);
            int facenum = random.Next() % 5;
            armLength = random.Next() % 100;
            RandomEye1(facenum,context);
            RandomEye2(facenum, context);
            paint = new Paint();
        }

        public void RandomEye1(int facenum,Context context)
        {
            switch (facenum)
            {
                case 0:
                    eye = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.e2);
                    break;
                case 1:
                    eye = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.e3);
                    break;
                case 2:
                    eye = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.e4);
                    break;
                case 3:
                    eye = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.e5);
                    break;
                case 4:
                    eye = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.e6);
                    break;
            }
        }

        public void RandomEye2(int facenum, Context context)
        {
            switch (facenum)
            {
                case 0:
                    eye2 = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.e2);
                    break;
                case 1:
                    eye2 = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.e3);
                    break;
                case 2:
                    eye2 = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.e4);
                    break;
                case 3:
                    eye2 = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.e5);
                    break;
                case 4:
                    eye2 = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.e6);
                    break;
            }
        }

        protected override void OnDraw(Canvas canvas)
        {
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
            bodyRects[EYE1] = new Rect(canvas.Width / 3 + 30, canvas.Height / 7, 2 * (canvas.Width / 3) - 200, 5 * (canvas.Height / 22));
            bodyRects[SHOULDERS] = new Rect(canvas.Width / 8, canvas.Height / 4, 7 * (canvas.Width / 8), 3*(canvas.Height / 8));
            bodyRects[EYE2] = new Rect(canvas.Width / 3 + 200, canvas.Height / 7, 2 * (canvas.Width / 3)  ,5 * (canvas.Height / 22));
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
            canvas.DrawBitmap(eye, bodySourceRects[6], bodyRects[6], paint);
            canvas.DrawBitmap(eye2, bodySourceRects[8], bodyRects[8], paint);
            text.TextSize = 120;
            text.Color = Color.Black;

            var personGenerator = new PersonNameGenerator();
            var name = personGenerator.GenerateRandomFirstAndLastName();
            canvas.DrawText(Health.ToString(), canvas.Width / 9, 100, text);
            canvas.DrawText(Attack.ToString(), (float)(canvas.Width / 1.1), 100, text);
            canvas.DrawText(name, canvas.Width / 6, 200, text);
        }
    }
}