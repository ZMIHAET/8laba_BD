namespace UI.Areas.Admin.Models.ViewModels
{
	public class DrugTypesViewModel
	{
		public SearchResultViewModel<DrugTypeModel> DT_model { get; set; }
		public SearchResultViewModel<MedicineModel> medicine_model { get; set; }
		public SearchResultViewModel<StorageRuleModel> SR_model { get; set; }
		public SearchResultViewModel<ManufacturerModel> manufacturer_model { get; set; }

	}
}