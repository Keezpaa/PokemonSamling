using Microsoft.Toolkit.Mvvm.Input;
using PokemonSamling.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PokemonSamling.ViewModels;

namespace PokemonSamling.ViewModels
{
    public partial class PokemonViewModel : PokemonDetailViewModel<Pokemon>
    {
        public PokemonViewModel()
        {
            Pokemon.GettingStarted.OrderBy(p => p.Name).ToList().ForEach(p => Items.Add(p));

            Items.CollectionChanged += Items_CollectionChanged;
        }
        public ICommand DuplicateCommand => new RelayCommand<string>(DuplicateCommand_Executed);

        public ICommand DeleteCommand => new RelayCommand<string>(DeleteCommand_Executed);

        public override bool ApplyFilter(Pokemon item, string filter)
        {
            return item.ApplyFilter(filter);
        }

        public override Pokemon UpdateItem(Pokemon item, Pokemon original)
        {
            // Does not raise CollectionChanged.
            return original.UpdateFrom(item);
        }

        private void DeleteCommand_Executed(string parm)
        {
            if (parm is not null)
            {
                var toBeDeleted = Items.FirstOrDefault(p => p.Name == parm);

                // Not OK when a filter is applied.
                // Items.Remove(toBeDeleted);

                DeleteItem(toBeDeleted);
            }
        }

        private void DuplicateCommand_Executed(string parm)
        {
            var toBeDuplicated = Items.FirstOrDefault(p => p.Name == parm);
            var clone = toBeDuplicated.Clone();
            // Items.Add(clone);
            AddItem(clone);
            if (Items.Contains(clone))
            {
                Current = clone;
            }
        }
        private void Items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Debug.WriteLine($"Collection changed: {e.Action}.");
        }
    }
}
