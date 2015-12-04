using Util.Core.DataAnnotationsTemplates;

namespace Util.Core.Tests.DataAnnotationsTemplates
{
    public class Person
    {
        [DescriptionLocalized(typeof(PersonRes), nameof(PersonRes.Id))]
        public int Id { get; set; } 
        [DescriptionLocalized(typeof(PersonRes), nameof(PersonRes.Name))]
        public int Name { get; set; }
    }
}