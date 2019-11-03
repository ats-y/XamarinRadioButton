using System;
using System.Diagnostics;
using Prism.Navigation;
using Reactive.Bindings;

namespace RadioButton.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
		public ReactiveProperty<bool> IsChecked1 { get; set; } = new ReactiveProperty<bool>();
        public ReactiveProperty<bool> IsChecked2 { get; set; } = new ReactiveProperty<bool>();
        public ReactiveProperty<bool> IsChecked3 { get; set; } = new ReactiveProperty<bool>();
        public ReactiveCommand TestCommand { get; set; }

        public MainPageViewModel()
        {
            TestCommand = new ReactiveCommand();
            TestCommand.Subscribe( _=>
            {
                Debug.WriteLine("Testボタンタップ");
            });
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            IsChecked2.Value = true;
        }
    }
}
