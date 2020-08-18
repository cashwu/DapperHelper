using System.ComponentModel.DataAnnotations;

namespace testDapper
{
    public class Person
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}