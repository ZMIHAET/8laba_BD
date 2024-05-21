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
	public class medicinesController : Controller
	{
		public async Task<IActionResult> Index(int page = 1)
		{
			const int objectsPerPage = 20;
			var searchResultmedicines = await new medicinesBL().GetAsync(new medicinesSearchParams
			{
				StartIndex = (page - 1) * objectsPerPage,
				ObjectsCount = objectsPerPage,
			});
			var viewModelmedicines = new SearchResultViewModel<MedicineModel>(MedicineModel.FromEntitiesList(searchResultmedicines.Objects),
				searchResultmedicines.Total, searchResultmedicines.RequestedStartIndex, searchResultmedicines.RequestedObjectsCount, 5);

			var searchResultDT = await new drug_typesBL().GetAsync(new drug_typesSearchParams
			{
				StartIndex = (page - 1) * objectsPerPage,
				ObjectsCount = objectsPerPage,
			});
			var viewModelDT = new SearchResultViewModel<DrugTypeModel>(DrugTypeModel.FromEntitiesList(searchResultDT.Objects),
				searchResultDT.Total, searchResultDT.RequestedStartIndex, searchResultDT.RequestedObjectsCount, 5);

			var searchResultSR = await new storage_rulesBL().GetAsync(new storage_rulesSearchParams
			{
				StartIndex = (page - 1) * objectsPerPage,
				ObjectsCount = objectsPerPage,
			});
			var viewModelSR = new SearchResultViewModel<StorageRuleModel>(StorageRuleModel.FromEntitiesList(searchResultSR.Objects),
				searchResultSR.Total, searchResultSR.RequestedStartIndex, searchResultSR.RequestedObjectsCount, 5);

			var searchResultmanufacturer = await new manufacturersBL().GetAsync(new manufacturersSearchParams
			{
				StartIndex = (page - 1) * objectsPerPage,
				ObjectsCount = objectsPerPage,
			});
			var viewModelmanufacturer = new SearchResultViewModel<ManufacturerModel>(ManufacturerModel.FromEntitiesList(searchResultmanufacturer.Objects),
				searchResultmanufacturer.Total, searchResultmanufacturer.RequestedStartIndex, searchResultmanufacturer.RequestedObjectsCount, 5);

			var viewModel = new DrugTypesViewModel
			{
				medicine_model = viewModelmedicines,
				DT_model = viewModelDT,
				SR_model = viewModelSR,
				manufacturer_model = viewModelmanufacturer
			};

			return View(viewModel);
		}

		public async Task<IActionResult> Update(int? id)
		{
			var model = new MedicineModel();
			if (id != null)
			{
				model = MedicineModel.FromEntity(await new medicinesBL().GetAsync(id.Value));
				if (model == null)
					return NotFound();
			}
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update(MedicineModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			await new medicinesBL().AddOrUpdateAsync(MedicineModel.ToEntity(model));
			TempData[OperationResultType.Success.ToString()] = "Данные сохранены";
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Delete(int id)
		{
			var result = await new medicinesBL().DeleteAsync(id);
			if (result)
				TempData[OperationResultType.Success.ToString()] = "Объект удален";
			else
				TempData[OperationResultType.Error.ToString()] = "Объект не найден";
			return RedirectToAction("Index");
		}
	}
}
