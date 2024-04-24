using CQRS.Ejemplo.Infrastructure;
using CQRS.Ejemplo.Infrastructure.Commands;
using MediatR;

namespace CQRS.Ejemplo.Application.Handlers
{
    public class DeleteTaskHandle : IRequestHandler<DeleteTaskCommand, bool>
    {

        private readonly ApplicationDbContext _dbContext;

        public DeleteTaskHandle(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var taskItem = await _dbContext.TaskItems.FindAsync(
                new object[] { request.Id }, cancellationToken);

            if (taskItem != null)
            {
                return false;
            }

            _dbContext.TaskItems.Remove(taskItem);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
