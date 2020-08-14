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
        private readonly IOrderHistoryRepository _orderHistoryRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderController(IFoodRepository foodRepository, IPassengerRepository passengerRepository, IOrderHistoryRepository orderHistoryRepository, IOrderRepository orderRepository)
        {
            _foodRepository = foodRepository;
            _passengerRepository = passengerRepository;
            _orderHistoryRepository = orderHistoryRepository;
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

                OrderHistory orderHistory = new OrderHistory(newOrderLine)
                {
                    OrderId = order.OrderId,
                    PassengerId = passenger.UserId
                };

                _orderHistoryRepository.Add(orderHistory);
            }
 
            passenger.Orders.Add(order);

            _orderHistoryRepository.SaveChanges();
            _passengerRepository.SaveChanges();

            return Ok(order);
        }

        [HttpPost("orderHistory/{flightId}/{passengerSeat}")]
        public ActionResult<List<OrderHistory>> GetOrderHistory(string flightId, string passengerSeat)
        {
            Passenger passenger = _passengerRepository.GetByFlightIdAndSeatNumber(flightId, passengerSeat);

            if (passenger == null)
            {
                return NotFound("User not found");
            }

            return Ok(_orderHistoryRepository.GetUserOrderHistory(passenger.UserId).ToList());
        }

        [HttpPost("flightId/passengerSeat/{orderId}completeOrder")]
        public ActionResult CompleteOrder(int orderId)
        {
            _orderRepository.RemoveOrderById(orderId);

            _orderRepository.SaveChanges();

            return Ok("Order succesfully removed");
        }
    }
}