using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using MyLife.Core.Models.ContentCreation;

namespace MyLife.Maui.Controls;

public partial class HorizontalPublicationsSection : VerticalStackLayout
{
    public static readonly BindableProperty ItemsProperty = BindableProperty.Create(nameof(Items),
        typeof(IEnumerable<AccountPublications>), typeof(HorizontalPublicationsSection), propertyChanged: OnItemsChanged);

    private static void OnItemsChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (HorizontalPublicationsSection)bindable;
        control.Items = (IEnumerable<AccountPublications>)newValue;
    }
    
    public IEnumerable<AccountPublications> Items
    {
        get => GetValue(ItemsProperty) as IEnumerable<AccountPublications> ?? [];
        set => SetValue(ItemsProperty, value);
    }

    public HorizontalPublicationsSection()
    {
        InitializeComponent();
    }
}