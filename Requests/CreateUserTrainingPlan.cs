using System;

namespace Graphql.Api.Requests
{
    public class CreateUserTrainingPlan
    {
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
    }
}