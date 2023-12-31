﻿using FluentValidation;

using MediatR;

using Tohme.Application.Command.GymCommands;
using Tohme.Application.Interfaces;
using Tohme.Domain.Entities;

namespace Tohme.Application.Command.TrainerCommands
{
    public record CreateTrainer(int? id, string Name, int Age) : IRequest<Trainer>;
    public class CreateTrainerHandler : IRequestHandler<CreateTrainer, Trainer>
    {
        private readonly IBaseRepository<Trainer> _trainers;
        public CreateTrainerHandler(IBaseRepository<Trainer> trainer)
        {
            _trainers = trainer;
        }

        public async Task<Trainer> Handle(CreateTrainer request, CancellationToken cancellationToken)
        {
            var (id, name, age) = request;
            var trainer = await _trainers.GetNullableById(id, cancellationToken);
            trainer?.Update(name, age);
            trainer ??= new Trainer(name, age);
            return await _trainers.CreateOrUpdate(id, trainer, cancellationToken);
        }
    }
    public class CreateTrainerValidator : AbstractValidator<CreateTrainer>
    {
        public CreateTrainerValidator()
        {
            RuleFor(c => c.Name).Must(n => n == "Hussein").When(c => c.Age == 24);
            ;
        }
    }
}
