using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class CommentData
    {
        public static List<comment> showcomments(int? id)
        {
            List<comment> lst = null;
            using (BookReadingEntities db = new BookReadingEntities())
            {
                lst = (from u in db.comments where u.Event_id == id select u).ToList();
            }
            return lst;
        }

        public static List<comment> ViewComments(int? id)
        {
            List<comment> lst = null;
            using (BookReadingEntities db = new BookReadingEntities())
            {
                lst = (from u in db.comments where u.Id == id select u).ToList();
            }
            return lst;
        }

        public static int SaveComment(comment detail)
        {

            using (BookReadingEntities db = new BookReadingEntities())
            {
                db.comments.Add(detail);
                db.SaveChanges();
            }
            return 1;
        }

        public static List<comment> EditComments(comment detail)
        {
            List<comment> lst = null;
            using (BookReadingEntities db = new BookReadingEntities())
            {
                db.Entry(detail).State = EntityState.Modified;
                db.SaveChanges();
            }
            return lst;
        }

        public static int DeleteComments(int? id)
        {

            using (BookReadingEntities db = new BookReadingEntities())
            {
                comment detail = db.comments.Find(id);
                db.comments.Remove(detail);
                db.SaveChanges();
            }
            return 1;
        }

        public static int ValidateUser(int? id, int? userid)
        {
            using (BookReadingEntities db = new BookReadingEntities())
            {
                List<comment> lst = db.comments.Where(i => i.Id == userid && i.created_by == id).ToList();
                var detail = lst.FirstOrDefault();
                if (detail != null)
                    return 1;
                else
                    return 0;
            }
        }
    }


}

