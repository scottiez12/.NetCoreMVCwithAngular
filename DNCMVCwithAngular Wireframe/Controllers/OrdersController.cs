using AutoMapper;
using DNCMVCwithAngular_Wireframe.Data;
using DNCMVCwithAngular_Wireframe.Data.Entities;
using DNCMVCwithAngular_Wireframe.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNCMVCwithAngular_Wireframe.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrdersController : Controller
    {
        private readonly IProjectRepository _repository;
        private readonly ILogger<OrdersController> _logger;
        private readonly IMapper _mapper;

        public OrdersController(IProjectRepository repository, ILogger<OrdersController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(bool includeItems = true)
        {
            try
            {
                //var result = _repository.GetAllOrders();
                ////so by default, it's the incoming type, then the desination type.
                ////but if you're passing a parameter of the incoming type, you don't need to state it as a parameter in the Map<>()
                //return Ok(_mapper.Map<IEnumerable<OrderViewModel>>(result));              

                ////using api queries..
                //var results = _repository.GetAllOrders(includeItems);
                ////so by default, it's the incoming type, then the desination type.
                ////but if you're passing a parameter of the incoming type, you don't need to state it as a parameter in the Map<>()
                //return Ok(_mapper.Map<IEnumerable<OrderViewModel>>(results));

                var username = User.Identity.Name;
                var results = _repository.GetAllOrdersByUser(username, includeItems);

                return Ok(_mapper.Map<IEnumerable<Order>, IEnumerable<OrderViewModel>>(results));
                //var results = _repository.GetAllOrders(includeItems);
                //return Ok(_mapper.Map<IEnumerable<OrderViewModel>>(results));

                //now that we have the JWT all setup, we cna use identity in our operations.. 
                //remember that the entire class is decorated with the [Authorize]
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get orders: {ex}");
                return BadRequest("Failed to get orders.");

            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var order = _repository.GetOrderById(id);
                if (order!= null)
                {
                    return Ok(_mapper.Map<Order, OrderViewModel>(order));
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get orders: {ex}");
                return BadRequest("Failed to get orders.");

            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]OrderViewModel model)
        {
            //add it to db
            try
            {
                if (ModelState.IsValid)
                {
                    var newOrder = _mapper.Map<OrderViewModel, Order>(model);

                    if (newOrder.OrderDate == DateTime.MinValue)
                    {
                        newOrder.OrderDate = DateTime.Now;
                    }

                    _repository.AddEntity(newOrder);

                    if (_repository.SaveAll())
                    {
                        return Created($"/api/orders/{newOrder.Id}", _mapper.Map<Order, OrderViewModel>(newOrder));
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to save a new order: {ex}");
            }

            return BadRequest("Failed to save new order.");
        }

    }
}
