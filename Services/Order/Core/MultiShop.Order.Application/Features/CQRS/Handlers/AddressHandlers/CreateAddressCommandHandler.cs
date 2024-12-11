using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateAddressCommand createAddressCommand)
        {
            //AutoMapper kullanıp konfigürasyon yaparsan bundan daha kısa ve kolay olur.
            await _repository.CreateAsync(new Address
            {
                UserId = createAddressCommand.UserId,
                Name = createAddressCommand.Name,
                Surname = createAddressCommand.Surname,
                Email = createAddressCommand.Email,
                Phone = createAddressCommand.Phone,
                Country = createAddressCommand.Country,
                District = createAddressCommand.District,
                City = createAddressCommand.City,
                Detail1 = createAddressCommand.Detail1,
                Detail2 = createAddressCommand.Detail2,
                Description = createAddressCommand.Description,
                ZipCode = createAddressCommand.ZipCode,
            });
        }
    }
}
