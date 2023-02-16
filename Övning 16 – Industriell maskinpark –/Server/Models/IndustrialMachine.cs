namespace Övning_16___Industriell_maskinpark__.Client.Models
{
    public class IndustrialMachine
{
        public Guid Id { get; set; }
        public string Name { get; set; }

        public bool currentStatus { get; set; }

        public string latestDataSentFromMachine { get; set; }
    }
}
