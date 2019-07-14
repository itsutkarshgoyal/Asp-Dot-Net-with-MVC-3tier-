using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using BookReadingEventViewModel;

namespace BussinessLayer
{
    public class EventManager 
    {
        public List<EventDetail> ShowAllEvents()
        {
            
            return EventData.ShowAllEvents();
        }
        public List<EventDetail> Invitation(String email)
        {
           
            return EventData.Invitation(email);
        }
        public EventDetail SendInvitation(String email,int detail)
        {

            return EventData.SendInvitation(email, detail);
        }
        public List<EventDetail> GetAllEvents()
        {

            return  EventData.GetAllEvents();
        }

        public List<EventDetail> ViewEvents(int? id)
        {

            return EventData.ViewEvents(id);
        }
        public List<EventDetail> pastSearch(DateTime date)
        {

            return EventData.pasteventSearch(date);
        }
        public List<EventDetail> upSearch(DateTime date)
        {

            return EventData.upeventSearch(date);
        }
        public List<comment> showcomments(int? id)
        {

            return CommentData.showcomments(id);
        }

        public List<EventDetail> MyEvents(int ?id)
        {
            
            return EventData.MyEvents(id);
        }

        public int SaveEvents(EventDetailViewModel detail)
        {
            EventDetail user = new EventDetail()
            {
                Event_id = detail.Event_id,
                title = detail.title,
                location = detail.location,
                start_time = detail.start_time,
                duration = detail.duration,
                created_by=detail.created_by,
                other_details=detail.other_details,
                description=detail.description,
                comments=detail.comments,
                invitation=detail.invitation,
                Invitations=detail.Invitations,
                type=detail.type
                
                

            };
            return EventData.SaveEvents(user);
        }

        public List<EventDetail> EditEvents(EventDetailViewModel detail)
        {
            EventDetail user = new EventDetail()
            {
                Event_id = detail.Event_id,
                title = detail.title,
                location = detail.location,
                start_time = detail.start_time,
                duration = detail.duration,
                created_by = detail.created_by,
                other_details = detail.other_details,
                description = detail.description,
                comments = detail.comments,
                invitation = detail.invitation,
                Invitations = detail.Invitations,
                type = detail.type



            };
            return EventData.EditEvents(user);
        }

        public int DeleteEvents(int? id)
        {

            return EventData.DeleteEvents(id);
        }

        public int  ValidateUser(int? id,int? userid)
        {
           return EventData.ValidateUser(id,userid);
        }


    }
}
