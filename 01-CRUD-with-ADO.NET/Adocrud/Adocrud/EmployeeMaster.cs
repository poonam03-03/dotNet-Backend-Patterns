using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOcrudoops
{
    internal class EmployeeMaster : DBManager
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string EmailId { get; set; }

        public int Age { get; set; }
        public int Salary { get; set; }

        public void takeinput()
        {
            Console.WriteLine("Enter your  name : ");
            Name = Console.ReadLine();
            Console.WriteLine("Enter your EmailId : ");
            EmailId = Console.ReadLine();
            Console.WriteLine("Enter your age : ");
            Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your salary : ");
            Salary = int.Parse(Console.ReadLine());
        }

        // to insert record
        public string toinsertrecord()
        {
            takeinput();
            mycommand = "insert into emp(Name,EmailId,Age,Salary) values('" + Name + "','" + EmailId + "','" + Age + "','" + Salary + "')";
            bool b = isinsertupdatedelete();
            if (b)
                res = "Record successfully";
            else
                res = "Sorry";
            return res;
        }
        public void toshowrecord()
        {
            mycommand = "Select * from Employee";
            DataTable dt = tofetchrecord();
            foreach (DataRow dr in dt.Rows)
            {
                Console.WriteLine(dr["Id"]);
                Console.WriteLine(dr["Name"]);
                Console.WriteLine(dr["EmailId"]);
                Console.WriteLine(dr["Age"]);
                Console.WriteLine(dr["Salary"]);
            }
        }
        //to update record
        public string toupdateRecord()
        {

            Console.WriteLine("Enter the id which you want to update");
            int id = int.Parse(Console.ReadLine());
            takeinput();
            mycommand = "update Employee set Name='" + Name + "',EmailId='" + EmailId + "',Age='" + Age + "',Salary='" + Salary + "'where id ='" + id + "'";
            bool msg = isinsertupdatedelete();
            if (msg)
                res = "Record Updated sucessfully";
            else
                res = "Sorry unable to update the record";
            return res;

        }

        // to delete record

        public string todeleteRecord()
        {
            Console.WriteLine("Enter the id which you want to delete");
            int id = int.Parse(Console.ReadLine());
            //takeinput();
            mycommand = "Delete from Employee where id='" + id + "'";
            bool msg = isinsertupdatedelete();
            if (msg)
                res = "Record Deleted Sucessfully";
            else
                res = "Sorry unable to delete the record";

            return res;

        }
    }
}