using MongoDB.Driver;
using StudentManagement.Models;

namespace StudentManagement.Services
{
	public class StudentService : IStudentService
	{
		private IMongoCollection<Student> _student;

		public StudentService(IStudentStoreDatabaseSettings settings,IMongoClient mongoClient)
		{
			var database = mongoClient.GetDatabase(settings.DatabaseName);
			_student=database.GetCollection<Student>(settings.StudentCoursesCollectionName);
			
		}
		public Student Create(Student student)
		{
			_student.InsertOne(student);
			return student;
		}

		public Student GetById(string id)
		{
			return  _student.Find(student=>student.Id == id).FirstOrDefault();
		}

		public List<Student> GetList()
		{
			throw new NotImplementedException();
		}

		public void Remove(string id)
		{
			 _student.DeleteOne(student => student.Id == id);
		}

		public void Update(string id, Student student)
		{
			 _student.ReplaceOne(student => student.Id == id,student);
		}
	}
}
