using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    public static class Query
    {
        public delegate int StringToIntFunction(string s);
        internal static List<USState> GetStates()
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();

            List<USState> allStates = db.USStates.ToList();

            return allStates;
        }

        internal static Client GetClient(string userName, string password)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();

            Client client = db.Clients.Where(c => c.UserName == userName && c.Password == password).Single();

            return client;
        }

        internal static List<Client> GetClients()
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();

            List<Client> allClients = db.Clients.ToList();

            return allClients;
        }

        internal static void AddNewClient(string firstName, string lastName, string username, string password, string email, string streetAddress, int zipCode, int stateId)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();

            Client newClient = new Client();

            newClient.FirstName = firstName;
            newClient.LastName = lastName;
            newClient.UserName = username;
            newClient.Password = password;
            newClient.Email = email;

            Address addressFromDb = db.Addresses.Where(a => a.AddressLine1 == streetAddress && a.Zipcode == zipCode && a.USStateId == stateId).FirstOrDefault();

            // if the address isn't found in the Db, create and insert it
            if (addressFromDb == null)
            {
                Address newAddress = new Address();
                newAddress.AddressLine1 = streetAddress;
                newAddress.AddressLine2 = null;
                newAddress.Zipcode = zipCode;
                newAddress.USStateId = stateId;

                db.Addresses.InsertOnSubmit(newAddress);
                db.SubmitChanges();

                addressFromDb = newAddress;
            }

            // attach AddressId to clientFromDb.AddressId
            newClient.AddressId = addressFromDb.AddressId;

            db.Clients.InsertOnSubmit(newClient);

            db.SubmitChanges();
        }

        internal static void UpdateClient(Client clientWithUpdates)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();

            // find corresponding Client from Db
            Client clientFromDb = db.Clients.Where(c => c.ClientId == clientWithUpdates.ClientId).Single();

            // update clientFromDb information with the values on clientWithUpdates (aside from address)
            clientFromDb.FirstName = clientWithUpdates.FirstName;
            clientFromDb.LastName = clientWithUpdates.LastName;
            clientFromDb.UserName = clientWithUpdates.UserName;
            clientFromDb.Password = clientWithUpdates.Password;
            clientFromDb.Email = clientWithUpdates.Email;

            // get address object from clientWithUpdates
            Address clientAddress = clientWithUpdates.Address;

            // look for existing Address in Db (null will be returned if the address isn't already in the Db
            Address updatedAddress = db.Addresses.Where(a => a.AddressLine1 == clientAddress.AddressLine1 && a.USStateId == clientAddress.USStateId && a.Zipcode == clientAddress.Zipcode).FirstOrDefault();

            // if the address isn't found in the Db, create and insert it
            if(updatedAddress == null)
            {
                Address newAddress = new Address();
                newAddress.AddressLine1 = clientAddress.AddressLine1;
                newAddress.AddressLine2 = null;
                newAddress.Zipcode = clientAddress.Zipcode;
                newAddress.USStateId = clientAddress.USStateId;

                db.Addresses.InsertOnSubmit(newAddress);
                db.SubmitChanges();

                updatedAddress = newAddress;
            }

            // attach AddressId to clientFromDb.AddressId
            clientFromDb.AddressId = updatedAddress.AddressId;
            
            // submit changes
            db.SubmitChanges();
        }
        internal static void Adopt(Animal animal, Client client)
        {
           
        }
        internal static List<Adoption> GetPendingAdoptions()
        {
            List<Adoption> animals = new List<Adoption>();
            return animals;
        }
        internal static Employee RetrieveEmployeeUser(string email, int employeeNumber)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();

            Employee employeeFromDb = db.Employees.Where(e => e.Email == email && e.EmployeeNumber == employeeNumber).FirstOrDefault();

            if(employeeFromDb == null)
            {
                throw new NullReferenceException();            
            }
            else
            {
                return employeeFromDb;
            }            
        }
        internal static void UpdateAdoption(bool accessibility, Adoption adoption)
        {

        }

        internal static Employee EmployeeLogin(string userName, string password)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();

            Employee employeeFromDb = db.Employees.Where(e => e.UserName == userName && e.Password == password).FirstOrDefault();

            return employeeFromDb;
        }

        internal static bool CheckEmployeeUserNameExist(string userName)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();

            Employee employeeWithUserName = db.Employees.Where(e => e.UserName == userName).FirstOrDefault();

            return employeeWithUserName == null;
        }
        internal static void RunEmployeeQueries(Employee employee, string words)
        {

        }

        internal static void AddUsernameAndPassword(Employee employee)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();

            Employee employeeFromDb = db.Employees.Where(e => e.EmployeeId == employee.EmployeeId).FirstOrDefault();

            employeeFromDb.UserName = employee.UserName;
            employeeFromDb.Password = employee.Password;

            db.SubmitChanges();
        }
        internal static int? GetCategoryId()
        {

            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            string input = UserInterface.GetUserInputWithOutput("What type of animal are you cataloging?");
            int ?category = db.Categories.Where(c => c.Name == input).Select(c => c.CategoryId).Single();
            if (category == null)
            {
                Console.WriteLine("This species does not exist.");
                int newCategory = AddCategoryName();
                return newCategory;
            }
            return category;
        }
        internal static int AddCategoryName()
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            Category newCategory = new Category();
            
            string input = UserInterface.GetUserInputWithOutput("What would you like to name this new species?");
            newCategory.Name = input;
            db.Categories.InsertOnSubmit(newCategory);
            db.SubmitChanges();
            int category = db.Categories.Where(c => c.Name == input).Select(c => c.CategoryId).Single();
            
            return category;
        }
        internal static Animal GetAnimalByID(int AnimalId, string name)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();

            Animal animal = db.Animals.Where(a => a.AnimalId == AnimalId && a.Name == name).Single();

            return animal;
        }
        public static int GetDietPlanId()
        {
            //this is an empty method with a dummy return to remove an error. FIX
            return 6;
        }
        internal static List<Animal> SearchForAnimalByMultipleTraits()
        {
            List<Animal> animal = new List<Animal>();
            return animal;
        }
        internal static void AddAnimal(Animal animal)
        {
            //Create
        }
        internal static void EnterAnimalUpdate(Animal animal, Dictionary<int, string> updates)
        {

        }
        internal static void RemoveAnimal(Animal animal)
        {
            //Delete
        }
        internal static List<AnimalShot> GetShots(Animal animal)
        {
                HumaneSocietyDataContext db = new HumaneSocietyDataContext();
                List<AnimalShot> animalShots = new List<AnimalShot>();
                animalShots = db.AnimalShots.Where(s => s.AnimalId == animal.AnimalId).ToList();
            
            return animalShots;
        }
        internal static void UpdateShot(string booster, Animal animal)
        {
            int year;
            int month;
            int day;
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();
            AnimalShot animalShot = new AnimalShot();
            if (UserInterface.GetBitData($"Was {booster} what you meant to type?"))
            {
                //DateTime get
                Console.WriteLine("What year was the shot administered?");
                year = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("What month was the shot administered?");
                month = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine("What day was the shot administered?");
                day = Convert.ToInt16(Console.ReadLine());
                DateTime date = new DateTime(year, month, day);
                animalShot.DateReceived = date;
                animalShot.AnimalId = animal.AnimalId;
                animalShot.ShotId = db.Shots.Where(s => s.Name == booster).Select(s=>s.ShotId).Single();
            }
            

        }
        internal static Room GetRoom(int AnimalId)
        {
            HumaneSocietyDataContext db = new HumaneSocietyDataContext();

            Room room = new Room();

            return room;
        }
    }

}