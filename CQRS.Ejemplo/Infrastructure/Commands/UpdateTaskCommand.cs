using CQRS.Ejemplo.Application.DTOs;
using MediatR;

namespace CQRS.Ejemplo.Infrastructure.Commands
{
    public record UpdateTaskCommand (int Id, string Title, string Description, bool isCompleted)
        : IRequest<TaskItemDto>;
}
