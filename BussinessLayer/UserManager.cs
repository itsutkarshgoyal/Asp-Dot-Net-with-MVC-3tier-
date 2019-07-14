using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookReadingEventViewModel;
using DataLayer;

namespace BussinessLayer
{
   public class UserManager
    {
        public String Createdby(int? id)
        {
            return UserData.Createdby(id);
        }
        public List<UserDetail> showusers()
        {

            return UserData.showusers();
        }

        public List<UserDetail> ViewUsers(int id)
        {

            return UserData.Viewusers(id);
        }

        public List<UserDetail> LoginUser(UserDetailViewModel detail)
        {
            UserDetail user = new UserDetail()
            {
                email = detail.email,
                first_name = detail.first_name,
                last_name = detail.last_name,
                password = detail.password,
                role = detail.role
            };
            return UserData.LoginUser(user);
        }


        public int SaveUser(UserDetailViewModel detail)
        {
            UserDetail user = new UserDetail()
            {
                email = detail.email,
                first_name = detail.first_name,
                last_name = detail.last_name,
                password = detail.password,
                role = detail.role
            };
            return UserData.SaveUser(user);
        }

        public List<UserDetail> EditUser(UserDetailViewModel detail)
        {
            UserDetail user = new UserDetail()
            {
                email = detail.email,
                first_name = detail.first_name,
                last_name = detail.last_name,
                password = detail.password,
                role = detail.role
            };
            return UserData.EditUser(user);
        }

        public int DeleteUser(int? id)
        {

            return UserData.DeleteUsers(id);
        }
    }
}
