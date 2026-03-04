using DependencyInjection.Data;
using DependencyInjection.Responses;
using DependencyInjection.Requests;
using DependencyInjection.Services.Abstractions;
using DependencyInjection.Models;

namespace DependencyInjection.Services.Implementations;

public class FoodService : IFoodService
{
    private readonly Baza _baza;

    public FoodService(Baza baza)
    {
        _baza = baza;
    }

    public AddFoodResponse AddFood(AddFoodRequest food)
    {
        var newFood = new Food
        {
            Name = food.Name,
            Price = food.Price
        };

        _baza.Foods.Add(newFood);
        _baza.SaveChanges();

        return new AddFoodResponse { Id = newFood.Id };
    }
}
