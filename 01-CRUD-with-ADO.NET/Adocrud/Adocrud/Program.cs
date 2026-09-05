using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOcrudoops
{
    internal class Program
    {
        static void Main(string[] args)
        {

            EmployeeMaster em = new EmployeeMaster();
            while (true)
            {
                Console.WriteLine("Enter 1 : To insert Record" + "\t" + "Enter 2 : To Show Record" + "\t" + "Enter 3 : To update " + "\t" + "Enter 4 : to delete" + "\t" + "Enter 5 : exit\n");
                int ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        string result = em.toinsertrecord();
                        Console.WriteLine(result);
                        break;
                    case 2:
                        em.toshowrecord();
                        break;
                    case 3:
                        string msg = em.toupdateRecord();
                        Console.WriteLine(msg);
                        break;
                    case 4:
                        string dmsg = em.todeleteRecord();
                        Console.WriteLine(dmsg);
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;


                }
                //string result = em.toinsertrecord();
                //Console.WriteLine(result);
                //em.toshowrecord();
                //em.toupdateRecord();
                string de = em.todeleteRecord();
                Console.WriteLine(de);
                Console.ReadKey();
            }

        }
    }
}