using MediatR;
using RestAPI.Domain.Commands.ProductCommands;
using RestAPI.Domain.Interfaces;
using RestAPI.Domain.MediatorHandler;
using RestAPI.Domain.Notifications;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestAPI.Domain.CommandHandlers
{
    public class ProductCommandHandler :
        IRequestHandler<AddProductCommand, Unit>,
        IRequestHandler<UpdateProductCommand, Unit>,
        IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IProductRepository _productRepository;

        public ProductCommandHandler(IProductRepository productRepository, IMediatorHandler mediatorHandler)
        {
            _productRepository = productRepository;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
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

            if (_productRepository.Query().Where(product => product.Name == request.Product.Name).Any())
            {
                await _mediatorHandler.RaiseDomainNotificationAsync(
                    new DomainNotification("DuplicatedValue", "Name duplicated", "The field 'Name' must be unique"));
                return Unit.Value;
            }

            request.Product.CreatedAt = DateTime.UtcNow;
            _productRepository.AddProduct(request.Product);
            _productRepository.UnitOfWork.Commit();

            return Unit.Value;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
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

            var product = _productRepository.GetProductById(request.AggregateId);
            if (product == null)
            {
                await _mediatorHandler.RaiseDomainNotificationAsync(
                    new DomainNotification("NotFound", "Product not found", "The informed 'Product' was not found"));
                return Unit.Value;
            }

            if (_productRepository.Query().Where(p => p.Id != request.AggregateId
                                                   && p.Name == request.Product.Name).Any())
            {
                await _mediatorHandler.RaiseDomainNotificationAsync(
                    new DomainNotification("DuplicatedValue", "Name duplicated", "The field 'Name' must be unique"));
                return Unit.Value;
            }

            product.Name = request.Product.Name;
            product.Description = request.Product.Description;
            product.Image = request.Product.Image;
            product.QuantityAvailable = request.Product.QuantityAvailable;
            product.IsActive = request.Product.IsActive;
            product.UnitOfMeasurement = request.Product.UnitOfMeasurement;
            product.Currency = request.Product.Currency;
            product.CategoryId = request.Product.CategoryId;

            _productRepository.UpdateProduct(product);
            _productRepository.UnitOfWork.Commit();

            return Unit.Value;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
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

            var product = _productRepository.GetProductById(request.AggregateId);
            if (product == null)
            {
                return Unit.Value;
            }

            _productRepository.DeleteProduct(product);
            _productRepository.UnitOfWork.Commit();

            return Unit.Value;
        }
    }
}
