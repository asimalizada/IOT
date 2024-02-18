using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IOTSystem.Entities.Concrete
{
    public class Income : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int ReasonId { get; set; }

        public DateTime Date { get; set; }

        public int UserId { get; set; }

        public decimal Amount { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Name) && Name.Length > 0
                && ReasonId != 0 && Date != null && Amount > 0;
        }
    }
}
