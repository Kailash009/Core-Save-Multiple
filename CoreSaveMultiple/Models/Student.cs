using System.ComponentModel.DataAnnotations;

namespace CoreSaveMultiple.Models
{
    public class Student
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string address { get; set; }
        public string mobileno { get; set; }
        public string city { get; set; }
        public decimal fees { get; set; }
    }
}
