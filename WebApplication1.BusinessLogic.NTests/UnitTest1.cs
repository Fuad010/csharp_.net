using NUnit.Framework;
using System;
using WebApplication1.Core.Exceptions;
using WebApplication1.Core.Repositories;
using WebApplication1.Core;
using AutoFixture;
using Moq;
using FluentAssertions;

namespace WebApplication1.BusinessLogic.NTests
{
    public class HomeworksServiceTests
    {
        private Mock<IHomeworksRepository> _homeworkRepositoryMock;
        private HomeworksService _service;

        public HomeworksServiceTests()
        {

        }

        [SetUp]
        public void SetUp()
        {
            _homeworkRepositoryMock = new Mock<IHomeworksRepository>();
            _service = new HomeworksService(_homeworkRepositoryMock.Object);
        }

        // unit testing name patterns
        // MethodName_Conditions_Result
        [Test]
        public void Create_HomeworkIsValid_ShouldCreateNewHomework()
        {
            //arrange - подготавливаем данные
            var fixture = new Fixture();

            var homework = fixture.Build<Homework>()
                .With(x => x.MemberId, 351)
                .Without(x => x.MentorId)
                .Create();

            var homeworks = fixture.Build<Homework>()
                .With(x => x.MemberId, 351)
                .Without(x => x.MentorId).CreateMany<Homework>(4);

            //act - запускаем тестируемый метод
            var result = _service.Create(homework);

            //assert - проверяем/валидируем результаты теста
            result.Should().BeTrue();
            _homeworkRepositoryMock.Verify(x => x.Add(homework), Times.Once);
        }

        [Test]
        public void Create_HomeworkIsNull_ShouldThrowArgumentlNullException()
        {
            //arrange
            Homework homework = null;

            //act
            bool result = false;
            var exception = Assert.Throws<ArgumentNullException>(() => result = _service.Create(homework));

            //assert
            exception.Should().NotBeNull()
                .And
                .Match<ArgumentNullException>(x => x.ParamName == "homework");


            //Assert.IsNotNull(exception);
            //Assert.AreEqual("homework", exception.ParamName);
            //Assert.IsFalse(result);

            result.Should().BeFalse();
            _homeworkRepositoryMock.Verify(x => x.Add(homework), Times.Never);
        }
        [Test]
        public void Create_HomeworkIsInvalid_ShouldThrowBusinessException()
        {
            //arrange
            var homework = new Homework();

            //act
            bool result = false;
            var exception = Assert.Throws<BusinessException>(() => result = _service.Create(homework));

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

        [Test]
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

            _homeworkRepositoryMock.Verify(x => x.Delete(homeworkId), Times.Once);
        }
    }
}