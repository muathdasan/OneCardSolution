using SmartMvc.Core.App_GlobalResources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMvc.Core.Domain
{
    public class Template
    {
        [Key]
        [Display(Name = "Id", ResourceType = typeof(AppResource))]
        public int TempId { get; set; }

        [Display(Name = "TempCode", ResourceType = typeof(AppResource))]
        [StringLength(20, ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "StringLengthError")]
        public string TempCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "TempTitle", ResourceType = typeof(AppResource))]
        [StringLength(150, ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "StringLengthError")]
        public string TempTitle { get; set; }

        [Display(Name = "TempPath", ResourceType = typeof(AppResource))]
        [StringLength(100, ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "StringLengthError")]
        public string TempPath { get; set; }

        [Display(Name = "TempDescription", ResourceType = typeof(AppResource))]
        public string TempDescription { get; set; }

        [Required(ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "CategoryType", ResourceType = typeof(AppResource))]
        public int CategoryTypeId { get; set; }

        [Display(Name = "TempIsDefualt", ResourceType = typeof(AppResource))]
        public bool TempIsDefualt { get; set; }

        [Display(Name = "AddDate", ResourceType = typeof(AppResource))]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime TempAddDate { get; set; }

        [Display(Name = "ModifyDate", ResourceType = typeof(AppResource))]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime TempModifyDate { get; set; }

        public Guid TempUserId { get; set; }

        public Guid? TempModifyUserId { get; set; }

        [Required(ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Priority", ResourceType = typeof(AppResource))]
        public int TempPriority { get; set; }

        public bool TempIsDeleted { get; set; }

        [Display(Name = "IsPublished", ResourceType = typeof(AppResource))]
        public bool TempIsPublished { get; set; }


        [ForeignKey("CategoryTypeId")]
        public virtual CategoryType CategoryType { get; set; }


        public virtual ICollection<Owner> Owners { get; set; }
    }
}
