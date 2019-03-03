using SmartMvc.Core.App_GlobalResources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMvc.Core.Domain
{
    public class Terminal
    {
        [Key]
        [Display(Name = "Id", ResourceType = typeof(AppResource))]
        public int TermId { get; set; }

        [Display(Name = "TermCode", ResourceType = typeof(AppResource))]
        [StringLength(20, ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "StringLengthError")]
        public string TermCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "TermTitle", ResourceType = typeof(AppResource))]
        [StringLength(150, ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "StringLengthError")]
        public string TermTitle { get; set; }

        [Display(Name = "TermDescription", ResourceType = typeof(AppResource))]
        public string TermDescription { get; set; }

        [Display(Name = "AddDate", ResourceType = typeof(AppResource))]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime TermAddDate { get; set; }

        [Display(Name = "ModifyDate", ResourceType = typeof(AppResource))]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime TermModifyDate { get; set; }

        public Guid TermUserId { get; set; }

        public Guid? TermModifyUserId { get; set; }

        [Required(ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Priority", ResourceType = typeof(AppResource))]
        public int TermPriority { get; set; }

        public bool TermIsDeleted { get; set; }

        [Display(Name = "IsPublished", ResourceType = typeof(AppResource))]
        public bool TermIsPublished { get; set; }


    }
}
