using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace BigClock
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //Game World
        SpriteFont font;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>("SpriteFont1");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            /*Create a vector2 object named "textVector" and a position to draw the text.
            Vector2 textVector = new Vector2(20, 30);*/

            /*Draw font to screen.
            _spriteBatch.Begin();
            _spriteBatch.DrawString
                (font, "Hello World", textVector, Color.Red); // Font used, content/type displayed, screen position, text color.
            _spriteBatch.End();*/

            /*Create a for loop that adds additional layers of colored text.
            Color nowColor = new Color(0,0,0,20);
            for(int layer = 0; layer < 10; layer++)
            {
                _spriteBatch.DrawString
                (font, nowString, nowVector, nowColor); //Font used, content/type displayed, screen position, text color.
                nowVector.X++;
                nowVector.Y++;
            }

            nowVector.X = nowVector.X + 4; //Moves text drawing position.
            nowVector.Y = nowVector.Y + 4; //Moves text drawing position.
            _spriteBatch.DrawString(font, nowString, nowVector, Color.Yellow);*/

            // Create a vector2 object to get current time and position text on screen.
            DateTime nowDateTime = DateTime.Now;
            String nowString = nowDateTime.ToLongTimeString();
            Vector2 nowVector = new Vector2(170, 350);
            int layer;

            _spriteBatch.Begin();

            //Draw the shadow (bg layer)
            Color nowColor = new Color(0, 0, 0, 20);
            for (layer = 0; layer < 10; layer++)
            {
                _spriteBatch.DrawString
                (font, nowString, nowVector, nowColor); //Font used, content/type displayed, screen position, text color.
                nowVector.X++;
                nowVector.Y++;
            }

            //Draw the solid part of the characters (mid layer)
            nowColor = Color.Gray;
            for (layer = 0; layer < 10; layer++)
            {
                _spriteBatch.DrawString
                (font, nowString, nowVector, nowColor); //Font used, content/type displayed, screen position, text color.
                nowVector.X++;
                nowVector.Y++;
            }

            //Draw top layer of characters
            _spriteBatch.DrawString(font, nowString, nowVector, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}