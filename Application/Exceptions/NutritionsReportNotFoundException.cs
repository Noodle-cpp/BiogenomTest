using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    [Serializable]
    public class NutritionsReportNotFoundException : Exception
    {
        public NutritionsReportNotFoundException()
        {
        }

        public NutritionsReportNotFoundException(string? message) : base(message)
        {
        }

        public NutritionsReportNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NutritionsReportNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
