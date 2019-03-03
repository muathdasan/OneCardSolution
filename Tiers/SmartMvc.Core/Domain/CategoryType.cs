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
    public class CategoryType
    {
        [Key]
        [Display(Name = "Id", ResourceType = typeof(AppResource))]
        public int CtId { get; set; }

        [Display(Name = "CtCode", ResourceType = typeof(AppResource))]
        [StringLength(20, ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "StringLengthError")]
        public string CtCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "CtTitle", ResourceType = typeof(AppResource))]
        [StringLength(100, ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "StringLengthError")]
        public string CtTitle { get; set; }

        [Display(Name = "CtDescription", ResourceType = typeof(AppResource))]
        public string CtDescription { get; set; }

        [Display(Name = "AddDate", ResourceType = typeof(AppResource))]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CtAddDate { get; set; }

        [Display(Name = "ModifyDate", ResourceType = typeof(AppResource))]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CtModifyDate { get; set; }

        public Guid CtUserId { get; set; }

        [Required(ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Priority", ResourceType = typeof(AppResource))]
        public int CtPriority { get; set; }

        public bool CtIsDeleted { get; set; }

        [Display(Name = "IsPublished", ResourceType = typeof(AppResource))]
        public bool CtIsPublished { get; set; }

        public virtual ICollection<Template> Templates { get; set; }
        public virtual ICollection<Owner> Owners { get; set; }
    }
}
