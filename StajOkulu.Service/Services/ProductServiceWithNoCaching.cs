using StajOkulu.Core.Repositories;
using StajOkulu.Core.UnitOfWorks;
using StajOkulu.Core;
using StajOkulu.Core.DTOs;
using AutoMapper;
using StajOkulu.Core.Services;

namespace StajOkulu.Service.Services
{
    public class ProductServiceWithNoCaching : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductServiceWithNoCaching(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWitCategory()
        {
            var products = await _productRepository.GetProductsWitCategory();

            var productsDto = _mapper.Map<List<ProductWithCategoryDto>>(products);
            return CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, productsDto);

        }
    }
}
