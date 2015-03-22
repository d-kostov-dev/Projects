namespace MVCAppTemplate.DatabaseModels
{
    using System.ComponentModel.DataAnnotations;

    using MVCAppTemplate.DatabaseModels.Base;
    
    public class Post : AuditInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [MinLength(20)]
        public string Content { get; set; }
    }
}
