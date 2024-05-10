//using System.ComponentModel.DataAnnotations;
//using WebApiDemo.Models;

//namespace WebApplication1.Models
//{
//    public class TodoTag
//    {
//        [Key]

//        public Guid ID { get; set; }
//        [Required]
//        [StringLength(100, MinimumLength = 1)]
//        [RegularExpression("^\\w+$", MatchTimeoutInMilliseconds = 1000)]
//        public string Name { get; set; } = string.Empty;

//        public List<TodoEntry> TaggedEntries { get; } = [];
//    }
//}
