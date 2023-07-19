using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace shepOSMudBlazorCrud.Models
{
    [Table("shepOS User DataSchema")]
    public class UserDataSchema
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int uds_Reference { get; set; }

        [Required(ErrorMessage = "Data Schema.")]
        public string uds_DataSchemaCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Business Name.")]
        public string uds_BusinessName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Trade Name.")]
        public string uds_TradeName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Document.")]
        public string uds_DocumentNumber { get; set; } = string.Empty;

        public string uds_Address { get; set; } = string.Empty;
        public int uds_Number { get; set; }
        public string uds_Supplement { get; set; } = string.Empty;
        public string uds_ZipCode { get; set; } = string.Empty;
        public string uds_Neighborhood { get; set; } = string.Empty;
        public string uds_City { get; set; } = string.Empty;
        public string uds_StateAbbreviation { get; set; } = string.Empty;
        public string uds_StateName { get; set; } = string.Empty;
        public string uds_Phone { get; set; } = string.Empty;
        public string uds_CellPhone { get; set; } = string.Empty;
        public string uds_EMail { get; set; } = string.Empty;
        public string uds_HomePage { get; set; } = string.Empty;
        public int uds_Language { get; set; }
        public string uds_FooterText { get; set; } = string.Empty;
        public string uds_ReportTipoFile { get; set; } = string.Empty;
        public string uds_HeaderStampFile { get; set; } = string.Empty;
        public string uds_FooterStampFile { get; set; } = string.Empty;
    }
}
