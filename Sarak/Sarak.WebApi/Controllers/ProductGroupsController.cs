using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sarak.Data.Entities;
using Sarak.Models.DTOs;
using Sarak.Models.Views;
using Sarak.Services.Services;
using Sarak.WebAPI.Base;
using System;
using System.Collections.Generic;

namespace Sarak.WebAPI.Controllers
{
    public class ProductGroupsController : BaseController
    {
        private ProcustGroupsService _productGroupsService;

        public ProductGroupsController(UserManager<User> userManager
            , ProcustGroupsService productGroupsService)
            : base(userManager)
        {
            _productGroupsService = productGroupsService;
        }

        [HttpGet]
        public  List<ProductGroupDTO> GetAllData()
        {
            try
            {
                return _productGroupsService.Get<ProductGroupDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public List<ProductGroupView> GetPaged([FromBody] ProductGroupSearchDTO query)
        {
            return _productGroupsService.GetPaged(query);
        }

        [HttpGet]
        public ProductGroupDTO GetByID(int id)
        {
            return _productGroupsService.GetByID(id);
        }

        [HttpPost]
        public ProductGroupDTO Insert([FromBody] ProductGroupDTO entity)
        {
            return _productGroupsService.Insert(entity);
        }

        [HttpPut]
        public bool Update([FromBody] ProductGroupDTO entity)
        {
            return _productGroupsService.Update(entity);
        }

        [HttpDelete]
        public long DeleteByID(int id)
        {
            return _productGroupsService.Delete(id);
        }
    }
}
