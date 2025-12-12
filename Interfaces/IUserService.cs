// <summary>
// Interface for user services.
public interface IUserSevice
{
    // Method to list all users
    void ListUsers();
    // Method to create a new user
    void CreateNewUser(Users newUser);
    // Method to list all Orders
    void ListOrders();
    //Method to search for ID
    Users GetUserById(int userId);
    //Method to search and list for NameUser
    List<Users> GetUsersByName(string name);
    //Method to Update a record
    bool UpdateUserEmail(int userId, string newEmail);
    //Method to Delete a saved record
    bool DeleteUser(int userId);
}