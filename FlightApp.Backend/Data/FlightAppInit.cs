using FlightApp.Backend.Models.Domain;
using System;
using System.Collections.Generic;

namespace FlightApp.Backend.Data
{
    public class FlightAppInit
    {
        private readonly ApplicationDbContext _dbContext;

        public FlightAppInit(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Init()
        {
            _dbContext.Database.EnsureDeleted();
            if (_dbContext.Database.EnsureCreated())
            {
                #region Make Foods
                Food chips = new Food() { Name = "Chips", Type = "snack", Description = "paprika chips" };
                Food steakWithMashPotatos = new Food() { Name = "Steak", Type = "meal", Description = "fat steak with mash potatos" };
                Food cola = new Food() { Name = "Cola", Type = "drink", Description = "refreshing ice cold cola" };
                Food veggieBurger = new Food() { Name = "Vegie burger", Type = "meal", Description = "burger for the vegetarians" };
                Food soupWithMeatballs = new Food() { Name = "Soup", Type = "starter", Description = "soup with meatballs" };

                _dbContext.Foods.AddRange(new List<Food>() { chips, steakWithMashPotatos, cola, veggieBurger, soupWithMeatballs });
                #endregion

                #region Make Orders
                Order mohamedsOrder = new Order();
                mohamedsOrder.OrderFoods.Add(new OrderFood() { Food = steakWithMashPotatos, FoodId = steakWithMashPotatos.FoodId, Order = mohamedsOrder, OrderId = mohamedsOrder.OrderId });
                mohamedsOrder.OrderFoods.Add(new OrderFood() { Food = chips, FoodId = chips.FoodId, Order = mohamedsOrder, OrderId = mohamedsOrder.OrderId });
                Order gabrielsOrder = new Order();
                gabrielsOrder.OrderFoods.Add(new OrderFood() { Food = chips, FoodId = chips.FoodId, Order = gabrielsOrder, OrderId = gabrielsOrder.OrderId });
                gabrielsOrder.OrderFoods.Add(new OrderFood() { Food = veggieBurger, FoodId = veggieBurger.FoodId, Order = gabrielsOrder, OrderId = gabrielsOrder.OrderId });
                Order victorsOrder = new Order();
                victorsOrder.OrderFoods.Add(new OrderFood() { Food = soupWithMeatballs, FoodId = soupWithMeatballs.FoodId, Order = victorsOrder, OrderId = victorsOrder.OrderId });
                Order noahsOrder = new Order();
                noahsOrder.OrderFoods.Add(new OrderFood() { Food = steakWithMashPotatos, FoodId = steakWithMashPotatos.FoodId, Order = noahsOrder, OrderId = noahsOrder.OrderId });
                noahsOrder.OrderFoods.Add(new OrderFood() { Food = chips, FoodId = chips.FoodId, Order = noahsOrder, OrderId = noahsOrder.OrderId });

                _dbContext.Orders.AddRange(new List<Order>() { mohamedsOrder, gabrielsOrder, victorsOrder, noahsOrder });
                #endregion

                #region Make Seats
                List<Seat> seatsForAirbusA333 = new List<Seat>();
                seatsForAirbusA333.AddRange(FillPlaneWithSeats(seatsForAirbusA333, 20));
                List<Seat> seatsForBoeing777 = new List<Seat>();
                seatsForBoeing777.AddRange(FillPlaneWithSeats(seatsForBoeing777, 25));
                List<Seat> seatsForDeltaL1011 = new List<Seat>();
                seatsForDeltaL1011.AddRange(FillPlaneWithSeats(seatsForDeltaL1011, 30));

                _dbContext.Seats.AddRange(seatsForAirbusA333);
                _dbContext.Seats.AddRange(seatsForBoeing777);
                _dbContext.Seats.AddRange(seatsForDeltaL1011);
                #endregion

                #region Make Flights
                Flight flightBelgiumBulgaria = new Flight()
                {
                    Destination = "Bulgaria",
                    FlightDuration = 2.5,
                    Origin = "Belgium",
                    TimeOfDepart = new DateTime(2019, 10, 22, 8, 0, 0)
                };
                Flight flightBrazilAntarctic = new Flight()
                {
                    Destination = "Antarctic",
                    FlightDuration = 99,
                    Origin = "Brazil",
                    TimeOfDepart = new DateTime(2019, 10, 23, 10, 0, 0)
                };

                Flight flightChinaUsa = new Flight()
                {
                    Destination = "USA",
                    FlightDuration = 0.1,
                    Origin = "China",
                    TimeOfDepart = new DateTime(2019, 10, 24, 9, 0, 0)
                };
                #endregion

                #region Make Planes
                Plane airbusA333 = new Plane() { Name = "Airbus A333-300", MaxSeats = 30, Seats = seatsForAirbusA333,
                    PlaneFlights = new List<Flight>() { flightBelgiumBulgaria } };
                Plane boeing777 = new Plane() { Name = "Boeing 777", MaxSeats = 30, Seats = seatsForBoeing777,
                    PlaneFlights = new List<Flight>() { flightBrazilAntarctic } };
                Plane deltaL1011 = new Plane() { Name = "Delta L-1011", MaxSeats = 30, Seats = seatsForDeltaL1011,
                    PlaneFlights = new List<Flight>() { flightChinaUsa } };

                _dbContext.Planes.AddRange(new List<Plane>() { airbusA333, boeing777, deltaL1011 });
                #endregion

                #region Make Users
                Passenger arthur = new Passenger() { Name = "Arthur I", Seat = airbusA333.Seats[0] };

                Passenger noah = new Passenger() { Name = "Noah", Seat = airbusA333.Seats[2], Orders = new List<Order>() { noahsOrder } };

                Passenger adam = new Passenger() { Name = "Adam", Seat = airbusA333.Seats[4] };

                Passenger louis = new Passenger() { Name = "Louis", Seat = boeing777.Seats[0] };

                Passenger liam = new Passenger() { Name = "Liam", Seat = boeing777.Seats[1] };

                Passenger lucas = new Passenger() { Name = "Lucas", Seat = boeing777.Seats[3] };

                Passenger jules = new Passenger() { Name = "Jules", Seat = boeing777.Seats[5] };

                Passenger victor = new Passenger() { Name = "Victor", Seat = deltaL1011.Seats[10], Orders = new List<Order>() { victorsOrder } };

                Passenger gabriel = new Passenger() { Name = "Gabriel", Seat = deltaL1011.Seats[8], Orders = new List<Order>() { gabrielsOrder } };

                Passenger mohamed = new Passenger() { Name = "Mohamed", Seat = deltaL1011.Seats[15], Orders = new List<Order>() { mohamedsOrder } };

                Staff alihan = new Staff() { Name = "Alihan", LoginCode = 1234 };

                Staff dean = new Staff() { Name = "Dean", LoginCode = 5678 };

                Staff boike = new Staff() { Name = "BOI'KE", LoginCode = 1111 };

                _dbContext.FlightStaff.AddRange(new List<Staff>() { alihan, dean, boike });
                #endregion

                #region Make FlightPassengers (intermediate table)
                //Flight from Belgium to Bulgaria
                PassengerFlight arthurflightBelgiumBulgaria = FillPassengerInAFlight(arthur, flightBelgiumBulgaria);
                PassengerFlight noahflightBelgiumBulgaria = FillPassengerInAFlight(noah, flightBelgiumBulgaria);
                PassengerFlight adamflightBelgiumBulgaria = FillPassengerInAFlight(adam, flightBelgiumBulgaria);
                //Flight from Brazil to Antarctic
                PassengerFlight louisflightBrazilAntarctic = FillPassengerInAFlight(louis, flightBrazilAntarctic);
                PassengerFlight liamflightBrazilAntarctic = FillPassengerInAFlight(liam, flightBrazilAntarctic);
                PassengerFlight lucasflightBrazilAntarctic = FillPassengerInAFlight(lucas, flightBrazilAntarctic);
                PassengerFlight julesflightBrazilAntarctic = FillPassengerInAFlight(jules, flightBrazilAntarctic);
                //Flight from China to USA
                PassengerFlight victorflightChinaUsa = FillPassengerInAFlight(victor, flightChinaUsa);
                PassengerFlight gabrielflightChinaUsa = FillPassengerInAFlight(gabriel, flightChinaUsa);
                PassengerFlight mohamedflightChinaUsa = FillPassengerInAFlight(mohamed, flightChinaUsa);

                _dbContext.PassengerFlights.AddRange(new List<PassengerFlight>() { arthurflightBelgiumBulgaria, noahflightBelgiumBulgaria, adamflightBelgiumBulgaria,
                        louisflightBrazilAntarctic, liamflightBrazilAntarctic, lucasflightBrazilAntarctic, julesflightBrazilAntarctic, victorflightChinaUsa,
                        gabrielflightChinaUsa, mohamedflightChinaUsa});
                #endregion

                #region Give passenger their seat
                arthur.Seat = seatsForAirbusA333[0];
                noah.Seat = seatsForAirbusA333[2];
                adam.Seat = seatsForAirbusA333[4];
                louis.Seat = seatsForBoeing777[0];
                liam.Seat = seatsForBoeing777[1];
                lucas.Seat = seatsForBoeing777[3];
                jules.Seat = seatsForBoeing777[5];
                victor.Seat = seatsForDeltaL1011[10];
                gabriel.Seat = seatsForDeltaL1011[8];
                mohamed.Seat = seatsForDeltaL1011[15];
                #endregion

                #region Fill flights with passengers
                flightBelgiumBulgaria.Passengers = new List<PassengerFlight>() { arthurflightBelgiumBulgaria, noahflightBelgiumBulgaria, adamflightBelgiumBulgaria };
                flightBrazilAntarctic.Passengers = new List<PassengerFlight>() { louisflightBrazilAntarctic, liamflightBrazilAntarctic, lucasflightBrazilAntarctic, julesflightBrazilAntarctic };
                flightChinaUsa.Passengers = new List<PassengerFlight>() { victorflightChinaUsa, gabrielflightChinaUsa, mohamedflightChinaUsa };
                #endregion

                #region Fill flights with staff
                flightBelgiumBulgaria.FlightStaff = new List<StaffFlight>() { new StaffFlight {Flight = flightBelgiumBulgaria, FlightId = flightBelgiumBulgaria.FlightId, Staff = alihan, StaffId = alihan.UserId } };
                flightBrazilAntarctic.FlightStaff = new List<StaffFlight>() { new StaffFlight { Flight = flightBrazilAntarctic, FlightId = flightBrazilAntarctic.FlightId, Staff = dean, StaffId = dean.UserId } };
                flightChinaUsa.FlightStaff = new List<StaffFlight>() { new StaffFlight { Flight = flightChinaUsa, FlightId = flightChinaUsa.FlightId, Staff = boike, StaffId = boike.UserId } };

                _dbContext.Flights.AddRange(new List<Flight>() { flightBelgiumBulgaria, flightBrazilAntarctic, flightChinaUsa });
                #endregion

                #region Fill passengers flights
                arthur.PassengerFlights = new List<PassengerFlight>() { arthurflightBelgiumBulgaria};
                noah.PassengerFlights = new List<PassengerFlight>() { noahflightBelgiumBulgaria};
                adam.PassengerFlights = new List<PassengerFlight>() { adamflightBelgiumBulgaria};
                louis.PassengerFlights = new List<PassengerFlight>() { louisflightBrazilAntarctic};
                liam.PassengerFlights = new List<PassengerFlight>() { liamflightBrazilAntarctic};
                lucas.PassengerFlights = new List<PassengerFlight>() { lucasflightBrazilAntarctic};
                jules.PassengerFlights = new List<PassengerFlight>() { julesflightBrazilAntarctic};
                victor.PassengerFlights = new List<PassengerFlight>() { victorflightChinaUsa};
                gabriel.PassengerFlights = new List<PassengerFlight>() { gabrielflightChinaUsa};
                mohamed.PassengerFlights = new List<PassengerFlight>() { mohamedflightChinaUsa};

                _dbContext.Passengers.AddRange(new List<Passenger>() { arthur, noah, adam, louis, liam, lucas, jules, victor, gabriel, mohamed});
                #endregion
            }

            _dbContext.SaveChanges();
        }

        private List<Seat> FillPlaneWithSeats(List<Seat> seats, int numberOfSeats)
        {
            for (int i = 1; i <= numberOfSeats; i++)
            {
                Seat seat = new Seat();

                if (i % 2 == 0)
                {
                    if (i <= 9)
                    {
                        seat.Seatnumber = "0" + i + "A";
                    }
                    else
                    {
                        seat.Seatnumber = i + "A";
                    }
                }
                else
                {
                    if (i <= 9)
                    {
                        seat.Seatnumber = "0" + i + "B";
                    }
                    else
                    {
                        seat.Seatnumber = i + "B";
                    }
                }


                seats.Add(seat);
            }

            return seats;
        }
        private PassengerFlight FillPassengerInAFlight(Passenger passenger, Flight flight)
        {
            return new PassengerFlight() {
                Flight = flight,
                FlightId = flight.FlightId,
                Passenger = passenger,
                PassengerId = passenger.UserId
            };
        }
    }
}
