using System;
namespace Mocks.Tests
{
    public class ScoreUpdater : IScoreUpdater
    {
        public Student UpdateScore(Student student, float score)
        {
            student.Score = student.Score + score;
            return student;
        }
    }
}
