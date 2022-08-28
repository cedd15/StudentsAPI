using System;
using System.Collections.Generic;

namespace StudentAPI.Models
{
    public partial class COURSES
    {
        public COURSES()
        {
            STUDENTS_COURSES = new HashSet<STUDENTS_COURSES>();
        }

        public int ID { get; set; }
        public string COURSE_TITLE { get; set; } = null!;

        public virtual ICollection<STUDENTS_COURSES> STUDENTS_COURSES { get; set; }
    }
}
