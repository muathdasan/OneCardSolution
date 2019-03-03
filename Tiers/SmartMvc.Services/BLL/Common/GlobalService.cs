using SmartMvc.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMvc.Services.BLL.Common
{
    public class GlobalService
    {
        public AppModel _db = new AppModel();

        public DateTime CurrentDate { get { return DateTime.Now; } }
        public bool IsDeleted { get { return false; } }
        public bool IsPublished { get { return true; } }
        public int Priority { get { return 1; } }
        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
