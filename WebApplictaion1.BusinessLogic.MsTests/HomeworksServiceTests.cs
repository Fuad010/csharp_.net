using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.BusinessLogic;
using WebApplication1.Core;

namespace WebApplictaion1.BusinessLogic.MsTests
{
    [TestClass]
    public class HomeworksServiceTests
    {
        private string _guidCtor;
        private string _guidTestInitialize;

        public HomeworksServiceTests()
        {
            _guidCtor = Guid.NewGuid().ToString() + " ctor";
        }

        [TestInitialize]
        public void SetUp()
        {
            _guidTestInitialize = Guid.NewGuid().ToString() + " TestInitialize";
        }
        public void Log()
        {
            Console.WriteLine(_guidCtor);
            Console.WriteLine(_guidTestInitialize);
        }

        // unit testing name patterns
        // MethodName_Conditions_Result
        [TestMethod]
        public void Create_HomeworkIsValid_ShouldCreateNewHomework()
        {
            Log();
            //arrange - подготавливаем данные
            //var homeworkRepositoryMock = new HomeworksRepositoryMock();

            var homeworkRepositoryMock = new Mock<IHomeworksRepository>();

            var service = new HomeworksService(homeworkRepositoryMock.Object);

            var homework = new Homework();

            //act - запускаем тестируемый метод
            var result = service.Create(homework);

            //assert - проверяем/валидируем результаты теста
            Assert.IsTrue(result);

            homeworkRepositoryMock.Verify(x=>x.Add(homework), Times.Once);
        }

        [TestMethod]
        public void Create_HomeworkIsNull_ShouldThrowArgumentlNullException()
        {
            Log();
            //arrange
            var homeworksRepositoryMock = new Mock<IHomeworksRepository>();

            var service = new HomeworksService(homeworksRepositoryMock.Object);

            Homework homework = null;

            //act
            bool result = false;
            var exception = Assert.ThrowsException<ArgumentNullException>(() => result = service.Create(homework));

            //assert
            Assert.IsNotNull(exception);
            Assert.AreEqual("homework", exception.ParamName);
            Assert.IsFalse(result);
            homeworksRepositoryMock.Verify(x => x.Add(homework), Times.Never);
        }
        [TestMethod]
        public void Create_HomeworkIsInvalid_ShouldThrowBusinessException()
        {
            Log();
            //arrange


            //act
            //var result = service.Create(homework); 

            //assert
        }

        [TestMethod]
        public void Delete_ShouldDeleteHomework()
        {
            Log();
            //arrange
            var homeworkId = 1;
            var homeworkRepositoryMock = new Mock<IHomeworksRepository>();
            var service = new HomeworksService(homeworkRepositoryMock.Object);

            //act
            var result = service.Delete(homeworkId);

            //assert
            Assert.IsTrue(result);

            homeworkRepositoryMock.Verify(x=>x.Delete(homeworkId), Times.Once);
        }
    }
}
