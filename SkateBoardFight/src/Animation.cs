using Microsoft.Xna.Framework;
using System;

namespace SkateBoardFight.src
{
    public struct SpriteSheet
    {
        public Rectangle[] Cells;

        public Rectangle[] SliceSpriteSheet(int totalFrames, int indentFrame, Vector2 Dimensions)
        {
            Rectangle[] frames = new Rectangle[totalFrames];

            int width = (int)Dimensions.X;
            int height = (int)Dimensions.Y;

            int i = 0;
            float Iterations = (float)totalFrames / (float)indentFrame;

            for (int y = 0; y < Iterations; y++)
            {
                for (int x = 0; x < indentFrame; x++)
                {
                    try
                    {
                        frames[i] = new Rectangle(x * width, y * height, width, height);
                        i++;
                    }
                    catch
                    {
                        
                    }
                }
            }

            return frames;
        }
    }

    //Plays the animation
    public class Animation
    {
        public int CurrentFrame = 0;

        public int StartFrame = 0;
        public int EndFrame = 0;
        public float AnimationSpeed = 100;

        float elapsedTime = 0;

        public bool Playing = true;
        public bool Looping = true;

        //Animates the animation
        public int Animate(GameTime gameTime)
        {
            if (elapsedTime >= AnimationSpeed && Playing)
            {
                CurrentFrame++;

                if (CurrentFrame > EndFrame)
                {
                    if (Looping)
                    {
                        CurrentFrame = StartFrame;
                    }
                    else
                    {
                        Playing = false;
                    }
                }

                elapsedTime = 0;
                return CurrentFrame;
            }
            else
            {
                elapsedTime += Time.DeltaTime_InMS(gameTime);
                return CurrentFrame;
            }
        }

        //Stops/Pauses the animation
        public void StopAnimation()
        {
            Playing = false;
            elapsedTime = 0;
        }

        //Restarts/Starts the animation from the begining
        public void StartAnimation()
        {
            if (!Playing)
            {
                Playing = true;
                CurrentFrame = StartFrame;
                elapsedTime = 0;
            }
        }
    }
}
