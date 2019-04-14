using System;
namespace Mocks
{
    public class ScoreManager
    {
        private IDataManager dataManager;

        public ScoreManager(IDataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public void AddScore(string studentId, float score)
        {
            Student student = dataManager.GetByKey(studentId);
            dataManager.Save(student);
            student.Score = score;
        }
    }
}
