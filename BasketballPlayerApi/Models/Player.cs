namespace BasketballPlayerApi.Models
{
    /// <summary>
    /// dotnet ef dbcontext scaffold "Server=.;Database=SampleDatabase;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models --force
    /// </summary>
    public partial class Player
    {
        public int PlayerId { get; set; }
        public string? Name { get; set; }
        public int? JerseyNumber { get; set; }
        public int? TeamId { get; set; }

        //public virtual Team? Team { get; set; }
    }
}
