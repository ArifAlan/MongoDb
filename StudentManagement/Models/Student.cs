using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace StudentManagement.Models
{
	[BsonIgnoreExtraElements]//MongoDB'deki belgelerle ilişkilendirilmiş sınıflarda, belirli bir sınıfın dışında kalan fazla alanların (extra elements) yok sayılmasını sağlayan bir niteliktir.

	public class Student
	{
		[BsonId]//Bu özelliği belgenin birincil anahtarı yapmak için
		[BsonRepresentation(BsonType.ObjectId)]//Mongo, 'den string öğesine dönüştürmeyi ObjectIdişler.
		public string Id { get; set; }=string.Empty;

		[BsonElement("name")]
		public string Name { get; set; } = string.Empty;

		[BsonElement("graduated")]// özniteliğinin değeri graduated MongoDB koleksiyonundaki özellik adını temsil eder.
		public bool IsGraduated { get; set; }
		[BsonElement("courses")]
		public string[]? Courses { get; set; }

		[BsonElement("gender")]
		public string Gender { get; set; } = string.Empty;

		[BsonElement("age")]
		public int Age { get; set; }

	}
}
