using System;
using System.Collections.Generic;

namespace Graphql.Api.Core.Models
{
    public class UserTrainingSession
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public bool IsCompleted { get; set; }  
        public IList<UserExercise> Exercises { get; set; }      
    }
}