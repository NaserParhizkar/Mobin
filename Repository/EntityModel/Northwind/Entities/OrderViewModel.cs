using System;
using System.ComponentModel.DataAnnotations;

namespace Northwind.Repository
{
    public class OrderViewModel
    {
		public int OrderID
		{
			get;
			set;
		}

		public decimal? Freight
		{
			get;
			set;
		}

		[Required]
		public DateTime? OrderDate
		{
			get;
			set;
		}

		public string ShipCity
		{
			get;
			set;
		}

		public string ShipName
		{
			get;
			set;
		}
	}
}
