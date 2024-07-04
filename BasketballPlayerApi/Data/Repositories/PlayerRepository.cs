using BasketballPlayerApi.Data.Interfaces;
using BasketballPlayerApi.Models;

namespace BasketballPlayerApi.Data.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        public readonly SampleDatabaseContext _databaseContext;

        public PlayerRepository( SampleDatabaseContext databaseContext )
        {
            _databaseContext = databaseContext;
        }

        public async Task<int> CreatePlayer( Player player )
        {
            _databaseContext.Players.Add( player );
            await _databaseContext.SaveChangesAsync();
            return player.PlayerId;
        }

        public async Task<bool> DeletePlayer( int playerId )
        {
            var player = await _databaseContext.Players.Where( x => x.PlayerId == playerId ).FirstOrDefaultAsync();
            if ( player != null )
            {
                _databaseContext.Players.Remove( player );
                await _databaseContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<int> EditPlayer( Player player )
        {
            var playerToEdit = await _databaseContext.Players.Where( x => x.PlayerId == player.PlayerId ).FirstOrDefaultAsync();
            playerToEdit.Name = player.Name;
            playerToEdit.JerseyNumber = player.JerseyNumber;
            await _databaseContext.SaveChangesAsync();
            return playerToEdit.PlayerId;
        }

        public async Task<List<Player>> GetPlayers()
        {
            var result = await _databaseContext.Players.ToListAsync();
            return result;
        }
    }
}
