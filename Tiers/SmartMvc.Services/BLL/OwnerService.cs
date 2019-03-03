using SmartMvc.Core.Domain;
using SmartMvc.Services.BLL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace SmartMvc.Services.BLL
{
    public class OwnerService : GlobalService
    {
        public int Add(Owner owner)
        {
            if (owner == null)
            {
                return 0;
            }
            owner.OwnerAddDate = owner.OwnerModifyDate = CurrentDate;
            owner.OwnerIsDeleted = IsDeleted; 
            _db.Owners.Add(owner);
            return _db.SaveChanges();
        }
        public int Edit(Owner owner)
        {
            if (owner == null)
            {
                return 0;
            }
            Owner item = _db.Owners.Find(owner.OwnerId); 
            item.OwnerFirstName = owner.OwnerFirstName;
            item.OwnerSecondName = owner.OwnerSecondName;
            item.OwnerFamilyName = owner.OwnerFamilyName;

            item.OwnerEmail = owner.OwnerEmail;
            item.OwnerMobile = owner.OwnerMobile;
            item.OwnerNationalNo = owner.OwnerNationalNo;

            item.OwnerGender = owner.OwnerGender;
            item.OwnerNationality = owner.OwnerNationality;
            item.OwnerCollage = owner.OwnerCollage;

            item.OwnerPlaceOfBirth = owner.OwnerPlaceOfBirth;
            item.OwnerDateOfBirth = owner.OwnerDateOfBirth;
            item.OwnerBloodType = owner.OwnerBloodType;

            item.OwnerPassportNo = owner.OwnerPassportNo;
            item.OwnerPassportPlace = owner.OwnerPassportPlace;
            item.OwnerPassportEndDate = owner.OwnerPassportEndDate;

            item.CategoryTypeId = owner.CategoryTypeId;
            item.OwnerTemplateId = owner.OwnerTemplateId;
            item.OwnerStatus = owner.OwnerStatus;

            item.OwnerDescription = owner.OwnerDescription;
            item.OwnerImagePath = owner.OwnerImagePath;
            item.OwnerAttachFile1 = owner.OwnerAttachFile1;
            item.OwnerAttachFile2 = owner.OwnerAttachFile2;
            item.OwnerAttachFile3 = owner.OwnerAttachFile3;

            //item.OwnerFirstName = owner.OwnerFirstName;
            //item.OwnerFirstName = owner.OwnerFirstName;
            //item.OwnerFirstName = owner.OwnerFirstName;
            //item.OwnerFirstName = owner.OwnerFirstName;

            item.OwnerModifyUserId = owner.OwnerModifyUserId;
            item.OwnerModifyDate = CurrentDate;
            return _db.SaveChanges();

        }
        public List<Owner> GetList()
        {
            var owners = _db.Owners.Include(d => d.CategoryType).Include(d => d.Template).Where(d => d.OwnerIsDeleted == false).OrderByDescending(d => d.OwnerId);
            return owners.ToList();
        }
        public Owner GetItem(int id)
        {
            if (id == 0)
            {
                return null;
            }
            Owner owners = _db.Owners.FirstOrDefault(d => d.OwnerId == id && d.OwnerIsDeleted == false);
            return owners;
        }
        public int Delete(int id, Guid userId)
        {
            Owner item = _db.Owners.Find(id);
            item.OwnerIsDeleted = true;
            item.OwnerStatus = false;
            item.OwnerModifyDate = CurrentDate;
            item.OwnerModifyUserId = userId;
            return _db.SaveChanges();

        }
    }
}
