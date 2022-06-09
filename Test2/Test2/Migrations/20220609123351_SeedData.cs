using Microsoft.EntityFrameworkCore.Migrations;

namespace Test2.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Planes(IdPlane, Name, MaxSeats) VALUES(1, 'Plane', 13)");

            migrationBuilder.Sql("INSERT INTO CityDicts(IdCityDict, City) VALUES(1, 'Radom')");

            migrationBuilder.Sql("INSERT INTO Passengers(IdPassanger, FirstName, LastName, PassportNum) VALUES(1, 'John', 'Doe', 123)");

            migrationBuilder.Sql("INSERT INTO Flights(IdFlight, FlightDate, Comments, IdPlane, IdCityDict) VALUES(1, GETDATE(), 'hmmyes', 1,1)");

            migrationBuilder.Sql("INSERT INTO FlightPassangers(IdFlight, IdPassanger) VALUES(1, 1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM FlightPassangers");

            migrationBuilder.Sql("DELETE FROM Flights WHERE IdFireTruckAction = 1");

            migrationBuilder.Sql("DELETE FROM Passengers WHERE IdFireTruckAction = 1");

            migrationBuilder.Sql("DELETE FROM CityDicts WHERE IdFireTruckAction = 1");

            migrationBuilder.Sql("DELETE FROM Planes WHERE IdFireTruckAction = 1");
        }
    }
}
