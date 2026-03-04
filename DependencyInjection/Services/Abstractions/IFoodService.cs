using Microsoft.EntityFrameworkCore.Migrations.Operations;
using DependencyInjection.Requests;
using DependencyInjection.Responses;

namespace DependencyInjection.Services.Abstractions;

public interface IFoodService
{
    AddFoodResponse AddFood(AddFoodRequest request);
}
