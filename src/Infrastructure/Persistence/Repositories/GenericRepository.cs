using Application.Contracts.Persistences;
using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		public Task CreateAsync(T entity)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(T entity)
		{
			throw new NotImplementedException();
		}

		public Task<IReadOnlyList<T>> GetAsync()
		{
			throw new NotImplementedException();
		}

		public Task<T> GetByIdAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task UpdateAsync(T entity)
		{
			throw new NotImplementedException();
		}
	}
}
