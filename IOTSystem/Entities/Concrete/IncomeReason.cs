namespace IOTSystem.Entities.Concrete
{
    public class IncomeReason : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal? Amount { get; set; }

        public bool IsValid()
        {
            return string.IsNullOrWhiteSpace(Name) && Name.Length > 0;
        }
    }
}
