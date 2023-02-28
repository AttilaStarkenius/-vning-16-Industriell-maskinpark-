using Övning_16___Industriell_maskinpark__.Shared.Entities;

namespace ToDoBlazor.Services
{
    public class ToDoMockClient //: IToDoClient
    {
        private readonly HttpClient httpClient;

        public ToDoMockClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<IndustrialMachine>> GetAsync()
        {
            return new List<IndustrialMachine>()
            {
                new IndustrialMachine()
                {
                    Text = "Electric motor rider truck"
                },
                new IndustrialMachine()
                {
                    Text = "Electric motor narrow aisle truck"
                },
                new IndustrialMachine()
                {
                    Text = "Electric motor hand trucks or hand/rider truck",
                    Completed = true
                },
                new IndustrialMachine()
                {
                    Text = "Internal combustion engine trucks (solid/cushion tires)"
                }
            };
        }
    }
}
