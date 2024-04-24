using MediatR;

namespace CQRS.Ejemplo.Infrastructure.Commands
{
    public record DeleteTaskCommand (int Id) :IRequest<bool>;

}
