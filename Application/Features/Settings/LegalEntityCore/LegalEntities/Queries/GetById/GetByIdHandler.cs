﻿using Adapters.Repositories.Settings.LegalEntityCore.LegalEntities;
using Application.Features.Settings.LegalEntityCore.LegalEntities.Queries.GetById;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities.Settings.LegalEntityCore.LegalEntities;
using DTO.Settings.LegalEntityCore.LegalEntities;
using MediatR;

namespace Application.Features.Settings.LegalEntityCore.Queries.GetByIdHandler
{
    internal class GetByHandler : IRequestHandler<GetByIdQuery, Response<LegalEntityDTO>>
    {
        private readonly ILegalEntityRepository _legalEntityRepository;
        private readonly IMapper _mapper;

        public GetByHandler(
            ILegalEntityRepository legalEntityRepository,
            IMapper mapper
            )
        {
            _legalEntityRepository = legalEntityRepository;
            _mapper = mapper;
        }

        public async Task<Response<LegalEntityDTO>> Handle(
            GetByIdQuery query,
            CancellationToken cancellationToken)
        {
            LegalEntity? legalEntity = await _legalEntityRepository.GetByIdAsync(query.Id);

            LegalEntityDTO? legalEntityDTO = _mapper.Map<LegalEntityDTO>(legalEntity);

            return new(legalEntityDTO);
        }
    }
}
