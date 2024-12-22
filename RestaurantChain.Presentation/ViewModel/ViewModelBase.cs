using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RestaurantChain.Presentation.ViewModel;

public class ViewModelBase
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}