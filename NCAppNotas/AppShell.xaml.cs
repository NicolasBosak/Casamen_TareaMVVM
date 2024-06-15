namespace NCAppNotas
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Views.NCNotePage1), typeof(Views.NCNotePage1));
        }
    }
}
