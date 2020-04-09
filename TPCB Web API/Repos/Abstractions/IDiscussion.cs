using System;
using System.Collections.Generic;
using System.Text;

namespace Repos.Abstractions
{
   public interface IDiscussion<T>
    {
        IEnumerable<T> GetDiscussion();
        void AddDiscussion(T comment);
        void ModifyDiscussion(T comment);
        void RemoveDiscussion(int id);
    }
}
