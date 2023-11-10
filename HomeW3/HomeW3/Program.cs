using Client;

namespace HomeW3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var clientsRepository = new ClientsRepository();

            clientsRepository.UpdateClient("Artem Ivamov", "9006475040", Guid.Parse("5F1B137C-F39B-4C3F-8F27-F86AD492E8E9"));

            var clientsString = clientsRepository.GetClientsFromDB();

            Console.WriteLine(clientsString);
        }
    }
}