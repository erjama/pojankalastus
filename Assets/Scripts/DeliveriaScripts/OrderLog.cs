using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class OrderLog : MonoBehaviour
{
    public List<Order> Orders;

    public float CustomerOrderTimer = 30.0f;
    private float OriginalCustomerOrderTimer;

    List<Restaurant> restaurants;
    List<TargetAddress> targets;

    public TMP_Text orderLogText;

    public int MaxOrders = 5;

    void Start()
    {
        OriginalCustomerOrderTimer = CustomerOrderTimer;
        Orders = new List<Order>();
        restaurants = CreateRestaurants();
        targets = CreateTargets();
    }

    void Update()
    {
        CustomerOrderTimer -= Time.deltaTime;

        if (CustomerOrderTimer <= 0)
        {
            if (Orders.Count < MaxOrders)
            {
                AddOrder(GetRandomOrder());
            }
            CustomerOrderTimer = OriginalCustomerOrderTimer;
        }
    }

    private List<TargetAddress> CreateTargets()
    {
        var targets = new List<TargetAddress>();

        //First target address
        var targetAddress = new TargetAddress();
        targetAddress.Address = "Viljelijäntie 24 C A";
        targetAddress.Position = new Vector2(10, 10);
        targets.Add(targetAddress);

        //Second target address
        targetAddress = new TargetAddress();
        targetAddress.Address = "Kieronkatu 5";
        targetAddress.Position = new Vector2(20, 120);
        targets.Add(targetAddress);

        return targets;
    }

    private List<Restaurant> CreateRestaurants()
    {
        var restaurants = new List<Restaurant>();

        //First restaurant 
        var restaurant = new Restaurant();
        restaurant.Address = "Nakkikatu 66B";
        restaurant.Position = new Vector2(2, 2);
        restaurant.Name = "Nippe's Pizza";
        restaurants.Add(restaurant);

        //Second restaurant
        restaurant = new Restaurant();
        restaurant.Address = "Söpölä 55 Z";
        restaurant.Position = new Vector2(44, 2);
        restaurant.Name = "Mokis's Burger";
        restaurants.Add(restaurant);

        return restaurants;
    }

    private Order GetRandomOrder()
    {
        var order = new Order();
        order.Status = OrderStatus.Open;
        order.RewardAmount = GetRandomReward();
        order.Target = GetRandomTargetAddress();
        order.Restaurant = GetRandomRestaurant();
        order.Meals = new List<OrderItem>();
        return order;
    }

    private float GetRandomReward()
    {
        const float minReward = 1f;
        const float maxReward = 100f;
        float randomFloat = UnityEngine.Random.Range(minReward, maxReward);
        float roundedFloat = Mathf.Floor(randomFloat * 2) / 2f; //only halfs, for example 1.0, 1.5, 2.0, 3.5, 55.5, 100.0
        return roundedFloat;
    }

    private TargetAddress GetRandomTargetAddress()
    {
        return targets[UnityEngine.Random.Range(0, targets.Count)];
    }

    private Restaurant GetRandomRestaurant()
    {
        return restaurants[UnityEngine.Random.Range(0, restaurants.Count)];
    }

    public void AddOrder(Order order)
    {
        Orders.Add(order);
        var sb = new StringBuilder();
        foreach (Order temp in Orders)
        {
            sb.Append(temp.Target.Address + "(" + temp.Target.Position.x + "," + temp.Target.Position.y + ")" + Environment.NewLine);
        }
        orderLogText.SetText(sb.ToString());
    }

}
