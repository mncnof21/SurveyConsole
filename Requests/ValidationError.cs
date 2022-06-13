using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyConsole.Requests
{
    public class ValidationError
    {
        public String FieldName { get; set; }
        public String ErrorMessage { get; set; }

        public ValidationError(String _fieldName, String _errorMessage)
        {
            FieldName = _fieldName;
            ErrorMessage = _errorMessage;
        }
    }
}
