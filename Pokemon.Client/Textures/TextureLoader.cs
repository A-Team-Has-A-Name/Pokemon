using Pokemon.Client.Core.Engines;

namespace Pokemon.Client.Textures
{
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    public static class TextureLoader
    {
        public static Texture2D TrainerSheet { get; private set; }
        public static Texture2D PokemonSheet { get; private set; }
        public static Texture2D ButtonSheet { get; private set; }
        public static Texture2D TextBoxSheet { get; private set; }
        public static Texture2D WorldBackground { get; private set; }
        public static Texture2D MenuBackgorund { get; private set; }
        public static Texture2D ChatWindowBackground { get; private set; }

        //For debugging -  drawing the bounding boxes
        public static Texture2D TheOnePixel { get; private set; }

        public static int ButtonTextureHeight = 111;
        public static int ButtonTextureWidth = 306;
        public static int TextBoxWidth = 798;
        public static int TextBoxHeigth = 195;
        public static int MenuBackgorundWidth = SessionEngine.WindowWidth;
        public static int MenuBackgorundHeigth = SessionEngine.WindowHeight;


        public static void Load(ContentManager content)
        {
            TrainerSheet = content.Load<Texture2D>("Sprites/RedTrainer_96x96");
            MenuBackgorund = content.Load<Texture2D>("Sprites/MenuBG");
            TextBoxSheet = content.Load<Texture2D>("Sprites/textBox");
            PokemonSheet = content.Load<Texture2D>("Sprites/Pokemon_100x100");
            ButtonSheet = content.Load<Texture2D>("Sprites/Button");
            WorldBackground = content.Load<Texture2D>("Sprites/WorldBackground_1180x860");
            ChatWindowBackground = content.Load<Texture2D>("Windows/ChatWindow_30x30");
            TheOnePixel = content.Load<Texture2D>("Sprites/TheOnePixel");
        }
    }
}
