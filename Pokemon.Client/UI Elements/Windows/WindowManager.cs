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
    using Core;
    using Microsoft.Xna.Framework.Input;

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
        public void FinishedMessageWindow(int id, MessageWindow message)
        {
            switch (id)
            {
                case 1:
                    SessionEngine.Trainer.StopSurprise();
                    WorldEngine.RemovePendingPokemon();
                    break;
                case 2:
                    WaitForUserInput(message);
                    break;
            }
            
        }

        private void WaitForUserInput(MessageWindow message)
        {
            var keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.M))
            {
                message = null;
            }
            else if(message != null)
            {
                message.IsDone = false;
                WorldEngine.WindowManager.QueueWindow(message);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentWindow?.Draw(spriteBatch);
        }
    }
}
