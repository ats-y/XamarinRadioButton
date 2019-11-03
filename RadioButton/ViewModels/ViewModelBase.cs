using System;
using Prism.Mvvm;
using Prism.Navigation;

namespace RadioButton.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        public ViewModelBase()
        {
        }

        public void Destroy()
        {
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }
    }
}
