using HmadeShop.Data.Infrastructure;
using HmadeShop.Data.Repositories;
using HmadeShop.Model.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmadeShop.UnitTest.ReponsitoryTest
{
    [TestClass] //để nó nhận trong TestExploer
    public class PostCategoryReponsitoryTest
    {
        IDbFactory dbFactory;
        IPostCategoryRepository objRepository;
        IUnitOfWork unitOfWork;
        [TestInitialize] //có thuộc tính giúp chạy lần đầu khi ứng dụng chạy
        public void TestInitialize()
        {
            dbFactory = new DbFactory();
            objRepository = new PostCategoryRepository(dbFactory);
            unitOfWork = new UnitOfWork(dbFactory);
        }
        [TestMethod]
        public void PostCategory_Repository_GetAll()
        {
            var list = objRepository.GetAll().ToList();
            Assert.AreEqual(3, list.Count);
            Assert.IsNotNull(list);
        }

        [TestMethod] //nhận tên phương thức trong TestExploer
        public void PostCategory_Repository_Create()
        {
            PostCategory category = new PostCategory();
            category.Name = "Test category";
            category.Alias = "Test-category";
            category.Status = true;

            var result = objRepository.Add(category);
            unitOfWork.Commit();

            //Asert chứa các phương thức để so sánh giữa hai giá trị
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);

        }
       
    }
}
