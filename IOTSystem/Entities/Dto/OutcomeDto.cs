﻿using System;

namespace IOTSystem.Entities.Dto
{
    internal class OutcomeDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int ReasonId { get; set; }

        public string ReasonName { get; set; }

        public DateTime Date { get; set; }

        public int Alternative { get; set; }

        public string AlternativeName { get; set; }

        public bool IsAlternative { get; set; }

        public decimal Amount { get; set; }

        public int BalanceId { get; set; }

        public string BalanceName { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Name) && Name.Length > 0
                && ReasonId != 0 && Date != null;
        }
    }
}
