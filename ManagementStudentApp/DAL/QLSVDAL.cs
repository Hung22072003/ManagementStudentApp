using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementStudentApp.DTO;

namespace ManagementStudentApp.DAL
{
    internal class QLSVDAL
    {
        public Student GetStudentByDataRow(DataRow row)
        {
            return new Student
            {
                MSSV = row["MSSV"].ToString(),
                Name = row["Name"].ToString(),
                LopSH = row["LopSH"].ToString(),
                Gender = Convert.ToBoolean(row["Gender"].ToString()),
                Ngaysinh = DateTime.Parse(row["NgaySinh"].ToString()),
                DTB = Convert.ToDouble(row["DTB"].ToString()),
                Anh = Convert.ToBoolean(row["Anh"].ToString()),
                HocBa = Convert.ToBoolean(row["HocBa"].ToString()),
                CCCD = Convert.ToBoolean(row["CCCD"].ToString())
            };
        }

        public List<Student> GetAllStudent()
        {
            List<Student> listStudents = new List<Student>();
            string query = "select * from SV";
            foreach (DataRow i in DBHelper.Instance.GetRecords(query).Rows)
            {
                listStudents.Add(GetStudentByDataRow(i));
            }
            return listStudents;
        }

        public void AddStudentDAL(Student St) 
        {
            string query = "insert into SV (MSSV, Name, LopSH, Gender, NgaySinh, DTB, Anh, HocBa, CCCD) values('"
                    + St.MSSV + "','" + St.Name + "','" + St.LopSH + "'," + ((St.Gender) ? "1" : "0") + ",'" + St.Ngaysinh.ToString()
                    + "'," + St.DTB.ToString() + ", " + ((St.Anh) ? "1" : "0") + ", " + ((St.HocBa) ? "1" : "0") + ", " + ((St.CCCD) ? "1" : "0") + ")";
            DBHelper.Instance.ExcuteDB(query);
        }

        public void UpdateStudentDAL(Student St)
        {
            string query = "update SV set Name = '" + St.Name + "', LopSH = '" + St.LopSH + "', Gender = " + ((St.Gender) ? "1" : "0") + ", NgaySinh = '" + St.Ngaysinh.ToString()
                    + "', DTB = " + St.DTB.ToString() + ", Anh = " + ((St.Anh) ? "1" : "0") + ", HocBa = " + ((St.HocBa) ? "1" : "0") + ", CCCD = " + ((St.CCCD) ? "1" : "0") + "where MSSV = '" + St.MSSV + "'";
            DBHelper.Instance.ExcuteDB(query);
        }

        public void DeleteStudentDAL(string MSSV)
        {
            string query = "delete from SV where MSSV = N'" + MSSV + "'";
            DBHelper.Instance.ExcuteDB(query);
        }
    }
}
