using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OneCard.MVC.Models.DTOs
{
    public class CategoryTypeDto
    {
        [Key]
        public int CtId { get; set; }

        [StringLength(20)]
        public string CtCode { get; set; }

        [StringLength(100)]
        public string CtTitle { get; set; }

        public string CtDescription { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CtAddDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CtModifyDate { get; set; }

        public Guid CtUserId { get; set; }
        public int CtPriority { get; set; }
        public bool CtIsDeleted { get; set; }
        public bool CtIsPublished { get; set; }
    }
}