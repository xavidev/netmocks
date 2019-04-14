using System;
namespace Mocks
{
    public class ScoreManagerResponsabilityOk
    {
        private IDataManager dataManager;
        private IScoreUpdater scoreUpdater;

        public ScoreManagerResponsabilityOk(IDataManager dataManager,
            IScoreUpdater scoreUpdater)
        {
            this.dataManager = dataManager;
            this.scoreUpdater = scoreUpdater;
        }

        /* Se puede mejorar el diseño si el ScoreManager sabe guardar
         * objetos Student       
        public void AddScore(string studentId, float score)
        {
            Student student = dataManager.GetByKey(studentId);
            dataManager.Save(student);
            scoreUpdater.UpdateScore(student, score);
        }
        */

        public void AddScore(Student student, float score)
        {
            dataManager.Save(student);
            scoreUpdater.UpdateScore(student, score);
        }
    }
}
