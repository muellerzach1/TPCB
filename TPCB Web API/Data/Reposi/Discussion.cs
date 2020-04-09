using System;
using System.Collections.Generic;
using System.Text;
using Repos.Abstractions;
using Data;
using System.Linq;

namespace Data.Reposi
{
   public class Discussion : Repos.Abstractions.IDiscussion<Discussions>
    {
        TPCBContext TPC;

        public Discussion()
        {
            TPC = new TPCBContext();
        }

        public Discussion(TPCBContext TPC)
        {
            this.TPC = TPC ?? throw new ArgumentNullException(nameof(TPC));
        }

        public void AddDiscussion(Discussions comment)
        {
            if (TPC.Discussion.Any(e => e.Comment == comment.Comment) || comment.Comment == null)
            {
                Console.WriteLine($"This location name {comment.Comment} is already in use");
                return;
            }
            else
                TPC.Discussion.Add(comment);
            TPC.SaveChanges();
        }

        public IEnumerable<Discussions> GetDiscussion()
        {
            var query = from e in TPC.Discussion
                        select e;

            return query;
        }

        public void ModifyDiscussion(Discussions comment)
        {
            throw new NotImplementedException();
        }

        public void RemoveDiscussion(int id)
        {
            var com = TPC.Discussion.FirstOrDefault(e => e.CommentId == id);
            if (com.CommentId == id )
            {
                TPC.Remove(com);
                TPC.SaveChanges();
            }
            else
            {
                Console.WriteLine($"Comment was never made");
                return;
            }
        }
    }
}
