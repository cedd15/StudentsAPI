using System;
using System.Collections.Generic;

namespace StudentAPI.Models
{
    public partial class STUDENTS_COURSES
    {
        public int STUDENT_ID { get; set; }
        public int COURSE_ID { get; set; }
        public DateTime? CREATED_DT { get; set; }

        public virtual COURSES COURSE { get; set; } = null!;
        public virtual STUDENTS STUDENT { get; set; } = null!;
    }
}
