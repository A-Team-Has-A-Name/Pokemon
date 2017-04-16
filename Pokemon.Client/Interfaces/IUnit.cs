using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Client.Interfaces
{
    public interface IUnit : IGameObject, IMovable, IUpdatable, IAnimatable, IFacingDirection
    {
       //bool IsMovingLeft { get; set; }
       //bool IsMovingRight { get; set; }
       //bool IsMovingUp { get; set; }
       //bool IsMovingDown { get; set; }
    }
}
