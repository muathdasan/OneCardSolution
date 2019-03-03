using SmartMvc.Core.App_GlobalResources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMvc.Core.Enums
{
    public enum Gender
    {
        //[Display(ResourceType = typeof(AppResource), Name = "PleaseSelect")]
        //آNone = 0,
        [Display(ResourceType = typeof(AppResource), Name = "Male")]
        Male = 1,
        [Display(ResourceType = typeof(AppResource), Name = "Female")]
        Female = 2,
    }
}
