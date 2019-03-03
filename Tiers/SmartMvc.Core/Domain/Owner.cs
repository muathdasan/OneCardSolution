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
    public class Owner
    {
        [Key]
        [Display(Name = "Id", ResourceType = typeof(AppResource))]
        public int OwnerId { get; set; }

        [Display(Name = "OwnerCode", ResourceType = typeof(AppResource))]
        [StringLength(20, ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "StringLengthError")]
        public string OwnerCode { get; set; }

        [Display(Name = "Description", ResourceType = typeof(AppResource))]
        public string OwnerDescription { get; set; }

        [Display(Name = "Address", ResourceType = typeof(AppResource))]
        public string OwnerAddress { get; set; }

        [Required(ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "FirstName", ResourceType = typeof(AppResource))]
        [StringLength(50, ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "StringLengthError")]
        public string OwnerFirstName { get; set; }

        [Display(Name = "SecondName", ResourceType = typeof(AppResource))]
        [StringLength(50, ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "StringLengthError")]
        public string OwnerSecondName { get; set; }

        [Required(ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "FamilyName", ResourceType = typeof(AppResource))]
        [StringLength(50, ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "StringLengthError")]
        public string OwnerFamilyName { get; set; }

        [Display(Name = "Name", ResourceType = typeof(AppResource))]
        [StringLength(100, ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "StringLengthError")]
        public string OwnerFullNameEn { get; set; }
        
        [EmailAddress(ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "InvalidEmail")]
        [Display(Name = "Email", ResourceType = typeof(AppResource))]
        [StringLength(100, ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "StringLengthError")]
        public string OwnerEmail { get; set; }

        [Display(Name = "Phone", ResourceType = typeof(AppResource))]
        [StringLength(20, ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "StringLengthError")]
        public string OwnerPhone { get; set; }

        [Display(Name = "Mobile", ResourceType = typeof(AppResource))]
        [StringLength(20, ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "StringLengthError")]
        public string OwnerMobile { get; set; }

        [Required(ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "NationalNo", ResourceType = typeof(AppResource))]
        [StringLength(20, ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "StringLengthError")]
        public string OwnerNationalNo { get; set; }

        [Required(ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "RequiredField")]  ////////enum
        [Display(Name = "Gender", ResourceType = typeof(AppResource))]
        public int? OwnerGender { get; set; }

        [Display(Name = "PlaceOfBirth", ResourceType = typeof(AppResource))]    ////////enum
        public int? OwnerPlaceOfBirth { get; set; }

        [Display(Name = "DateOfBirth", ResourceType = typeof(AppResource))]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? OwnerDateOfBirth { get; set; }

        [Display(Name = "BloodType", ResourceType = typeof(AppResource))]   ////////enum
        public int? OwnerBloodType { get; set; }

        [Display(Name = "PassportNo", ResourceType = typeof(AppResource))]
        [StringLength(50, ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "StringLengthError")]
        public string OwnerPassportNo { get; set; }

        [Display(Name = "PassportPlace", ResourceType = typeof(AppResource))]
        [StringLength(100, ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "StringLengthError")]
        public string OwnerPassportPlace { get; set; }

        [Display(Name = "PassportEndDate", ResourceType = typeof(AppResource))]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? OwnerPassportEndDate { get; set; }

        [Display(Name = "Collage", ResourceType = typeof(AppResource))]    ////////enum
        public int? OwnerCollage { get; set; }

        [Required(ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "RequiredField")]  ////////enum
        [Display(Name = "Nationality", ResourceType = typeof(AppResource))]    
        public int? OwnerNationality { get; set; }

        [Display(Name = "Status", ResourceType = typeof(AppResource))]
        public bool OwnerStatus { get; set; }

        [Required(ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "CategoryType", ResourceType = typeof(AppResource))]
        public int CategoryTypeId { get; set; }

        [Required(ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "RequiredField")]
        [Display(Name = "Template", ResourceType = typeof(AppResource))]
        public int? OwnerTemplateId { get; set; }


        [Display(Name = "DocumentNo", ResourceType = typeof(AppResource))]
        [StringLength(50, ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "StringLengthError")]
        public string OwnerDocumentNo { get; set; }

        [Display(Name = "DocumentDate", ResourceType = typeof(AppResource))]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? OwnerDocumentDate { get; set; }

        [Display(Name = "HafizaNo", ResourceType = typeof(AppResource))]
        [StringLength(50, ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "StringLengthError")]
        public string OwnerHafizaNo { get; set; }

        [Display(Name = "HafizaDate", ResourceType = typeof(AppResource))]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? OwnerHafizaDate { get; set; }
        
        [Display(Name = "IqamaNo", ResourceType = typeof(AppResource))]
        [StringLength(50, ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "StringLengthError")]
        public string OwnerIqamaNo { get; set; }

        [Display(Name = "IqamaPlace", ResourceType = typeof(AppResource))]
        [StringLength(50, ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "StringLengthError")]
        public string OwnerIqamaPlace { get; set; }

        [Display(Name = "OwnerIqamaStartDate", ResourceType = typeof(AppResource))]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? OwnerIqamaStartDate { get; set; }

        [Display(Name = "IqamaEndDate", ResourceType = typeof(AppResource))]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? OwnerIqamaEndDate { get; set; }

        [Display(Name = "ImagePath", ResourceType = typeof(AppResource))]
        [StringLength(100, ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "StringLengthError")]
        public string OwnerImagePath { get; set; }

        [Display(Name = "ContentType", ResourceType = typeof(AppResource))]
        [StringLength(25, ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "StringLengthError")]
        public string OwnerImageContentType { get; set; }

        [Display(Name = "ImageExtension", ResourceType = typeof(AppResource))]
        [StringLength(100, ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "StringLengthError")]
        public string OwnerImageExtension { get; set; }

        [Display(Name = "ImageLength", ResourceType = typeof(AppResource))]
        [StringLength(100, ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "StringLengthError")]
        public string OwnerImageLength { get; set; }

        [Display(Name = "Document1", ResourceType = typeof(AppResource))]
        [StringLength(150, ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "StringLengthError")]
        public string OwnerAttachFile1 { get; set; }

        [Display(Name = "Document2", ResourceType = typeof(AppResource))]
        [StringLength(150, ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "StringLengthError")]
        public string OwnerAttachFile2 { get; set; }

        [Display(Name = "Document3", ResourceType = typeof(AppResource))]
        [StringLength(150, ErrorMessageResourceType = typeof(AppResource), ErrorMessageResourceName = "StringLengthError")]
        public string OwnerAttachFile3 { get; set; }

        [Display(Name = "AddDate", ResourceType = typeof(AppResource))]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime OwnerAddDate { get; set; }

        [Display(Name = "ModifyDate", ResourceType = typeof(AppResource))]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime OwnerModifyDate { get; set; }

        public Guid OwnerUserId { get; set; }

        public Guid? OwnerModifyUserId { get; set; }

        public bool OwnerIsDeleted { get; set; }

        [ForeignKey("CategoryTypeId")]
        public virtual CategoryType CategoryType { get; set; }

        [ForeignKey("OwnerTemplateId")]
        public virtual Template Template { get; set; }

    }
}
