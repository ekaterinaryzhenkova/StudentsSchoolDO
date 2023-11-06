using DbModels;
using Provider;

namespace HW3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var userRepository = new UserRepository();

            List<DbUser> users = userRepository.GetUsersEF();

            foreach (var item in users)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }
    }
}