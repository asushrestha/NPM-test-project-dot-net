namespace Domain
{
    public class Nurse
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime CreatedAt { get; set; }

        public string Contact { get; set; }
        public string Email { get; set; }
    }
}