using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistences
{
	public interface IGenericRepository<T> where T : BaseEntity
	{
		Task<IReadOnlyList<T>> GetAsync();
		Task<T> GetByIdAsync(int id);
		Task CreateAsync(T entity);
		Task UpdateAsync(T entity);
		Task DeleteAsync(T entity);
	}
}
