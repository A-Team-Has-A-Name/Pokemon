namespace Pokemon.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Items")]
    public class ItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int OwnerId { get; set; }
        public virtual TrainerModel Owner { get; set; }
    }
}
