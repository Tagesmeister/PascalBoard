namespace PascalBoard
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();

        }

        private async void OnSwipedLeft(object sender, SwipedEventArgs e)
        {
            await Shell.Current.GoToAsync("///VibrationPage");
        }




    }

}
