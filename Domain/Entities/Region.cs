using Domain.Data.Abstracts;


namespace Domain.Entities
{
    public class Region : BaseEntity<Guid>
    {
        public string Name { get; set; }
    }
}
