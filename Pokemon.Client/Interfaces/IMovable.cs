using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.Client.Interfaces
{
    public interface IMovable
    {
        float MovementSpeed { get; }

        float DefaultMovementSpeed { get; }

        bool IsMoving { get; set; }
    }
}
