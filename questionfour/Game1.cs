using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Diagnostics;

namespace Question_Four
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Planet thesun;
        private Planet mecury;
        private Planet venus;
        private Planet earth;
        private Planet mars;
        private Planet jupiter;
        private Planet saturn;
        private Planet uranus;
        private Planet neptune;
        private Planet pluto;
        private Planet moon;

        private List<Planet> gameobjectlist = new List<Planet>(9);

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 512;
            graphics.PreferredBackBufferHeight = 512;
            graphics.ApplyChanges();

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //create instance for the planets, star, and moon
            thesun = new Planet("TheSun", "Circle", 0, 0, 2, 2, 0, 0, 0);
            mecury = new Planet("Mercury", "Circle", 0, 0, 0.6f, 0.6f, 50, 1, 1);
            venus = new Planet("Venus", "Circle", 0, 0, 0.7f, 0.7f, 70, 20, 0.7f);
            earth = new Planet("Earth", "Circle", 0, 0, 0.8f, 0.8f, 80, 100, 0.8f);
            mars = new Planet("Mars", "Circle", 0, 0, 0.7f, 0.7f, 100, 50, 0.9f);
            jupiter = new Planet("Jupiter", "Circle", 0, 0, 1.5f, 1.5f, 140, 250, 0.6f);
            saturn = new Planet("Saturn", "Circle", 0, 0, 1.2f, 1.2f, 160, 150, 0.3f);
            uranus = new Planet("Uranus", "Circle", 0, 0, 1.1f, 1.1f, 180, 300, 0.4f);
            neptune = new Planet("Neptune", "Circle", 0, 0, 1.1f, 1.1f, 200, 320, 0.5f);
            pluto = new Planet("Pluto", "Circle", 0, 0, 0.2f, 0.2f, 210, 330, 0.3f);
            moon = new Planet("Moon", "Circle", 0, 0, 0.3f, 0.3f, 20, 0, 0.9f);

            //add planets to gameobjectlist
            gameobjectlist.Add(mecury);
            gameobjectlist.Add(venus);
            gameobjectlist.Add(earth);
            gameobjectlist.Add(mars);
            gameobjectlist.Add(jupiter);
            gameobjectlist.Add(saturn);
            gameobjectlist.Add(uranus);
            gameobjectlist.Add(neptune);
            gameobjectlist.Add(pluto);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            //load all the texture
            thesun.LoadContent(Content);
            for (int i = 0; i < gameobjectlist.Count; ++i)
            {
                gameobjectlist[i].LoadContent(Content);
            }
            moon.LoadContent(Content);

            //set the sun coordinate
            thesun.x = (int)(graphics.PreferredBackBufferWidth * 0.5 - thesun.width * 0.5f);
            thesun.y = (int)(graphics.PreferredBackBufferHeight * 0.5 - thesun.height * 0.5f);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            //other planet's orbit
            for (int i = 0; i < gameobjectlist.Count; ++i)
            {
                //increase the rotation angle
                gameobjectlist[i].orbitDegree += gameobjectlist[i].orbitSpeed;
                //rotate the planet
                Polar.Rotate(gameobjectlist[i], gameobjectlist[i].orbitMagnitude, (double)MathHelper.ToRadians(gameobjectlist[i].orbitDegree), (int)(thesun.x + thesun.width * 0.5f), (int)(thesun.y + thesun.height * 0.5f));
                //center the planet
                gameobjectlist[i].x -= (int)(gameobjectlist[i].width * 0.5f);
                gameobjectlist[i].y -= (int)(gameobjectlist[i].height * 0.5f);
            }

            //moon's orbit
            moon.orbitDegree += moon.orbitSpeed;
            Polar.Rotate(moon, moon.orbitMagnitude, (double)MathHelper.ToRadians(moon.orbitDegree), (int)(earth.x + earth.width * 0.5f), (int)(earth.y + earth.height * 0.5f));
            moon.x -= (int)(moon.width * 0.5f);
            moon.y -= (int)(moon.height * 0.5f);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            //call the Draw function from all the object
            thesun.Draw(spriteBatch, true);
            for (int i = 0; i < gameobjectlist.Count; ++i)
            {
                gameobjectlist[i].Draw(spriteBatch, true);
            }
            moon.Draw(spriteBatch, true);

            base.Draw(gameTime);
        }
    }
}
