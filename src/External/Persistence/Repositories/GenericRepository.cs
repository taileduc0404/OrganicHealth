﻿using Application.Contracts.Persistences;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
	public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
	{
		private readonly ApplicationDbContext _context;

		public GenericRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task CreateAsync(T entity)
		{
			await _context.AddAsync(entity);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(T entity)
		{
			_context.Remove(entity);
			await _context.SaveChangesAsync();
		}

		public async Task<IReadOnlyList<T>> GetAsync()
		{
			return await _context.Set<T>().AsNoTracking().ToListAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			var entity = await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
			if (entity == null)
			{
				throw new Exception($"Not Found {id}");
			}
			else
			{

				return entity;
			}
		}

		public async Task UpdateAsync(T entity)
		{
			_context.Entry(entity).State=EntityState.Modified;
			await _context.SaveChangesAsync();
		}
	}
}