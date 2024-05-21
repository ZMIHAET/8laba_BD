namespace UI.Areas.Admin.Models.ViewModels
{
	public class DosageFormsViewModel
	{
		public SearchResultViewModel<MedicationModel> medication_model { get; set; }
		public SearchResultViewModel<DosageFormModel> DF_model { get; set; }
		public SearchResultViewModel<DrugTypeModel> DT_model { get; set; }

	}
}