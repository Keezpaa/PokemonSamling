using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.UI.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using PokemonSamling.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace PokemonSamling.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PokemonPage : Page
    {
        public PokemonPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.PropertyChanged += ViewModel_PropertyChanged;

            base.OnNavigatedTo(e);
        }
        public ICommand NewCommand => new AsyncRelayCommand(OpenNewDialog);
        public ICommand EditCommand => new AsyncRelayCommand(OpenEditDialog);
        private ICommand AddCommand => new RelayCommand(Add);
        private ICommand UpdateCommand => new RelayCommand(Update);

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "Current" && ViewModel.HasCurrent)
            {
                PokemonListView.ScrollIntoView(ViewModel.Current);
            }
        }

        private void ListViewItem_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            if(e.Pointer.PointerDeviceType is PointerDeviceType.Mouse or PointerDeviceType.Pen)
            {
                VisualStateManager.GoToState(sender as Control, "HoverButtonsShown", true);
            }
        }
        private void ListViewItem_PointerExited(object sender, PointerRoutedEventArgs e)
        {
            VisualStateManager.GoToState(sender as Control, "HoverButtonsHidden", true);
        }

        private void SearchBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            ViewModel.Filter = args.QueryText;
        }

        private async Task OpenNewDialog()
        {
            EditDialog.Title = "New Pokemon";
            EditDialog.PrimaryButtonText = "Add";
            EditDialog.PrimaryButtonCommand = AddCommand;
            EditDialog.DataContext = new Pokemon();
            await EditDialog.ShowAsync();
        }

        private async Task OpenEditDialog()
        {
            EditDialog.Title = "Edit Pokemon";
            EditDialog.PrimaryButtonText = "Update";
            EditDialog.PrimaryButtonCommand = UpdateCommand;
            var clone = ViewModel.Current.Clone();
            clone.Name = ViewModel.Current.Name;
            EditDialog.DataContext = clone;
            await EditDialog.ShowAsync();
        }


        private void Update()
        {
            ViewModel.UpdateItem(EditDialog.DataContext as Pokemon, ViewModel.Current);
        }
        private void Add()
        {
            var pokemon = ViewModel.AddItem(EditDialog.DataContext as Pokemon);
            if (ViewModel.Items.Contains(pokemon))
            {
                ViewModel.Current = pokemon;
            }
        }
    }   
}
