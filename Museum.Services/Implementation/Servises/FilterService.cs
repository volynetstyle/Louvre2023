﻿using AutoMapper;
using Museum.App.Services.Abstractions;
using Museum.App.Services.Adapters;
using Museum.App.Services.Implementation.Repositories;
using Museum.App.Services.Interfaces.Servises;
using Museum.App.ViewModels.Filter;
using Museum.App.ViewModels.Home;
using Museum.Models.TableModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.App.Services.Implementation.Servises
{
    public class FilterService : IFilterService
    {
        private readonly IMapper _mapper;
        private readonly IBasicService<Artists ,ArtistAdapter> _artistService;
        private readonly IBasicService<Categories, CategoryAdapter> _categoryService;
        private readonly IBasicService<CollectionModel, CollectionAdapter> _collectionService;
        private readonly IFilterRepository _filterRepository;

        public FilterService(IMapper mapper, 
                             IBasicService<Artists, ArtistAdapter> artistService,
                             IBasicService<Categories, CategoryAdapter> categoryService,
                             IBasicService<CollectionModel, CollectionAdapter> collectionService,
                             IFilterRepository filterRepository)
        {
            _mapper = mapper;
            _artistService = artistService;
            _categoryService = categoryService;
            _collectionService = collectionService;
            _filterRepository = filterRepository;
        }

        public IEnumerable<DepartmentSection>? GetDepartmentSection()
        {
            return _collectionService.GetAll().Select(c => new DepartmentSection
            {
                DepartmentName = c.Department,
                DepartmentItem = _mapper.Map<IEnumerable<SectionItem>>(_filterRepository.GetGalleryObjectsByCollectionID(c.CollectionId))
            });
        }

        public IEnumerable<ArtistAdapter> GetArtists() => _artistService.GetAll();

        public IEnumerable<CategoryAdapter> GetCategories() => _categoryService.GetAll();

        public IEnumerable<CollectionAdapter> GetDepartmens() => _collectionService.GetAll();

        public async Task<IEnumerable<DepartmentSection>> SearchActionAsync(string? pattern = null)
        {
            var departmentSectionsDict = await GetDepartmentSectionsDictAsync();

            if (!string.IsNullOrEmpty(pattern))
            {
                var filteredDepartmentSections = FilterDepartmentSections(departmentSectionsDict, pattern);
                return filteredDepartmentSections;
            }
            else
            {
                var allDepartmentSections = GetAllDepartmentSections(departmentSectionsDict);
                return allDepartmentSections;
            }
        }

        private async Task<Dictionary<string, List<DepartmentSection>>> GetDepartmentSectionsDictAsync()
        {
            var collections = await _collectionService.GetAllAsync();
            var departmentSectionsDict = new Dictionary<string, List<DepartmentSection>>();

            foreach (var c in collections)
            {
                var sectionItems = await _filterRepository.GetGalleryObjectsByCollectionIDAsync(c.CollectionId);
                var departmentItem = _mapper.Map<IEnumerable<SectionItem>>(sectionItems);
                var departmentSection = new DepartmentSection { DepartmentName = c.Department, DepartmentItem = departmentItem };

                if (departmentSection.DepartmentName != null)
                {
                    AddDepartmentSectionToDict(departmentSectionsDict, departmentSection);
                }
            }

            return departmentSectionsDict;
        }

        private void AddDepartmentSectionToDict(Dictionary<string, List<DepartmentSection>> dict, DepartmentSection departmentSection)
        {
            if (departmentSection.DepartmentName != null)
            {
                if (!dict.ContainsKey(departmentSection.DepartmentName))
                {
                    dict[departmentSection.DepartmentName] = new List<DepartmentSection>();
                }
                dict[departmentSection.DepartmentName].Add(departmentSection);
            }
        }

        private List<DepartmentSection> FilterDepartmentSections(Dictionary<string, List<DepartmentSection>> departmentSectionsDict, string pattern)
        {
            var filteredDepartmentSections = new List<DepartmentSection>();

            foreach (var keyValuePair in departmentSectionsDict)
            {
                if (keyValuePair.Key.Contains(pattern, StringComparison.OrdinalIgnoreCase))
                {
                    filteredDepartmentSections.AddRange(keyValuePair.Value);
                    continue;
                }

                var departmentSections = new List<DepartmentSection>();

                foreach (var ds in keyValuePair.Value)
                {
                    if (ds.DepartmentDescription?.Contains(pattern, StringComparison.OrdinalIgnoreCase) == true)
                    {
                        departmentSections.Add(ds);
                    }
                    else if (ds.DepartmentItem != null)
                    {
                        foreach (var si in ds.DepartmentItem)
                        {
                            if (si.Title?.Contains(pattern, StringComparison.OrdinalIgnoreCase) == true)
                            {
                                departmentSections.Add(ds);
                                break;
                            }
                        }
                    }
                }

                filteredDepartmentSections.AddRange(departmentSections);
            }

            return filteredDepartmentSections;
        }

        private List<DepartmentSection> GetAllDepartmentSections(Dictionary<string, List<DepartmentSection>> departmentSectionsDict)
        {
            return departmentSectionsDict.Values.SelectMany(x => x).ToList();
        }

        public IEnumerable<DepartmentSection>? Filter(FilterViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}