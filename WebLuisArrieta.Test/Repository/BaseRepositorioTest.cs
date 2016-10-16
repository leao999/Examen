using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebLuisArrieta.Model;
using WebLuisArrieta.Repositorio;
using Xunit;
using FluentAssertions;
using System.Data.Entity;
using Moq;


namespace WebDeveloper.Tests.Repository
{
    public class BaseRepositorioTest
    {
        private IRepositorio<Customer> repositorio;
        public BaseRepositorioTest()
        {
            repositorio = new BaseRepositorio<Customer>();
        }

        [Fact(DisplayName = "AddTestWrongWithMissingData")]
        public void AddTestWrongWithMissingData()
        {
            var customer = new Customer();            
            
            customer.FirstName = "Test";
            customer.LastName = "Test";
           
            try
            {
                repositorio.Agregar(customer);
            }
            catch (Exception exception)
            {
                exception.Source.Should().Be("EntityFramework");
            }
        }

        [Fact(DisplayName = "AddTestWrongWithNull")]
        public void AddTestWrongWithNull()
        {
            var customer = new Customer();
            try
            {
                repositorio.Agregar(customer);
            }
            catch (Exception exception)
            {
                exception.Should().NotBeNull();
            }            
        }

        [Fact(DisplayName = "AddTestWithProperData")]
        public void AddTestWithProperData()
        {
            Customer customer = TestcustomerOk();
            var result = repositorio.Agregar(customer);
            result.Should().BeGreaterThan(0);
        }


        [Fact(DisplayName = "UpdateTestWrongWithMissingData")]
        public void UpdateTestWrongWithMissingData()
        {
            var customer = new Customer();
            customer.FirstName = "Test";
            customer.LastName = "Test";            
            try
            {
                repositorio.Actualizar(customer);
            }
            catch (Exception exception)
            {
                exception.Source.Should().Be("EntityFramework");
            }
        }

        [Fact(DisplayName = "UpdateTestWrongWithNull")]
        public void UpdateTestWrongWithNull()
        {
            var customer = new Customer();
            try
            {
                repositorio.Actualizar(customer);
            }
            catch (Exception exception)
            {
                exception.Should().NotBeNull();
            }
        }


       




        [Fact(DisplayName = "DeleteTestWrongWithMissingData")]
        public void DeleteTestWrongWithMissingData()
        {
            var customer = new Customer();
            
            customer.FirstName = "Test";
            customer.LastName = "Test";
          
            try
            {
                repositorio.Borrar(customer);
            }
            catch (Exception exception)
            {
                exception.Source.Should().Be("EntityFramework");
            }
        }

        [Fact(DisplayName = "DeleteTestWrongWithMissingData2")]
        public void DeleteTestWrongWithMissingData2()
        {
            var customer = new Customer();
           
            customer.FirstName = "Test";
            customer.LastName = "Test";
           
            try
            {
                repositorio.Borrar(customer);
            }
            catch (Exception exception)
            {
                exception.Source.Should().Be("EntityFramework");
            }
        }


        [Fact(DisplayName = "DeleteTestWrongWithNull")]
        public void DeleteTestWrongWithNull()
        {
            var customer = new Customer();
            try
            {
                repositorio.Borrar(customer);
            }
            catch (Exception exception)
            {
                exception.Should().NotBeNull();
            }
        }



        private static Customer TestcustomerOk()
        {
            var customer = new Customer();
          
            customer.FirstName = "Test";
            customer.LastName = "Test";
         
            
            //customer.Id = new Customer()
            //{
                
            //    //customer = customer.Id
            //};
            return customer;
        }

        [Fact(DisplayName = "MockData")]

         
        public void MockData()
        {
            var customerDbSetMock =
                new Mock<DbSet<Customer>>();
                //new Mock<DbSet<customer>> ();

            var webContextMock =
                new Mock<WebContextDb>();

            webContextMock.Setup(m => m.Set<Customer>()).
                Returns(customerDbSetMock.Object);

            webContextMock.Setup(m => m.Set<Customer>()).
                Returns(customerDbSetMock.Object);

            var repositorio = 
            new BaseRepositorio<Customer>(webContextMock.Object);

            var newcustomer = TestcustomerOk();
            repositorio.Agregar(newcustomer);
            customerDbSetMock.Verify(p=> p.Add(It.IsAny<Customer>()), Times.Once);
            webContextMock.Verify(w => w.SaveChanges(), Times.Once);
        }

