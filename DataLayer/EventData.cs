using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class EventData

    {
        public EventData()
        {
            //this.AddInterceptor(new Interceptor());

        }
        public static List<EventDetail> Invitation(String email)
        {
            List<EventDetail> lst = null;
            using (BookReadingEntities db = new BookReadingEntities())
            {
                // lst = (from u in db.EventDetails where u.Event_id In
                //  (from i  in db.Invitations where i.email==email select i.Event_id) select u).ToList();
                lst = (from u in db.EventDetails
                       join c in db.Invitations
                         on u.Event_id equals c.Event_id
                       where c.email.Contains(email)
                       select u).ToList();
            }
            return lst;
        }

        public static EventDetail SendInvitation(String email,int detail)
        {
            EventDetail d = null;
            using (BookReadingEntities db = new BookReadingEntities())
            {
                Invitation invite = new Invitation();
                invite.email = email;
                invite.Event_id = detail;
               
                    db.Invitations.Add(invite);
                    db.SaveChanges();
            }
            return d;
        }

        public  static List<EventDetail> GetAllEvents()
        {
            List<EventDetail> lst=null ;
            using (BookReadingEntities db=new BookReadingEntities())
            {

              //  StreamWriter writetext = new StreamWriter("D:\\write.txt");
               // db.Database.Log = writetext.WriteLine;
                lst = (from u in db.EventDetails where u.type=="public" select u).ToList();

            }
          
            return lst;
           
        }

        public static List<EventDetail> ViewEvents(int ?id)
        {
            List<EventDetail> lst = null;
            using (BookReadingEntities db = new BookReadingEntities())
            {
                lst = (from u in db.EventDetails where u.Event_id==id select u).ToList();
            }
           
            return lst;
            
        }

        public static List<EventDetail> pasteventSearch(DateTime date)
        {
            List<EventDetail> lst = null;
            using (BookReadingEntities db = new BookReadingEntities())
            {
                lst = (from u in db.EventDetails where u.start_time < date  && u.type == "public" select u).ToList();
            }
           
            return lst;
        }

        public static List<EventDetail> upeventSearch(DateTime date)
        {
            List<EventDetail> lst = null;
            using (BookReadingEntities db = new BookReadingEntities())
            {
                lst = (from u in db.EventDetails where u.start_time >= date && u.type == "public" select u).ToList();
            }
           
            return lst;
           
        }

        public static List<EventDetail> MyEvents(int? id)
        {
            
            List<EventDetail> lst = null;
            using (BookReadingEntities db = new BookReadingEntities())
            {
              lst = (from u in db.EventDetails orderby u.start_time descending where u.created_by==id select u).ToList();
            }
            return lst;
        }

        public static List<EventDetail> ShowAllEvents()
        {

            List<EventDetail> lst = null;
            using (BookReadingEntities db = new BookReadingEntities())
            {
                lst = (from u in db.EventDetails orderby u.start_time descending  select u).ToList();
            }
            
            return lst;
           
        }
        public static int SaveEvents(EventDetail detail)
        {
            
            using (BookReadingEntities db = new BookReadingEntities())
            {
                db.EventDetails.Add(detail);
                db.SaveChanges();
            }
            return 1;
        }

        public static List<EventDetail> EditEvents(EventDetail detail)
        {
            List<EventDetail> lst = null;
            using (BookReadingEntities db = new BookReadingEntities())
            {
                db.Entry(detail).State = EntityState.Modified;
                db.SaveChanges();
            }
            return lst;
        }

        public static int DeleteEvents(int? id)
        {

            using (BookReadingEntities db = new BookReadingEntities())
            {
                EventDetail detail = db.EventDetails.Find(id);
                List<comment> comments = db.comments.Where(i => i.Event_id == id).ToList();
                List<Invitation> invitations = db.Invitations.Where(i => i.Event_id == id).ToList();
                db.comments.RemoveRange(comments);
                db.Invitations.RemoveRange(invitations);
                detail.comments = null;
                detail.Invitations = null;
                db.EventDetails.Remove(detail);
                db.SaveChanges();
            }
            return 1;
        }

        public static int ValidateUser(int? id,int? userid)
        {
            using (BookReadingEntities db = new BookReadingEntities())
            {
                List<EventDetail> lst = db.EventDetails.Where(i => i.created_by == id && i.Event_id == userid).ToList();
                var detail = lst.FirstOrDefault();
                if (detail != null)
                    return 1;
                else
                    return 0;
                    }
        }


    }

}
