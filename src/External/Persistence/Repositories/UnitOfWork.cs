using Application.Contracts.Persistences;
using AutoMapper;
using Microsoft.Extensions.FileProviders;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileProvider _fileProvider;

        public ICategoryRepository CategoryRepository { get; }
        public IProductRepository ProductRepository { get; }

        public UnitOfWork(ApplicationDbContext context, IMapper mapper, IFileProvider fileProvider)
        {
            _context = context;
            this._mapper = mapper;
            this._fileProvider = fileProvider;
            CategoryRepository = new CategoryRepository(_context, _mapper);
            ProductRepository = new ProductRepository(_context, _fileProvider, _mapper);
        }


    }
}
