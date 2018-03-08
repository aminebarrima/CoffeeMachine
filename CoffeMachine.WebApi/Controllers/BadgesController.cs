﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CoffeeMachine.GetWay;
using CoffeeMachine.Models;
using CoffeeMachine.GetWay.Infrastructure;

namespace CoffeMachine.WebApi.Controllers
{
    public class BadgesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public BadgesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // GET: api/Badges
        [HttpGet]
        [Route("api/Badges")]
        public IEnumerable<Badge> GetBadge()
        {
            var badgeRepository = _unitOfWork.Repository<Badge>();
            return badgeRepository.GetAll().ToList();

        }

        
    }
}