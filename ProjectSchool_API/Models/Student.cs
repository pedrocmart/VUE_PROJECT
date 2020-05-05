
namespace ProjectSchool_API.Models
{
    public class Student
    {
        
        [System.ComponentModel.DataAnnotations.Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string DtBirth { get; set; }
        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }
    }
}