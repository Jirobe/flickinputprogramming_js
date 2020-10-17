using System.ComponentModel;
using Xamarin.Forms;
using FlickInputProgramming_JS.ViewModels;

namespace FlickInputProgramming_JS.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}