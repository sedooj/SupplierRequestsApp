using SupplierRequestsApp.Domain.Models;
using SupplierRequestsApp.Domain.Service;
using SupplierRequestsApp.Util;

namespace SupplierRequestsApp.Data.Service;

public class LocalDeliveryService : IDeliveryService
{

    private readonly IStorage<Order> _orderService = new LocalStorageService<Order>();
    private readonly IStorage<Product> _productService = new LocalStorageService<Product>();
    private readonly IStorage<Shelf> _shelfService = new LocalStorageService<Shelf>();

    public void PayOrder(Order order)
    {
        order.PayStatus = PayStatus.Paid;
        DeliverOrder(order);
    }

    private void DeliverOrder(Order order)
    {
        order.DeliveryStatus = DeliveryStatus.Delivered;
        UpdateOrder(order);
    }
    
    public void RefundOrder(Order order)
    {
        order.PayStatus = PayStatus.Refund;
        order.DeliveryStatus = DeliveryStatus.Refund;
        UpdateOrder(order);
    }

    public void ReceiveOrder(Order order)
    {
        DeliverProductsToStorages(order);
        order.DeliveryStatus = DeliveryStatus.Received;
        UpdateOrder(order);
    }

    private void UpdateOrder(Order order)
    {
        _orderService.UpdateEntity(order);
    }

    private void DeliverProductsToStorages(Order order)
    {
        foreach (var orderItem in order.OrderProducts)
        {
            var shelf = _shelfService.LoadEntity(orderItem.Product.ShelfId.ToString());
            if (!shelf!.CanStore(orderItem.Quantity)) throw new NoFreeSpaceForItemException("Нет места на полке.");
            for (var i = 0; i < orderItem.Quantity; i++)
            {
                shelf.StoreProduct(orderItem.Product.Id);
            }
            _shelfService.UpdateEntity(shelf);
        }
    }
}