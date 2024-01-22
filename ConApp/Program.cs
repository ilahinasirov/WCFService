using Entities2;
using ServiceReference1;
using WcfServiceApp.DataContext;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Enter user information:");

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Surname: ");
        string surname = Console.ReadLine();

        Console.Write("Username: ");
        string username = Console.ReadLine();

        Console.Write("Password: ");
        string password = Console.ReadLine();


        ServiceReference1.User user = new ServiceReference1.User()
        {
            Name= name,
            SurName= surname,
            UserName= username,
            Password= password
        };

        using(Service1Client client = new Service1Client())
        {
            try
            {
                await client.AddUserAsync(user);
                Console.WriteLine("User Added Successfully");

                
            }
            catch (Exception ex)
            {
               Console.WriteLine($"User can Not Added, Because of {ex.Message}");
            }
           
        }
    }

}
