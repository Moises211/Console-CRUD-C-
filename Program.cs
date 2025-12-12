public class Program
{
    public static void Main(string[] args)
    {
        using var db = new AppDBMySQLContext();
        IUserSevice userService = new UserService();
        bool option = true;
        int id = 0;
        do
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1. Create a new user");
            Console.WriteLine("2. List all users");
            Console.WriteLine("3. List all orders");
            Console.WriteLine("4. Get User By Id");
            string switch_on = Console.ReadLine();
            switch (switch_on)
            {
                case "1":
                    // Create a new user
                    Users newUser = new Users();
                    Console.Write("Enter user name: ");
                    newUser.UserName = Console.ReadLine();
                    Console.Write("Enter user email: ");
                    newUser.UserEmail = Console.ReadLine();
                    userService.CreateNewUser(newUser);
                    break;
                case "2":
                    // List all users
                    userService.ListUsers();
                    break;
                case "3":
                    //List all orders
                    userService.ListOrders();
                    break;
                case "4":
                    Console.WriteLine("Enter the ID for serch");
                    id = int.Parse(Console.ReadLine());
                    userService.GetUserById(id);
                    break;
                case "5":
                    Console.WriteLine("Enter de ID of the record");
                    id = int.Parse(Console.ReadLine());
                    var user = userService.GetUserById(id);
                    Console.WriteLine("Email anterior: "+user.UserEmail);
                    
                    break;
                default:
                    option = false;
                    break;
            }
        } while (option);
        // Close the database connection        
        db.CloseConnection();
    }
}
