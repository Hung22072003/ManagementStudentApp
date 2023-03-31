using ManagementStudentApp.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementStudentApp.DTO;

namespace ManagementStudentApp.BLL
{
    internal class QLSVBLL
    {
        public delegate bool Compare(object o1, object o2);
        public static void SortAscending(ref List<Student> listStudents, Compare cmp)
        {
            for (int i = 0; i < listStudents.Count - 1; i++)
            {
                for (int j = i + 1; j < listStudents.Count; j++)
                {
                    if (cmp(listStudents[i], listStudents[j]))
                    {
                        Student temp = listStudents[i];
                        listStudents[i] = listStudents[j];
                        listStudents[j] = temp;
                    }
                }
            }
        }

        public static void SortDescending(ref List<Student> listStudents, Compare cmp)
        {
            for (int i = 0; i < listStudents.Count - 1; i++)
            {
                for (int j = i + 1; j < listStudents.Count; j++)
                {
                    if (!cmp(listStudents[i], listStudents[j]))
                    {
                        Student temp = listStudents[i];
                        listStudents[i] = listStudents[j];
                        listStudents[j] = temp;
                    }
                }
            }
        }
        public List<string> SetCBBLSH()
        {
            string query = "select distinct LopSH from SV ";
            DataTable dt = DBHelper.Instance.GetRecords(query);
            List<string> list = new List<string>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(row["LopSH"].ToString());
            }
            return list;
        }

        public List<Student> GetStudentDRV(string text1, string text2)
        {
            QLSVDAL dal = new QLSVDAL();    
            List<Student> list = new List<Student>();
            if (text1 == "All")
            {
                foreach(Student i in dal.GetAllStudent())
                {
                    if (i.Name.Contains(text2)) list.Add(i);
                }
            } else
            {
                foreach (Student i in dal.GetAllStudent())
                {
                    if (i.LopSH == text1 && i.Name.Contains(text2)) list.Add(i);
                }
            }
            return list;
        }

        public void DeleteStudentBll(List<string> list)
        {
            QLSVDAL dal = new QLSVDAL();
            foreach(string i in list)
            {
                dal.DeleteStudentDAL(i);
            }
        }

        public void AddUpdate(Student St)
        {
            QLSVDAL dal = new QLSVDAL();
            List<string> li = new List<string>();
            foreach (Student s in dal.GetAllStudent())
            {
                li.Add(s.MSSV);
            }

            if (li.IndexOf(St.MSSV) != -1)
            {
                dal.UpdateStudentDAL(St);
            }
            else
            {
                dal.AddStudentDAL(St);
            }
        }

        public Student FindStudent(string str)
        {
            QLSVDAL dal = new QLSVDAL();
            foreach (Student student in dal.GetAllStudent())
            {
                if (student.MSSV == str) return student;
            }
            return null;
        }

        public List<Student> GetListStudent(List<string> li)
        {
            QLSVDAL dal = new QLSVDAL();
            List<Student> data = new List<Student>();
            foreach (string i in li)
            {
                foreach (Student j in dal.GetAllStudent())
                {
                    if (i == j.MSSV)
                    {
                        data.Add(j);
                    }
                }

            }
            return data;
        }

        public List<Student> SortBy(List<string> li, string s)
        {
            List<Student> data = new List<Student>();
            data = GetListStudent(li);
            if (s == "MSSV (min -> max)")
            {
                SortAscending(ref data, Student.CompareMSSV);
            }

            if (s == "MSSV (max -> min)")
            {
                SortDescending(ref data, Student.CompareMSSV);
            }

            if (s == "DTB (min -> max)")
            {
                SortAscending(ref data, Student.CompareDTB);
            }

            if (s == "DTB (max -> min)")
            {
                SortDescending(ref data, Student.CompareDTB);
            }

            if (s == "Name (min -> max)")
            {
                SortAscending(ref data, Student.CompareName);
            }

            if (s == "Name (max -> min)")
            {
                SortDescending(ref data, Student.CompareName);
            }

            return data;
        }
    }
}
