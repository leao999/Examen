
//using System.Web.Mvc;
using WebLuisArrieta.Areas.Fabrica.Controllers;
using Xunit;
using FluentAssertions;
using System.Collections;
using WebLuisArrieta.Model;
using System.Collections.Generic;
using System.Linq;
using WebLuisArrieta.Repositorio;
using System;

namespace WebLuisArrieta.Tests.Controllers
{
    public class ClienteControllerTest
    {
        private ClienteController controller;

        public object result { get; private set; }

        public ClienteControllerTest()
        {
            controller = new ClienteController(new BaseRepositorio<Customer>());
        }

        [Fact(DisplayName = "ListActionWithEmptyParameters")]
        public void ListActionWithEmptyParameters()
        {
            //var result = controller.List(null, null) as PartialViewResult;
            //result.ViewName.Should().Be("_List");

            //var modelCount = (IEnumerable<Customer>)result.Model;
            //modelCount.Count().Should().Be(15);
        }


        [Fact(DisplayName = "ListActionWithEmptyParameters2")]
        public void ListActionWithEmptyParameters2()
        {
            //var result = controller.List(15, null) as PartialViewResult;
            //result.ViewName.Should().Be("_List");

            //var modelCount = (IEnumerable<Customer>)result.Model;
            //modelCount.Count().Should().Be(15);
        }

        [Fact(DisplayName = "ListActionWithEmptyParameters3")]
        public void ListActionWithEmptyParameters3()
        {
            var result = controller.List(null, 14) as PartialViewResult;
            result.ViewName.Should().Be("_List");

            var modelCount = (IEnumerable<Customer>)result.Model;
            modelCount.Count().Should().Be(15);
        }

        [Fact(DisplayName = "CreateActionWithParameters")]
        public void CreateActionWithParameters()
        {
            var customer = new Customer();
           
            customer.FirstName = "Miguel";
            customer.LastName = "Serna";
          
            try
            {
                //var result = controller.Create(customer);
            }
            catch (Exception exception)
            {
                exception.Source.Should().Be("EntityFramework");
            }

        }

        [Fact(DisplayName = "DeleteActionWithEmptyParameters")]
        public void DeleteActionWithEmptyParameters()
        {
            var customer = new Customer();
            
            customer.FirstName = "Claudia";
            customer.LastName = "Pereda";
            
            try
            {
                //controller.Borrar(customer);
            }
            catch (Exception exception)
            {
                exception.Source.Should().Be("EntityFramework");
            }
        }

        private class ClienteController
        {
            private BaseRepositorio<Customer> baseRepositorio;

            public ClienteController(BaseRepositorio<Customer> baseRepositorio)
            {
                this.baseRepositorio = baseRepositorio;
            }

            internal PartialViewResult List(object p, int v)
            {
                throw new NotImplementedException();
            }
        }
    }
}
