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
        private Bitmap hp, ap;
        private Bitmap[] bodyParts;
        private Paint paint;
        public Paint text;
        private Rect[] bodyRects, bodySourceRects;
        private int armLength;
        public int Health;
        public int Attack;

        public Drawing(Context context, Bitmap[] bP,int health, int attack) : base(context)
        {
            hp = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.hp);
            ap = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.ap);
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
        }

        public Bitmap RandomEye(int facenum,Context context)
        {
            /*switch (facenum)
            {
                case 0:
                    return BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.e2);
                    break;
                case 1:
                    return BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.e3);
                    break;
                case 2:
                    return BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.e4);
                    break;
                case 3:
                    return BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.e5);
                    break;
                case 4:
                    return BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.e6);
                    break;
            }*/
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
            // canvas.DrawBitmap(eye2, bodySourceRects[8], bodyRects[8], paint);
            
            var personGenerator = new PersonNameGenerator();
            var name = personGenerator.GenerateRandomFirstAndLastName();
            text.TextSize = canvas.Width/name.Length+5;
            text.Color = Color.Black;
            canvas.DrawText("HP:  "+Health.ToString(), canvas.Width / 10, canvas.Height/15 + text.TextSize * 1, text);
            canvas.DrawText("AP:  "+Attack.ToString(), canvas.Width / 10, canvas.Height/15 + text.TextSize* 3, text);
            canvas.DrawBitmap(hp, canvas.Width / 10, canvas.Height / 15, paint);
            canvas.DrawBitmap(ap, canvas.Width / 10, canvas.Height / 15 + text.TextSize * 2, paint);
            canvas.DrawText(name, canvas.Width / 10, 50, text);
        }
    }
}