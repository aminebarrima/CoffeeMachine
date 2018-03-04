using CoffeeMachine.GetWay;
using CoffeeMachine.GetWay.Infrastructure;
using System.Linq;
using CoffeeMachine.Models;

namespace ConsoleApplication1
{
    class Program
    {

        //public readonly  IUnitOfWork _unitOfWork;

        //public Program(IUnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}

        public void test() {
            //var operations = _unitOfWork.Repository<Boisson>();

        }
        static void Main(string[] args)
        {
            CoffeeMachineDbContext cntx = new CoffeeMachineDbContext();
            UnitOfWork _unitOfWork = new UnitOfWork(cntx);
            var boisson = _unitOfWork.Repository<Boisson>();
            var y = boisson.GetAll().ToList();



           // BoissoinRepository bb = new BoissoinRepository();
           //var y= bb.GetAll().ToList();
          
                
                }
    }
}
