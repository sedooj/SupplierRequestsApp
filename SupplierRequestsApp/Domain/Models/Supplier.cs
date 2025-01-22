﻿using SupplierRequestsApp.Data;

namespace SupplierRequestsApp.Domain.Models;

public class Supplier
{
    private Guid _id;
    private string _name;
    private string _address;
    private string _phone;
    private List<Product.Product> _products;

    public Supplier(Guid id, string name, string address, string phone, List<Product.Product> products)
    {
        _id = id;
        _name = name;
        _address = address;
        _phone = phone;
        _products = products;
    }

    public Guid Id
    {
        get => _id;
        set => _id = Validator.RequireGuid(value);
    }

    public string Name
    {
        get => _name;
        set => _name = Validator.RequireNotBlank(value);
    }

    public string Address
    {
        get => _address;
        set => _address = Validator.RequireNotBlank(value);
    }

    public string Phone
    {
        get => _phone;
        set => _phone = Validator.RequireNotBlank(value);
    }

    public List<Product.Product> Products
    {
        get => _products;
        set => _products = value;
    }
}