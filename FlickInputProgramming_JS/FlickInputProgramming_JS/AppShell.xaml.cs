using FlickInputProgramming_JS.ViewModels;
using FlickInputProgramming_JS.Views;
using System;
using Xamarin.Forms;

namespace FlickInputProgramming_JS
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private void OnMenuItemClicked(object sender, EventArgs e)
        {
            ExercisesViewModel.Current.Reset();
        }
    }
}
