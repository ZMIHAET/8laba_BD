namespace UI.Areas.Admin.Models.ViewModels
{
	public class EmployeeViewModel
	{
		public SearchResultViewModel<EmployeeAttendanceModel> employeeattendance_model { get; set; }
		public SearchResultViewModel<EmployeeTrainingModel> employeetraining_model { get; set; }
		public SearchResultViewModel<EmployeeModel> employee_model { get; set; }
		public SearchResultViewModel<CustomerModel> customer_model { get; set; }
		public SearchResultViewModel<OrderModel> order_model { get; set; }

	}
}