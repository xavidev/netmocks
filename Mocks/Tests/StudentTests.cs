using System;
using NUnit.Framework;
using Rhino.Mocks;

namespace Mocks.Tests
{
    [TestFixture]
    public class StudentTests
    {
        /*En este caso detectamos que el colaborador es un mock con dos 
         * expectativas, guardar un estudiante y actualizar el Score. 
         Además tiene un problema de fragilidad, ya que conoce cómo
         funciona el SUT más de lo que debería. Sabe que el SUT hace
         dos llamadas a su colaborador y además conoce el orden y ni si quiera
         estamos comprobando si los puntos han subido al marcador.
         En este caso hay que separar la responsabilidad del SUT de actualizar
         el marcador.*/
        [Test]
        public void AddStudentScore()
        {
            string studentId = "23145";
            float score = 8.5f;
            Student dummyStudent = new Student();

            IDataManager dataManagerMock =
                MockRepository.GenerateStrictMock<IDataManager>();
            dataManagerMock.Expect(
                x => x.GetByKey(studentId)).Return(dummyStudent);
            dataManagerMock.Expect(
                x => x.Save(dummyStudent));

            ScoreManager smanager = new ScoreManager(dataManagerMock);
            smanager.AddScore(studentId, score);

            dataManagerMock.VerifyAllExpectations();
        }

        [Test]
        public void AddStudentScoreResponsabilityOK()
        {
            float score = 8.5f;
            Student dummyStudent = new Student();

            IScoreUpdater scoreUpdaterMock =
                MockRepository.GenerateStrictMock<IScoreUpdater>();
            scoreUpdaterMock.Expect(
                y => y.UpdateScore(dummyStudent, score)).Return(dummyStudent);
            IDataManager dataManagerMock =
                MockRepository.GenerateStrictMock<IDataManager>();
            dataManagerMock.Expect(
                x => x.Save(dummyStudent));

            ScoreManagerResponsabilityOk smanager =
                new ScoreManagerResponsabilityOk(dataManagerMock, scoreUpdaterMock);
            smanager.AddScore(dummyStudent, score);

            dataManagerMock.VerifyAllExpectations();
            scoreUpdaterMock.VerifyAllExpectations();
        }

        //Podemos usar Stubs para partir más el test i probar solo
        //el aspecto que nos interese, haciendo así asl test menos
        //frágil.
        [Test]
        public void AddStudentWithStub()
        {
            float score = 8.5f;
            Student dummyStudent = new Student();

            IScoreUpdater scoreUpdaterMock =
                MockRepository.GenerateStrictMock<IScoreUpdater>();
            scoreUpdaterMock.Expect(
                y => y.UpdateScore(dummyStudent, score)).Return(dummyStudent);
            //Realizamos un Stub del Datamaneger que en este test nos da igual.
            IDataManager dataManagerMock =
                MockRepository.GenerateStrictMock<IDataManager>();
            dataManagerMock.Stub(
                x => x.Save(dummyStudent));
        }
    }
}


