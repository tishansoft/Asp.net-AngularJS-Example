using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChennaiSarees.BusinessObjects.Messaging
{
    public abstract class LongIdRequest : ServiceRequestBase
    {
        private long _id;

        public LongIdRequest(long id)
        {
            if (id < 1)
            {
                throw new ArgumentException("ID must be positive.");
            }
            _id = id;
        }

        public long Id { get { return _id; } }
    }
}
