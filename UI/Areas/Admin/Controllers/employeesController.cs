using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Common.Enums;
using Common.Search;
using BL;
using UI.Areas.Admin.Models;
using UI.Areas.Admin.Models.ViewModels;
using UI.Other;

namespace UI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = nameof(UserRole.Admin))]
	public class employeesController : Controller
	{
		public async Task<IActionResult> Index(int page = 1)
		{
			const int objectsPerPage = 20;
			var searchResultemployees = await new employeesBL().GetAsync(new employeesSearchParams
			{
				StartIndex = (page - 1) * objectsPerPage,
				ObjectsCount = objectsPerPage,
			});
			var viewModeltemployees = new SearchResultViewModel<EmployeeModel>(EmployeeModel.FromEntitiesList(searchResultemployees.Objects),
				searchResultemployees.Total, searchResultemployees.RequestedStartIndex, searchResultemployees.RequestedObjectsCount, 5);



			var searchResultemployees_roles = await new employee_rolesBL().GetAsync(new employee_rolesSearchParams
			{
				StartIndex = (page - 1) * objectsPerPage,
				ObjectsCount = objectsPerPage,
			});
			var viewModelemployees_roles = new SearchResultViewModel<EmployeeRoleModel>(EmployeeRoleModel.FromEntitiesList(searchResultemployees_roles.Objects),
				searchResultemployees_roles.Total, searchResultemployees_roles.RequestedStartIndex, searchResultemployees_roles.RequestedObjectsCount, 5);



			var viewModel = new EmployeeRoleViewModel
			{
				employeerole_model = viewModelemployees_roles,
				employee_model = viewModeltemployees
			};



			return View(viewModel);
		}

		public async Task<IActionResult> Update(int? id)
		{
			var model = new EmployeeModel();
			if (id != null)
			{
				model = EmployeeModel.FromEntity(await new employeesBL().GetAsync(id.Value));
				if (model == null)
					return NotFound();
			}
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update(EmployeeModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			await new employeesBL().AddOrUpdateAsync(EmployeeModel.ToEntity(model));
			TempData[OperationResultType.Success.ToString()] = "Данные сохранены";
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Delete(int id)
		{
			var result = await new employeesBL().DeleteAsync(id);
			if (result)
				TempData[OperationResultType.Success.ToString()] = "Объект удален";
			else
				TempData[OperationResultType.Error.ToString()] = "Объект не найден";
			return RedirectToAction("Index");
		}
	}
}
