
using DIDemo.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIDemo.Services.Service
{
    public class ServiceB : IServiceB
    {
        public ServiceB()
        {

        }
        public void B()
        {
            throw new NotImplementedException();
        }
    }
}
