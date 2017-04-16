namespace Pokemon.Client.Content
{
    using Pokemon.Client.Interfaces;
    public static class Collision
    {
        public static bool CheckForCollisionBetweenCollidables(ICollidable firstObj, ICollidable secondObj)
        {
            return firstObj.BoundingBox.Intersects(secondObj.BoundingBox);
        }
    }
}
