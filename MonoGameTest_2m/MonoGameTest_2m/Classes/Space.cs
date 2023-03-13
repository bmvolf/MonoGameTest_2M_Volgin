using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameSpaceWar_2m.Classes
{
    public class Space
    {
        public Vector2 position1;
        public Vector2 position2;
        public Texture2D texture;
        private float speed;

        public Space()
        {
            texture = null;
            position1 = Vector2.Zero;
            position2 = new Vector2(0, -950);
            speed = 1;
        }
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("space");
        }
        public void Update()
        {
            position1.Y += speed;
            position2.Y += speed;
            if(position2.Y >= 0)
            {
                position1.Y = 0;
                position2.Y = -950;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position1, Color.White);
            spriteBatch.Draw(texture, position2, Color.White);
        }
    }
}
