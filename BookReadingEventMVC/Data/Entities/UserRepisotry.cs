using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookReadingEventMVC.Data.Entities
{
   public class UserRepisotry
    {
        private readonly EventsContext _context = null;
        public UserRepisotry(EventsContext context)
        {
            _context = context;
        }
        public List< User> GetUser()
        {
            //EventsContext e = new EventsContext();
            return _context.Userss.ToList();
        }
    }
}
