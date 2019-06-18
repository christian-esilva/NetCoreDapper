using System;
using System.Collections.Generic;
using GameStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using GameStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using GameStore.Domain.StoreContext.Handlers;
using GameStore.Domain.StoreContext.Queries;
using GameStore.Domain.StoreContext.Respositories;
using GameStore.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly CustomerHandler _handler;

        public CustomerController(ICustomerRepository repository, CustomerHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("customers")]
        [ResponseCache(Duration = 15)]
        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("customers/{id}")]
        public GetCustomerQueryResult GetById(Guid id)
        {
            return _repository.Get(id);
        }

        [HttpGet]
        [Route("customers/{id}/orders")]
        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
        {
            return _repository.GetOrders(id);
        }

        [HttpPost]
        [Route("customers")]
        public ICommandResult Post([FromBody]CreateCustomerCommand command)
        {
            var result = (CreateCustomerCommandResult) _handler.Handle(command);
            return result;
        }
    }
}