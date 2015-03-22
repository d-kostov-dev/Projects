namespace MVCAppTemplate.DatabaseModels
{
    using System.ComponentModel.DataAnnotations;

    using MVCAppTemplate.DatabaseModels.Base;
    
    public class Category : AuditInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
    }
}
