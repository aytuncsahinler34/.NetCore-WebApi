using System.ComponentModel.DataAnnotations;
using UserDemo.Core.Entities;

namespace UserDemo.Entities
{
	public class User : DbObjectBase, IEntity
	{
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public string Country { get; set; }
		[Required]
		public string City { get; set; }
		[Required]
		public int Age { get; set; }
	}
}
