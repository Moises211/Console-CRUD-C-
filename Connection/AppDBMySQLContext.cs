using Microsoft.EntityFrameworkCore;

/// <summary>
/// * Instalar antes los paquetes de conexion:
/// 
/// version de la comunidad(recomendada): 
/// dotnet add package Pomelo.EntityFrameworkCore.MySql --version 8.0.2 
/// dotnet add package Microsoft.EntityFrameworkCore.MySql --version 8.0.2
/// * Nota: se debe de crear la base de datos con las entidades y atributos
/// tomar los atributos que estan en models
/// </summary>
public class AppDBMySQLContext : DbContext
{
    // Database connection parameters
    private string Host = "localhost";
    private string Port = "3307"; // PUERTO ESTÁNDAR DE MYSQL
    private string Database = "dbproducts";//crear base en MySQL
    private string Username = "root";//Reemplazar por usuario local
    private string Password = "usbw";//Reemplazar por contraseña local

    // Define DbSets for each model
    public DbSet<Users> Users { get; set; }
    public DbSet<Orders> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // CAMBIO 1: Definir la versión del Servidor MySQL/MariaDB
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 32)); // Ejemplo: MySQL 8.0.32
                                                                      //Tambien se puede usar MariaDB:
                                                                      // var serverVersion = new ServerVersion(new Version(10, 5, 8), ServerType.MariaDb);             
                                                                      // O usar la detección automática (más común):
                                                                      // var serverVersion = ServerVersion.AutoDetect(connectionString);

        // CAMBIO 2: Usar UseMySql en lugar de UseNpgsql
        string connectionString = @$"Server={Host};
        Port={Port};
        Database={Database};
        Uid={Username}; 
        Pwd={Password};"; // MySQL usa 'Pwd' o 'Password', // MySQL usa 'Uid' o 'User ID' en lugar de 'Username'

        optionsBuilder.UseMySql(
            connectionString,
            serverVersion
        );
    }

    // Configure model mappings
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //  CAMBIO 3: MySQL generalmente no usa esquemas (schemas) como PostgreSQL (public)
        // Por defecto, las entidades se mapearán a tablas con el mismo nombre en la base de datos seleccionada.
        modelBuilder.Entity<Users>().ToTable("Users");
        modelBuilder.Entity<Orders>().ToTable("Orders");

        // Si desea especificar el motor (engine) de la tabla (ej. InnoDB), puede usar:
        // modelBuilder.Entity<Users>().ToTable("Users", t => t.HasEngine("InnoDB"));
    }

    // Method to close the database connection
    public void CloseConnection()
    {
        Console.WriteLine("Closing database connection...");
        base.Dispose(); // Dispose the context to close the connection
        Console.WriteLine("Database connection closed.");
    }
}