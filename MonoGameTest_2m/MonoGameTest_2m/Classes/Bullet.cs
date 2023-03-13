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
    public class Bullet
    {
        private Texture2D texture;
        private Rectangle destinationRectangle;
        private int width = 20;
        private int height = 20;
        private int speed = 3;
        private bool isAlive = true;
        #region Constructors
        public Bullet()
        {
            texture = null;
            destinationRectangle = new Rectangle(0, 0, width, height);
        }
        public Bullet(Vector2 position)
        {
            texture = null;
            destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width , height);
        }
        #endregion
        #region Properties
        public int Width
        { get { return width; } }

        public int Height
        { get { return height; } }

        public Vector2 Position
        {
            get
            {
                return new Vector2(destinationRectangle.X, destinationRectangle.Y);
            }
            set
            {
                destinationRectangle.X = (int)value.X;
                destinationRectangle.Y = (int)value.Y;
            }
        }
        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }
        public Rectangle Collision  
        {
            get
            {
                return destinationRectangle;
            }
        }
        #endregion
        #region Methods
        public void Update()
        {
            destinationRectangle.Y -= speed;
            if(Position.Y  < -height)
            {
                isAlive = false;
            }
        }
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("asteroid");
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, destinationRectangle, Color.Blue);
        }
        #endregion
    }
}
