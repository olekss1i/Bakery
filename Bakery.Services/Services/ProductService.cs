using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bakery.Infrastructure.Models;
using Bakery.Infrastructure.Repositories;
using Bakery.Services.DTO;
using AutoMapper;

namespace Bakery.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _unitOfWork.Products.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            return product == null ? null : _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> CreateAsync(ProductCreateDto dto)
        {
            var product = _mapper.Map<Product>(dto);
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<bool> UpdateAsync(int id, ProductCreateDto dto)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null) return false;
            _mapper.Map(dto, product);
            _unitOfWork.Products.Update(product);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null) return false;
            _unitOfWork.Products.Delete(product);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
