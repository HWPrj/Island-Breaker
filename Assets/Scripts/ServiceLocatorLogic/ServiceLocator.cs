using System;
using System.Collections.Generic;

public class ServiceLocator<T> : IServiceLocator<T>
{
    protected Dictionary<Type, T> _itemsMap { get; }
    public ServiceLocator()
    {
        _itemsMap = new Dictionary<Type, T>();
    }
    public TP Register<TP>(TP newService) where TP : T
    {
        var type = typeof(TP);
        if (_itemsMap.ContainsKey(type))
        {
            throw new Exception($"Cannot add item of type {type} Type alredy registred");
        }
        _itemsMap[type] = newService;
        return newService;
    }
    public void Unregister<TP>(TP newService) where TP : T
    {
        var type = newService.GetType();
        if (_itemsMap.ContainsKey(type))
        {
            _itemsMap.Remove(type);
        }
    }
    public TP Get<TP>() where TP : T
    {
        var type = typeof(TP);
        if (!_itemsMap.ContainsKey(type))
        {
            throw new Exception($"Type of type: {type} did not registred");
        }
        return (TP)_itemsMap[type];
    }
}