using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MemoarWeb.Models
{
    public class Memoar
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [DisplayName("Name of Memoar")]
        [MinLength(4, ErrorMessage ="Can not less than 4 character")]
        public string Quotation { get; set; }

    }
}
