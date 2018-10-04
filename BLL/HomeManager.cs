using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repository;

namespace BLL
{
    public class HomeManager
    {
        HomeRepository homeRepository=new HomeRepository();

        public bool CheckAdmin(AdminCredentials adminCredentials)
        {
            return homeRepository.CheckAdmin(adminCredentials);
        }
    }
}
