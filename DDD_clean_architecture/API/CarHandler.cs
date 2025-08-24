using Core.Entities;
using Core.Request;
using Core.Responses;
using Core.Uses_Cases;
using DDD_clean_architecture.Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DDD_clean_architecture.API;

[ApiController]
public class CarHandler(Context context): ICarHandle
{
    [HttpPost("/car")]
    public  async Task<JsonResponses<CarsFactory?>> PostHandler([FromBody]  CarDto request)
    {
        var car = new CarsFactory
        {
            CarModel = request.CarModel,
            Carcolor = request.Carcolor,
            CarPrice = request.CarPrice,
        };
        try
        {
            await context.AddAsync(car);
            return new JsonResponses<CarsFactory?>(null, 201, car);
        }
        catch (Exception e)
        {
            return new JsonResponses<CarsFactory?>(e.Message,400,null);
        }
        
        
    }
    
    [HttpPut("/car/{id}")]
    public async Task<JsonResponses<CarsFactory?>> UpdateHandler(
        [FromBody] CarDto request,
        [FromRoute] int id)
    {
        var car = await context.Cars.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (car == null)
        {
            return new JsonResponses<CarsFactory?>("Not Found", 404, null);

        }

        if (car.IsSold)
        {
            return new JsonResponses<CarsFactory?>("The Car Is Sold", 404, null);
        }

        car.Carcolor = "Empty";
        car.CarModel = "Empty";
        car.IsSold = request.sold;
        try
        {
            context.Update(car);
            await context.SaveChangesAsync();
            return new JsonResponses<CarsFactory?>(null, 200, car);
        }
        catch (Exception e)
        {
            return new JsonResponses<CarsFactory?>(e.Message, 500, null);
        }
    }
}