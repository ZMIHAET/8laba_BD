using System;
using System.Collections.Generic;
using Common.Enums;

namespace Common.Search
{
	public class employee_attendanceSearchParams : BaseSearchParams
	{
		public employee_attendanceSearchParams(int startIndex = 0, int? objectsCount = null) : base(startIndex, objectsCount)
		{
		}
	}
}
