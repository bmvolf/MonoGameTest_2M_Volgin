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
    internal class Asteroid
    {
        private Vector2 position;
        private Texture2D texture;
        private Rectangle collision;
        private bool isAlive = true;

        public Asteroid()
        {
            texture = null;
            position = Vector2.Zero;
        }

        public Rectangle Collision
        {
            get { return collision; }
            set { collision = value; }
        }
        public bool IsAlive
        {
            get { return isAlive; } 
            set { isAlive = value; }
        }

        public Vector2 Position
        { 
            get { return position; } 
            set { position = value; }      
        }
        public int Height
        {
            get { return texture.Height; }
        }
        public int Width
        {
            get { return texture.Width; }
        }

        public Asteroid(Vector2 position)
        {
            texture = null;
            this.position = position;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("asteroid");
        }
        public void Update()
        {
            position.Y += 3;
            collision = new Rectangle((int)position.X, (int)position.Y,
    Width, Height);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
