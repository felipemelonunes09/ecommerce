using System.Net;
using Catalog.Application.Commands;
using Catalog.Application.Queries;
using Catalog.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace Catalog.API.Controllers {
    public class CatalogController:ApiController {
        private readonly IMediator mediator;
        public CatalogController(IMediator mediator)
        {
            this.mediator = mediator;
        }   

        [HttpGet]
        [Route("[action]/{id}", Name="GetProductById")]
        [ProducesResponseType(typeof(ProductResponse), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        public async Task<ActionResult<ProductResponse>> GetProductById(string id) {
            var query = new GetProductByIdQuery(id);
            var result = await this.mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]/{name}", Name="GetProductByName")]
        [ProducesResponseType(typeof(ProductResponse), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        public async Task<ActionResult<ProductResponse>> GetProductByName(string name) {
            var query = new GetProductByNameQuery(name);
            var result = await this.mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllProducts")]
        [ProducesResponseType(typeof(IList<ProductResponse>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<IList<ProductResponse>>> GetAllProducts()
        {
            var query = new GetAllProductsQuery();
            var result = await this.mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllBrands")]
        [ProducesResponseType(typeof(IList<BrandResponse>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<IList<BrandResponse>>> GetAllBrands()
        {
            var query = new GetAllBrandsQuery();
            var result = await this.mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllTypes")]
        [ProducesResponseType(typeof(IList<TypesResponse>), (int) HttpStatusCode.OK)]
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        public async Task<ActionResult<IList<TypesResponse>>> GetAllTypes(string name) {
            var query = new GetProductByNameQuery(name);
            var result = await this.mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("[action]/{brand}", Name="GetProductByBrand")]
        [ProducesResponseType(typeof(IList<ProductResponse>), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<IList<ProductResponse>>> GetProductByBrand(string brand) {
            var query = new GetProductByBrandQuery(brand);
            var result = await this.mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        [Route("CreateProduct")]
        [ProducesResponseType(typeof(ProductResponse), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<ProductResponse>> CreateProduct([FromBody] CreateProductCommand command) {
            var result = await this.mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateProduct")]
        [ProducesResponseType(typeof(bool), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> UpdateProduct([FromBody] UpdateProductCommand command) {
            var result = await this.mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete]
        [Route("[id]", Name="DeleteProduct")]
        [ProducesResponseType(typeof(bool), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteProduct(string id) {
            var command = new DeleteProductByIdCommand(id);
            var result = await this.mediator.Send(command);
            return Ok(result);
        }
    }
}