
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MauiApp1.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {


        public MainViewModel()
        {
            items = new ObservableCollection<string>();
        }

        [ObservableProperty]
        ObservableCollection<string> items;




        [ObservableProperty]
        string text;

        [RelayCommand]
        public void Add()
        {
            if (string.IsNullOrWhiteSpace(Text))
            {
                return;
            }

            items.Add(Text);
            Text = string.Empty;
        }

        [RelayCommand]
        public void Delete(string s)
        {
            if (Items.Contains(s))
            {
                Items.Remove(s);
            }
        }

        [RelayCommand]
        async Task Tap(string s)
        {
            await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");
        }

        [RelayCommand]
        async Task Edit(string correctText)
        {
            string newText = await Shell.Current.DisplayPromptAsync(
                "Edit Task",
                "Change task text",
                initialValue: correctText
             );

            if (!string.IsNullOrWhiteSpace(newText))
            {
                int index = Items.IndexOf(correctText);
                if (index >= 0)
                {
                    Items[index] = newText;
                }
            }
        }




    }

}
