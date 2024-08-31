using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string Message) : base(Message)
        {

        }

        public BadRequestException(string message, string details) : base(message)
        {
            this.Details = details;
        }

        public string? Details { get; }
    }
}
