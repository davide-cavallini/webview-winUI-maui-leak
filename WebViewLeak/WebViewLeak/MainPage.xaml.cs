namespace WebViewLeak;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        
        Page2InstancesLabel.Text = $"Page2 instances: {Page2.Instances}";
        GcCollectButton.Clicked += GcCollectButtonOnClicked;
        NavigationButton.Clicked += NavigationButtonOnClicked;
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        
        GcCollectButton.Clicked -= GcCollectButtonOnClicked;
        NavigationButton.Clicked -= NavigationButtonOnClicked;
    }

    private void NavigationButtonOnClicked(object? sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(Page2));
    }

    private void GcCollectButtonOnClicked(object? sender, EventArgs e)
    {
        GC.Collect();
        GC.WaitForPendingFinalizers();
        GC.Collect();
        
        Page2InstancesLabel.Text = $"Page2 instances: {Page2.Instances}";
    }
}