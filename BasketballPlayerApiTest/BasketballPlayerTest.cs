using BasketballPlayerApi.Controllers;
using BasketballPlayerApi.Data.Interfaces;
using BasketballPlayerApi.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BasketballPlayerApiTest
{
    [TestClass]
    public class BasketballPlayerTests
    {
        private readonly Mock<IPlayerRepository> _playerRepoMock = new Mock<IPlayerRepository>();
        Random random = new Random();

        [TestMethod]
        public async Task Get_WithExistingClients_ReturnsAllClients()
        {
            // Arrange
            var activelist = new List<Player>() { CreateRandomPlayer(), CreateRandomPlayer(), CreateRandomPlayer() };

            _playerRepoMock.Setup(repo=> repo.GetPlayers()).ReturnsAsync( activelist );

            var controller = new PlayersController( _playerRepoMock.Object );

            // Act

            var actualPlayers = await controller.GetPlayers();
            var players = actualPlayers as ObjectResult;

            //Assert
            players.Value.Should().BeEquivalentTo(
                activelist,
                options => options.ComparingByMembers<Player>()
            );
        }

        private Player CreateRandomPlayer()
        {
            return new Player()
            {
                PlayerId = random.Next( 1000 ),
                Name = "Test",
                JerseyNumber = random.Next( 1000 )
            };
        }
    }
}