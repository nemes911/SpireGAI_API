using EGAIP.API.a_p_i;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EGAIP.API.Models;

namespace EGAIP.API.Forms
{
    public partial class LoginForm : Form
    {
        private readonly UserAPI _userapi;

        public LoginForm(UserAPI userapi)
        {
            InitializeComponent();
            _userapi = userapi;
        }

        private async void btnLogin_click(object sender, EventArgs a) 
        {
            var user = new LoginUserModel { };

            var result = await _userapi.SendUserToLogin(user);
        }

    }
}
