using AutoMapper;
using Evento.BLL.Interfaces;
using Evento.Models.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Evento.BLL.Services
{
    public class TagService : ITagService<Tag>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public TagService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task AddTag(Tag tag)
        {
            await unitOfWork.Tags.Create(tag);
        }

        public async Task RemoveTag(int tagId)
        {
            await unitOfWork.Tags.Delete(tagId);
        }
        public async Task AttachTagToEvent(Tag tag, Event e)
        {

            var tagEvent = new TagEvent()
            {
                TagId = tag.Id,
                EventId = e.Id,
                Event = e,
                Tag = tag
            };
            await unitOfWork.TagEvents.Create(tagEvent);
        }

        public async Task<Tag> GetTagByName(string name)
        {
            var tag = await unitOfWork.Tags.GetByCondition(t => t.TagName == name);
            return tag.FirstOrDefault();
        }

        public async Task<bool> HasTag(string name)
        {
            var tag = await unitOfWork.Tags.GetByCondition(t => t.TagName == name);
            return tag is null;
        }
    }
}
