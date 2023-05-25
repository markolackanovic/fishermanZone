﻿using Application.BusinessLogic.Shared.Create;
using Application.Common.Mappings;
using AutoMapper;
using MediatR;

namespace Application.BusinessLogic.UlogaKorisnika.Commands.CreateUlogaKorisnikaCommand;

public class CreateUlogaKorisnikaCommand : CreateCommand , IMapFrom<Domain.Entities.UlogaKorisnika>
{
    public string Naziv { get; set; }
    public string Opis { get; set; }
    public bool Aktivno { get; set; }
}
