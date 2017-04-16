namespace Pokemon.Client.Input
{
    using GameObjects.Units.PlayableCharacters;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Input;

    public static class InputHandler
    {
        private static KeyboardState previousKeyboardState;
        private static KeyboardState currentKeyboardState;

        public static void HandleInput(GameTime gameTime, Trainer trainer)
        {
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            //Stop movement, keep facing direction
            if (currentKeyboardState != previousKeyboardState)
            {
                trainer.MakeUnitIdle();
            }

            //Movement
            if (currentKeyboardState.IsKeyDown(Keys.Right))
            {
                trainer.ValidateMovementRight();
            }

            if (currentKeyboardState.IsKeyDown(Keys.Left))
            {
                trainer.ValidateMovementLeft();
            }

            if (currentKeyboardState.IsKeyDown(Keys.Up))
            {
                trainer.ValidateMovementUp();
            }

            if (currentKeyboardState.IsKeyDown(Keys.Down))
            {
                trainer.ValidateMovementDown();
            }
        }
    }
}
