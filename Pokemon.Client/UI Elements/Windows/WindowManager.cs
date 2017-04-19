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
    using Core.Engines;
    using Message;

    public class WindowManager : IWindowQueuer
    {
        private readonly Queue<MessageWindow> windows;
        private MessageWindow currentWindow;
        private List<int> windowIds;
        public WindowManager()
        {
            windows = new Queue<MessageWindow>();
            windowIds = new List<int>();
        }

        public void QueueWindow(MessageWindow window)
        {
            if (!windowIds.Contains(window.Id))
            {
                windows.Enqueue(window);
                windowIds.Add(window.Id);
            }

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
            if (currentWindow == null)
            {
                return;
            }
            currentWindow.Update(gameTime);

            if (currentWindow.IsDone)
            {
                windowIds.Remove(currentWindow.Id);
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
