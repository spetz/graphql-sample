using System;

namespace Graphql.Api.Requests
{
    public class CreateTrainingPlan
    {
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
    }
}