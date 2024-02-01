using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebViewLeak;

public partial class Page2 : ContentPage
{
    public static int Instances = 0;
    
    public Page2()
    {
        InitializeComponent();
        Instances++;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        
        BackButton.Clicked += BackButtonOnClicked;
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        BackButton.Clicked -= BackButtonOnClicked;
    }

    private void BackButtonOnClicked(object? sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    ~Page2()
    {
        Instances--;
    }
}