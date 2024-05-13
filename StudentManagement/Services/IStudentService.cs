using MongoDB.Bson;
using StudentManagement.Models;
using System.Linq.Expressions;

namespace StudentManagement.Services
{
	public interface IStudentService
	{
		Student Create(Student student);
		List<Student> GetList();
		Student GetById(string id);
		void Remove(string id);
		void Update(string id, Student student);
	}
}
