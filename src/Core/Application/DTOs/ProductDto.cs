﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
	public class ProductDto
	{
        public int Id{ get; set; }
        public string? Name { get; set; }
		public string? Description { get; set; }
		public DateTime CreatedDate { get; set; } = DateTime.Now;
	}
}
