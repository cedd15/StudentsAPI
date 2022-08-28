using System;
using System.Collections.Generic;

namespace StudentAPI.Models
{
    public partial class STUDENTS
    {
        public STUDENTS()
        {
            STUDENTS_COURSES = new HashSet<STUDENTS_COURSES>();
        }

        public int ID { get; set; }
        public string LNAME { get; set; } = null!;
        public string FNAME { get; set; } = null!;
        public DateTime BIRTH_DT { get; set; }

        public virtual ICollection<STUDENTS_COURSES> STUDENTS_COURSES { get; set; }
    }
}
