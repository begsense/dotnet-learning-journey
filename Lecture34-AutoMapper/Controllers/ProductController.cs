using AutoMapper;
using Lecture34_AutoMapper.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lecture34_AutoMapper.Requests;
using Lecture34_AutoMapper.Models;
using Lecture34_AutoMapper.Responses;

namespace Lecture34_AutoMapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Baza _baza;
        private readonly IMapper _mapper;

        public ProductController(Baza baza, IMapper mapper)
        {
            _baza = baza;
            _mapper = mapper;
        }

        [HttpPost("add-product")]
        public IActionResult AddProduct(CreateProductRequest request)
        {
            var product = _mapper.Map<Product>(request);

            _baza.Products.Add(product);
            _baza.SaveChanges();

            return Ok(product);
        }
        [HttpGet("get-all-product")]
        public IActionResult GetAddProduct()
        {
            var allProducts = _baza.Products.ToList();

            var productResponse = _mapper.Map<List<GetProduct>>(allProducts);


            return Ok(productResponse);
        }
    }
}
