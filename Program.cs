using System;
using System.Xml.Linq;

class EmployeeDatabase
{
    XElement employeeData = new XElement("EmployeeData");
    //static XElement employeeData = XElement.Load("D://EmployeeData.xml");
    public static void Main(string[] args)
    {
        Boolean flag = true;
        int choice = 0;

        try
        {
            while (flag)
            {
                menu();
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddEmployeeData();
                        break;
                    case 2:
                        UpdateEmployeeData();
                        break;
                    case 3:
                        DeleteEmployeeData();
                        break;
                    case 4:
                        ShowEmployeeData();
                        break;
                    case 5:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("\n\n");
            }
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadKey();
        }
        finally { 
            Console.ReadKey();
            employeeData.Save("D://EmployeeData.xml");
        }
    }

    public static void menu()
    {
        Console.WriteLine("=====================================");
        Console.WriteLine("========= EmployeeDB ================");
        Console.WriteLine("=====================================");
        Console.WriteLine("====== 1. Add new Data ==============");
        Console.WriteLine("====== 2. Update Data  ==============");
        Console.WriteLine("====== 3. Delete Data  ==============");
        Console.WriteLine("====== 4. Show Data    ==============");
        Console.WriteLine("====== 5. Exit         ==============");
        Console.WriteLine("=====================================");
        Console.WriteLine("Choice => ");
    }

    public static void AddEmployeeData()
    {
        Console.WriteLine("=====================================");
        Console.WriteLine("Enter Employee ID: ");
        string employee_id = Console.ReadLine();
        Console.WriteLine("Enter Employee Name: ");
        string employee_name = Console.ReadLine();
        Console.WriteLine("Enter Employee Department: ");
        string employee_dept = Console.ReadLine();
        Console.WriteLine("Enter Employee Salary: ");
        int employee_salary = Convert.ToInt32(Console.ReadLine());

        XElement employee = new XElement("Employee",
            new XElement("EmployeeID", employee_id),
            new XElement("EmployeeName", employee_name),
            new XElement("EmployeeDepartment", employee_dept),
            new XElement("EmployeeSalary", employee_salary)
        );

        employeeData.Add(employee);
    
        Console.WriteLine("====== Added Data to EmployeeDB =====");
        Console.WriteLine("=====================================");
    }

    public static void UpdateEmployeeData()
    {
        Console.WriteLine("=====================================");
        Console.WriteLine("Enter Employee ID: ");
        string employee_id = Console.ReadLine();

        Console.WriteLine("=====================================");
        Console.WriteLine("====== 1. Update Name ===============");
        Console.WriteLine("====== 2. Update Department  ========");
        Console.WriteLine("====== 3. Update Salary  ============");
        Console.WriteLine("=====================================");

        int employee_update = Convert.ToInt32(Console.ReadLine());

        XElement employee = employeeData.Elements("Employee").FirstOrDefault(e => e.Element("EmployeeID").Value == employee_id);

        if (employee != null)
        {
            switch (employee_update)
            {
                case 1:
                    Console.WriteLine("Enter Employee Name: ");
                    string employee_name = Console.ReadLine();
                    employee.Element("EmployeeName").Value = employee_name;
                    break;
                case 2:
                    Console.WriteLine("Enter Employee Department: ");
                    string employee_dept = Console.ReadLine();
                    employee.Element("EmployeeDepartment").Value = employee_dept;
                    break;
                case 3:
                    Console.WriteLine("Enter Employee Salary: ");
                    int employee_salary = Convert.ToInt32(Console.ReadLine());
                    employee.Element("EmployeeSalary").Value = employee_salary.ToString();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine("=====================================");
            Console.WriteLine("====== Updated Data to EmployeeDB ===");
            Console.WriteLine("=====================================");
        }
        else
        {
            Console.WriteLine("Employee with ID " + employee_id + " not found.");
        }
    }

    public static void DeleteEmployeeData()
    {
        Console.WriteLine("=====================================");
        Console.WriteLine("Enter Employee ID: ");
        string employee_id = Console.ReadLine();

        XElement employee = employeeData.Elements("Employee").FirstOrDefault(e => e.Element("EmployeeID").Value == employee_id);

        if (employee != null)
        {
            employee.Remove();
            Console.WriteLine("===== Deleted Data to EmployeeDB ====");
            Console.WriteLine("=====================================");
        }
        else
        {
            Console.WriteLine("Employee with ID " + employee_id + " not found.");
        }
    }

    public static void ShowEmployeeData()
    {
        Console.WriteLine("=====================================");
        Console.WriteLine("============ EmployeeDB =============");
        Console.WriteLine("=====================================\n");

        foreach (var employee in employeeData.Elements("Employee"))
        {
            Console.WriteLine("Employee ID: " + employee.Element("EmployeeID").Value);
            Console.WriteLine("Employee Name: " + employee.Element("EmployeeName").Value);
            Console.WriteLine("Employee Department: " + employee.Element("EmployeeDepartment").Value);
            Console.WriteLine("Employee Salary: " + employee.Element("EmployeeSalary").Value);
            Console.WriteLine("\n");
        }

        Console.WriteLine("===== Data Printed - EmployeeDB =====");
        Console.WriteLine("=====================================");
    }
}