using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Common.Models.Respones
{
    public class ServiceResponse
    {
        public List<string> Errors { get; set; }
        public bool Succedded { get; set; }
        public object Data { get; set; }

        public ServiceResponse() { }  
        public ServiceResponse(object result, List<string> errors, bool success)
        {
            Errors = errors;
            Data = result;
            Succedded = success;
        }
        public static ServiceResponse Success(object result)
        {
            return new ServiceResponse(result, new(), true);
        }
        public static ServiceResponse Failure(List<string> errors)
        {
            return new ServiceResponse(new(), errors, false);
        }
    }
}
