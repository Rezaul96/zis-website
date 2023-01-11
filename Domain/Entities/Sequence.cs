using Domain.Data.Abstracts;


namespace Domain.Entities
{
    public class Sequence : BaseEntity<Guid>
    {
        //public int Position { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
