﻿/**************************************************************************  
*   =================================
*   CLR版本  ：4.0.30319.42000
*   命名空间 ：Memoyu.Mbill.WebApi.Controllers.Bill
*   文件名称 ：CategoryController.cs
*   =================================
*   创 建 者 ：Memoyu
*   创建日期 ：2021-01-06 23:47:41
*   邮箱     ：mmy6076@outlook.com
*   功能描述 ：
***************************************************************************/

using AutoMapper;
using Memoyu.Mbill.Application.Bill.Category;
using Memoyu.Mbill.Application.Contracts.Attributes;
using Memoyu.Mbill.Application.Contracts.Dtos.Bill.Category;
using Memoyu.Mbill.Domain.Entities.Bill.Category;
using Memoyu.Mbill.Domain.Shared.Const;
using Memoyu.Mbill.ToolKits.Base;
using Memoyu.Mbill.ToolKits.Base.Page;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Memoyu.Mbill.WebApi.Controllers.Bill
{
    /// <summary>
    /// 账单分类管理
    /// </summary>
    [Route("api/category")]
    public class CategoryController : ApiControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        /// <summary>
        /// 新增账单分类
        /// </summary>
        /// <param name="dto">账单分类</param>
        [Logger("用户新建了一个账单分类")]
        [HttpPost("create")]
        [Authorize]
        [ApiExplorerSettings(GroupName = SystemConst.Grouping.GroupName_v1)]
        public async Task<ServiceResult> CreateAsync([FromBody] ModifyCategoryDto dto)
        {
            await _categoryService.InsertAsync(_mapper.Map<CategoryEntity>(dto));
            return ServiceResult.Successed("账单分类创建成功");
        }

        /// <summary>
        /// 获取分类
        /// </summary>
        /// <param name="id">分类id</param>
        [HttpGet("get")]
        [Authorize]
        [ApiExplorerSettings(GroupName = SystemConst.Grouping.GroupName_v1)]
        public async Task<ServiceResult<CategoryDto>> GetAsync([FromQuery] long id)
        {
            return ServiceResult<CategoryDto>.Successed(await _categoryService.GetAsync(id));
        }

        /// <summary>
        /// 获取分类父项
        /// </summary>
        /// <param name="id">分类id</param>
        [HttpGet("parent/get")]
        [Authorize]
        [ApiExplorerSettings(GroupName = SystemConst.Grouping.GroupName_v1)]
        public async Task<ServiceResult<CategoryDto>> GetParentAsync([FromQuery] long id)
        {
            return ServiceResult<CategoryDto>.Successed(await _categoryService.GetParentAsync(id));
        }

        /// <summary>
        /// 获取分组后的账单分类
        /// </summary>
        /// <param name="type">账单类型</param>
        [HttpGet("groups")]
        [Authorize]
        [ApiExplorerSettings(GroupName = SystemConst.Grouping.GroupName_v1)]
        public async Task<ServiceResult<IEnumerable<CategoryGroupDto>>> GetGroupAsync([FromQuery] string type)
        {
            return ServiceResult<IEnumerable<CategoryGroupDto>>.Successed(await _categoryService.GetGroupsAsync(type));
        }
    }
}
