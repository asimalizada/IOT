namespace IOTSystem.Entities.Concrete
{
    public class Balance : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Name) && Name.Length > 1
                  && Amount >= 0;
        }
    }
}
