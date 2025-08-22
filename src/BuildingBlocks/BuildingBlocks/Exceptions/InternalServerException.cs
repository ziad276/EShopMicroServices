using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Exceptions
{
    public class InternalServerException: 
        Exception
    {
        public InternalServerException(string message) : base(message)
        {
        }

        public InternalServerException(string details, string message) : base(message)
        {
            Details = details;
        }

        public string? Details { get; }
    }
}
