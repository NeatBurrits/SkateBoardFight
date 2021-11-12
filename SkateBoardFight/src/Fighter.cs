using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;

namespace SkateBoardFight.src
{
    class Fighter : GameObject
    {
        //Movement variables
        public float Acceleration = 0.2f;
        public float Deacceleration = 5.0f;
        public float MidAirDeacceleration = 0.05f;
        float DeaccelerationTime = 0.0f;

        //Jump variables
        public float JumpForce = -17;

        Vector2 TerminalVelocity = new Vector2(15, 24);
        bool grounded = false;

        Animation Idle = new Animation()
        {
            StartFrame = 0,
            EndFrame = 1,
            AnimationSpeed = 100,
            Looping = true
        };
        Animation Ollie = new Animation()
        {
            StartFrame = 8,
            EndFrame = 14,
            AnimationSpeed = 25,
            Playing = false,
            Looping = false
        };
        Animation Step = new Animation()
        {
            StartFrame = 8,
            EndFrame = 11,
            AnimationSpeed = 150,
            Playing = false,
            Looping = false
        };
        Animation Push = new Animation()
        {
            StartFrame = 2,
            EndFrame = 7,
            AnimationSpeed = 60,
            Looping = true
        };

        //Innit
        public Fighter()
        {
            sprite = Art.AlanItalian;
            spriteBounds = new Rectangle(0,0,16,16);
            Orgin = new Vector2(8, 8);

            Size = new Vector2(16, 16);
            Scale = 2;

            Position = new Vector2(8,8) * Scale;
        }

        public override void Update(GameTime gameTime)
        {
            //If the fighter isn't grounded apply gravity
            if (!grounded)
            {
                Velocity.Y += GlobalVariables.Gravity;
            }

            //If the position is below the window shift it up
            if (Position.Y > GlobalVariables.Window_Height - Size.Y)
            {
                grounded = true;
                Position.Y = GlobalVariables.Window_Height - Size.Y;
                Velocity.Y = 0;
            }

            Move(gameTime);
            Jump(gameTime);

            //Clamps velocity
            Velocity.X = MathHelper.Clamp(Velocity.X, -TerminalVelocity.X, TerminalVelocity.X);
            Velocity.Y = MathHelper.Clamp(Velocity.Y, -TerminalVelocity.Y, TerminalVelocity.Y);

            //Adds the velocity to the position
            Position += Velocity;
        }

        void Move(GameTime gameTime)
        {
            //Sets the value to either 1 or -1 depending on the 
            int h = Input.GetAxis(Keys.D, Keys.A);

            if (grounded)
            {
                Velocity.X += Acceleration * h;
            }

            if (h == 0)
            {
                //If none of the movement buttons are pressed then animate
                spriteBounds = Art.AlanItalianSS.Cells[Idle.Animate(gameTime)];

                //Sets the deaceleration rate depending on wether or not the player is grounded
                float Deac = grounded ? Deacceleration : MidAirDeacceleration;
                DeaccelerationTime = Time.DeltaTime_InSec(gameTime) * Deac;

                //Lerps the x velocity from it's inital state to zero
                Velocity.X = MathHelper.Lerp(Velocity.X, 0, DeaccelerationTime);
            }
            else
            {
                spriteBounds = grounded ? Art.AlanItalianSS.Cells[Push.Animate(gameTime)] : Art.AlanItalianSS.Cells[Idle.Animate(gameTime)];
            }
        }

        void Jump(GameTime gameTime)
        {
            //If the space bar is pressed then set the Y velocity to the jump force
            if (Input.KeyPressed(Keys.Space) && grounded)
            {
                Velocity.Y = JumpForce;
                Ollie.StartAnimation();

                grounded = false;
            }

            //If the animation is playing then continue playing it
            if (Ollie.Playing)
            {
                spriteBounds = Art.AlanItalianSS.Cells[Ollie.Animate(gameTime)];
            }
        }

        public override void Draw()
        {
            base.Draw();
        }
    }
}