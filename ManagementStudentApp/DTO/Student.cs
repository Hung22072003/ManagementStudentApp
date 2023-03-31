using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementStudentApp.DTO
{
    public class Student
    {
        public string MSSV { get; set; }
        public string Name { get; set; }
        public string LopSH { get; set; }   
        public bool Gender { get; set; }
        public DateTime  Ngaysinh { get; set; }
        public double DTB { get; set; }
        public bool Anh { get; set; }
        public bool HocBa { get; set;  }
        public bool CCCD { get; set; }

        public static bool CompareDTB(object o1, object o2)
        {
            return ((Student)o1).DTB > ((Student)o2).DTB;
        }

        public static bool CompareMSSV(object o1, object o2)
        {
            return Convert.ToDouble(((Student)o1).MSSV) > Convert.ToDouble(((Student)o2).MSSV);
        }

        public static bool CompareName(object o1, object o2)
        {
            return String.Compare(((Student)o1).Name, ((Student)o2).Name) > 0;
        }
    }
}
