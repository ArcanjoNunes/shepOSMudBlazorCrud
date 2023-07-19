using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shepOSMudBlazorCrud.Models
{
    [Table("shepOS ComboboxItems")]
    public class ComboboxItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Reference { get; set; }
        
        public int Class { get; set; }
        
        public int Code { get; set; }

        [Required(ErrorMessage = "Titulo deve ser preenchido.")]
        [StringLength(128)]
        public string Title { get; set; } = string.Empty;

    }
    public class ComboboxItemDTO
    {
        [Key]
        public int Code { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}
