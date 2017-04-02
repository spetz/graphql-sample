using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Graphql.Api.Core.Models;
using Graphql.Api.Core.Services;
using Graphql.Api.Requests;

namespace Graphql.Api.Controllers
{
    [Route("training-plans")]
    public class TrainingPlansController : Controller
    {
        private readonly ITrainingPlanService _trainingPlanService;

        public TrainingPlansController(ITrainingPlanService trainingPlanService)
        {
            _trainingPlanService = trainingPlanService;
        }

        [HttpGet]
        public IEnumerable<string> Get() => _trainingPlanService.GetAll().Select(x => x.Name);

        [Route("{name}")]
        [HttpGet]
        public TrainingPlan Get(string name) => _trainingPlanService.Get(name);

        [HttpPost]
        public IActionResult Post([FromBody]CreateTrainingPlan request)
        {
            var plan = _trainingPlanService.Create(request.Name, request.Weeks, request.DaysBreak);

            return Created($"http://localhost:5000/training-plans/{plan.Id}", new object());
        }
    }
}