using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School_Database.Controllers
{
    public class StatisticsController : Controller
    {
        static List<SubjectModel> subjects = new List<SubjectModel>();
        static List<StudentModel> students = new List<StudentModel>();


        [NonAction]
       public void seed()
        {
            subjects = new Data().Get2();
            students = new Data().Get();

        }
        public IActionResult Index()
        {
            seed();
            Response.Cookies.Append("studentCount", students.Count().ToString());
            Response.Cookies.Append("subjectCount", subjects.Count().ToString());
            var oops_max = students.Max(stud => stud.OOPS_Marks);
            var oops_min = students.Min(stud => stud.OOPS_Marks);
            var c_max = students.Max(stud => stud.C_Marks);
            var c_min = students.Min(stud => stud.C_Marks);
            var oops_avg = students.Average(stud => stud.OOPS_Marks);
            var c_avg = students.Average(stud => stud.C_Marks);

            var user_with_max_mks_oops = from stud in students
                                         where stud.OOPS_Marks == oops_max
                                         select new { UserId = stud.ID, UserName = stud.Name,UserAge =stud.Age,UserClass = stud.Class };
            var user_with_max_mks_c = from stud in students
                                       where stud.C_Marks == c_max
                                      select new { UserId = stud.ID, UserName = stud.Name, UserAge = stud.Age, UserClass = stud.Class };
            var user_with_min_mks_oops = from stud in students
                                         where stud.OOPS_Marks == oops_min
                                         select new { UserId = stud.ID, UserName = stud.Name, UserAge = stud.Age, UserClass = stud.Class };
            var user_with_min_mks_c = from stud in students
                                       where stud.C_Marks == c_min
                                      select new { UserId = stud.ID, UserName = stud.Name, UserAge = stud.Age, UserClass = stud.Class };
            Response.Cookies.Append("max_oops", oops_max.ToString());
            Response.Cookies.Append("min_oops", oops_min.ToString());
            Response.Cookies.Append("max_c", c_max.ToString());
            Response.Cookies.Append("min_c", c_min.ToString());
            Response.Cookies.Append("avg_oops", oops_avg.ToString());
            Response.Cookies.Append("avg_c", c_avg.ToString());
            var obj1 = user_with_max_mks_oops.ToArray()[0];
            var obj2 = user_with_min_mks_oops.ToArray()[0];
            var obj3 = user_with_max_mks_c.ToArray()[0];
            var obj4 = user_with_min_mks_c.ToArray()[0];
            Response.Cookies.Append("stud_max_oops", "Name of the student: " + obj1.UserName +  "\tAge of the student:\t" +obj1.UserAge + "\tClass of the student:\t" + obj1.UserClass);
            Response.Cookies.Append("stud_min_oops", "Name of the student: " + obj2.UserName + "\tAge of the student:\t" + obj2.UserAge + "\tClass of the student:\t" + obj2.UserClass);
            Response.Cookies.Append("stud_max_c", "Name of the student: " + obj3.UserName +  "\tAge of the student:\t" + obj3.UserAge + "\tClass of the student:\t" + obj3.UserClass);
            Response.Cookies.Append("stud_min_c", "Name of the student: " + obj4.UserName +  "\tAge of the student:\t" + obj4.UserAge + "\tClass of the student:\t" + obj4.UserClass);


            return View();
        }
        
    }
}
