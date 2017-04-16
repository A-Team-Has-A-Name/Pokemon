using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Client.Interfaces
{
    public interface IAnimatable : IDrawable
    {
        int CurrentFrame { get; }

        int BasicAnimationFrameCount { get; }

        double Timer { get; }

        int Delay { get; }

        Rectangle FrameRect { get; }
    }
}
