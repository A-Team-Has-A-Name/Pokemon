namespace Pokemon.Client.UI_Elements.Windows.Message
{
    using Microsoft.Xna.Framework;
    using Pokemon.Client.Core;
    using Pokemon.Client.Core.Engines;
    using System.Text;

    public static class Messages
    {
        public static void DisplayCaughtPokemonMessageWindow()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("Caught Pokemon: ");

            foreach(var p in SessionEngine.Trainer.CaughtPokemon)
            {
                stringBuilder.Append($"{p.Name} ");
            }

            var messageWindow = new MessageWindow(new Vector2(640, 400), 460, 400, stringBuilder.ToString(), 2, 6);
            messageWindow.Font = SessionEngine.PokemonFont20;

            WorldEngine.WindowManager.QueueWindow(messageWindow);
        }

        public static void EncounteredPokemonMessageWindow(int trainerY, string pokemonName, bool isCaught)
        {
            int y = getWindowY(trainerY);
            var messageWindow = new MessageWindow(new Vector2(15, y), 1150, 200, 1);
            messageWindow.AddPage($"Encountered a wild {pokemonName}!", false);
            messageWindow.AddPage("Attempting to catch ", true);

            if (isCaught)
            {
                messageWindow.AddPage($"Successfully caught {pokemonName}.", false);
            }
            else
            {
                messageWindow.AddPage("The pokemon ran away.", false);
            }

            WorldEngine.WindowManager.QueueWindow(messageWindow);
        }

        private static int getWindowY(int trainerY)
        {
            int yWindow = 650;

            if (trainerY > SessionEngine.WindowHeight / 2)
            {
                yWindow = 15;
            }
            return yWindow;
        }

    }
}
