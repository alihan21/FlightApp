using FlightApp.Backend.Data.Repositories.Interfaces;
using FlightApp.Backend.Models.Domain;
using FlightApp.Backend.Models.DTO_s;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FlightApp.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IPassengerRepository _passengerRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderController(IFoodRepository foodRepository, IPassengerRepository passengerRepository, IOrderRepository orderRepository)
        {
            _foodRepository = foodRepository;
            _passengerRepository = passengerRepository;
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public ActionResult<List<OrderDTO>> GetAll()
        {
            List<OrderDTO> allOrderDTOs = new List<OrderDTO>();
            var allOrders = _orderRepository.GetAll().ToList();

            foreach(Order order in allOrders)
            {
                OrderDTO orderDTO = new OrderDTO(order);
                allOrderDTOs.Add(orderDTO);
            }

            return allOrderDTOs;
        }

        [HttpGet("flights/{flightId}/orders/all")]
        public ActionResult<List<OrderDTO>> GetAllByFlightId(string flightId)
        {
            List<OrderDTO> allOrderDTOs = new List<OrderDTO>();
            var allOrders = _orderRepository.GetAll().ToList();

            foreach(Order o in allOrders)
            {
                var passenger = o.Passenger;

                if(passenger == null)
                {
                    return NotFound("Passenger not found");
                }

                var currentFlight = passenger.UserFlights.Last();

                if (currentFlight == null)
                {
                    return NotFound("Flight not found");
                }

                if(currentFlight.FlightId == flightId)
                {
                    allOrderDTOs.Add(new OrderDTO(o));
                }
            }

            return allOrderDTOs;
        }

        [HttpPost("{flightId}/{passengerSeat}/placeOrder")]
        public ActionResult<Order> PlaceOrder(string flightId, string passengerSeat, List<OrderLineDTO> orderLineDTOs)
        {
            Passenger passenger = _passengerRepository.GetByFlightIdAndSeatNumber(flightId, passengerSeat);

            if(passenger == null)
            {
                return NotFound("Passenger not found");
            }
            Order order = new Order()
            {
                Passenger = passenger
            };

            _orderRepository.AddNewOrder(order);
            _orderRepository.SaveChanges();

            order = _orderRepository.GetLastOrder();

            foreach(OrderLineDTO orderLineDTO in orderLineDTOs)
            {
                var food = _foodRepository.GetById(orderLineDTO.Food.FoodId);

                if(food == null)
                {
                    return NotFound("Food not found");
                }

                OrderLine newOrderLine = new OrderLine
                {
                    FoodId = food.FoodId,
                    Quantity = orderLineDTO.Quantity
                };

                order.AddOrderLine(newOrderLine);
            }
 
            passenger.Orders.Add(order);

            _passengerRepository.SaveChanges();

            return Ok(order);
        }

        [HttpGet("passengers/{passengerId}/orderHistory")]
        public ActionResult<List<OrderDTO>> GetOrderHistory(int passengerId)
        {
            List<OrderDTO> allOrderDTOs = new List<OrderDTO>();
            Passenger passenger = _passengerRepository.GetById(passengerId);

            if (passenger == null)
            {
                return NotFound("User not found");
            }

            var orders = _orderRepository.RetrieveAllOrdersByUserId(passenger.UserId).ToList();

            if(orders == null)
            {
                return NotFound("Orders not found");
            }

            foreach (Order order in orders)
            {
                OrderDTO orderDTO = new OrderDTO(order);
                allOrderDTOs.Add(orderDTO);
            }

            return Ok(allOrderDTOs);
        }

        [HttpPost("flightId/passengerSeat/orders/{orderId}/completeOrder")]
        public ActionResult CompleteOrder(int orderId)
        {
            var order = _orderRepository.GetById(orderId);

            if (order == null)
            {
                return NotFound("Order not found");
            }

            order.IsCompleted = true;

            _orderRepository.SaveChanges();

            return Ok("Order completed");
        }
    }
}