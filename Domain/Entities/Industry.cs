using Domain.Data.Abstracts;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Industry : BaseEntity<Guid>
    {
        public string Name { get; set; }
    }
}
