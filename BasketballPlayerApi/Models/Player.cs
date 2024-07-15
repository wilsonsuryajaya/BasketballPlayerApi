namespace BasketballPlayerApi.Models
{
    /// <summary>
    /// Entity Framework
    /// dotnet tool install --global dotnet-ef --version 6.*
    /// dotnet ef dbcontext scaffold "Server=.;Database=SampleDatabase;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models --force
    /// dotnet ef dbcontext scaffold "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\Databases\\SampleDB.mdf;Integrated Security=True;Connect Timeout=30" Microsoft.EntityFrameworkCore.SqlServer -o Models --force
    /// </summary>
    public partial class Player
    {
        public int PlayerId { get; set; }

        public string? Name { get; set; }

        public int? JerseyNumber { get; set; }
    }
}
