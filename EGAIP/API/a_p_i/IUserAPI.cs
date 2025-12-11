using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EGAIP.API.Models;

namespace EGAIP.API.a_p_i
{
    public interface IUserAPI
    {
        public Task<OutLoginUserModel> SendUserToLogin(LoginUserModel model);

    }
}
