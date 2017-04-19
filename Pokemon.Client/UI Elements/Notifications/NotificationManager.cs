namespace Pokemon.Client.UI_Elements.Notifications
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections;
    using System.Collections.Generic;
    using System;
    using System.Linq;

    public class NotificationManager : IUpdatable
    {
        private Queue<Notification> notifications;
        private Notification currentNotification;

        public NotificationManager()
        {
            notifications = new Queue<Notification>();
        }

        public void QueueNotification(Notification notification)
        {
            notifications.Enqueue(notification);
            ShowNextNotification();
        }

        private void ShowNextNotification()
        {
            if (!notifications.Any() || currentNotification != null)
            {
                return;
            }
            currentNotification = notifications.Dequeue();
        }

        public void Update(GameTime gameTime)
        {
            if (currentNotification == null)
            {
                return;
            }
            currentNotification.Update(gameTime);

            if (currentNotification.IsDone)
            {
                currentNotification = null;
                ShowNextNotification();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentNotification?.Draw(spriteBatch);
        }
    }
}
