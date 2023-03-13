using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic; //Lists
using MonoGameSpaceWar_2m.Classes;
using System;

namespace MonoGameTest_2m
{
    public class Game1 : Game
    {
        //инструменты
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        int screenWidth = 800;
        int screenHeight = 600;
        //fields
        private Player player;
        private Space space;
        //private Asteroid asteroid;
        private List<Asteroid> asteroids;
        private List<Explosion> explosions;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = screenWidth;
            _graphics.PreferredBackBufferHeight = screenHeight;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            player = new Player();
            space = new Space();
            //asteroid = new Asteroid();
            asteroids = new List<Asteroid>();
            explosions = new List<Explosion>();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here\
            player.LoadContent(Content);
            space.LoadContent(Content);
            Texture2D texture = Content.Load<Texture2D>("explosion3");
            LoadAsteroid();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            player.Update(Content);
            space.Update();
            UpdateAsteroids();
            CheckCollision();
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            space.Draw(_spriteBatch);
            player.Draw(_spriteBatch);
            foreach (Asteroid asteroid in asteroids)
            {
                asteroid.Draw(_spriteBatch);
            }
            //asteroid.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
        private void UpdateAsteroids()
        {
            for (int i = 0; i < asteroids.Count; i++)
            {
                Asteroid asteroid = asteroids[i];
                asteroid.Update();

                // teleport
                if (asteroid.Position.Y > screenHeight)
                {
                    Random random = new Random();
                    int y = random.Next(-screenHeight, 0 - asteroid.Height);
                    int x = random.Next(0, screenWidth - asteroid.Width);

                    asteroid.Position = new Vector2(x, y);
                }
                if (!asteroid.IsAlive)
                {
                    asteroids.Remove(asteroid);
                    i--;
                }
            }
            if(asteroids.Count < 10)
            {
                LoadAsteroid();
            }
        }
        private void LoadAsteroid()
        {
                Vector2 pos = new Vector2();
                Asteroid asteroid = new Asteroid(pos);
                asteroid.LoadContent(Content);

                int rectWidth = screenWidth;
                int rectHeight = screenHeight;

                Random random = new Random();

                int x = random.Next(0, rectWidth - asteroid.Width);
                int y = random.Next(0, rectHeight - asteroid.Height);

                asteroid.Position = new Vector2(x, -y);
                asteroids.Add(asteroid);
        }
        private void CheckCollision()
        {
            foreach(Asteroid asteroid in asteroids)
            {
                //each asteroid and player
                if (asteroid.Collision.Intersects(player.Collision))
                {
                    asteroid.IsAlive = false;
                }
                //each asteroid and each Bullet
                foreach (Bullet bullet in player.Bullets)
                {
                    if (asteroid.Collision.Intersects(bullet.Collision))
                    {
                        asteroid.IsAlive = false;
                        bullet.IsAlive = false;
                    }
                }
            }
        }
    }
}