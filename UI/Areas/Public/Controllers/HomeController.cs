using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using UI.Areas.Public.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UI.Areas.Public.Controllers
{
	[Area("Public")]
	public class HomeController : Controller
	{
		static string connectionString = "Data Source=LAPTOP-HP\\SQLEXPRESS;Initial Catalog=db3;Integrated security=true;TrustServerCertificate=True;";
		public IActionResult Index()
		{
			return View();
		}

		[Route("robots.txt")]
		public IActionResult Robots()
		{
			string filename;
			if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
			{
				filename = "robotsDevelopment.txt";
			}
			else
			{
				filename = "robotsProduction.txt";
			}

			string filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filename);
			byte[] filedata = System.IO.File.ReadAllBytes(filepath);
			string contentType = "text/plain";

			return File(filedata, contentType);
		}
		public IActionResult ordersINFO_2Method(string status)
		{
			string sqlExpression = "ordersINFO_2";

			int customersCount = 0;

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				SqlCommand command = new SqlCommand(sqlExpression, connection);
				command.Parameters.AddWithValue("@status", status);
				command.Parameters.Add("@count_customers", SqlDbType.Int).Direction = ParameterDirection.Output;
				command.CommandType = System.Data.CommandType.StoredProcedure;

				var reader = command.ExecuteReader();

				customersCount = (int)command.Parameters["@count_customers"].Value;
			}

			return View(customersCount);
		}

		public IActionResult OrderInfoMethod(int price)
		{
			string sqlExpression = "OrderInfo";

			List<OrderInfoViewModel> orderInfoViewModel = new List<OrderInfoViewModel>();

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				SqlCommand command = new SqlCommand(sqlExpression, connection);

				command.Parameters.AddWithValue("@price", price);

				command.CommandType = System.Data.CommandType.StoredProcedure;

				var reader = command.ExecuteReader();

				if (reader.HasRows)
				{
					while (reader.Read())
					{
						OrderInfoViewModel view3row = new OrderInfoViewModel
						{
							Id = reader.GetInt32(0),
							CustomerId = reader.GetInt32(1),
							EmployeeId = reader.GetInt32(2),
							Date = reader.GetDateTime(3),
							Status = reader.GetString(4),
							TotalPrice = reader.GetInt32(5),
							Id_2 = reader.GetInt32(6),
							MedicineId = reader.GetInt32(7),
							CourierId = reader.GetInt32(8),
							OrderId = reader.GetInt32(9),
							Date_2 = reader.GetDateTime(10),
							Distance = Convert.ToSingle(reader.GetDouble(11))
						};

						orderInfoViewModel.Add(view3row);
					}
				}
				reader.Close();
			}
			

			return View(orderInfoViewModel);
		}
		public IActionResult ViewCountOrdersWithCustomersMethod()
		{
			string sqlExpression = "SELECT * FROM ViewCountOrdersWithCustomers";

			List<ViewCountOrdersWithCustomersViewModel> viewCountOrdersWithCustomersViewModel = new List<ViewCountOrdersWithCustomersViewModel>();

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				SqlCommand command = new SqlCommand(sqlExpression, connection);

				var reader = command.ExecuteReader();

				if (reader.HasRows)
				{
					while (reader.Read())
					{
						ViewCountOrdersWithCustomersViewModel view3row = new ViewCountOrdersWithCustomersViewModel
						{
							FullName = reader.GetString(0),
							CountOrders = reader.GetInt32(1)
						};

						viewCountOrdersWithCustomersViewModel.Add(view3row);
					}
				}
				reader.Close();
			}
			return View(viewCountOrdersWithCustomersViewModel);
		}






		public IActionResult ViewCountEmployeesWithRolesMethod()
		{
			string sqlExpression = "SELECT * FROM ViewCountEmployeesWithRoles";

			List<ViewCountEmployeesWithRolesViewModel> viewCountEmployeesWithRolesViewModel = new List<ViewCountEmployeesWithRolesViewModel>();

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();
				SqlCommand command = new SqlCommand(sqlExpression, connection);

				var reader = command.ExecuteReader();

				if (reader.HasRows)
				{
					while (reader.Read())
					{
						ViewCountEmployeesWithRolesViewModel view3row = new ViewCountEmployeesWithRolesViewModel
						{
							RoleName = reader.GetString(0),
							CountEmployees = reader.GetInt32(1)
						};

						viewCountEmployeesWithRolesViewModel.Add(view3row);
					}
				}
				reader.Close();
			}
			return View(viewCountEmployeesWithRolesViewModel);
		}





	}
}