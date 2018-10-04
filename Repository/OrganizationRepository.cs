using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DatabaseContext;
using Models;

namespace Repository
{
  
    public class OrganizationRepository
    {
        OnlineExaminationSystem db=new OnlineExaminationSystem();


        public bool AddOrganization(Organization organization)
        {
            db.Organizations.Add(organization);
            return db.SaveChanges() > 0;
        }

        public List<Organization> GetOrganization()
        {
            var data = db.Organizations;
            return data.ToList();
        }

        public List<Organization> GetOrganizationBySearchCriteria(Organization organization)
        {
            var data =
                db.Organizations.Where(
                    o =>
                        o.Name == organization.Name || o.Code == organization.Code || o.Address == organization.Address ||
                        o.ContactNo == organization.ContactNo);
            return data.ToList();
        }


        public byte[] GetImageFromDataBase(int id)
        {
            var firstOrDefault = db.Organizations.FirstOrDefault(o => o.Id == id);
            if (firstOrDefault != null)
            {
                byte[] image = firstOrDefault.Logo;
                return image;
            }
            return null;
        }
    }
}
