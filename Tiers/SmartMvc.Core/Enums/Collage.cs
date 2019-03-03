using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SmartMvc.Core.App_GlobalResources;

namespace SmartMvc.Core.Enums
{
    public enum Collage
    {
        //[Display(ResourceType = typeof(AppResource), Name = "PleaseSelect")]
        //آNone = 0,
        [Display(ResourceType = typeof(CollageResource), Name = "Sience")]
        Sience = 1,
        [Display(ResourceType = typeof(CollageResource), Name = "BusinessManagement")]
        BusinessManagement = 2,
        [Display(ResourceType = typeof(CollageResource), Name = "Arts")]
        Arts = 3,

    }

}
