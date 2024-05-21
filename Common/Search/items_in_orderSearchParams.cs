using System;
using System.Collections.Generic;
using Common.Enums;

namespace Common.Search
{
	public class items_in_orderSearchParams : BaseSearchParams
	{
		public items_in_orderSearchParams(int startIndex = 0, int? objectsCount = null) : base(startIndex, objectsCount)
		{
		}
	}
}
