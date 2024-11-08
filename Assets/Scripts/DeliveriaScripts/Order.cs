using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum OrderType
{
    Hamburger,
    Pizza
}

public enum OrderStatus
{
    Open,
    Taken,
    Abandoned,
    Failed,
    Finished
}

public class TargetAddress
{
    public string Address;
    public Vector2 Position;
}

public class Restaurant
{
    public string Name;
    public string Address;
    public OrderType Type;
    public Image Image;
    public Vector2 Position;
    public List<OrderItem> Meals;
}

public class OrderItem
{
    public Image MealImage;
    public string MealName;
}

public class Order
{
    public List<OrderItem> Meals;
    public float RewardAmount;

    public TargetAddress Target;

    public Restaurant Restaurant;

    public OrderStatus Status;
}
