﻿using FluentValidation;
using MediatR;

namespace EmployeeMangement.Behaviour
{

    
        public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        {
            private readonly IEnumerable<IValidator<TRequest>> _validators;

            public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
            {
                _validators = validators;
            }

            public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
            {
                var context = new ValidationContext<TRequest>(request);

                var failures = _validators
                    .Select(v => v.Validate(context))
                    .SelectMany(result => result.Errors)
                    .Where(f => f != null)
                    .ToList();

                if (failures.Count != 0)
                {
                    throw new ValidationException(failures);
                }

                return next();
            }
        }
    }

