using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UserData
    {
        public static String Createdby(int? id)
        {
            using (BookReadingEntities db = new BookReadingEntities())
            {
                List<UserDetail> detail = (from u in db.UserDetails where u.id==id select u).ToList();               
                String name = detail.FirstOrDefault().first_name.ToString().TrimEnd();
                return name;
            }
        }
        public static List<UserDetail> showusers()
        {
            List<UserDetail> lst = null;
            using (BookReadingEntities db = new BookReadingEntities())
            {
                lst = (from u in db.UserDetails  select u).ToList();
            }
            return lst;
        }

        public static List<UserDetail> Viewusers(int id)
        {
            List<UserDetail> lst = null;
            using (BookReadingEntities db = new BookReadingEntities())
            {
                lst = (from u in db.UserDetails where u.id==id select u).ToList();
            }
            return lst;
        }

        public static List<UserDetail> LoginUser(UserDetail std)
        {
            std.password = GetBase64EncodedString(std.password);
            List<UserDetail> lst = null;
            using (BookReadingEntities db = new BookReadingEntities())
            {
                lst = (from u in db.UserDetails where u.email == std.email && u.password == std.password select u).ToList();
            }
            return lst;
        }



        public static int SaveUser(UserDetail detail)
        {
             
            using (BookReadingEntities db = new BookReadingEntities())
            {
                
                var exist = (from u in db.UserDetails where u.email == detail.email select u.email).ToList().FirstOrDefault();
                if (exist== null)
                {
                    detail.password = GetBase64EncodedString(detail.password);
                    db.UserDetails.Add(detail);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception( "User Already Exists");
                }
            }
            return 1;
        }

        public static List<UserDetail> EditUser(UserDetail detail)
        {
            List<UserDetail> lst = null;
            using (BookReadingEntities db = new BookReadingEntities())
            {
                db.Entry(detail).State = EntityState.Modified;
                db.SaveChanges();
            }
            return lst;
        }

        public static int DeleteUsers(int? id)
        {

            using (BookReadingEntities db = new BookReadingEntities())
            {
              UserDetail detail = db.UserDetails.Find(id);
                db.UserDetails.Remove(detail);
                db.SaveChanges();
            }
            return 1;
        }

        private static string GetBase64EncodedString(string text)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(text);
            return System.Convert.ToBase64String(plainTextBytes);
        } 
    }
}
