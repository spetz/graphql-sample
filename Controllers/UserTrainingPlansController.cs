using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Source.Core.Models;
using Source.Requests;
using Source.Core.Services;

namespace Source.Controllers
{
    [Route("user-training-plans")]
    public class UserTrainingPlansController : Controller
    {
        private readonly IUserTrainingPlanService _trainingPlanService;

        public UserTrainingPlansController(IUserTrainingPlanService trainingPlanService)
        {
            _trainingPlanService = trainingPlanService;
        }

        [HttpGet]
        public IEnumerable<object> Get() => _trainingPlanService.GetAll()
            .Select(x => new {Id = x.Id, Name = x.Name});

        [Route("{id}")]
        [HttpGet]
        public UserTrainingPlan Get(Guid id) => _trainingPlanService.Get(id);

        [HttpPost]
        public IActionResult Post([FromBody]CreateTrainingPlan request)
        {
            var startDate = request.StartDate.GetValueOrDefault(DateTime.UtcNow);
            var plan = _trainingPlanService.Create(request.Name, startDate);

            return Created($"http://localhost:5000/user-training-plans/{plan.Id}", new object());
        }
    }
}