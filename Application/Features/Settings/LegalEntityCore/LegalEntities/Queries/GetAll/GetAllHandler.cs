﻿using Adapters.Repositories.Settings.LegalEntityCore.LegalEntities;
using Application.Features.Settings.LegalEntityCore.LegalEntities.Queries.GetById;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.LegalEntityCore.LegalEntities;
using DTO.Settings.LegalEntityCore.LegalEntities;
using MediatR;

namespace Application.Features.Settings.LegalEntityCore.Queries.GetByIdHandler
{
    internal class GetAllHandler : IRequestHandler<GetAllQuery, Response<IEnumerable<LegalEntityDTO>>>
    {
        private readonly ILegalEntityRepository _legalEntityRepository;
        private readonly IMapper _mapper;

        public GetAllHandler(
            ILegalEntityRepository legalEntityRepository,
            IMapper mapper
            )
        {
            _legalEntityRepository = legalEntityRepository;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<LegalEntityDTO>>> Handle(
            GetAllQuery query,
            CancellationToken cancellationToken)
        {
            IEnumerable<LegalEntity>? legalEntity = _legalEntityRepository.GetAllLegalEntities();

            IEnumerable<LegalEntityDTO>? legalEntityDTO = _mapper.Map<IEnumerable<LegalEntity>, IEnumerable<LegalEntityDTO>>(legalEntity);

            return new(legalEntityDTO);
        }
    }
}
