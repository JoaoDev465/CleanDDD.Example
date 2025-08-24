using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Core.Responses;
// class Created to standardize responses
public class JsonResponses<T>
{
    public string? Message { get; set; }
    public int Code { get; set; }
    public T? Data{ get; set; }
   
    [JsonConstructor]
    public JsonResponses(){}
    
    public JsonResponses(string message, int code, T? data = default)
    {
        Message = message;
        Code = code;
        Data = data;
    }

    [JsonIgnore] public bool IsSucess => Code is >= 200 and <= 299;
    public bool IsError => Code is >= 400 and <= 500;

}

