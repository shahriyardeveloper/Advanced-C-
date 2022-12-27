using HRAdministrationAPI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HRAdministration
{    
    internal class Program
    {
        static void Main(string[] args)
        {
            var employees = new List<IEmployee>();
            SeedData(employees);

            Console.WriteLine($"Total salary: {employees.Sum(e => e.Salary)}");
            Console.ReadKey();
        }

        public static void SeedData(List<IEmployee> employees)
        {
            IEmployee teacher = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 1, "Shahriyar", "Safarov", 4000);
            employees.Add(teacher);

            IEmployee headOfDepartment = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadOfDepartment, 1, "Bunyamin", "Abbasov", 5000);
            employees.Add(headOfDepartment);

            IEmployee deputyHeadMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.DeputyHeadMaster, 1, "Turxay", "Mammadov", 6000);
            employees.Add(deputyHeadMaster);

            IEmployee headOfMaster = EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadOfMaster, 1, "Axmed", "Abbasov", 7000);
            employees.Add(headOfMaster);
        }
    }

    public class Teacher : EmployeeBase { }
    public class DeputyHeadMaster : EmployeeBase { }
    public class HeadOfDepartment : EmployeeBase { }
    public class HeadOfMaster : EmployeeBase { }

    public static class EmployeeFactory
    {
        public static IEmployee GetEmployeeInstance(EmployeeType employeeType, int id, string firstName, string lastName, decimal salary)
        {
            IEmployee employee = null;
            switch (employeeType)
            {
                case EmployeeType.Teacher:
                    employee = FactoryPattern<IEmployee, Teacher>.GetInstance();
                    break;
                case EmployeeType.HeadOfDepartment:
                    employee = FactoryPattern<IEmployee, HeadOfDepartment>.GetInstance();
                    break;
                case EmployeeType.DeputyHeadMaster:
                    employee = FactoryPattern<IEmployee, DeputyHeadMaster>.GetInstance();
                    break;
                case EmployeeType.HeadOfMaster:
                    employee = FactoryPattern<IEmployee, HeadOfMaster>.GetInstance();
                    break;
                default:
                    break;

            }

            if (employee != null)
            {
                employee.Id = id;
                employee.FirstName = firstName;
                employee.LastName = lastName;
                employee.Salary = salary;
            }
            else
                throw new NullReferenceException();

            return employee;
        }
    }

    public enum EmployeeType
    {
        Teacher,
        HeadOfDepartment,
        DeputyHeadMaster,
        HeadOfMaster
    }
}
