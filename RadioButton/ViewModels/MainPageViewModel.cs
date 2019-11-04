using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Prism.Navigation;
using RadioButton.Views;
using Reactive.Bindings;
using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Services;

namespace RadioButton.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
		public ReactiveProperty<bool> IsChecked1 { get; set; } = new ReactiveProperty<bool>();
        public ReactiveProperty<bool> IsChecked2 { get; set; } = new ReactiveProperty<bool>();
        public ReactiveProperty<bool> IsChecked3 { get; set; } = new ReactiveProperty<bool>();
        public ReactiveCommand TestCommand { get; set; }

        private IPopupNavigation _popupNavigation;

        public MainPageViewModel(IPopupNavigation popupNavigation)
        {
            _popupNavigation = popupNavigation;

            TestCommand = new ReactiveCommand();
            TestCommand.Subscribe( async _ =>
            {
                Debug.WriteLine("Testボタンタップ");

                TrialPopupPage popup = new TrialPopupPage();

                popup.BindingContext = new TrialPopupPage.ContentData
                {
                    DisplayMessage = "abc",
                };

                Task popTask = _popupNavigation.PushAsync(popup);
                await popTask.ConfigureAwait(false);

                Debug.WriteLine("Testボタンタップ おわり");
            });
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            IsChecked2.Value = true;
        }
    }
}
