using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RedisMVC.Repository;
using Newtonsoft.Json;

namespace RedisMVC.Controllers
{
    public class CompanyController : Controller
    {
        readonly ICompanyRepository repo;
        //readonly ICache<T> cache;
        //RedisCache<List<Company>> cache = new RedisCache<List<Company>>();

        RedisCache<Company> cacheCompany = new RedisCache<Company>();

        RedisCache<List<Company>> cacheCompanyList = new RedisCache<List<Company>>();

        public CompanyController(ICompanyRepository tempProduct)
        {
            this.repo = tempProduct;
            //this.cache = redisCache;
        }
        public string Index()
        {
            var data = repo.GetAll().ToList();

            cacheCompany.Set("company",data.FirstOrDefault());

            var company =cacheCompany.Get<Company>("company");

            cacheCompanyList.Set("companylist", data);

            var companylist = cacheCompanyList.Get<List<Company>>("companylist");

            //cache.Get("temp");
            
            //cache.Set("temp", data);
            

            return JsonConvert.SerializeObject(data);
        }
    }
}