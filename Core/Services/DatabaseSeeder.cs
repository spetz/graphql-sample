namespace Graphql.Api.Core.Services
{
    public class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly ITrainingPlanService _trainingPlanService;

        public DatabaseSeeder(ITrainingPlanService trainingPlanService)
        {
            _trainingPlanService = trainingPlanService;
        }

        public void Seed()
        {
            AddPlans();
        }

        private void AddPlans()
        {
            _trainingPlanService.Create("stronglifts", 30, 2);
            _trainingPlanService.Create("smolov jr", 12, 3);
            _trainingPlanService.Create("5x5", 20, 2);
        }        
    }
}