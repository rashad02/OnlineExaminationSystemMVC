using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseContext;
using Models;

namespace Repository
{
    public class HomeRepository
    {
        OnlineExaminationSystem db=new OnlineExaminationSystem();

        public bool CheckAdmin(AdminCredentials adminCredentials)
        {
            var data =
                (db.AdminCredentialses.FirstOrDefault(
                    ac => ac.UserName == adminCredentials.UserName && ac.Password == adminCredentials.Password));
            if (data!=null)
            {
                return true;
            }
            return false;
        }
    }
}
