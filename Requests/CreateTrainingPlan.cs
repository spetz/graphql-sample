namespace Graphql.Api.Requests
{
    public class CreateTrainingPlan
    {
        public string Name { get; set; }
        public int Weeks { get; set; }
        public int DaysBreak { get; set; }
    }
}