using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Repository.Interfaces
{
    public interface IUserRepo
    {
        User Login(User u);
    }
}
