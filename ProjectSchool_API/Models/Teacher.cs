using System.Collections.Generic;

namespace ProjectSchool_API.Models
{
    public class Teacher
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
    }
}