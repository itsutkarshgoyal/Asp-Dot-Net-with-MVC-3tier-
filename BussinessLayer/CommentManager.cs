using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookReadingEventViewModel;
using DataLayer;

namespace BussinessLayer
{
    public class CommentManager
    {
        public List<comment> showcomments(int? id)
        {

            return CommentData.showcomments(id);
        }

        public List<comment> ViewComments(int? id)
        {

            return CommentData.ViewComments(id);
        }

        public int SaveComments(CommentsViewModel x)
        {
            comment user = new comment()
            {
                created_by = x.created_by,
                description = x.description,
                Event_id = x.Event_id,
                created_on = x.created_on,
                modified_on = x.modified_on,
                Id = x.Id,



            };
            return CommentData.SaveComment(user);
        }

        public List<comment> EditComments(CommentsViewModel x)
        {
            comment user = new comment()
            {
                created_by = x.created_by,
                description = x.description,
                Event_id = x.Event_id,
                created_on = x.created_on,
                modified_on = x.modified_on,
                Id = x.Id,



            };
            return CommentData.EditComments(user);
        }

        public int DeleteComments(int? id)
        {

            return CommentData.DeleteComments(id);
        }

        public int ValidateUser(int? id, int? userid)
        {
            return CommentData.ValidateUser(id, userid);
        }

    }
}
