using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocGauShop.Data.Infrastructure;
using SocGauShop.Data.Repositories;
using SocGauShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocGauShop.UnitTest.RepositoryTest
{
    [TestClass]
    public class PostCategoryRepositoryTest
    {
        IDbFactory dbFactory;
        IPostCategoryRepository objRepository;
        IUnitOfWork unitOfWork;
        [TestInitialize]
        public void Initialize()
        {
            dbFactory = new DbFactory();
            objRepository = new PostCategoryRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }
        [TestMethod]
        public void PostCategory_Repository_GetAll()
        {
            var result = objRepository.GetAll().ToList();
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            PostCategory category = new PostCategory();
            category.Name = "Test Category";
            category.Alias = "Test_Category";
            category.Status = true;
            
            var result = objRepository.Add(category);
            unitOfWork.Commit();

            Assert.IsNotNull(result);

        }
    }
}
