using AutoMapper;
using Evento.BLL.Interfaces;
using Evento.Models.Entities;
using System.Threading.Tasks;

namespace Evento.BLL.Services
{
    public class TagService: ITagService<Tag>
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
            var newTag = mapper.Map<Tag>(tag);
            await unitOfWork.Tags.Create(newTag);
        }

        public async Task RemoveTag(int tagId)
        {
            await unitOfWork.Tags.Delete(tagId);
        }
    }
}
