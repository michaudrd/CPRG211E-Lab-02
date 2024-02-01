using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CPRG211E_Lab_02
{
    public class Salaried : Employee
    {
        public double salary {  get; set; }

        public Salaried()
        {

        }

        public Salaried(string id, string name, string address, string phone, long sin, string dob, string dept, double salary) : base(id, name, address, phone, sin, dob, dept)
        {
            this.salary = salary;
        }

        public override double GetPay()
        {
            return salary;
        }

        public override string ToString()
        {
            return $"ID: {id}\n" +
            $"Name: {name}\n" +
            $"Address: {address}\n" +
            $"Phone Number: {phone}\n" +
            $"SIN: {sin}\n" +
            $"DOB: {dob}\n" +
            $"Department: {dept}\n" +
            $"Salary: {salary}";
        }
    }
}
