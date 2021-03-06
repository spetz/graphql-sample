using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Graphql.Api.Core.Services;
using Graphql.Api.Requests;

namespace Graphql.Api.Controllers
{
    [Route("exercises")]
    public class ExercisesController : Controller
    {
        private readonly IExerciseService _exerciseService;

        public ExercisesController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpGet]
        public IEnumerable<string> Get() => _exerciseService.GetAll();

        [HttpPost]
        public IActionResult Post([FromBody]CreateExercise request)
        {
             _exerciseService.Create(request.Name);

            return StatusCode(201);
        }
    }
}