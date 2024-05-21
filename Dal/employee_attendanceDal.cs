using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Common.Enums;
using Common.Search;
using Dal.DbModels;

namespace Dal
{
	public class employee_attendanceDal : BaseDal<DefaultDbContext, EmployeeAttendance, Entities.EmployeeAttendance, int, employee_attendanceSearchParams, object>
	{
		protected override bool RequiresUpdatesAfterObjectSaving => false;

		public employee_attendanceDal()
		{
		}

		protected internal employee_attendanceDal(DefaultDbContext context) : base(context)
		{
		}

		protected override Task UpdateBeforeSavingAsync(DefaultDbContext context, Entities.EmployeeAttendance entity, EmployeeAttendance dbObject, bool exists)
		{
			dbObject.EmployeeId = entity.EmployeeId;
			dbObject.AttendanceDate = entity.AttendanceDate;
			dbObject.IsPresent = entity.IsPresent;
			return Task.CompletedTask;
		}
	
		protected override Task<IQueryable<EmployeeAttendance>> BuildDbQueryAsync(DefaultDbContext context, IQueryable<EmployeeAttendance> dbObjects, employee_attendanceSearchParams searchParams)
		{
			return Task.FromResult(dbObjects);
		}

		protected override async Task<IList<Entities.EmployeeAttendance>> BuildEntitiesListAsync(DefaultDbContext context, IQueryable<EmployeeAttendance> dbObjects, object convertParams, bool isFull)
		{
			return (await dbObjects.ToListAsync()).Select(ConvertDbObjectToEntity).ToList();
		}

		protected override Expression<Func<EmployeeAttendance, int>> GetIdByDbObjectExpression()
		{
			return item => item.Id;
		}

		protected override Expression<Func<Entities.EmployeeAttendance, int>> GetIdByEntityExpression()
		{
			return item => item.Id;
		}

		internal static Entities.EmployeeAttendance ConvertDbObjectToEntity(EmployeeAttendance dbObject)
		{
			return dbObject == null ? null : new Entities.EmployeeAttendance(dbObject.Id, dbObject.EmployeeId,
				dbObject.AttendanceDate, dbObject.IsPresent);
		}
	}
}