        [Fact(DisplayName = "MockDataList")]
        public void MockDataList()
        {
            //var customerList = CustomerList().AsQueryable();
            var customerDbSetMock = new Mock<DbSet<Customer>>();
            customerDbSetMock.As<IQueryable<Customer>>()
                .Setup(m => m.Provider);
            //.Returns(customerList.Provider);

            customerDbSetMock.As<IQueryable<Customer>>()
                .Setup(m => m.Expression);
            //.Returns(customerList.Expression);

            customerDbSetMock.As<IQueryable<Customer>>()
             .Setup(m => m.ElementType);
            //.Returns(customerList.ElementType);

            customerDbSetMock.As<IQueryable<Customer>>()
            .Setup(m => m.GetEnumerator());
            //.Returns(customerList.GetEnumerator());

            var webContextMock =
                new Mock<WebContextDb>();

            webContextMock.Setup(m => m.Set<Customer>()).
                Returns(customerDbSetMock.Object);

            webContextMock.Setup(m => m.Set<Customer>()).
                Returns(customerDbSetMock.Object);

            var repository =
           new BaseRepositorio<Customer>(webContextMock.Object);

            var customerGetByID = repository
                .GetById(p => p.FirstName == "Name1");
            customerGetByID.Should().NotBeNull();

        }

        private object CustomerList()
        {
            throw new NotImplementedException();
        }

        private object customerList()
        {
            throw new NotImplementedException();
        }

        [Fact(DisplayName = "MockEdit")]
        
        public void MockEdit()
        {
            var customerDbSetMock =
                new Mock<DbSet<Customer>>();
          
            var webContextMock =
                new Mock<WebContextDb>();

            webContextMock.Setup(m => m.Set<Customer>()).
                Returns(customerDbSetMock.Object);

            webContextMock.Setup(m => m.Set<Customer>()).
                Returns(customerDbSetMock.Object);

            var repository =
            new BaseRepositorio<Customer>(webContextMock.Object);

            //customerMockList();

            var newcustomer = TestcustomerOk();
            repository.Agregar(newcustomer);
            // customerDbSetMock.Verify(p => p.Add(It.IsAny<customer>()), Times.Once);
            var customerGetByID = repositorio
                .GetById(p => p.FirstName == "Name1");
      //      var customerToUpdate = repository.GetById(x => x.FirstName == "Name1");
            webContextMock.Verify(w => w.SaveChanges(), Times.Once);
        }


        //[Fact(DisplayName = "MockDelete")]

        //public void MockDelete()
        //{
        //    var customerDbSetMock =
        //        new Mock<DbSet<customer>>();

        //    var webContextMock =
        //        new Mock<WebContextDb>();

        //    webContextMock.Setup(m => m.Set<customer>()).
        //        Returns(customerDbSetMock.Object);

        //    webContextMock.Setup(m => m.Set<customer>()).
        //        Returns(customerDbSetMock.Object);

        //    var repository =
        //    new BaseRepository<customer>(webContextMock.Object);

        //    var newcustomer = TestcustomerOk();
        //    repository.Add(newcustomer);
                                   
        //    var customerToUpdate = repository.GetById(x => x.FirstName == "Name1");
        //    //customer.Should().NotBeNull();
        //    var result = repository.Delete(customerToUpdate);
        //    webContextMock.Verify(c => c.SaveChanges(), Times.Once());

        //}


        //private IEnumerable<Customer> customerList()
        //{
        //    return Enumerable.Range(1, 10)
        //        .Select(i =>
        //        new Customer
        //        {
        //            Id = i,
        //            FirstName = $"Name{i}",
        //            LastName = $"LastName{i}"
                   
        //        });
        //}

    }
    
}
