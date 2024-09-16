namespace PascalBoard
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();


            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(VibrationPage), typeof(VibrationPage));
            Routing.RegisterRoute(nameof(ShakePage), typeof(ShakePage));


        }
    }
}
