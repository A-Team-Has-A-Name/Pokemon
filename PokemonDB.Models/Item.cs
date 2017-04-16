namespace Pokemon.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public virtual Trainer Owner { get; set; }
    }
}
