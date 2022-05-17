﻿using AutoMapper;
using RestAPI.Application.DTOs;
using RestAPI.Application.Interfaces;
using RestAPI.Application.Parameters;
using RestAPI.Application.Responses;
using RestAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestAPI.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
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

            return new PagedResponse<CategoryDTO>(items, totalItems, parameters.Page, totalPages);
        }
    }
}
