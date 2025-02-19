﻿using System.Diagnostics;
using SupplierRequestsApp.Presentation.Pages.Order;
using SupplierRequestsApp.Presentation.Pages.Product;
using SupplierRequestsApp.Presentation.Pages.Storage;
using SupplierRequestsApp.Presentation.Pages.Supplier;

namespace SupplierRequestsApp.Presentation.Pages;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnStoragesPageClicked(object sender, EventArgs e)
    {
        try
        {
            await Navigation.PushAsync(new StoragesPage());
        }
        catch (Exception exception)
        {
            Debug.WriteLine($"Can't open storages page. Caused by: {exception.Message}\n{exception.StackTrace}");
            await DisplayAlert("Произошла ошибка при попытке открыть страницу", exception.Message, "ОК");
        }
    }


    private async void OnOrdersPageClicked(object sender, EventArgs e)
    {
        try
        {
            await Navigation.PushAsync(new OrdersPage());
        }
        catch (Exception exception)
        {
            Debug.WriteLine($"Can't open orders page. Caused by: {exception.Message}\n{exception.StackTrace}");
            await DisplayAlert("Произошла ошибка при попытке открыть страницу", exception.Message, "ОК");
        }
    }

    private async void OnSupplierPageClicked(object? sender, EventArgs e)
    {
        try
        {
            await Navigation.PushAsync(new SuppliersPage());
        }
        catch (Exception exception)
        {
            Debug.WriteLine($"Can't open suppliers page. Caused by: {exception.Message}\n{exception.StackTrace}");
            await DisplayAlert("Произошла ошибка при попытке открыть страницу", exception.Message, "ОК");
        }
    }

    private async void OnProductPageClicked(object? sender, EventArgs e)
    {
        try
        {
            await Navigation.PushAsync(new ProductsPage());
        }
        catch (Exception exception)
        {
            Debug.WriteLine($"Can't open products page. Caused by: {exception.Message}\n{exception.StackTrace}");
            await DisplayAlert("Произошла ошибка при попытке открыть страницу", exception.Message, "ОК");
        }
    }
}