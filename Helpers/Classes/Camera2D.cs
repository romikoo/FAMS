using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
//using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Content;
using winForms = System.Windows.Forms;

namespace Helpers
{
    public class Camera2D : GameComponent
    {
        #region Members

        private Vector2 position;
        private float rotation;
        private float scale; //zoom
        private float speed;

        private Matrix transform;
        private Microsoft.Xna.Framework.Graphics.GraphicsDevice graphicsDevice;
        bool manualcamera;

        #endregion

        #region Properties

        public Matrix Transform
        {
            get { return transform; }
            set { transform = value; }
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        public float Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public bool ManualCamera
        {
            get { return manualcamera; }
            set { manualcamera = value; }
        }

        #endregion

        #region Methods

        public Camera2D(Game game, bool manualcamera)
            : base(game)
        {
            graphicsDevice = game.GraphicsDevice;
            this.manualcamera = manualcamera;
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            //Our start position, rotation, scale, and translation speed.
            //These are all changeable by property but I'm sure a function would work just as well/better,
            //feel free to experiment.
            position = Vector2.Zero;
            rotation = 0;
            scale = 1;
            speed = 5;

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            if (manualcamera)
            {
                //translation controls, left stick xbox or WASD keyboard
                if (Keyboard.GetState().IsKeyDown(Keys.A)
                    || GamePad.GetState(PlayerIndex.One).DPad.Left == ButtonState.Pressed
                    || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X < 0) { position.X -= speed; }
                if (Keyboard.GetState().IsKeyDown(Keys.D)
                    || GamePad.GetState(PlayerIndex.One).DPad.Right == ButtonState.Pressed
                    || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X > 0) { position.X += speed; }
                if (Keyboard.GetState().IsKeyDown(Keys.S)
                    || GamePad.GetState(PlayerIndex.One).DPad.Down == ButtonState.Pressed
                    || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y < 0) { position.Y += speed; }
                if (Keyboard.GetState().IsKeyDown(Keys.W)
                    || GamePad.GetState(PlayerIndex.One).DPad.Up == ButtonState.Pressed
                    || GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y > 0) { position.Y -= speed; }

                //rotation controls, right stick or QE keyboard
                if (Keyboard.GetState().IsKeyDown(Keys.Q)
                    || GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X < 0) { rotation -= 0.01f; }
                if (Keyboard.GetState().IsKeyDown(Keys.E)
                    || GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X > 0) { rotation += 0.01f; }

                //zoom/scale controls, left/right triggers or CZ keyboard
                if (Keyboard.GetState().IsKeyDown(Keys.C)
                    || GamePad.GetState(PlayerIndex.One).Triggers.Right > 0) { scale -= 0.001f; }
                if (Keyboard.GetState().IsKeyDown(Keys.Z)
                    || GamePad.GetState(PlayerIndex.One).Triggers.Left > 0) { scale += 0.001f; }
            }
            //
            transform = Matrix.CreateScale(new Vector3((scale * scale * scale), (scale * scale * scale), 0))
                * Matrix.CreateRotationZ(rotation)
                * Matrix.CreateTranslation(new Vector3(
                                            (graphicsDevice.Viewport.Width / 2) + position.X,
                                            (graphicsDevice.Viewport.Height / 2) + position.Y, 0)
            );

            base.Update(gameTime);
        }

        public void toTopLeft()
        {
            position = new Vector2(-graphicsDevice.Viewport.Width / 2, -graphicsDevice.Viewport.Height / 2);
        }

        public Vector2 rePosition(Vector2 currentMouse, Vector2 fromPosition)
        {

            return new Vector2(
                currentMouse.X - fromPosition.X * (float)Math.Pow(this.Scale, 3) - graphicsDevice.Viewport.Width / 2,
                currentMouse.Y - fromPosition.Y * (float)Math.Pow(this.Scale, 3) - graphicsDevice.Viewport.Height / 2);
        }

        public Vector2 worldCoordinates(Vector2 currentMouse)
        {
            float dX = currentMouse.X - graphicsDevice.Viewport.Width / 2 - this.Position.X;
            float dY = currentMouse.Y - graphicsDevice.Viewport.Height / 2 - this.Position.Y;
            return new Vector2(dX / (float)Math.Pow(this.Scale, 3), dY / (float)Math.Pow(this.Scale, 3));       
        }

        #endregion
    }
}
