﻿using Application.Common.Mappings;
using Application.Shared.Services.Create;
using AutoMapper;
using MediatR;

namespace Application.BusinessLogic.UlogaKorisnika.Commands.CreateUlogaKorisnikaCommand;

public class CreateUlogaKorisnikaCommand : CreateCommand , IMapFrom<Domain.Entities.UlogaKorisnika>
{
    public string Naziv { get; set; } = string.Empty;
    public string Opis { get; set; } = string.Empty;
}
