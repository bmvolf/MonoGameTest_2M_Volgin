using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameSpaceWar_2m.Classes
{
    public class Explosion
    {
        private bool isLoop = true;
        private int frameNumber = 5;
        private int frameWidth = 117;
        private int frameHeight = 117;
        private double timeTotalSeconds = 0;
        private double duration = 0.05;
        private Texture2D texture;
        private Vector2 position;
        private Rectangle sorceRectangle; //нужно для рисования кусочка текстуры
        #region Constructors
        public Explosion(Vector2 position)
        {
            texture = null;
            this.position = position;
        }
        #endregion
        #region Methods
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("explosion3");
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, sorceRectangle, Color.White);
        }
        public void Update(GameTime gameTime)
        {
            timeTotalSeconds += gameTime.ElapsedGameTime.TotalSeconds;
            if (timeTotalSeconds > duration)
            {
                frameNumber++;

                timeTotalSeconds = 0;
            }
            if(frameNumber == 17 && isLoop)
            {
                frameNumber = 0;
            }
                sorceRectangle = new Rectangle(frameNumber * frameWidth, 0, frameWidth, frameHeight);
                Debug.WriteLine("Time: " + gameTime.ElapsedGameTime.Seconds);
        }
        #endregion
    }
}
