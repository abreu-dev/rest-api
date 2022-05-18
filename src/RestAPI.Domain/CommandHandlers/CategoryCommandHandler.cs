using MediatR;
using RestAPI.Domain.Commands.CategoryCommands;
using RestAPI.Domain.Interfaces;
using RestAPI.Domain.MediatorHandler;
using RestAPI.Domain.Notifications;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestAPI.Domain.CommandHandlers
{
    public class CategoryCommandHandler :
        IRequestHandler<AddCategoryCommand, Unit>,
        IRequestHandler<UpdateCategoryCommand, Unit>,
        IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryCommandHandler(ICategoryRepository categoryRepository, IMediatorHandler mediatorHandler)
        {
            _categoryRepository = categoryRepository;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<Unit> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                foreach (var error in request.ValidationResult.Errors)
                {
                    await _mediatorHandler.RaiseDomainNotificationAsync(
                        new DomainNotification(error.ErrorCode, error.CustomState.ToString(), error.ErrorMessage));
                }
                return Unit.Value;
            }

            if (_categoryRepository.Query().Where(category => category.Name == request.Category.Name).Any())
            {
                await _mediatorHandler.RaiseDomainNotificationAsync(
                    new DomainNotification("DuplicatedValue", "Name duplicated", "The field 'Name' must be unique"));
                return Unit.Value;
            }

            _categoryRepository.AddCategory(request.Category);
            _categoryRepository.UnitOfWork.Commit();

            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                foreach (var error in request.ValidationResult.Errors)
                {
                    await _mediatorHandler.RaiseDomainNotificationAsync(
                        new DomainNotification(error.ErrorCode, error.CustomState.ToString(), error.ErrorMessage));
                }
                return Unit.Value;
            }

            if (_categoryRepository.Query().Where(category => category.Id != request.AggregateId
                                                           && category.Name == request.Category.Name).Any())
            {
                await _mediatorHandler.RaiseDomainNotificationAsync(
                    new DomainNotification("DuplicatedValue", "Name duplicated", "The field 'Name' must be unique"));
                return Unit.Value;
            }

            var category = _categoryRepository.GetCategoryById(request.AggregateId);
            if (category == null)
            {
                await _mediatorHandler.RaiseDomainNotificationAsync(
                    new DomainNotification("NotFound", "Category not found", "The informed 'Category' was not found"));
                return Unit.Value;
            }

            category.Name = request.Category.Name;

            _categoryRepository.UpdateCategory(category);
            _categoryRepository.UnitOfWork.Commit();

            return Unit.Value;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                foreach (var error in request.ValidationResult.Errors)
                {
                    await _mediatorHandler.RaiseDomainNotificationAsync(
                        new DomainNotification(error.ErrorCode, error.CustomState.ToString(), error.ErrorMessage));
                }
                return Unit.Value;
            }

            var category = _categoryRepository.GetCategoryById(request.AggregateId);
            if (category == null)
            {
                return Unit.Value;
            }

            _categoryRepository.DeleteCategory(category);
            _categoryRepository.UnitOfWork.Commit();

            return Unit.Value;
        }
    }
}
