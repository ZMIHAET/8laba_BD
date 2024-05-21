namespace UI.Areas.Admin.Models.ViewModels
{
	public class MedicineViewModel
	{
		public SearchResultViewModel<DeliveryModel> delivery_model { get; set; }
		public SearchResultViewModel<MedicineModel> medicine_model { get; set; }
		public SearchResultViewModel<CourierModel> cour_model { get; set; }
		public SearchResultViewModel<ItemsSupplyModel> IS_model { get; set; }
		public SearchResultViewModel<MedicineSupplierModel> MS_model { get; set; }
		public SearchResultViewModel<MedicineReviewModel> MR_model { get; set; }
		public SearchResultViewModel<CustomerModel> customer_model { get; set; }
		public SearchResultViewModel<OrderModel> order_model { get; set; }
		public SearchResultViewModel<ItemsInOrderModel> IIO_model { get; set; }
		public SearchResultViewModel<MedicineDiscountModel> MedDis_model { get; set; }
	}
}