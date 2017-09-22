using Shouldly;
using System;
using System.Linq;
using NSubstitute;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit;
using TestDemo.Application;
using TestDemo.Model;
using TestDemo.Repositories;
using Xunit;

namespace TestDemo.Tests
{
    public class CategoryTests
    {
        private readonly Fixture _fixture;

        public CategoryTests()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Fact]
        public void Category_Creation()
        {
            //Act
            var category = new Category();
            //Assert
            Assert.NotNull(category.CategoryLocations);

            #region Shouldly
            //Assert
            category.CategoryLocations.ShouldNotBeNull();
            #endregion

        }

        [Fact]
        public void Category_AddLocation()
        {
            //Arrange
            var category = new Category{Id=2, Name="Some category not important"};
            var location = new Location {Id = 1, Name = "Why am i doing this?"};

            //Act
            category.Add(location);

            //Assert
            category.CategoryLocations.Count.ShouldBe(1);
            category.CategoryLocations[0].ShouldNotBeNull();
            category.CategoryLocations[0].CategoryId.ShouldBe(2);
            category.CategoryLocations[0].Category.Id.ShouldBe(category.Id);
            category.CategoryLocations[0].Category.Name.ShouldBe(category.Name);
            category.CategoryLocations[0].Location.Name.ShouldBe(location.Name);
            category.CategoryLocations[0].Location.Id.ShouldBe(location.Id);
        }

        [Fact]
        public void Category_AddLocation_autoFixture()
        {

            var category = _fixture.Create<Category>();
            var location = _fixture.Create<Location>();

            category.HasLocation(location).ShouldBe(false);

            category.Add(location);
            category.HasLocation(location).ShouldBeTrue();
        }


        [Fact]
        public void CategoryApp_adds_location_to_category()
        {
            //Arrange
            var category = Substitute.For<Category>();
            var location = _fixture.Create<Location>();

            var cateogryRepo = Substitute.For<IRepository<Category>>();
            var locationRepo = Substitute.For<IRepository<Location>>();

            cateogryRepo.Get(category.Id).Returns(category);
            locationRepo.Get(location.Id).Returns(location);
            category.Add(location).Returns(true);
            category.HasLocation(location).Returns(false);

            var sut = new CategoryApp(locationRepo, cateogryRepo);
            var actual = sut.AddLocation(category.Id, location.Id);
            actual.ShouldBeTrue();

            category.Received().Add(location);
        }

        //TODO: Investigate
        //[Theory, AutoNSubstituteData]
        //public void CategoryApp_adds_location_to_category_using_autoMocking(
        //    [Frozen] IRepository<Category> categoryRepo,
        //    [Frozen] IRepository<Location> locationRepo, CategoryApp app)
        //{
        //    categoryRepo.Get(0).ReturnsForAnyArgs(new Category());
        //    locationRepo.Get(0).ReturnsForAnyArgs(new Location());

        //    var actual = app.AddLocation(0, 0);


        //}

        [Fact]
        public void DoSomthing_return_0_for_null()
        {
            var sute = new Something();
            sute.Do(null).ShouldBe(0);
        }


        [Theory]
        [InlineData(null, 0)]
        [InlineData(3,3)]
        [InlineData(4,400)]
        public void DoSomething_a_lot(int input, int expected)
        {
            var sute = new Something();
            sute.Do(input).ShouldBe(expected);
        }

    }

    public class Something
    {
        public int Do(int? i)
        {
            if (!i.HasValue) return 0;
            if (i.HasValue && i.Value%2 != 0) return i.Value;
            if (i.Value % 2 == 0) return i.Value * 100;
            return i.Value * 1000;
        }

    }

}
