using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Graphql.Api.Core.Models;
using Graphql.Api.Core.Services;

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
    }
}