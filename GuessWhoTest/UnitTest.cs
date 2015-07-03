using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GuessWho.Controllers;
using GuessWho.Models;

namespace GuessWho
{
    [TestClass]
    public class UnitTest
    {
        private Character character;
        private Game game;
        private Services services;
                
        [TestInitialize()]
        public void Initialize()
        {            
            character = new Character()
            {
                Bald = true,
                Beard = false,
                EyeColour = "Blue",
                Gender = (int)Gender.male,
                Glasses = true,
                HairColour = "Blonde",
                Hat = false,
                Moustache = true,
                PartitionKey = "Default",
                RowKey = "Ian"
            };
            game = new Game()
            {
                Turns = 0,
                Character = "Ian",
                RowKey = Guid.NewGuid().ToString(),
                PartitionKey = "+123456123456",
                Status = "Live"
            };
            services = new Services(null)
            {
                Game = game,
                Character = character
            };
        }

        [TestMethod]
        public void MaleTest()
        {
            Assert.IsTrue(services.gender(Gender.male));
        }

        [TestMethod]
        public void FemaleTest()
        {
            Assert.IsFalse(services.gender(Gender.female));
        }

        [TestMethod]
        public void HairTest()
        {
            Assert.IsTrue(services.hair("Blonde"));
        }

        [TestMethod]
        public void EyesTest()
        {
            Assert.IsTrue(services.eyes("Blue"));
        }

        [TestMethod]
        public void HatTest()
        {
            Assert.IsFalse(services.hat());
        }

        [TestMethod]
        public void BeardTest()
        {
            Assert.IsFalse(services.beard());
        }

        [TestMethod]
        public void GlassesTest()
        {
            Assert.IsTrue(services.glasses());
        }

        [TestMethod]
        public void MoustacheTest()
        {
            Assert.IsTrue(services.moustache());
        }

        [TestMethod]
        public void BaldTest()
        {
            Assert.IsTrue(services.bald());
        }

        [TestMethod]
        public void GuessTest()
        {
            Assert.IsTrue(services.guess("Ian"));
        }

        [TestMethod]
        public void TurnTest()
        {
            services.bald();
            services.moustache();
            Assert.IsTrue(game.Turns == 2);
        }

        [TestMethod]        
        public void WinTest()
        {
            services.guess("Ian");
            Assert.IsTrue(game.Status.ToLower() == "won");
        }
    }
}
