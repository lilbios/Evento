using Evento.BLL.Interfaces;
using Evento.DTO.Entities;
using Evento.DTO.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Evento.BLL.Services
{
    public class TagService: ITagService<Tag>
    {
        private readonly IUnitOfWork _unitOfWork;
        public TagService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddTag(Tag tag)
        {
            Tag _tag = new Tag();
            _tag.TagEvents = tag.TagEvents;
            _tag.TagName = tag.TagName;
            await _unitOfWork.Tags.Create(_tag);
        }

        public async Task RemoveTag(int tagId)
        {
            await _unitOfWork.Tags.Delete(tagId);
        }
    }
}
