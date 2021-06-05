using System;

public class FruitEntity
{
    public Guid Id { get; set; }

    public FruitValueObject Fruit { get; set; }

    public MoneyValueObject Cost { get; set; }

}