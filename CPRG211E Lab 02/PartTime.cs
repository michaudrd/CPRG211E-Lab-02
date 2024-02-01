using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211E_Lab_02
{
    public class PartTime : Employee
    {
        public double rate { get; set; }
        public double hours { get; set; }

        public PartTime()
        {

        }

        public PartTime(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours) : base(id, name, address, phone, sin, dob, dept)
        {
            this.rate = rate;
            this.hours = hours;
        }

        public override double GetPay()
        {
            return rate * hours;
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
            $"Rate: {rate}\n" +
            $"Hours: {hours}";
        }
    }
}
