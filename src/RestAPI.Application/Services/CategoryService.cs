using AutoMapper;
using RestAPI.Application.DTOs;
using RestAPI.Application.Interfaces;
using RestAPI.Application.Parameters;
using RestAPI.Application.Responses;
using RestAPI.Domain.Commands.CategoryCommands;
using RestAPI.Domain.Entities;
using RestAPI.Domain.Interfaces;
using RestAPI.Domain.MediatorHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMediatorHandler _mediator;

        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _mediator = mediator;
        }

        public PagedResponse<CategoryDTO> GetPagedCategories(CategoryParameters parameters)
        {
            var source = _categoryRepository
                .Query()
                .OrderBy(p => p.Name);

            var totalItems = source.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)parameters.Size);
            var items = _mapper.Map<IEnumerable<CategoryDTO>>(source
                .Skip(parameters.Page * parameters.Size)
                .Take(parameters.Size)
                .ToList());

            return new PagedResponse<CategoryDTO>(items, parameters.Page, totalItems, totalPages);
        }

        public async Task AddCategory(CategoryDTO categoryDTO)
        {
            var command = new AddCategoryCommand()
            {
                Category = _mapper.Map<Category>(categoryDTO)
            };

            await _mediator.SendCommand(command);
        }

        public async Task UpdateCategory(Guid id, CategoryDTO categoryDTO)
        {
            var command = new UpdateCategoryCommand(id)
            {
                Category = _mapper.Map<Category>(categoryDTO)
            };

            await _mediator.SendCommand(command);
        }

        public async Task DeleteCategory(Guid id)
        {
            var command = new DeleteCategoryCommand(id);

            await _mediator.SendCommand(command);
        }
    }
}
