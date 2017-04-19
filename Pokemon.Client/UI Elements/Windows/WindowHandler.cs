namespace Pokemon.Client.UI_Elements.Windows
{
    using System;
    using Pokemon.Client.Interfaces;
    using System.Collections;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework.Content;
    using System.Linq;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class WindowHandler : IWindowQueuer
    {
        private readonly Queue<Window> windows;
        private Window currentWindow;

        public WindowHandler()
        {
            windows = new Queue<Window>();
        }

        public void QueueWindow(Window window)
        {
            windows.Enqueue(window);
            ShowNextWindow();
        }

        private void ShowNextWindow()
        {
            if(!windows.Any() || currentWindow != null)
            {
                return;
            }
            currentWindow = windows.Dequeue();
        }

        public void Update(GameTime gameTime)
        {
            if(currentWindow == null)
            {
                return;
            }
            currentWindow.Update(gameTime);

            if (currentWindow.IsDone)
            {
                currentWindow = null;
                ShowNextWindow();
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentWindow?.Draw(spriteBatch);
        }
    }
}
