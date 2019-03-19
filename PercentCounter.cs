using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Mob
{
    class PercentCounter
    {
        ContentManager content;
        SpriteBatch batch;

        List<Texture2D> numbers;
        Texture2D percent;

        public PercentCounter(ContentManager content_, SpriteBatch batch_)
        {
            content = content_;
            batch = batch_;

            numbers = new List<Texture2D>();

            for (Int32 i = 0; i < 10; i++)
            {
                numbers.Add(content.Load<Texture2D>("mp" + i.ToString()));
            }

            percent = content.Load<Texture2D>("mp_percent");
        }

        public void DrawPercent(Vector2 pos, Vector2 scale, UInt16 pe)
        {
            String percentstr = pe.ToString();
            Color c = (pe <= 50 ? Color.Lerp(Color.Green, Color.Yellow, (float)pe / 50)
                             : Color.Lerp(Color.Yellow, Color.Red, (float)(pe - 50) / 50));


            for (UInt16 i = 0; i < percentstr.Length; i++)
            {
                batch.Draw(numbers[percentstr[i] - '0'], pos, c);
                pos.X += numbers[percentstr[i] - '0'].Bounds.Size.X + 20;
            }

            batch.Draw(percent, pos, c);
        }
    }
}
