using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

// this class represent the rich domain, that has entities and business rules.
public class CarStorage
{
    // here we have the car itens representation.
    public int Id{ get; private set; }
    public string CarModel { get; private set; } = string.Empty;
    public decimal CarPrice { get; private set; }
    public string Carcolor { get; private set; } = string.Empty;
    public bool IsSold { get; private set; }

    public CarStorage(string carmodel, decimal carprice, string carcolor, bool issold)
    {
        Carcolor = carcolor;
        CarModel = carmodel;
        CarPrice = carprice;
        IsSold = false;
        Sold();
        DisposibleCarColors();
        CarModelType();
        CarPriceValuation();
    }

    public void Sold()
    {
        if (IsSold)
            throw new Exception("The car is Alredy sold");
        IsSold = true;

    }

    public void DisposibleCarColors()
    {
        if (string.IsNullOrEmpty(Carcolor))
            throw new Exception("The Car Color can't null or empty");
    }

    public void CarModelType()
    {
        if (string.IsNullOrEmpty(CarModel))
            throw new("The car model can't null or empty");
    }

    public void CarPriceValuation()
    {
        if (CarPrice <= 5000)
            throw new Exception("Car price is very low");
    }
    
}