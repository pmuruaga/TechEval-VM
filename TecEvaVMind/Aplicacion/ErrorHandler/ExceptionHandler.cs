using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Aplicacion.ErrorHandler
{
    public class ExceptionHandler : Exception
    {
        public HttpStatusCode Code { get; }
        public object Errors { get; }
        public ExceptionHandler(HttpStatusCode code, object errors = null)
        {
            Code = code;
            Errors = errors;
        }
    }
}
