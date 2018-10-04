using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Models;
using Repository;

namespace BLL
{
   public class OrganizationManager
    {
       OrganizationRepository organizationRepository=new OrganizationRepository();

       public bool AddOrganization(Organization organization)
       {
           return organizationRepository.AddOrganization(organization);
       }

       public List<Organization> GetOrganization()
       {
           return organizationRepository.GetOrganization();
       }

       public List<Organization> GetOrganizationBySearchCriteria(Organization organization)
       {
            return organizationRepository.GetOrganizationBySearchCriteria(organization);
       }


       public byte[] GetImageFromDataBase(int id)
       {
           return organizationRepository.GetImageFromDataBase(id);
       }
    }
}
