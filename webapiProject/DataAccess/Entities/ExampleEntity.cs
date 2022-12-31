using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapiProject.DataAccess.Entities
{

    public class ExampleEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column("DataExample")]
        public DateTime DateExample { get; set; }
        
        [Column("IntExample")]
        public int IntExample { get; set; }

        [Column("PropertyExample")]
        public int PropertyExample => IntExample + 1000;

        [MinLength(2)]
        [MaxLength(1000)]
        [Column("StringExample", TypeName ="varchar")]
        public string? StringExample { get; set; }

        [Column("StringExample", TypeName = "varchar(Max)")]
        public string? StringExampleMax { get; set; }
    }

}
