using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Rusada.Common.CommenModel
{
    public class ServiceResponse
    {
     
        public Object ReturnObject { get; set; }
        
        public bool IsError { get; set; }
        
        public IList<Message> Messages { get; set; }
        
        public bool IsNotificationSendFail { get; set; }
       
        public HttpStatusCode StatusCode { get; set; }
       
    }
}