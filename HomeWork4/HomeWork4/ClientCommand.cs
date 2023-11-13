using DbModels;
using Provider;

namespace CLient
{
    public class ClientCommand
    {
        ClientRepository _clientRepository = new();

        public void AddClient(string name, string phoneNumber)
        {
            var Client = new DbClient
            {
                Id = Guid.NewGuid(),
                Name = name,
                PhoneNumber = phoneNumber,
            };

            _clientRepository.CreateClient(Client);
        }

        public void RemoveClient(Guid id)
        {
            _clientRepository.DeleteClient(id);
        }

        public string GetClient(Guid id)
        {
            DbClient dbClient = _clientRepository.GetClient(id);

            string strClient = $"{dbClient.Id} - {dbClient.Name} - {dbClient.PhoneNumber}";

            Console.WriteLine(strClient);

            return strClient;
        }

        public void GetClients()
        {
            List<string> _strClients = new();

            List<DbClient> _clients = _clientRepository.GetClients();

            foreach (DbClient client in _clients)
            {
                Console.WriteLine($"{client.Id} - {client.Name} - {client.PhoneNumber}");
                _strClients.Add($"{client.Id} - {client.Name} - {client.PhoneNumber}");
            }
        }

        public void UpdateClient(Guid id, string name, string phoneNumber)
        {
            _clientRepository.EditClient(id, name, phoneNumber);
        }
    }
}
