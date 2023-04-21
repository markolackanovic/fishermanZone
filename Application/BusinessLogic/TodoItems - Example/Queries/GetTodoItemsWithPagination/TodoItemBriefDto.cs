using Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using AutoMapper;

namespace Application.BusinessLogic.TodoItems___Example.Queries.GetTodoItemsWithPagination
{
    public class TodoItemBriefDto : IMapFrom<TodoItemExample>
    {
        public int Id { get; set; }

        public int ListId { get; set; }

        public string? Title { get; set; }

        public bool Done { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TodoItemExample, TodoItemBriefDto>()
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.Title));
        }
    }
}