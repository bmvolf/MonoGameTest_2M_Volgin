using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameSpaceWar_2m.Classes;


namespace MonoGameSpaceWar_2m.Classes
{
    public enum TypePlayer { Begginer, Intermediate, Advanced, Pro, God }
    internal class Player
    {
        private Vector2 position;
        private Texture2D texture;
        private TypePlayer typePlayer;
        private Rectangle collision;
        private float speed;
        private int time = 0;
        private int maxTime = 60;
        //weapons
        private List<Bullet> bulletsList = new List<Bullet> ();
        //prop
        public Player()
        {
            position = new Vector2(50 , 50);
            texture = null;
            typePlayer = TypePlayer.Begginer;
            speed = 10;
        }
        public List<Bullet> Bullets
        {
            get { return bulletsList; }
        }

        public Rectangle Collision { get { return collision; } }

        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("player");
        }
        public void Draw (SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
            foreach(Bullet bullet in bulletsList)
            {
                bullet.Draw(spriteBatch);
            }
        }
        public void Update(ContentManager manager)
        {
            #region Movement
            KeyboardState keyboardState = Keyboard.GetState();
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                position.X += speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                position.X -= speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                position.Y -= speed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                position.Y += speed;
            }
            #endregion
            #region Bounds
            if (position.X < 0)
            {
                position.X = 0;
            }
            if(position.Y < 0)
            {
                position.Y = 0;
            }
            if(position.X + texture.Width > 800)
            {
                position.X = 800 - texture.Width;
            }  
            if(position.Y + texture.Height > 600)
            {
                position.Y = 600 - texture.Height;
            }
            #endregion
            collision = new Rectangle((int)position.X, (int)position.Y,
    texture.Width, texture.Height);

            time++;
            if (time > maxTime)
            {
                Bullet bullet = new Bullet();
                bullet.Position = new Vector2(position.X + texture.Width/2  - bullet.Width/2,
                    position.Y - bullet.Height/2);
                bullet.LoadContent(manager);
                bulletsList.Add(bullet);

                time = 0;
            }
            for(int i = 0; i < bulletsList.Count; i++)
            {
                Bullet bullet = bulletsList[i];
                bullet.Update();
            }
            //чистка листа
            for(int i = 0; i < bulletsList.Count; i++)
            {
                if (!bulletsList[i].IsAlive)
                {
                    bulletsList.RemoveAt(i);
                    i--;
                }
            }
            if (keyboardState.IsKeyDown(Keys.Q))
            {
                int a = 1;
            }
        }
    }
}
