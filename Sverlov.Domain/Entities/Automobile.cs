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
    /// <summary>
    /// группа транспортных средств (например, легковые, грузовые и т.д.)
    /// </summary>
    public int TheTransportTypeId { get; set; }
    public TheTransportType? TheTransportType { get; set; }
}
