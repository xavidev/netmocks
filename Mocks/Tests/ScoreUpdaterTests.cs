using System;
using NUnit.Framework;

namespace Mocks.Tests
{
    [TestFixture]
    public class ScoreUpdaterTests
    {
        [Test]
        public void ScoreUpdaterWorks()
        {
            ScoreUpdater updater = new ScoreUpdater();
            Student student = updater.UpdateScore(
                new Student(), 5f);
            Assert.AreEqual(student.Score, 5f);
        }
    }
}
