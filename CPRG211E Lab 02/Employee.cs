using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CPRG211E_Lab_02
{
    public abstract class Employee
    {
        public string id { get; set; }
        public string name { get; set; }
        public long sin { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string dob { get; set; }
        public string dept { get; set; }

        public Employee()
        {

        }

        public Employee(string id, string name, string address, string phone, long sin, string dob, string dept)
        {
            this.id = id;
            this.name = name;
            this.sin = sin;
            this.address = address;
            this.phone = phone;
            this.dob = dob;
            this.dept = dept;
        }

        public abstract double GetPay();

        public override string ToString()
        {
            return $"ID: {id}\n" +
            $"Name: {name}\n" +
            $"Address: {address}\n" +
            $"Phone Number: {phone}\n" +
            $"SIN: {sin}\n" +
            $"DOB: {dob}\n" +
            $"Department: {dept}";
        }

    }
}
