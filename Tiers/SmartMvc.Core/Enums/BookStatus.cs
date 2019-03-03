using SmartMvc.Core.App_GlobalResources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMvc.Core.Enums
{
    public enum BookStatus
    {
        [Display(ResourceType = typeof(AppResource), Name = "In")]
        In = 1,
        [Display(ResourceType = typeof(AppResource), Name = "Out")]
        Out = 2,
    }
}
