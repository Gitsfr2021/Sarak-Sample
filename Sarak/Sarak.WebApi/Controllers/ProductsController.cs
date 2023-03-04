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
    public class ProductsController : BaseController
    {
        private ProcustsService _productsService;

        public ProductsController(UserManager<User> userManager
            , ProcustsService productsService)
            : base(userManager)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public List<ProductDTO> GetAllData()
        {
            try
            {
                return _productsService.Get<ProductDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public List<ProductGroupView> GetPaged([FromBody] ProductSearchDTO query)
        {
            return _productsService.GetPaged(query);
        }

        [HttpGet]
        public ProductDTO GetByID(int id)
        {
            return _productsService.GetByID(id);
        }

        [HttpPost]
        public ProductDTO Insert([FromBody] ProductDTO entity)
        {
            return _productsService.Insert(entity);
        }

        [HttpPut]
        public bool Update([FromBody] ProductDTO entity)
        {
            return _productsService.Update(entity);
        }

        [HttpDelete]
        public long DeleteByID(int id)
        {
            return _productsService.Delete(id);
        }
    }
}
