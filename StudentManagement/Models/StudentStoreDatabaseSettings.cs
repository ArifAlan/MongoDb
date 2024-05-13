namespace StudentManagement.Models
{
	public class StudentStoreDatabaseSettings: IStudentStoreDatabaseSettings
	{
		public string StudentCoursesCollectionName { get; set; }
		public string DatabaseName { get; set; }
		public string ConnectionString { get; set; }
	}
}
