using CPRG211E_Lab_02;

namespace CPRG211E_Lab_02
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] employees = File.ReadAllLines("C:\\Users\\micha\\source\\repos\\CPRG211E Lab 02\\CPRG211E Lab 02\\employees.txt");
            List<Employee> employeeList = new List<Employee>();

            foreach (string employee in employees)
            {
                string[] employeeData = employee.Split(':');

                string id = employeeData[0];
                string name = employeeData[1];
                string address = employeeData[2];
                string phone = employeeData[3];
                long sin = long.Parse(employeeData[4]);
                string dob = employeeData[5];
                string dept = employeeData[6];

                char employeeType = id[0];

                if (employeeType >= '0' && employeeType <= '4')
                {
                    double salary = double.Parse(employeeData[7]);
                    employeeList.Add(new Salaried(id, name, address, phone, sin, dob, dept, salary));
                }
                else if (employeeType >= '5' && employeeType <= '7')
                {
                    double rate = double.Parse(employeeData[7]);
                    double hours = double.Parse(employeeData[8]);
                    employeeList.Add(new Wages(id, name, address, phone, sin, dob, dept, rate, hours));
                }

                else if (employeeType >= '8' && employeeType <= '9')
                {
                    double rate = double.Parse(employeeData[7]);
                    double hours = double.Parse(employeeData[8]);
                    employeeList.Add(new PartTime(id, name, address, phone, sin, dob, dept, rate, hours));
                }
            }

            foreach (Employee employee in employeeList)
            {
                Console.WriteLine(employee.ToString());
                Console.WriteLine();
            }

            Console.WriteLine($"Average weekly pay is {CalculateAveragePay(employeeList)}");

            double highestWage = FindHighestWage(employeeList).GetPay();
            Console.WriteLine($"Highest weekly wage is {highestWage} for {FindHighestWage(employeeList).name}");

            double lowestSalary = FindLowestSalary(employeeList).GetPay();
            Console.WriteLine($"Lowest weekly salary is {lowestSalary} for {FindLowestSalary(employeeList).name}");

            CategoryPercent(employeeList);
        }

        static double CalculateAveragePay(List<Employee> employeeList)

        {
            double total = 0;

            foreach (Employee employee in employeeList)
            {
                total += CalculateWeeklyPay(employee);
            }

            return total / employeeList.Count;
        }

        static double CalculateWeeklyPay(Employee employee)

        {
            if (employee is Salaried salariedEmployee)
            {
                return salariedEmployee.GetPay();
            }
            else if (employee is Wages wageEmployee)
            {
                return wageEmployee.GetPay();
            }
            else if (employee is PartTime partTimeEmployee)
            {
                return partTimeEmployee.GetPay();
            }

            return 0;
        }

        static Employee FindHighestWage(List<Employee> employeeList)
        {
            double highestWage = 0;
            Employee highestWageEmployee = null;

            foreach (Employee employee in employeeList)
            {
                if (employee is Wages wageEmployee)
                {
                    double weeklyPay = wageEmployee.GetPay();
                    if (weeklyPay > highestWage)
                    {
                        highestWage = weeklyPay;
                        highestWageEmployee = employee;
                    }
                }
            }
            return highestWageEmployee;
        }




        static Employee FindLowestSalary(List<Employee> employeeList)
        {
            double lowestSalary = double.MaxValue;
            Employee lowestSalaryEmployee = null;

            foreach (Employee employee in employeeList)
            {
                if (employee is Salaried salariedEmployee)
                {
                    double salary = salariedEmployee.GetPay();
                    if (salary < lowestSalary)
                    {
                        lowestSalary = salary;
                        lowestSalaryEmployee = employee;
                    }
                }
            }

            return lowestSalaryEmployee;
        }

        static void CategoryPercent(List<Employee> employeeList)
        {
            int totalEmployees = employeeList.Count;
            int salariedAmount = 0;
            int wagesAmount = 0;
            int partTimeAmount = 0;

            foreach (Employee employee in employeeList)
            {
                if (employee is Salaried)
                {
                    salariedAmount++;
                }
                else if (employee is Wages)
                {
                    wagesAmount++;
                }
                else if (employee is PartTime)
                {
                    partTimeAmount++;
                }
            }

            double salariedPercentage = (double)salariedAmount / totalEmployees * 100;
            double wagesPercentage = (double)wagesAmount / totalEmployees * 100;
            double partTimePercentage = (double)partTimeAmount / totalEmployees * 100;

            Console.WriteLine($"Salaried employees: {salariedPercentage}%");
            Console.WriteLine($"Wages employees: {wagesPercentage}%");
            Console.WriteLine($"Part time employees: {partTimePercentage}%");
        }
    }    
}

