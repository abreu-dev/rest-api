using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using RestAPI.Application.DTOs;
using RestAPI.Application.Helpers;
using RestAPI.Application.Interfaces;
using RestAPI.Application.Parameters;
using RestAPI.Domain.Commands.CategoryCommands;
using RestAPI.Domain.Entities;
using RestAPI.Domain.Interfaces;
using RestAPI.Domain.MediatorHandler;
using RestAPI.Domain.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
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

        public IEnumerable<CategoryDTO> GetCategories(CategoryParameters parameters)
        {
            var source = _categoryRepository
                .Query();

            source = string.IsNullOrEmpty(parameters.Order) ? source.OrderBy(p => p.Name) : source.OrderBy(parameters.Order);

            if (parameters.Name.Any())
            {
                source = source.ApplyFilter("Name", parameters.Name);
            }

            return _mapper.Map<IEnumerable<CategoryDTO>>(source);
        }

        public CategoryDTO GetCategoryById(Guid id)
        {
            return _mapper.Map<CategoryDTO>(_categoryRepository.GetCategoryById(id));
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

        public async Task PatchCategory(Guid id, JsonPatchDocument<CategoryDTO> patchCategoryDTO)
        {
            var categoryDTO = GetCategoryById(id);

            if (categoryDTO == null)
            {
                await _mediator.RaiseDomainNotificationAsync(
                    new DomainNotification("NotFound", "Category not found", "The informed 'Category' was not found"));
                return;
            }

            patchCategoryDTO.ApplyTo(categoryDTO);

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
