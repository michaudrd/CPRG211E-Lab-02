using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPRG211E_Lab_02
{
    public class Wages : Employee
    {
        public double rate {  get; set; }
        public double hours { get; set; }

        public Wages()
        {

        }

        public Wages(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours) : base(id, name, address, phone, sin, dob, dept)
        {
            this.rate = rate;
            this.hours = hours;
        }

        public override double GetPay()
        {
            if (hours > 40)
            {
                double pay = rate * 40;
                double overtime = (hours - 40) * rate * 1.5;
                return pay + overtime;
            }

            else
            {
                return hours * rate;
            }
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
