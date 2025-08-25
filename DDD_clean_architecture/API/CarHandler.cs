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
    public  async Task<JsonResponses<CarStorage?>> PostHandler([FromBody]  CarDto request)
    {
        var car = new CarStorage(request.CarModel, request.CarPrice, request.Carcolor, request.sold);
        try
        {
            await context.AddAsync(car);
            return new JsonResponses<CarStorage?>(null, 201, car);
        }
        catch (Exception e)
        {
            return new JsonResponses<CarStorage?>(e.Message,400,null);
        }
        
        
    }
    
    [HttpPut("/car/{id}")]
    public async Task<JsonResponses<CarStorage?>> UpdateHandler(
        [FromBody] CarDto request,
        [FromRoute] int id)
    {
        var car = await context.Cars.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (car == null)
        {
            return new JsonResponses<CarStorage?>("Not Found", 404, null);

        }

        if (car.IsSold)
        {
            return new JsonResponses<CarStorage?>("The Car Is Sold", 404, null);
        }
        
        try
        {
            context.Update(car);
            await context.SaveChangesAsync();
            return new JsonResponses<CarStorage?>(null, 200, car);
        }
        catch (Exception e)
        {
            return new JsonResponses<CarStorage?>(e.Message, 500, null);
        }
    }
}