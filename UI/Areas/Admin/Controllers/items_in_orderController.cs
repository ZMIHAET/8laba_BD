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
	public class items_in_orderController : Controller
	{
		public async Task<IActionResult> Index(int page = 1)
		{
			const int objectsPerPage = 20;
			var searchResultIIO = await new items_in_orderBL().GetAsync(new items_in_orderSearchParams
			{
				StartIndex = (page - 1) * objectsPerPage,
				ObjectsCount = objectsPerPage,
			});
			var viewModelIIO = new SearchResultViewModel<ItemsInOrderModel>(ItemsInOrderModel.FromEntitiesList(searchResultIIO.Objects),
				searchResultIIO.Total, searchResultIIO.RequestedStartIndex, searchResultIIO.RequestedObjectsCount, 5);

			var searchResultmedicines = await new medicinesBL().GetAsync(new medicinesSearchParams
			{
				StartIndex = (page - 1) * objectsPerPage,
				ObjectsCount = objectsPerPage,
			});
			var viewModelmedicines = new SearchResultViewModel<MedicineModel>(MedicineModel.FromEntitiesList(searchResultmedicines.Objects),
				searchResultmedicines.Total, searchResultmedicines.RequestedStartIndex, searchResultmedicines.RequestedObjectsCount, 5);
			var viewModel = new MedicineViewModel
			{
				medicine_model = viewModelmedicines,
				IIO_model = viewModelIIO
			};
			return View(viewModel);
		}

		public async Task<IActionResult> Update(int? id)
		{
			var model = new ItemsInOrderModel();
			if (id != null)
			{
				model = ItemsInOrderModel.FromEntity(await new items_in_orderBL().GetAsync(id.Value));
				if (model == null)
					return NotFound();
			}
			return View(model);
		}



		public async Task<IActionResult> Select(int? id)
		{
			var model = new ItemsInOrderModel();
			if (id != null)
			{
				model = ItemsInOrderModel.FromEntity(await new items_in_orderBL().GetAsync(id.Value));
				if (model == null)
					return NotFound();
			}
			const int objectsPerPage = 20;
			var searchResultIIO = await new items_in_orderBL().GetAsync(new items_in_orderSearchParams
			{
				StartIndex = 0,
				ObjectsCount = objectsPerPage,
			});
			var viewModelIIO = new SearchResultViewModel<ItemsInOrderModel>(ItemsInOrderModel.FromEntitiesList(searchResultIIO.Objects),
				searchResultIIO.Total, searchResultIIO.RequestedStartIndex, searchResultIIO.RequestedObjectsCount, 5);

			var searchResultmedicines = await new medicinesBL().GetAsync(new medicinesSearchParams
			{
				StartIndex = 0,
				ObjectsCount = objectsPerPage,
			});
			var viewModelmedicines = new SearchResultViewModel<MedicineModel>(MedicineModel.FromEntitiesList(searchResultmedicines.Objects),
				searchResultmedicines.Total, searchResultmedicines.RequestedStartIndex, searchResultmedicines.RequestedObjectsCount, 5);


			var viewModel = new MedicineViewModel
			{
				medicine_model = viewModelmedicines,
				IIO_model = viewModelIIO
			};

			ViewBag.IIO = model;

			return View(viewModel);
		}



		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update(ItemsInOrderModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			await new items_in_orderBL().AddOrUpdateAsync(ItemsInOrderModel.ToEntity(model));
			TempData[OperationResultType.Success.ToString()] = "Данные сохранены";
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Delete(int id)
		{
			var result = await new items_in_orderBL().DeleteAsync(id);
			if (result)
				TempData[OperationResultType.Success.ToString()] = "Объект удален";
			else
				TempData[OperationResultType.Error.ToString()] = "Объект не найден";
			return RedirectToAction("Index");
		}
	}
}
