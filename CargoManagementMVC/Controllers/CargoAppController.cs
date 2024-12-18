using CargoManagementDataAccess.Entity.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CargoManagementMVC.Controllers
{
    public class CargoAppController : Controller
    {
        // GET: CargoApp
        public ActionResult CargoHomePage()
        {
            
            return View();
        }

        // logout
        public ActionResult Logout()
        {
            Session.Clear();   // Remove all session keys
            Session.Abandon(); // End the session
            return RedirectToAction("CargoHomePage", "CargoApp");
        }

        //GET the Admin Login Page
        public ActionResult AdminLogin()
        {
            if (Session["UserName"] != null)
            {
                return RedirectToAction("LoggedIn", "Redirected");
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AdminLogin(AdminLoginModel admin)
        {
            var username=admin.UserName;
            var password=admin.Password;

            const string apiUrl = "http://localhost:62239/api/Admin/Login";
            if (!ModelState.IsValid) return View();

            try
            {
                using (var client = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(admin), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        // Store data in session after successful login
                        Session["UserName"] = username;
                        Session["IsLoggedIn"] = true;

                        TempData["Message"] = $"Admin Login Successful! \n UserName: {username} Password: {password}";
                        return RedirectToAction("AdminDashboard", "Admins");
                    }

                    TempData["Message"] = "Error: Admin Login Failed.";
                    return RedirectToAction("Error", "Redirected");
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = $"Exception: {ex.Message}";
                return RedirectToAction("Error", "Redirected");
            }
        }



        // GET: Customer Login Page
        public ActionResult CustomerLogin()
        {
            if (Session["UserName"] != null)
            {
                return RedirectToAction("LoggedIn", "Redirected");
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CustomerLogin(CustomerLoginModel customer)
        {
            var username = customer.UserName;
            var password = customer.CustPassword;

            const string apiUrl = "http://localhost:62239/api/Customer/Login";
            if (!ModelState.IsValid) return View();

            try
            {
                using (var client = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {

                        // Store data in session after successful login
                        Session["UserName"] = username;
                        Session["IsLoggedIn"] = true;

                        TempData["Message"] = $"customer Login Successful! \n UserName: {username} Password: {password}";
                        return RedirectToAction("Success", "Redirected");
                    }

                    TempData["Message"] = "Error: customer Login Failed.";
                    return RedirectToAction("Error", "Redirected");
                }
            }
            catch (Exception ex)
            {
                TempData["Message"] = $"Exception: {ex.Message}";
                return RedirectToAction("Error", "Redirected");
            }
        }

        // GET: Employee Login Page
        public ActionResult EmployeeLogin()
        {
            if (Session["UserName"] != null)
            {
                return RedirectToAction("LoggedIn", "Redirected");
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> EmployeeLogin(EmployeeLoginModel employee)
        {
            var username = employee.UserName;
            var password = employee.Password;

            const string apiUrl = "http://localhost:62239/api/Employee/Login";
            if (!ModelState.IsValid) return View();

            try
            {
                using (var client = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(employee), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {

                        // Store data in session after successful login
                        Session["UserName"] = username;
                        Session["IsLoggedIn"] = true;

                        TempData["Message"] = $"employee Login Successful! \n UserName: {username} Password: {password}";
                        return RedirectToAction("Success", "Redirected");
                    }

                    TempData["Message"] = "Error: employee Login Failed.";
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