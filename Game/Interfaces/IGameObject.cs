namespace Pokemon.Client.Interfaces
{
    using Microsoft.Xna.Framework;
    public interface IGameObject : IDrawable, ICollidable
    {
        Vector2 Position { get; set; }
    }
}
