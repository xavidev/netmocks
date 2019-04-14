using System;
namespace Mocks
{
    public interface IDataManager
    {
        Student GetByKey(string studentId);
        void Save(Student dummyStudent);
    }
}
