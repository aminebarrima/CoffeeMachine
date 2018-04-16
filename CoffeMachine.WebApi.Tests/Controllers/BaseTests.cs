﻿using CoffeeMachine.GetWay;
using CoffeeMachine.GetWay.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeMachine.WebApi.Tests.Controllers
{
    [TestClass]
    public abstract class BaseTests<T> where T:class
    {
        protected Mock<IUnitOfWork> moqUnitOfWork;
        protected Mock<IRepository<T>> moqRepository;
        [TestInitialize]
        public void Initialize()
        {
                       //AutoMapperConfiguration.Configure();
            moqUnitOfWork = new Mock<IUnitOfWork>();            
            moqRepository = new Mock<IRepository<T>>();
        }

        [TestCleanup]
        public void Cleanup()
        {
            moqUnitOfWork = null;
            moqRepository = null;
            //AutoMapper.Mapper.Reset();
        }
    }
}