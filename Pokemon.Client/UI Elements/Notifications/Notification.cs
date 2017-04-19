using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Client.UI_Elements
{
    public class Notification : Text
    {
        private const int messageDuration = 500;
        private double timer;
        
        public Notification(string message, SpriteFont font, Color color) : base(message, font, new Vector2(15), color)
        {
            this.IsDone = false;          
        }      

        public override void Update(GameTime gametime)
        {
            this.timer += gametime.ElapsedGameTime.TotalMilliseconds;

            if(this.timer > messageDuration)
            {
                this.IsDone = true;
                return;
            }
        }

        public bool IsDone { get; set; }
    }
}
