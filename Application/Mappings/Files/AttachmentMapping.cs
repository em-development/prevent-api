using Application.Services.Files;
using AutoMapper;
using Domain.Entities.Files;
using DTO.Files;

namespace Application.Mappings.Files
{
    public class AttachmentMapping : Profile
    {
        public AttachmentMapping()
        {
            CreateMap<Attachment, AttachmentDto>()
                .ForMember(dto => dto.Guid, x => x.MapFrom(
                    ent => ent.Guid.Value))
                .ForMember(dto => dto.FileName, x => x.MapFrom(
                    ent => ent.FileName.Value))
                .ForMember(dto => dto.ContentType, x => x.MapFrom(
                    ent => ent.ContentType.Value))
                .ForMember(dto => dto.Bucket, x => x.MapFrom(
                    ent => ent.Bucket.Value))
                .ForMember(dto => dto.Url, x => x.MapFrom(
                    ent => AwsFileStorageService.GetObjectDirectLinkAsync(ent.Bucket.Value,
                        ent.Guid.Value,
                        ent.FileName.Value,
                        ent.ContentType.Value)));

            CreateMap<AttachmentDto, AwsScheduleFileDto > ()
                .ForMember(dto => dto.Key, x => x.MapFrom(
                    ent => ent.Guid))
                .ForMember(dto => dto.ContentType, x => x.MapFrom(
                    ent => ent.ContentType))
                .ForMember(dto => dto.Content, x => x.MapFrom(
                    ent => new MemoryStream(ent.Content)))
                .ForMember(dto => dto.Bucket, x => x.MapFrom(
                    ent => ent.Bucket));
        }
    }
}