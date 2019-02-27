using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class Admin : User
    {
        internal delegate void Delegate_Crud();

        public override void LogIn()
        {
            UserInterface.DisplayUserOptions("What is your password?");
            string password = UserInterface.GetUserInput();
            if (password.ToLower() != "poiuyt")
            {
                UserInterface.DisplayUserOptions("Incorrect password please try again or type exit");
            }
            else
            {
                RunUserMenus();
            }
        }

        protected override void RunUserMenus()
        {
            Console.Clear();
            List<string> options = new List<string>() { "Admin log in successful.", "What would you like to do?", "1. Create new employee", "2. Read employee info", "3. Update emplyee info", "4. Delete employee", "(type 1, 2, 3, 4,  create, read, update, or delete )" };
            UserInterface.DisplayUserOptions(options);
            string input = UserInterface.GetUserInput();
            RunInput(input);
        }
        protected void RunInput(string input)
        {
            Delegate_Crud EmployeeQueries = null;
            try
            {
              
                if (input == "1" || input.ToLower() == "create")
                {
                    EmployeeQueries = AddEmployee;
                    
                }
                else if (input == "2" || input.ToLower() == "read")
                {
                    EmployeeQueries = ReadEmployee;
               

                }
                else if (input == "3" || input.ToLower() == "update")
                {
                    EmployeeQueries = UpdateEmployee;

                }
                else if (input == "4" || input.ToLower() == "delete")
                {
                    EmployeeQueries = RemoveEmployee;

                }
                EmployeeQueries();
            }
            catch(NullReferenceException)
            {
                    UserInterface.DisplayUserOptions("Input not recognized please try again or type exit. Press any key to continue.");
                Console.ReadKey();
            }
            
            RunUserMenus();
        }

        private void UpdateEmployee()
        {
            Employee employee = new Employee();
            // Doesn't actually set PK EmployeeId. Temporarily sets it to find it in updateEmployeeFromDb
            employee.EmployeeId = int.Parse(UserInterface.GetUserInputWithOutput("What is the Unique Id you wish send these updates to?"));
            employee.FirstName = UserInterface.GetStringData("first name", "the employee's");
            employee.LastName = UserInterface.GetStringData("last name", "the employee's");
            employee.EmployeeNumber = int.Parse(UserInterface.GetStringData("employee number", "the employee's"));
            employee.Email = UserInterface.GetStringData("email", "the employee's");
            try
            {
                Query.RunEmployeeQueries(employee, "update");
                UserInterface.DisplayUserOptions("Employee update successful.");
            }
            catch
            {
                Console.Clear();
                UserInterface.DisplayUserOptions("Employee update unsuccessful please try again or type exit;");
                return;
            }
        }



        private void ReadEmployee()
        {
            try
            {
                Employee employee = new Employee();
                employee.EmployeeNumber = int.Parse(UserInterface.GetStringData("employee number", "the employee's"));
                Query.RunEmployeeQueries(employee, "read");
            }
            catch
            {
                Console.Clear();
                UserInterface.DisplayUserOptions("Employee not found please try again or type exit;");
                return;
            }
        }

        private void RemoveEmployee()
        {
            Employee employee = new Employee
            {
                EmployeeId = int.Parse(UserInterface.GetUserInputWithOutput("What is the Unique Id you wish send these updates to?"))
                
            };
            
            employee.EmployeeNumber = int.Parse(UserInterface.GetStringData("employee number", "the employee's"));
            try
            {
                Console.Clear();
                Query.RunEmployeeQueries(employee, "delete");
                UserInterface.DisplayUserOptions("Employee successfully removed");
            }
            catch
            {
                Console.Clear();
                UserInterface.DisplayUserOptions("Employee removal unsuccessful please try again or type exit");
                RemoveEmployee();
            }
        }

        private void AddEmployee()
        {
            Employee employee = new Employee();
            employee.FirstName = UserInterface.GetStringData("first name", "the employee's");
            employee.LastName = UserInterface.GetStringData("last name", "the employee's");
            employee.EmployeeNumber = int.Parse(UserInterface.GetStringData("employee number", "the employee's"));
            employee.Email = UserInterface.GetStringData("email", "the employee's"); ;
            try
            {
                Query.RunEmployeeQueries(employee, "create");
                UserInterface.DisplayUserOptions("Employee addition successful.");
            }
            catch
            {
                Console.Clear();
                UserInterface.DisplayUserOptions("Employee addition unsuccessful please try again or type exit;");
                return;
            }
        }

    }
}
