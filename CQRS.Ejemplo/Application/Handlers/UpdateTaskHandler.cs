﻿using CQRS.Ejemplo.Application.DTOs;
using CQRS.Ejemplo.Infrastructure;
using CQRS.Ejemplo.Infrastructure.Commands;
using MediatR;

namespace CQRS.Ejemplo.Application.Handlers
{
    public class UpdateTaskHandler : IRequestHandler<UpdateTaskCommand, TaskItemDto>
    {
        private readonly ApplicationDbContext _dbContext;

        public UpdateTaskHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<TaskItemDto> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var taskItem = await _dbContext.TaskItems.FindAsync(
                new object[] { request.Id }, cancellationToken);

            if (taskItem != null)
            {
                return null;
            }
            taskItem.Title = request.Title;
            taskItem.Description = request.Description;
            taskItem.IsCompleted = request.isCompleted;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return new TaskItemDto
            {
                Id = taskItem.Id,
                Title = taskItem.Title,
                Description = taskItem.Description,
                IsCompleted = taskItem.IsCompleted
            };
        }
    }
}
