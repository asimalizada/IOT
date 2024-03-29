﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IOTSystem.Entities.Concrete
{
    internal class User : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Username { get; set; }

        public byte[] Password { get; set; }
    }
}
