using SmartMvc.Core.App_GlobalResources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMvc.Core.Domain
{
    public class FoodMenu
    {
        [Key]
        [Display(Name = "Id", ResourceType = typeof(AppResource))]
        public int FMenuId { get; set; }

        [Display(Name = "FMenuCode", ResourceType = typeof(AppResource))]
        [StringLength(20, ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "StringLengthError")]
        public string FMenuCode { get; set; }

        [Required(ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "FMenuTitle", ResourceType = typeof(AppResource))]
        [StringLength(150, ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "StringLengthError")]
        public string FMenuTitle { get; set; }

        [Display(Name = "FMenuDescription", ResourceType = typeof(AppResource))]
        public string FMenuDescription { get; set; }

        [Required(ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "FMenuPrice", ResourceType = typeof(AppResource))]
        public int FMenuPrice { get; set; }

        [Display(Name = "AddDate", ResourceType = typeof(AppResource))]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FMenuAddDate { get; set; }

        [Display(Name = "ModifyDate", ResourceType = typeof(AppResource))]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FMenuModifyDate { get; set; }

        public Guid FMenuUserId { get; set; }

        public Guid? FMenuModifyUserId { get; set; }

        [Required(ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Priority", ResourceType = typeof(AppResource))]
        public int FMenuPriority { get; set; }

        public bool FMenuIsDeleted { get; set; }

        [Display(Name = "IsPublished", ResourceType = typeof(AppResource))]
        public bool FMenuIsPublished { get; set; }

    }
}
