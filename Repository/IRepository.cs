using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace App.Repository {

    public interface IRepository<T> {

        public IQueryable<T>GetAll();

        public T GetById(int id);

        public T InsertOne(T model);

        public bool FindOne(int id);

        public T DeleteOne(int id);

        public void DeleteAll();

        public bool FindByEmailAddress(string email);


    }







}