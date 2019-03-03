using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SmartMvc.Core.App_GlobalResources;

namespace SmartMvc.Core.Enums
{
    public enum BloodType
    {
        //[Display(ResourceType = typeof(AppResource), Name = "PleaseSelect")]
        //آNone = 0,
        [Display(ResourceType = typeof(BloodTypeResource), Name = "ANegative")]
        ANegative = 1,
        [Display(ResourceType = typeof(BloodTypeResource), Name = "APositive")]
        APositive = 2,
        [Display(ResourceType = typeof(BloodTypeResource), Name = "ABNegative")]
        ABNegative = 3,
        [Display(ResourceType = typeof(BloodTypeResource), Name = "ABPositive")]
        ABPositive = 4,
        [Display(ResourceType = typeof(BloodTypeResource), Name = "BNegative")]
        BNegative = 5,
        [Display(ResourceType = typeof(BloodTypeResource), Name = "BPositive")]
        BPositive = 6,
        [Display(ResourceType = typeof(BloodTypeResource), Name = "ONegative")]
        ONegative = 7,
        [Display(ResourceType = typeof(BloodTypeResource), Name = "OPositive")]
        OPositive = 8,
    }
}
