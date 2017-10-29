using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Views;

namespace AppTest
{
    class Drawing : View
    {
        private readonly ShapeDrawable _shape;
        private Bitmap bg;
        private Bitmap[] bodyParts;
        private Paint paint;
        private Rect[] bodyRects, bodySourceRects;

        public Drawing(Context context) : base(context)
        {
            bodyParts = new Bitmap[6];
            bodySourceRects = new Rect[6];
            bodyRects = new Rect[6];
            bg = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.BackgroundSmall);
            for(int i = 0; i<6; i++)
            {
                bodyParts[i] = BitmapFactory.DecodeResource(context.Resources, Resource.Drawable.beans);
                bodySourceRects[i] = new Rect(0, 0, bodyParts[i].Width, bodyParts[i].Height);
            }
            //configure Paint
            paint = new Paint();
            paint.SetARGB(255, 200, 255, 0);
            paint.SetStyle(Paint.Style.Stroke);
            paint.StrokeWidth = 4;

        }

        protected override void OnDraw(Canvas canvas)
        {
            bodyRects[0] = new Rect(canvas.Width / 4, canvas.Height / 2, 3*(canvas.Width / 8), canvas.Height);
            bodyRects[1] = new Rect(5*(canvas.Width / 8), canvas.Height /2 , 3*(canvas.Width / 4), canvas.Height);
            bodyRects[2] = new Rect(canvas.Width / 4, canvas.Height / 4, canvas.Width / 2 + canvas.Width / 4, 2 * (canvas.Height / 3));
            bodyRects[3] = new Rect(canvas.Width / 3, canvas.Height / 8, 2 * (canvas.Width / 3), 5 * (canvas.Height / 16));
            bodyRects[4] = new Rect(canvas.Width / 8, canvas.Height / 4, canvas.Width / 4, 2 * (canvas.Height / 3));
            bodyRects[5] = new Rect(6*(canvas.Width / 8), canvas.Height / 4, 7*(canvas.Width / 8), 2 * (canvas.Height / 3));

            Rect bg_rs = new Rect(0, 0, bg.Width, bg.Height);
            Rect bg_rd = new Rect(0, 0, canvas.Width, canvas.Height);

            //draw background
            canvas.DrawBitmap(bg, bg_rs, bg_rd, paint);

            //draw monster body parts
            for(int i = 0; i<6; i++)
            {
                canvas.DrawBitmap(bodyParts[i], bodySourceRects[i], bodyRects[i], paint);
            }
        }

    }
}