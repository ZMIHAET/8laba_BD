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
	public class deliveriesController : Controller
	{
		public async Task<IActionResult> Index(int page = 1)
		{
			const int objectsPerPage = 20;
			var searchResultdeliveries = await new deliveriesBL().GetAsync(new deliveriesSearchParams
			{
				StartIndex = (page - 1) * objectsPerPage,
				ObjectsCount = objectsPerPage,
			});
			var viewModeldeliveries = new SearchResultViewModel<DeliveryModel>(DeliveryModel.FromEntitiesList(searchResultdeliveries.Objects),
				searchResultdeliveries.Total, searchResultdeliveries.RequestedStartIndex, searchResultdeliveries.RequestedObjectsCount, 5);

			var searchResultmedicines = await new medicinesBL().GetAsync(new medicinesSearchParams
			{
				StartIndex = (page - 1) * objectsPerPage,
				ObjectsCount = objectsPerPage,
			});
			var viewModelmedicines = new SearchResultViewModel<MedicineModel>(MedicineModel.FromEntitiesList(searchResultmedicines.Objects),
				searchResultmedicines.Total, searchResultmedicines.RequestedStartIndex, searchResultmedicines.RequestedObjectsCount, 5);

			var searchResultcour = await new couriersBL().GetAsync(new couriersSearchParams
			{
				StartIndex = (page - 1) * objectsPerPage,
				ObjectsCount = objectsPerPage,
			});
			var viewModelcour = new SearchResultViewModel<CourierModel>(CourierModel.FromEntitiesList(searchResultcour.Objects),
				searchResultcour.Total, searchResultcour.RequestedStartIndex, searchResultcour.RequestedObjectsCount, 5);

			var searchResultord = await new ordersBL().GetAsync(new ordersSearchParams
			{
				StartIndex = (page - 1) * objectsPerPage,
				ObjectsCount = objectsPerPage,
			});
			var viewModelord = new SearchResultViewModel<OrderModel>(OrderModel.FromEntitiesList(searchResultord.Objects),
				searchResultord.Total, searchResultord.RequestedStartIndex, searchResultord.RequestedObjectsCount, 5);

			var viewModel = new MedicineViewModel
			{
				medicine_model = viewModelmedicines,
				delivery_model = viewModeldeliveries,
				cour_model = viewModelcour,
				order_model = viewModelord
			};
			return View(viewModel);
		}

		public async Task<IActionResult> Update(int? id)
		{
			var model = new DeliveryModel();
			if (id != null)
			{
				model = DeliveryModel.FromEntity(await new deliveriesBL().GetAsync(id.Value));
				if (model == null)
					return NotFound();
			}
			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update(DeliveryModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			await new deliveriesBL().AddOrUpdateAsync(DeliveryModel.ToEntity(model));
			TempData[OperationResultType.Success.ToString()] = "Данные сохранены";
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> Delete(int id)
		{
			var result = await new deliveriesBL().DeleteAsync(id);
			if (result)
				TempData[OperationResultType.Success.ToString()] = "Объект удален";
			else
				TempData[OperationResultType.Error.ToString()] = "Объект не найден";
			return RedirectToAction("Index");
		}
	}
}
