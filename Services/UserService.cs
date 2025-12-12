using System.Linq;
// <summary>
// Implementation of user services.


public class UserService : IUserSevice
{
    // Instance of OutputService to style output
    OutputService output = new OutputService();
    // Method to list all users
    public void ListUsers()
    {
        // Styling the output
        output.StyleOutput();
        Console.WriteLine("Listing all users...");
        output.StyleOutput();
        // Fetching users and their orders from the database
        using var db = new AppDBMySQLContext();
        //importing users
        var users = db.Users.ToList();
        // Displaying user details
        foreach (var item in users)
        {
            // Displaying order details
            Console.WriteLine($"ID: {item.UserID}");
            Console.WriteLine($"User: {item.UserName}");
            Console.WriteLine($"Email: {item.UserEmail}");
            output.StyleOutput();
        }
    }
    // List all orders
    public void ListOrders()
    {
        // Styling the output
        output.StyleOutput();
        Console.WriteLine("Listing all Orders...");
        output.StyleOutput();
        // Fetching users and their orders from the database
        using var db = new AppDBMySQLContext();
        //importing users and  orders   
        var users = db.Users.ToList();
        var orders = db.Orders.ToList();
        // Displaying user details
        foreach (var item in orders)
        {
            // Displaying order details
            Console.WriteLine($"Date: {item.OrderDate}");
            Console.WriteLine($"User: {item.User?.UserName}");
            Console.WriteLine($"Email: {item.User?.UserEmail}");
            output.StyleOutput();
        }
    }
    // Method to create a new user
    public void CreateNewUser(Users newUser)
    {
        // Adding the new user to the database
        using var db = new AppDBMySQLContext();
        // trying to add new user
        try
        {

            //adding new user
            db.Users.Add(newUser);
            db.SaveChanges(); // Save changes to the database
            Console.WriteLine("New user created successfully.");
            output.StyleOutput();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating user: {ex.Message}");
        }
    }

    public Users GetUserById(int userId)
    {
        using var context = new AppDBMySQLContext();
        //  Create the LINQ query
        var user = context.Users
            .Where(u => u.UserID == userId)
            .FirstOrDefault(); // Execute the query and return the first result or null
        return user;
    }

    public List<Users> GetUsersByName(string name)
    {
        using var context = new AppDBMySQLContext();
        var users = context.Users
            // .Where() Create a WHERE clause in SQL
            .Where(u => u.UserName.Contains(name))
            // .ToList() executes the query and returns a list
            .ToList();
        return users;
    }

    public bool UpdateUserEmail(int userId, string newEmail)
    {
        using (var context = new AppDBMySQLContext())
        {
            //  Get the user you want to modify (crucial)
            var userToUpdate = context.Users.Find(userId);

            if (userToUpdate != null)
            {
                //  Modify the properties of the tracked object
                userToUpdate.UserEmail = newEmail;

                //  Call SaveChanges. EF Core detects the change and executes the UPDATE.
                context.SaveChanges();
                Console.WriteLine("Users Updated!");
                return true;
            }
            return false;
        }
    }

    public bool DeleteUser(int userId)
    {
        using (var context = new AppDBMySQLContext())
        {
            //  Find the object
            var userToDelete = context.Users.Find(userId);

            if (userToDelete != null)
            {
                //  Mark the object to be removed
                context.Users.Remove(userToDelete);

                //  Execute the SQL DELETE statement                
                context.SaveChanges();
                Console.WriteLine("User was Delete!");
                return true;
            }
            return false;
        }
    }

    
}
