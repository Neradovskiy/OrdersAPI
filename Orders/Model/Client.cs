using Orders.Model.Service;

namespace Orders.Model
{
    public class Client
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public Client()
        {
            ClientId = default;
            Name = string.Empty;
        }
    }
}
