using System.Linq;
using App.Models;
using App.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace App.Repository {


    public class Repository<T> : IRepository<T> where T : BaseEntity
    {

        private readonly SalatyDbContext dbContext;
        

        private DbSet<T>entities;

        public Repository(SalatyDbContext dbContext)
        {
            this.dbContext = dbContext;

            entities = dbContext.Set<T>();


        }


        public void DeleteAll()
        {
            entities.RemoveRange(entities);
            dbContext.SaveChanges();
        }

        public T DeleteOne(int id)
        {
            var target = entities.SingleOrDefault<T>(instance => instance.Id == id);
            if(target != null){
                entities.Remove(target);
                dbContext.SaveChanges();
                return target;
            }else{
                return null;
            }
        }

        public bool FindByEmailAddress(string email)
        {
            var type = typeof(T).GetTypeInfo();
            if(type.Name == "User"){
                var userDbContext = dbContext.Set<User>();
                if(userDbContext.SingleOrDefault<User>(user=>user.EmailAddress == email) != null){
                    return true;
                }else{
                    return false;
                }

            }else{
                throw new System.Exception("INVALID TYPE FOR THE METHOD");
            }
        }

        public bool FindOne(int id)
        {
            var target = entities.SingleOrDefault<T>(instance => instance.Id == id);
            if(target != null){
                return true;
            }else{
                return false;
            }
        }

        public IQueryable<T> GetAll()
        {
            return entities;
        }

        public T GetById(int id)
        {
            var target = entities.SingleOrDefault<T>(instance => instance.Id == id);
            if(target != null){
                return target;
            }else{
                return null;
            }
        }

        public T InsertOne(T model)
        {
            entities.Add(model);
            dbContext.SaveChanges();
            return model;
        }
    }





}




