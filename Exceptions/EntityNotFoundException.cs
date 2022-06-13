using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyConsole.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public override string Message => base.Message;

        public EntityNotFoundException(String message) : base(message)
        {

        }
    }
}
