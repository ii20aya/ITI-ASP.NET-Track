using Microsoft.AspNetCore.Mvc;
using MVC_Consumer.Models;
using System.Text;
using System.Text.Json;

namespace MVC_Consumer.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "http://localhost:5066/api/Employee";
                                       

        public EmployeeController(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient();
        }


        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync(_apiUrl);
            var json = await response.Content.ReadAsStringAsync();
            var employees = JsonSerializer.Deserialize<List<EmployeeDTO>>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(employees);
        }


        public async Task<IActionResult> Details(int id)
        {
            var response = await _httpClient.GetAsync($"{_apiUrl}/{id}");
            if (!response.IsSuccessStatusCode) return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var employee = JsonSerializer.Deserialize<EmployeeDTO>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(employee);
        }

      
        public IActionResult Create()
        {
            return View();
        }

    
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateDTO dto)
        {
            var json = JsonSerializer.Serialize(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_apiUrl, content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(dto);
        }

    
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _httpClient.GetAsync($"{_apiUrl}/{id}");
            if (!response.IsSuccessStatusCode) return NotFound();

            var json = await response.Content.ReadAsStringAsync();
            var employee = JsonSerializer.Deserialize<EmployeeDTO>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

      
            var dto = new EmployeeCreateDTO
            {
                FullName = employee.FullName,
                PhoneNumber = employee.PhoneNumber,
                Salary = employee.Salary,
                Position = employee.Position,
                Department = employee.Department
            };

            ViewBag.Id = id;
            return View(dto);
        }

     
        [HttpPost]
        public async Task<IActionResult> Edit(int id, EmployeeCreateDTO dto)
        {
            var json = JsonSerializer.Serialize(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{_apiUrl}/{id}", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("Index");

            return View(dto);
        }

  
        public async Task<IActionResult> Delete(int id)
        {
            await _httpClient.DeleteAsync($"{_apiUrl}/{id}");
            return RedirectToAction("Index");
        }
    }
}