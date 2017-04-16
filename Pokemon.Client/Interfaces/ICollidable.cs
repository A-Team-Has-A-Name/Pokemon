namespace Pokemon.Client.Interfaces
{
    using Microsoft.Xna.Framework;

    public interface ICollidable
    {
        Rectangle BoundingBox { get; set; }
        int BoundingBoxX { get; set; }
        int BoundingBoxY { get; set; }
    }
}
