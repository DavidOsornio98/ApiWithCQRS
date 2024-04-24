using CQRS.Ejemplo.Application.DTOs;
using MediatR;

namespace CQRS.Ejemplo.Infrastructure.Commands
{
    public record CreateTaskCommand(string Title, string Description) : IRequest<TaskItemDto>;

}
