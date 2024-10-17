using AutoFixture;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.BusinessLogic;
using WebApplication1.Core;
using WebApplication1.Core.Exceptions;
using WebApplication1.Core.Repositories;

namespace WebApplictaion1.BusinessLogic.MsTests
{
    [TestClass]
    public class HomeworksServiceTests
    {
        private readonly Mock<IHomeworksRepository> _homeworkRepositoryMock;
        private readonly HomeworksService _service;

        public HomeworksServiceTests()
        {
            _homeworkRepositoryMock = new Mock<IHomeworksRepository>();
            _service = new HomeworksService(_homeworkRepositoryMock.Object);
        }

        // unit testing name patterns
        // MethodName_Conditions_Result
        [TestMethod]
        public void Create_HomeworkIsValid_ShouldCreateNewHomework()
        {
            //arrange - подготавливаем данные
            var fixture = new Fixture();

            var homework = fixture.Build<Homework>()
                .With(x => x.MemberId, 431)
                .Without(x => x.MentorId)
                .Create();

            var homeworks = fixture.Build<Homework>()
                .With(x => x.MemberId, 351)
                .Without(x => x.MentorId).CreateMany<Homework>(4);

            //act - запускаем тестируемый метод
            var result = _service.Create(homework);

            //assert - проверяем/валидируем результаты теста
            result.Should().BeTrue();
            _homeworkRepositoryMock.Verify(x=>x.Add(homework), Times.Once);
        }

        [TestMethod]
        public void Create_HomeworkIsNull_ShouldThrowArgumentlNullException()
        {
            //arrange
            Homework homework = null;

            //act
            bool result = false;
            var exception = Assert.ThrowsException<ArgumentNullException>(() => result = _service.Create(homework));

            //assert
            exception.Should().NotBeNull()
                .And
                .Match<ArgumentNullException>(x=>x.ParamName == "homework");


            //Assert.IsNotNull(exception);
            //Assert.AreEqual("homework", exception.ParamName);
            //Assert.IsFalse(result);

            result.Should().BeFalse();
            _homeworkRepositoryMock.Verify(x => x.Add(homework), Times.Never);
        }
        [DataTestMethod]
        [DataRow(4)]
        [DataRow(0)]
        [DataRow(034)]
        [DataRow(-3434)]
        [DataRow(-3454331)]
        [DataRow(134353543)]
        public void Create_HomeworkIsInvalid_ShouldThrowBusinessException(int memberId)
        {
            //arrange
            var homework = new Homework();
            homework.MemberId = memberId;
            //act
            bool result = false;
            var exception = Assert.ThrowsException<BusinessException>(() => result = _service.Create(homework));

            //assert
            exception.Should().NotBeNull()
              .And
              .Match<BusinessException>(x => x.Message == HomeworksService.HOMEWORK_IS_INVALID);


            //Assert.IsNotNull(exception);
            //Assert.AreEqual(HomeworksService.HOMEWORK_IS_INVALID, exception.Message);
            //Assert.IsFalse(result);

            result.Should().BeFalse(); 
            _homeworkRepositoryMock.Verify(x => x.Add(homework), Times.Never);
        }

        [TestMethod]
        public void Delete_ShouldDeleteHomework()
        {
            //arrange
            var fixture = new Fixture();
            var homeworkId = fixture.Create<int>();

            //act
            var result = _service.Delete(homeworkId);

            //assert
            //Assert.IsTrue(result);
            result.Should().BeTrue();

            _homeworkRepositoryMock.Verify(x=>x.Delete(homeworkId), Times.Once);
        }
    }
}
