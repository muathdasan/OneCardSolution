﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OneCard.MVC.Helpers
{
    public static class DataAnnotationHelpers
    {
        public static string GetDisplayValue(this Enum instance)
        {
            var fieldInfo = instance.GetType().GetMember(instance.ToString()).Single();
            var descriptionAttributes = fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[];
            if (descriptionAttributes == null) return instance.ToString();
            return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].GetName() : instance.ToString();

        }

    }
}