﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChennaiSarees.BusinessObjects.Messaging
{
    public abstract class IntegerIdRequest : ServiceRequestBase
    {
        private int _id;

        public IntegerIdRequest(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException("ID must be positive.");
            }
            _id = id;
        }

        public int Id { get { return _id; } }
    }
}
