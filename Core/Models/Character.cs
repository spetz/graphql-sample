namespace Graphql.Api.Core.Models
{
    public abstract class Character
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string[] Friends { get; set; }
        public int[] AppearsIn { get; set; }        
    }
}