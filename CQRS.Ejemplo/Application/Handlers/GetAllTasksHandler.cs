using CQRS.Ejemplo.Application.DTOs;
using CQRS.Ejemplo.Domain;
using CQRS.Ejemplo.Infrastructure;
using CQRS.Ejemplo.Infrastructure.Quieries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Ejemplo.Application.Handlers
{
    public class GetAllTasksHandler : IRequestHandler<GetAllQuery, IEnumerable<TaskItemDto>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetAllTasksHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<TaskItemDto>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var tasks = await _dbContext.TaskItems.ToListAsync(cancellationToken);

            return tasks.Select(task => new TaskItemDto()
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted,
            });
        }
    }
}
