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
            #region Make Foods
            Food chips = new Food("Chips", "Paprika chips", "snack", 0.7m);
            Food steakWithMashPotatos = new Food("Steak", "Fat steak with mash potatos", "Main course", 4.1m);
            Food cola = new Food("Cola", "Refreshing ice cold cola", "Drink", 0.6m);
            Food veggieBurger = new Food("Vegie burger", "Burger for the vegetarians", "Main Course", 3.5m);
            Food soupWithMeatballs = new Food("Soup", "Soup with meatballs", "Starter", 2.0m);

            Food chocoMilk = new Food("Choco Milk", "Cold choco milk with whipped cream", "Drink", 0.50m);
            Food tiramisu = new Food("Tiramisu", "Lovely homemade tiramisu", "Dessert", 1.5m);
            Food chickenTikiMasala = new Food("Chicken Tiki Masala", "Spicy chicken with rice", "Main Course", 3.1m);
            Food doubleCheeseBurger = new Food("Double Cheese Burger", "2 delicious pigburgers and a lot of cheese", "Main Course", 2.6m);
            Food tomatoSoup = new Food("Tomato Soup", "Homemade tomato soup", "starter", 1.0m);

            Food snickers = new Food("Snickers", "You're not you when you're hungry", "Snack", 0.70m);
            Food fanta = new Food("Fanta Lemon", "Nice and cold fanta with lemon", "Drink", 0.6m);
            Food sprite = new Food("Sprite", "Sprite", "Drink", 0.6m);
            Food ribs = new Food("Ribs with honey", "Fresh ribs from our BBQ", "Main Course", 3.0m);
            Food tostis = new Food("Tosti's", "Hot sandwich made with ham and cheese", "Main Course", 2.0m);

            Food nuts = new Food("Nuts", "Mix of peanuts, almonds, pistachios, cashews, walnuts and hazelnuts", "Snack", 1.5m);
            Food apple = new Food("Apple", "Lovely green apple", "Snack", 0.4m);
            Food cake = new Food("Vanilla Cheese Cake", "Yummu cheese cake", "Dessert", 1.2m);
            Food appleJuice = new Food("Apple Juice", "Freshly squeezed apple", "Snack", 0.5m);
            Food whiskey = new Food("Whiskey", "Whiskey with a glass cola", "Drink", 2.1m);

            _dbContext.Foods.AddRange(new List<Food>() { chips, steakWithMashPotatos, cola, veggieBurger, soupWithMeatballs,
               chocoMilk, tiramisu, chickenTikiMasala, doubleCheeseBurger, tomatoSoup, snickers, fanta, sprite, ribs, tostis, nuts, apple, cake, appleJuice, whiskey});
            #endregion

            #region Make Orders
            /*Order mohamedsOrder = new Order();
            mohamedsOrder.AddOrder(new OrderFood(mohamedsOrder, steakWithMashPotatos));
            mohamedsOrder.AddOrder(new OrderFood(mohamedsOrder, chips));

            Order gabrielsOrder = new Order();
            gabrielsOrder.AddOrder(new OrderFood(gabrielsOrder, chips));
            gabrielsOrder.AddOrder(new OrderFood(gabrielsOrder, veggieBurger));

            Order victorsOrder = new Order();
            victorsOrder.AddOrder(new OrderFood(victorsOrder, soupWithMeatballs));

            Order noahsOrder = new Order();
            noahsOrder.AddOrder(new OrderFood(noahsOrder, steakWithMashPotatos));
            noahsOrder.AddOrder(new OrderFood(noahsOrder, chips));

            _dbContext.Orders.AddRange(new List<Order>() { mohamedsOrder, gabrielsOrder, victorsOrder, noahsOrder });*/
            #endregion

            #region Make Seats
            List<Seat> seatsForAirbusA333 = new List<Seat>();
            seatsForAirbusA333.AddRange(FillPlaneWithSeats(seatsForAirbusA333, 20));

            List<Seat> seatsForBoeing777 = new List<Seat>();
            seatsForBoeing777.AddRange(FillPlaneWithSeats(seatsForBoeing777, 25));

            List<Seat> seatsForDeltaL1011 = new List<Seat>();
            seatsForDeltaL1011.AddRange(FillPlaneWithSeats(seatsForDeltaL1011, 30));

            /*_dbContext.Seats.AddRange(seatsForAirbusA333);
            _dbContext.Seats.AddRange(seatsForBoeing777);
            _dbContext.Seats.AddRange(seatsForDeltaL1011);*/
            #endregion

            #region Make Planes
            Plane airbusA333 = new Plane("Airbus A333-300", 30)
            {
                Seats = seatsForAirbusA333
            };
            Plane boeing777 = new Plane("Boeing 777", 30)
            {
                Seats = seatsForBoeing777
            };
            Plane deltaL1011 = new Plane("Delta L-1011", 30)
            {
                Seats = seatsForDeltaL1011
            };

            #region Make Flights
            Flight flightBelgiumBulgaria = new Flight("Bulgaria", "Belgium", 2.5, new DateTime(2019, 10, 22, 8, 0, 0), airbusA333)
            {
                FlightId = "BG0800"
            };
            airbusA333.AddPlaneFlight(flightBelgiumBulgaria);

            Flight flightBrazilAntarctic = new Flight("Antarctic", "Brazil", 99, new DateTime(2019, 10, 23, 10, 0, 0), boeing777)
            {
                FlightId = "AT1000"
            };
            boeing777.AddPlaneFlight(flightBrazilAntarctic);

            Flight flightChinaUsa = new Flight("USA", "China", 0.1, new DateTime(2019, 10, 24, 9, 0, 0), deltaL1011)
            {
                FlightId = "US0900"
            };
            deltaL1011.AddPlaneFlight(flightChinaUsa);
            #endregion

            _dbContext.Planes.AddRange(new List<Plane>() { airbusA333, boeing777, deltaL1011 });
            #endregion

            #region Make Users
            Passenger arthur = new Passenger(airbusA333.Seats[0], "Arthur I");

            Passenger noah = new Passenger(airbusA333.Seats[2], "Noah");
            //noah.PlaceOrder(noahsOrder);

            Passenger adam = new Passenger(airbusA333.Seats[4], "Adam");

            Passenger louis = new Passenger(boeing777.Seats[0], "Louis");

            Passenger liam = new Passenger(boeing777.Seats[1], "Liam");

            Passenger lucas = new Passenger(boeing777.Seats[3], "Lucas");

            Passenger jules = new Passenger(boeing777.Seats[5], "Jules");

            Passenger victor = new Passenger(deltaL1011.Seats[10], "Victor");
            //victor.PlaceOrder(victorsOrder);

            Passenger gabriel = new Passenger(deltaL1011.Seats[8], "Gabriel");
            //gabriel.PlaceOrder(gabrielsOrder);

            Passenger mohamed = new Passenger(deltaL1011.Seats[15], "Mohamed");
            //mohamed.PlaceOrder(mohamedsOrder);

            Staff alihan = new Staff(1234, "Alihan");

            Staff dean = new Staff(5678, "Dean");

            Staff boike = new Staff(1111, "BOI'KE");

            _dbContext.FlightStaff.AddRange(new List<Staff>() { alihan, dean, boike });
            #endregion

            #region Make FlightPassengers (intermediate table)
            //Flight from Belgium to Bulgaria
            UserFlight arthurflightBelgiumBulgaria = new UserFlight(arthur, flightBelgiumBulgaria);
            UserFlight noahflightBelgiumBulgaria = new UserFlight(noah, flightBelgiumBulgaria);
            UserFlight adamflightBelgiumBulgaria = new UserFlight(adam, flightBelgiumBulgaria);
            //Flight from Brazil to Antarctic
            UserFlight louisflightBrazilAntarctic = new UserFlight(louis, flightBrazilAntarctic);
            UserFlight liamflightBrazilAntarctic = new UserFlight(liam, flightBrazilAntarctic);
            UserFlight lucasflightBrazilAntarctic = new UserFlight(lucas, flightBrazilAntarctic);
            UserFlight julesflightBrazilAntarctic = new UserFlight(jules, flightBrazilAntarctic);
            //Flight from China to USA
            UserFlight victorflightChinaUsa = new UserFlight(victor, flightChinaUsa);
            UserFlight gabrielflightChinaUsa = new UserFlight(gabriel, flightChinaUsa);
            UserFlight mohamedflightChinaUsa = new UserFlight(mohamed, flightChinaUsa);

            _dbContext.UserFlights.AddRange(new List<UserFlight>() { arthurflightBelgiumBulgaria, noahflightBelgiumBulgaria, adamflightBelgiumBulgaria,
                                louisflightBrazilAntarctic, liamflightBrazilAntarctic, lucasflightBrazilAntarctic, julesflightBrazilAntarctic, victorflightChinaUsa,
                                gabrielflightChinaUsa, mohamedflightChinaUsa});
            #endregion

            #region Fill flights with passengers
            flightBelgiumBulgaria.AddUserToFlight(arthurflightBelgiumBulgaria);
            flightBelgiumBulgaria.AddUserToFlight(noahflightBelgiumBulgaria);
            flightBelgiumBulgaria.AddUserToFlight(adamflightBelgiumBulgaria);

            flightBrazilAntarctic.AddUserToFlight(louisflightBrazilAntarctic);
            flightBrazilAntarctic.AddUserToFlight(liamflightBrazilAntarctic);
            flightBrazilAntarctic.AddUserToFlight(lucasflightBrazilAntarctic);
            flightBrazilAntarctic.AddUserToFlight(julesflightBrazilAntarctic);

            flightChinaUsa.AddUserToFlight(victorflightChinaUsa);
            flightChinaUsa.AddUserToFlight(gabrielflightChinaUsa);
            flightChinaUsa.AddUserToFlight(mohamedflightChinaUsa);
            #endregion

            #region Fill flights with staff
            flightBelgiumBulgaria.AddUserToFlight(new UserFlight(alihan, flightBelgiumBulgaria));

            flightBrazilAntarctic.AddUserToFlight(new UserFlight(dean, flightBrazilAntarctic));

            flightChinaUsa.AddUserToFlight(new UserFlight(boike, flightChinaUsa));

            _dbContext.Flights.AddRange(new List<Flight>() { flightBelgiumBulgaria, flightBrazilAntarctic, flightChinaUsa });
            #endregion

            #region Fill passengers flights
            arthur.AddFlight(arthurflightBelgiumBulgaria);

            noah.AddFlight(noahflightBelgiumBulgaria);

            adam.AddFlight(adamflightBelgiumBulgaria);

            louis.AddFlight(louisflightBrazilAntarctic);

            liam.AddFlight(liamflightBrazilAntarctic);

            lucas.AddFlight(lucasflightBrazilAntarctic);

            jules.AddFlight(julesflightBrazilAntarctic);

            victor.AddFlight(victorflightChinaUsa);

            gabriel.AddFlight(gabrielflightChinaUsa);

            mohamed.AddFlight(mohamedflightChinaUsa);

            _dbContext.Passengers.AddRange(new List<Passenger>() { arthur, noah, adam, louis, liam, lucas, jules, victor, gabriel, mohamed });
            #endregion

            _dbContext.SaveChanges();
        }

        private List<Seat> FillPlaneWithSeats(List<Seat> seats, int numberOfSeats)
        {
            Seat seat;
            string seatNumber = "";

            for (int i = 1; i <= numberOfSeats; i++)
            {
                if (i % 2 == 0)
                {
                    if (i <= 9)
                    {
                        seatNumber = "0" + i + "A";

                    }
                    else
                    {
                        seatNumber = i + "A";
                    }
                }
                else
                {
                    if (i <= 9)
                    {
                        seatNumber = "0" + i + "B";
                    }
                    else
                    {
                        seatNumber = i + "B";
                    }
                }

                seat = new Seat(seatNumber);

                seats.Add(seat);
            }

            return seats;
        }
    }
}
