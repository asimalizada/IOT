namespace IOTSystem.Entities.Concrete
{
    internal class User : IEntity
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public byte[] Password { get; set; }
    }
}
