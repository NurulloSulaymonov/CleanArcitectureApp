using AutoMapper;
using Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CategoryService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CategoryService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> GetCategories()
        {
            var list = await (
                from p in _context.Categories
                select new CategoryDto()
                {
                    CategoryId = p.CategoryId,
                    CategoryName = p.CategoryName
                }
            ).ToListAsync();
            return list;
        }

        public async Task<int> InsertCategory(CategoryDto categoryDto)
        {
            var map = _mapper.Map<Category>(categoryDto);
            await _context.Categories.AddAsync(map);
            return await _context.SaveChangesAsync();
        }

    }
}
