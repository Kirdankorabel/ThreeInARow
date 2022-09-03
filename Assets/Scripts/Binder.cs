using System;
using System.ComponentModel;
using System.Reflection;

class Binder
{
    private readonly object _ui;
    private readonly object _data;
    private readonly string _uiPropName;
    private readonly string _dataPropName;
    private readonly Type _uiType;
    private readonly Type _dataType;

    public Binder(object ui, string uiPropName, object data, string datrPropName)
    {
        _ui = ui;
        _data = data;
        _uiPropName = uiPropName;
        _dataPropName = datrPropName;
        _uiType = ui.GetType();
        _dataType = data.GetType();

        var eventInfo = _dataType.GetEvent("PropertyChanged");
        eventInfo.AddEventHandler(_data, new PropertyChangedEventHandler(Update));
    }

    private void Update(object sender, PropertyChangedEventArgs args)
    {
        if (args.PropertyName != _uiPropName)
            return;
        var value = _dataType.InvokeMember(_dataPropName, BindingFlags.GetProperty, null, _data, null);
        _uiType.InvokeMember(_uiPropName, BindingFlags.SetProperty, null, _ui, new object[] { value });
    }
}
