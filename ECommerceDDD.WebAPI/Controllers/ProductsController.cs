﻿using ECommerceDDD.Application.Features.Products.CreateProduct;
using ECommerceDDD.Application.Features.Products.GetAllProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceDDD.WebAPI.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public ProductsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateProductCommand request, CancellationToken cancellationToken)
		{
			await _mediator.Send(request, cancellationToken);
			return NoContent();
		}

		[HttpPost]
		public async Task<IActionResult> GetAll(GetAllProductQuery request, CancellationToken cancellationToken)
		{
			var response = await _mediator.Send(request, cancellationToken);
			return Ok(response);
		}
	}
}
