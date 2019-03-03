using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneCard.MVC.Utilities
{
    public class ManageUsers
    {
        public static Guid GetId()
        {
            return Guid.NewGuid();
        }
    }
}