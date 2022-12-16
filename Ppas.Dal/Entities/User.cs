namespace Ppas.Models.Entities;

[Table("users", Schema = "ppas")]
[Index(nameof(Name), IsUnique = true)]
public partial class User
{
    [Required]
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required, StringLength(50)]
    public string Name { get; set; } = "";

    [Column("quadrant")]
    [Required]
    [Comment("Quadrant identifier")]
    public QuadrantType Quadrant { get; set; }

}
