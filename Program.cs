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
            Console.WriteLine("5. Update User's Email");
            Console.WriteLine("6. Delete a User");
            string switch_on = Console.ReadLine();
            Console.Clear();
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
                    //Search user by Id
                case "4":
                    Console.WriteLine("Enter the ID for serch");
                    id = int.Parse(Console.ReadLine());
                    var user = userService.GetUserById(id);
                    Console.WriteLine($"{user.UserName} <--> {user.UserEmail}");
                    break;
                    //Update a Email user
                case "5":
                    Console.WriteLine("Enter record's ID");
                    id = int.Parse(Console.ReadLine());
                     user = userService.GetUserById(id);
                    Console.WriteLine("Now Email: " + user.UserEmail + "\nEnter new Email");
                    string email = Console.ReadLine();
                    userService.UpdateUserEmail(id, email);
                    break;
                    //Delete a user
                case "6":
                    Console.WriteLine("Enter record's ID");
                    id = int.Parse(Console.ReadLine());
                    user = userService.GetUserById(id);
                    Console.WriteLine("UserData:" + user + "\n Deleted? : Y");
                    if (Console.ReadLine().ToUpper() == "Y")
                        userService.DeleteUser(id);
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
