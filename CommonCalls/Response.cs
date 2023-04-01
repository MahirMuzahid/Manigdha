using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CommonCalls
{
    public class Response
    {
        public string? Message { get; set; }
        public HttpStatusCode Status { get; set; }
        public string? ReturnString { get; set; }
        public string? ReturnStringTwo { get; set; }
        public string? ReturnStringThree { get; set; }
        public string? ReturnStringFour { get; set; }
        public Response()
        {

        }
        public Response( HttpStatusCode sts)
        {
            Status = sts;
        }
        public Response(string msg, HttpStatusCode sts)
        {
            Message = msg;
            Status = sts;
        }
        public Response(string msg, HttpStatusCode sts, string rs)
        {
            Message = msg;
            Status = sts;
            ReturnString = rs;
        }
        public Response(string msg, HttpStatusCode sts, string rs, string rs2)
        {
            Message = msg;
            Status = sts;
            ReturnString = rs;
            ReturnStringTwo = rs2;
        }
        public Response(string msg, HttpStatusCode sts, string rs, string rs2, string rs3)
        {
            Message = msg;
            Status = sts;
            ReturnString = rs;
            ReturnStringTwo = rs2;
            ReturnStringThree = rs3;
        }
        public Response(string msg, HttpStatusCode sts, string rs, string rs2, string rs3, string rs4)
        {
            Message = msg;
            Status = sts;
            ReturnString = rs;
            ReturnStringTwo = rs2;
            ReturnStringThree = rs3;
            ReturnStringFour = rs4;
        }
    }
}
