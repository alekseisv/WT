using Sverlov.Domain.Entities;

namespace Sverlov.API.Data
{
    public static class DbInit
    {

        public static async Task SetupAsync(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            using var db = scope.ServiceProvider.GetService<AppDbContext>();


            await db.TheTransportTypes.AddRangeAsync([
                new TheTransportType {Name = "легковой автомобиль", NormalizedName = "car" },
                new TheTransportType { Name = "грузовой автомобиль", NormalizedName = "truck" },
                new TheTransportType {Name = "микро автобус", NormalizedName = "minibus" },
                new TheTransportType {Name = "мотоцикл", NormalizedName = "motorbike" }

                ]);
            await db.SaveChangesAsync();

            await db.Automobiles.AddRangeAsync(
                [new Automobile
                {
                    Id = 1,
                    Name = "MAZ",
                    Description = "Грузовой автомобиль",
                    LiftingCapacity = 20000,
                    Image = "https://localhost:7002/images/Maz.jfif",
                    parsedDate = new DateOnly(2015, 10, 12),
                    TheTransportTypeId = db.TheTransportTypes.First(c=>c.NormalizedName.Equals("truck"))!.Id,
                    TheTransportType = db.TheTransportTypes.First(c=>c.NormalizedName.Equals("truck"))
                },
                 new Automobile
                 {
                     Id = 2,
                     Name = "Автобус МАЗ",
                     Description = "Пассажирский автобус",
                     LiftingCapacity = 330,
                     Image = "https://localhost:7002/images/MiniMaz.jfif",
                     parsedDate = new DateOnly(2015, 10, 12),
                     TheTransportTypeId = db.TheTransportTypes.First(c=>c.NormalizedName.Equals("minibus"))!.Id,
                     TheTransportType = db.TheTransportTypes.First(c=>c.NormalizedName.Equals("minibus"))
                 },
                 new Automobile
                 {
                     Id = 3,
                     Name = "Mercedes",
                     Description = "Легковой автомобиль",
                     LiftingCapacity = 500,
                     Image = "https://localhost:7002/images/Mersedes.jfif",
                     parsedDate = new DateOnly(2015, 10, 12),
                     TheTransportTypeId = db.TheTransportTypes.First(c=>c.NormalizedName.Equals("car"))!.Id,
                     TheTransportType = db.TheTransportTypes.First(c=>c.NormalizedName.Equals("car"))
                 },
                 new Automobile
                 {
                     Id = 4,
                     Name = "Мотоцикл",
                     Description = "Вааще что-то новенькое!!!",
                     LiftingCapacity = 100,
                     Image = "https://localhost:7002/images/Motobike.jfif",
                     parsedDate = new DateOnly(2015, 10, 12),
                     TheTransportTypeId = db.TheTransportTypes.First(c=>c.NormalizedName.Equals("motorbike"))!.Id,
                     TheTransportType = db.TheTransportTypes.First(c=>c.NormalizedName.Equals("motorbike"))
                 },
                 new Automobile
                 {
                     Id = 5,
                     Name = "Volvo",
                     Description = "Грузовой автомобиль",
                     LiftingCapacity = 25000,
                     Image = "https://localhost:7002/images/Volvo.jfif",
                     parsedDate = new DateOnly(2015, 10, 12),
                     TheTransportTypeId = db.TheTransportTypes.First(c=>c.NormalizedName.Equals("truck"))!.Id,
                     TheTransportType = db.TheTransportTypes.First(c=>c.NormalizedName.Equals("truck"))
                 },
                 new Automobile
                 {
                     Id = 6,
                     Name = "BMW",
                     Description = "Легковой автомобиль",
                     LiftingCapacity = 300,
                     Image = "https://localhost:7002/images/BMW.jfif",
                     parsedDate = new DateOnly(2015, 10, 12),
                     TheTransportTypeId = db.TheTransportTypes.First(c=>c.NormalizedName.Equals("car"))!.Id,
                     TheTransportType = db.TheTransportTypes.First(c=>c.NormalizedName.Equals("car"))
                 }

                ]);

            await db.SaveChangesAsync();
        }
    }
}
