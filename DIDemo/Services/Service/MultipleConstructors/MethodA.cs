
using DIDemo.Services.Interface;

namespace DIDemo.Services.Service
{
    public class MethodA : IMethodA
    {

        private IServiceA _serviceA;
        private IServiceB _serviceB;
        private IServiceC _serviceC;
        private IServiceD _serviceD;
        private IServiceE _serviceE;

        public MethodA( IServiceC serviceC, IServiceD serviceD, IServiceE serviceE)
        {
            _serviceC = serviceC;
            _serviceD = serviceD;
            _serviceE = serviceE;

        }
        public MethodA(IServiceA serviceA)
        {
            _serviceA = serviceA;
        }

        public MethodA( IServiceB serviceB)
        {
            _serviceB = serviceB;
        }
        //public MethodA(IServiceB serviceB, IServiceA serviceA, IServiceC serviceC, IServiceD serviceD, IServiceE serviceE)
        //{
        //    _serviceB = serviceB;
        //    _serviceA = serviceA;
        //    _serviceC = serviceC;
        //    _serviceD = serviceD;
        //    _serviceE = serviceE;

        //}

        public string A()
        {
            _serviceA.A();
            _serviceB.B();
            _serviceC.C();
            return "OK";
        }
    }
}
