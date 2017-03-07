using System;

namespace Source.Requests
{
    public class CreateTrainingPlan
    {
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
    }
}