using SmartMvc.Core.Domain;
using SmartMvc.Services.BLL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMvc.Services.BLL
{
   public class TerminalService : GlobalService
    {
        public int Add(Terminal term)
        {
            if (term == null)
            {
                return 0;
            }
            term.TermAddDate = term.TermModifyDate = CurrentDate;
            term.TermIsDeleted = IsDeleted;
            term.TermIsPublished = IsPublished;
            term.TermPriority = term.TermPriority > 0 ? term.TermPriority : Priority;
            _db.Terminals.Add(term);
            return _db.SaveChanges();
        }
        public int Edit(Terminal term)
        {
            if (term == null)
            {
                return 0;
            }
            Terminal item = _db.Terminals.Find(term.TermId);
            item.TermTitle = term.TermTitle;
            item.TermDescription = term.TermDescription;
            item.TermPriority = term.TermPriority > 0 ? term.TermPriority : Priority;
            item.TermCode = term.TermCode;
            item.TermModifyUserId = term.TermModifyUserId;
            item.TermModifyDate = CurrentDate;
            return _db.SaveChanges(); 
         
        }
        public List<Terminal> GetList()
        {
            var terms = _db.Terminals.Where(d => d.TermIsDeleted == false).OrderByDescending(d => d.TermId);
            return terms.ToList();
        }
        public Terminal GetItem(int id)
        {
            if (id == 0)
            {
                return null;
            }
            Terminal term = _db.Terminals.FirstOrDefault(d => d.TermId == id && d.TermIsDeleted == false);
            return term;
        }
        public int Delete(int id, Guid userId)
        {
            Terminal item = _db.Terminals.Find(id);
            item.TermIsDeleted = true;
            item.TermIsPublished = false;
            item.TermModifyDate = CurrentDate;
            item.TermModifyUserId = userId;
            return _db.SaveChanges();

        }
    }
}
