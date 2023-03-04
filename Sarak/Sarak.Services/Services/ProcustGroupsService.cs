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
    public class ProcustGroupsService : ServiceBase
    {
        public IHttpContextAccessor HttpContextAccessor { get; }
        public SarakDbContext Db { get; }

        public ProcustGroupsService(
            SarakDbContext db,
            IHttpContextAccessor httpContextAccessor,
            UserManager<User> userManager)
            : base(userManager)
        {
            this.HttpContextAccessor = httpContextAccessor;
            this.Db = db;
        }

        public virtual List<ProductGroupDTO> Get<TResult>()
        {
            var queryable = Db.Set<ProductGroup>().AsQueryable().AsNoTracking();

            return queryable.ProjectTo<ProductGroupDTO>().ToList();
        }

        public List<ProductGroupView> GetPaged(ProductGroupSearchDTO query)
        {
            throw new NotImplementedException();
        }

        protected virtual List<ProductGroupDTO> Get<TResult>(Expression<Func<ProductGroup, bool>> where)
        {
            var queryable = Db.Set<ProductGroup>().AsQueryable().AsNoTracking();

            return queryable
                     .Where(where)
                     .ProjectTo<ProductGroupDTO>()
                     .ToList();
        }

        public virtual ProductGroupDTO GetByID(int id)
        {
            var entity = Db.Set<ProductGroup>().Find(id);
            return Mapper.Map<ProductGroupDTO>(entity);
        }

        public ProductGroupDTO Insert(ProductGroupDTO dtoEntity, bool? ignoreSaveBranch = null)
        {
            //Validate(dtoEntity, ValidateType.Insert);

            var entity = Mapper.Map<ProductGroup>(dtoEntity);
            Db.Set<ProductGroup>().Add(entity);

            Db.SaveChanges(ignoreSaveBranch is null ? false : ignoreSaveBranch.Value);

            return Mapper.Map(entity, dtoEntity);
        }

        public bool Update(ProductGroupDTO dtoEntity, bool? ignoreSaveBranch = null)
        {
            //Validate(dtoEntity, ValidateType.Update);

            var entity = GetByID(dtoEntity.Id);
            entity = Mapper.Map(dtoEntity, entity);

            Db.Entry(entity).State = EntityState.Modified;

            return Db.SaveChanges(ignoreSaveBranch is null ? false : ignoreSaveBranch.Value) > 0;
        }

        public virtual int Delete(int id)
        {
            //Validate(dtoEntity, ValidateType.Delete);

            var entity = Db.Set<ProductGroup>().Find(id);
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
