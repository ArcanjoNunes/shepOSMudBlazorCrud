using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace shepOSMudBlazorCrud.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome deve ser preenchido.")]
        [StringLength(64)]
        public string FirstName { get; set; } = "";

        [Required(ErrorMessage = "Sobrenome deve ser preenchido.")]
        [StringLength(64)]
        public string LastName { get; set; } = "";

        [StringLength(32)]
        public string PhoneNumber { get; set; } = "";

        public int Region { get; set; } = 1;

        public string RegionTitle => Region switch
        {
            1 => "Sudeste",
            2 => "Sul",
            3 => "Centro-Oeste",
            4 => "Norte",
            5 => "Nordeste",
            _ => "-"
        };

        public string Validate()
        {
            ValidationContext context = new ValidationContext(this, serviceProvider: null, items: null);
            List<ValidationResult> results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(this, context, results, true);

            if (isValid == false)
            {
                StringBuilder sbrErrors = new StringBuilder();
                foreach (var validationResult in results)
                {
                    sbrErrors.AppendLine(validationResult.ErrorMessage);
                }
                return sbrErrors.ToString();
            }
            return "";
        }

    }
}
