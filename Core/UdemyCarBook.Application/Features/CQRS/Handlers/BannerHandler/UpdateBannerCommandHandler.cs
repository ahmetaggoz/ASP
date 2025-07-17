using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.BannerCommand;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandler
{
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateBannerCommand command)
        {
            var value = await _repository.GetByIdAsync(command.BannerId);
            if (value != null)
            {
                value.Title = command.Title;
                value.Description = command.Description;
                value.VideoDescription = command.VideoDescription;
                value.VideoUrl = command.VideoUrl;
                await _repository.UpdateAsync(value);
            }
            else
            {
                throw new Exception("Banner not found");
            }
        }
    }
}
