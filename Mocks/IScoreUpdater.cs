using System;
namespace Mocks
{
    public interface IScoreUpdater
    {
        Student UpdateScore(Student student, float score);
    }
}
