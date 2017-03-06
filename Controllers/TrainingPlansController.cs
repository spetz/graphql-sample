using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Source.Core.Models;
using Source.Core.Services;

namespace Source.Controllers
{
    [Route("training-plans")]
    public class TrainingPlansController : Controller
    {
        private readonly ITrainingPlanService _trainingPlanService;

        public TrainingPlansController(ITrainingPlanService trainingPlanService)
        {
            _trainingPlanService = trainingPlanService;
        }

        public IEnumerable<string> Get() => _trainingPlanService.GetAll().Select(x => x.Name);

        [Route("{name}")]
        public TrainingPlan Get(string name) => _trainingPlanService.Get(name);
    }
}