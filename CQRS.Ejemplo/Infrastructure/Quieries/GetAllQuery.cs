using CQRS.Ejemplo.Application.DTOs;
using MediatR;

namespace CQRS.Ejemplo.Infrastructure.Quieries
{
    public record GetAllQuery :IRequest<IEnumerable<TaskItemDto>>;
  
}
