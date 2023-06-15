namespace Domain
{
    public class Nurse
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public DateTime CreatedAt { get; set; } =DateTime.UtcNow.AddMonths(0);

        public string Contact { get; set; }
        public string Email { get; set; }
        public bool IsRoundingManager {get;set;} = false;
    }
}