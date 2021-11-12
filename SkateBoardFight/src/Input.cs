using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

using System;

namespace SkateBoardFight.src
{
    public class Input
    {
        static KeyboardState keyboardState;
        static KeyboardState lastKeyboardState;

        public static KeyboardState GetKeyState()
        {
            lastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            return keyboardState;
        }

        public static int GetAxis(Keys input1, Keys input2)
        {
            keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(input1))
            {
                return 1;
            }
            else if (keyboardState.IsKeyDown(input2))
            {
                return -1;
            }

            return 0;
        }

        public static bool GetKeyDown(Keys input)
        {
            return keyboardState.IsKeyDown(input);
        }

        public static bool GetKeyUp(Keys input)
        {
            return keyboardState.IsKeyUp(input);
        }

        public static bool KeyPressed(Keys input)
        {
            return keyboardState.IsKeyDown(input) && !lastKeyboardState.IsKeyDown(input);
        }

        public static Keys[] GetPressedKeys()
        {
            return keyboardState.GetPressedKeys();
        }

        public static bool LeftClick()
        {
            return Mouse.GetState().LeftButton == ButtonState.Pressed;
        }

        public static bool RightClick()
        {
            return Mouse.GetState().RightButton == ButtonState.Pressed;
        }
    }
}
