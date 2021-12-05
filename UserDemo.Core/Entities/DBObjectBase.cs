using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace UserDemo.Core.Entities
{
    public abstract class DbObjectBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataMember]
        [Key]
        public int Id { get; set; }

		[DataMember]
		public DateTimeOffset CreatedDate { get; set; }

		[DataMember]
		public DateTimeOffset? ModifiedDate { get; set; }

		[DataMember]
		[Timestamp]
		public byte[] Timestamp { get; set; }

		[DataMember]
		public int Creator { get; set; }

		[DataMember]
		public int? Modifier { get; set; }
	}
}
