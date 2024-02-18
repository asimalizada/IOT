using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IOTSystem.Entities.Concrete
{
    internal class Outcome : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int ReasonId { get; set; }

        public DateTime Date { get; set; }

        public int Alternative { get; set; }

        public bool IsAlternative { get; set; }

        public decimal Amount { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Name) && Name.Length > 0
                && ReasonId != 0 && Date != null;
        }
    }
}
