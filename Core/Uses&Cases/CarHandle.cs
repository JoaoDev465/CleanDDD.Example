
using System.Threading.Tasks;
using Core.Entities;
using Core.Request;
using Core.Responses;
using Core.Uses_Cases;

// BuyCarHandle represent Uses&Cases flux, I guess about let how interface to flexibility my handler
// this step I'm implementing CQRS
namespace Core.Uses_Cases;

public interface ICarHandle
{
    Task<JsonResponses<CarsFactory?>> PostHandler(CarDto request);
  
    Task<JsonResponses<CarsFactory?>> UpdateHandler(CarDto request, int id);
    
}