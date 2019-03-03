using SmartMvc.Core.App_GlobalResources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMvc.Core.Domain
{
    public class Book
    {
        [Key]
        [Display(Name = "Id", ResourceType = typeof(AppResource))]
        public int BookId { get; set; }

        [Display(Name = "BookCode", ResourceType = typeof(AppResource))]
        [StringLength(20, ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "StringLengthError")]
        public string BookCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "BookTitle", ResourceType = typeof(AppResource))]
        [StringLength(150, ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "StringLengthError")]
        public string BookTitle { get; set; }

        [Display(Name = "BookPrice", ResourceType = typeof(AppResource))]
        public int? BookPrice { get; set; }

        [Required(ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "BookStatus", ResourceType = typeof(AppResource))]
        public int? BookStatus { get; set; }

        [Display(Name = "BookAuthor", ResourceType = typeof(AppResource))]
        [StringLength(100, ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "StringLengthError")]
        public string BookAuthor { get; set; }

        [Display(Name = "BookYear", ResourceType = typeof(AppResource))]
        public int? BookYear { get; set; }

        [Display(Name = "Quantity", ResourceType = typeof(AppResource))]
        public int? BookQuantity { get; set; }

        [Display(Name = "AddDate", ResourceType = typeof(AppResource))]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BookAddDate { get; set; }

        [Display(Name = "ModifyDate", ResourceType = typeof(AppResource))]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BookModifyDate { get; set; }

        public Guid BookUserId { get; set; }

        [Required(ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Priority", ResourceType = typeof(AppResource))]
        public int BookPriority { get; set; }

        public bool BookIsDeleted { get; set; }

       


    }
}
