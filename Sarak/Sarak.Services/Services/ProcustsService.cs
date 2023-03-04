using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sarak.Data.DbContexts;
using Sarak.Data.Entities;
using Sarak.Models.DTOs;
using Sarak.Models.Views;
using Sarak.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Sarak.Services.Services
{
    public class ProcustsService : ServiceBase
    {
        public IHttpContextAccessor HttpContextAccessor { get; }
        public SarakDbContext Db { get; }

        public ProcustsService(
            SarakDbContext db,
            IHttpContextAccessor httpContextAccessor,
            UserManager<User> userManager)
            : base(userManager)
        {
            this.HttpContextAccessor = httpContextAccessor;
            this.Db = db;
        }

        public virtual List<ProductDTO> Get()
        {
            var queryable = Db.Set<Product>().AsQueryable().AsNoTracking();

            return queryable.ProjectTo<ProductDTO>().ToList();
        }

        public List<ProductGroupView> GetPaged(ProductSearchDTO query)
        {
            throw new NotImplementedException();
        }

        protected virtual List<ProductDTO> Get(Expression<Func<Product, bool>> where)
        {
            var queryable = Db.Set<Product>().AsQueryable().AsNoTracking();

            return queryable
                     .Where(where)
                     .ProjectTo<ProductDTO>()
                     .ToList();
        }

        public virtual ProductDTO GetByID(int id)
        {
            return Mapper.Map<ProductDTO>(Db.Set<Product>().Find(id));
        }

        public ProductDTO Insert(ProductDTO dtoEntity, bool? ignoreSaveBranch = null)
        {
            //Validate(dtoEntity, ValidateType.Insert);

            var entity = Mapper.Map<Product>(dtoEntity);
            Db.Set<Product>().Add(entity);

            Db.SaveChanges(ignoreSaveBranch is null ? false : ignoreSaveBranch.Value);

            return Mapper.Map(entity, dtoEntity);
        }

        public bool Update(ProductDTO dtoEntity, bool? ignoreSaveBranch = null)
        {
            //Validate(dtoEntity, ValidateType.Insert);

            var entity = GetByID(dtoEntity.Id);
            entity = Mapper.Map(dtoEntity, entity);

            Db.Entry(entity).State = EntityState.Modified;

            return Db.SaveChanges(ignoreSaveBranch is null ? false : ignoreSaveBranch.Value) > 0;
        }

        public virtual int Delete(int id)
        {
            //Validate(dtoEntity, ValidateType.Insert);

            var entity = Db.Set<Product>().Find(id);
            Db.Entry(entity).State = EntityState.Deleted;

            Db.SaveChanges();

            return id;
        }

        public void Dispose()
        {
            this.Db.Dispose();
        }
    }
}
