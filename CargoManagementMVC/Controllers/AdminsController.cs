using CargoManagementDataAccess.Entity.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static System.Net.WebRequestMethods;

namespace CargoManagementMVC.Controllers
{
    public class AdminsController : Controller
    {

        //admin dashboard
        //a comment
        public ActionResult AdminDashboard()
        {
            return View();
        }

        // GET: Admin (Read All)
        public async Task<ActionResult> Index()
        {
            string apiUrl = "http://localhost:62239/api/Admin/GetAllAdmin";
            List<Admin> admins = new List<Admin>();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    admins = await response.Content.ReadAsAsync<List<Admin>>();
                }
            }
            return View(admins);
        }

        //Create Employee
        // GET: Employees/Create
        public ActionResult CreateEmployee()
        {
            return View();
        }
        // POST: Employees/Create
        [HttpPost]
        public async Task<ActionResult> CreateEmployee(Employee employee)
        {
            const string apiUrl = "http://localhost:62239/api/Employee/CreateEmployee";
            if (!ModelState.IsValid) return View(employee);

            try
            {
                using (var client = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        TempData["Message"] = "Employee created successfully!";
                        return RedirectToAction("Success", "Redirected");
                    }

                    TempData["Message"] = "Error: Could not create employee. Please try again.";
                    return RedirectToAction("Error", "Redirected");
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = $"Exception: {ex.Message}";
                return RedirectToAction("Error", "Redirected");
            }
        }


        //Get all employees
        public async Task<ActionResult> EmployeesList()
        {
            string apiUrl = "http://localhost:62239/api/Employee/GetAllEmployee";
            List<Employee> employees = new List<Employee>();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    employees = await response.Content.ReadAsAsync<List<Employee>>();
                }
            }
            return View(employees);
        }


        //get emp by id
        public async Task<ActionResult> EmployeeDetails(int id)
        {
            string apiUrl = $"http://localhost:62239/api/Employee/GetEmployeeById/{id}";
            Employee employee = null;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    employee = await response.Content.ReadAsAsync<Employee>();
                }
            }
            return View(employee);
        }

        //edit emp details
        public async Task<ActionResult> EditEmployee(int id)
        {
            string apiUrl = $"http://localhost:62239/api/Employee/GetEmployeeById/{id}";
            Employee employee = null;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    employee = await response.Content.ReadAsAsync<Employee>();
                }
            }
            return View(employee);
        }

        [HttpPost]
        public async Task<ActionResult> EditEmployee(int id, Employee employee)
        {
            string apiUrl = $"http://localhost:62239/api/Employee/UpdateEmployee/{id}";
            if (!ModelState.IsValid) return View(employee);

            try
            {
                using (var client = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");

                    var response = await client.PutAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        TempData["Message"] = "Employee updated successfully!";
                        return RedirectToAction("Success", "Redirected");
                    }

                    TempData["Message"] = "Error: Could not update employee. Please try again.";
                    return RedirectToAction("Error", "Redirected");
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = $"Exception: {ex.Message}";
                return RedirectToAction("Error", "Redirected");
            }
        }

        public async Task<ActionResult> DeleteEmployee(int id)
        {
            string apiUrl = $"http://localhost:62239/api/Employee/GetEmployeeById/{id}";
            Employee employee = null;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    employee = await response.Content.ReadAsAsync<Employee>();
                }
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            string apiUrl = $"http://localhost:62239/api/Employee/DeleteEmployee/{id}";

            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.DeleteAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        TempData["Message"] = "Employee deleted successfully!";
                        return RedirectToAction("Success", "Redirected");
                    }
                    else
                    {
                        TempData["Message"] = "Error deleting the employee. Please try again.";
                        return RedirectToAction("Error", "Redirected");
                    }
                }
                catch (Exception ex)
                {
                    TempData["Message"] = $"Error: {ex.Message}";
                    return RedirectToAction("Error", "Redirected");
                }
            }
        }




        //get all customer
        public async Task<ActionResult> CustomersList()
        {
            string apiUrl = "http://localhost:62239/api/Customer/GetAllCustomer";
            List<Customer> customer = new List<Customer>();
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    customer = await response.Content.ReadAsAsync<List<Customer>>();
                }
            }
            return View(customer);
        }

        //Get All CargoTypes
        // GET: CargoTypes

        public async Task<ActionResult> CargoTypeList()

        {

            string apiUrl = "http://localhost:62239/api/CargoTypes/GetAllCargoTypes";

            List<CargoType> cargotypes = new List<CargoType>();

            using (var client = new HttpClient())

            {

                var response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)

                {

                    cargotypes = await response.Content.ReadAsAsync<List<CargoType>>();

                }

            }

            return View(cargotypes);

        }

        //create cargotype view
        public ActionResult CreateCargoType()
        {
            return View();
        }

        //Create cargotype

        [HttpPost]
        public async Task<ActionResult> CreateCargoType(CargoType cargoType)
        {
            const string apiUrl = "http://localhost:62239/api/CargoTypes/CreateCargoType";
            if (!ModelState.IsValid) return View(cargoType);

            try
            {
                using (var client = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(cargoType), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        TempData["Message"] = "CargoType created successfully!";
                        return RedirectToAction("Success", "Redirected");
                    }

                    TempData["Message"] = "Error: Could not create cargoType. Please try again.";
                    return RedirectToAction("Error", "Redirected");
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = $"Exception: {ex.Message}";
                return RedirectToAction("Error", "Redirected");
            }
        }

        

        //edit cargotype
        public async Task<ActionResult> EditCargoType(int id)
        {
            string apiUrl = $"http://localhost:62239/api/CargoTypes/GetCargoTypeById/{id}";
            CargoType cargoType = null;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    cargoType = await response.Content.ReadAsAsync<CargoType>();
                }
            }
            return View(cargoType);
        }

        [HttpPost]
        public async Task<ActionResult> EditCargoType(int id, CargoType cargotype)
        {
            string apiUrl = $"http://localhost:62239/api/CargoTypes/UpdateCargoType/{id}";
            if (!ModelState.IsValid) return View(cargotype);

            try
            {
                using (var client = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(cargotype), Encoding.UTF8, "application/json");

                    var response = await client.PutAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        TempData["Message"] = "Cargotype updated successfully!";
                        return RedirectToAction("Success", "Redirected");
                    }

                    TempData["Message"] = "Error: Could not update Cargotype. Please try again.";
                    return RedirectToAction("Error", "Redirected");
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = $"Exception: {ex.Message}";
                return RedirectToAction("Error", "Redirected");
            }
        }


        //get all city
        public async Task<ActionResult> CityList()

        {

            string apiUrl = "http://localhost:62239/api/Cities/GetAllCities";

            List<City> city = new List<City>();

            using (var client = new HttpClient())

            {

                var response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)

                {

                    city = await response.Content.ReadAsAsync<List<City>>();

                }

            }

            return View(city);

        }

        //edit city : get by id
        public async Task<ActionResult> EditCity(int id)
        {
            string apiUrl = $"http://localhost:62239/api/Cities/GetCityById/{id}";
            City city = null;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    city = await response.Content.ReadAsAsync<City>();
                }
            }
            return View(city);
        }

        //update city
        //post

        [HttpPost]
        public async Task<ActionResult> EditCity(int id, City city)
        {
            string apiUrl = $"http://localhost:62239/api/Cities/UpdateCity/{id}";
            if (!ModelState.IsValid) return View(city);

            try
            {
                using (var client = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(city), Encoding.UTF8, "application/json");

                    var response = await client.PutAsync(apiUrl, content);

                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        TempData["Message"] = "City updated successfully!";
                        return RedirectToAction("Success", "Redirected");
                    }

                    TempData["Message"] = "Error: Could not update City. Please try again.";
                    return RedirectToAction("Error", "Redirected");
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = $"Exception: {ex.Message}";
                return RedirectToAction("Error", "Redirected");
            }
        }


    }
}