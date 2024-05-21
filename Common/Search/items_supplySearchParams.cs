using System;
using System.Collections.Generic;
using Common.Enums;

namespace Common.Search
{
	public class items_supplySearchParams : BaseSearchParams
	{
		public items_supplySearchParams(int startIndex = 0, int? objectsCount = null) : base(startIndex, objectsCount)
		{
		}
	}
}
