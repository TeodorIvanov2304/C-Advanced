using System;
using NUnit.Framework;
using System.Linq;
using System.Collections.Generic;

namespace SocialMediaManager.Tests
{
    public class Tests
    {
        

        [Test]
        public void Influencer_Ctor_WorkingCorrectly()
        {
            Influencer influencer = new("Joro", 5);
            Assert.IsNotNull(influencer);
            Assert.That("Joro", Is.EqualTo(influencer.Username));
            Assert.That(5, Is.EqualTo(influencer.Followers));
        }

        [Test]
        public void InfluencerRepository_Ctor_WorkingCorrectly()
        {
            InfluencerRepository repo = new();
            Assert.IsNotNull(repo);
            Assert.That(repo.Influencers.Count, Is.EqualTo(0));
        }

        [Test]
        public void RegisterInfluencer_ReturnsNull()
        {
            Influencer influencer = new Influencer("Garo", 10);
            InfluencerRepository repo = new();
            repo.RegisterInfluencer(influencer);
            Influencer result = repo.GetInfluencer("Maro");
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() =>
            {
                repo.RegisterInfluencer(result);
            });
            string expectedResult = "Influencer is null (Parameter 'influencer')";
            Assert.That(expectedResult, Is.EqualTo(ex.Message));
        }

        [Test]
        public void RegisterInfluencer_AlreadyExists()
        {
            Influencer influencer = new Influencer("Garo", 10);
            InfluencerRepository repo = new();
            repo.RegisterInfluencer(influencer);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() =>
            {
                repo.RegisterInfluencer(influencer);
            });
            string expectedResult = $"Influencer with username Garo already exists";
            Assert.That(expectedResult, Is.EqualTo(ex.Message));
        }

        [Test]
        public void RegisterInfluencer_WorkingCorrectly()
        {
            Influencer influencer = new Influencer("Garo", 10);
            InfluencerRepository repo = new();
            string actualResult = repo.RegisterInfluencer(influencer);
            string expectedResult = $"Successfully added influencer Garo with 10";
            Assert.That(expectedResult,Is.EqualTo(actualResult));

        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("\t")]
        public void RemoveInfluencer_ThrowsExcepitonWhenUsernameNull(string username)
        {
            Influencer influencer = new Influencer(username, 10);
            InfluencerRepository repo = new();
            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() =>
            {
                repo.RemoveInfluencer(username);
            });

            string expectedResult = "Username cannot be null (Parameter 'username')";
            Assert.That(expectedResult,Is.EqualTo(ex.Message));
        }
        [Test]
        public void RemoveInfluencer_ReturnsTrue()
        {
            Influencer influencer = new Influencer("Garo", 10);
            InfluencerRepository repo = new();
            repo.RegisterInfluencer(influencer);

            bool isRemoved = true;
            Assert.That(isRemoved, Is.EqualTo(repo.RemoveInfluencer("Garo")));

        }

        [Test]

        public void GetInfluencerWithMostFollowers_RetusnTrue()
        {
            Influencer influencer = new Influencer("Garo", 10);
            Influencer influencer2 = new Influencer("Maro", 20);
            InfluencerRepository repo = new();
            repo.RegisterInfluencer(influencer);
            repo.RegisterInfluencer(influencer2);
            Influencer toCheck = repo.GetInfluencerWithMostFollowers();
            Assert.That(toCheck.Username,Is.EqualTo(influencer2.Username));
            Assert.That(toCheck.Followers,Is.EqualTo(20));
        }
    }
}