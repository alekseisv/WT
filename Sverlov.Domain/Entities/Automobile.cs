using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sverlov.Domain.Entities;

public class Automobile
{
    public int Id { get; set; } // id авто
    public string Name { get; set; } // марка машины
    public string Description { get; set; } // описание машины
    public int LiftingCapacity { get; set; } // грузоподъмность
    public string? Image { get; set; } // путь к файлу изображения
                                       // Навигационные свойства

    public DateOnly parsedDate { get; set; }//Дата тех осмотра

   // string dateString = "12/10/2015";
   // DateTime parsedDate = DateTime.Parse(dateString);
  //  Console.WriteLine(parsedDate.DayOfWeek); // Example usage after parsing



    /// <summary>
    /// группа транспортных средств (например, легковые, грузовые и т.д.)
    /// </summary>
    public int TheTransportTypeId { get; set; }
    public TheTransportType? TheTransportType { get; set; }
}
