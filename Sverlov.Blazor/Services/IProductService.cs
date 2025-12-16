using Sverlov.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sverlov.Blazor.Services
{
    public interface IProductService
    {
        List<Automobile> Automobiles { get; }
        int CurrentPage { get; }
        int TotalPages { get; }
        event Action? ListChanged;

        Task GetProducts(int pageNo = 1, string? category = null);

        List<Automobile> Products { get; }
    }
}