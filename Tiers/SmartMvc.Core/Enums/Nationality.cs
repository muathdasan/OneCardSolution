﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SmartMvc.Core.App_GlobalResources;

namespace SmartMvc.Core.Enums
{
    public enum Nationality
    {
        //[Display(ResourceType = typeof(AppResource), Name = "PleaseSelect")]
        //آNone = 0,
        [Display(ResourceType = typeof(NationalityResource), Name = "Saudi")]
        Saudi = 1,
        [Display(ResourceType = typeof(NationalityResource), Name = "Jordan")]
        Jordan = 2,
        [Display(ResourceType = typeof(NationalityResource), Name = "Syria")]
        Syria = 3,
        [Display(ResourceType = typeof(NationalityResource), Name = "Eygept")]
        Eygept = 4,
        [Display(ResourceType = typeof(NationalityResource), Name = "Yemen")]
        Yemen = 5,
    }

}
