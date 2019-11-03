using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RadioButton.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// チェックボックスのIsChecked値が変わった
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnChangeCheckbox(CheckBox sender, CheckedChangedEventArgs args)
        {
            Debug.WriteLine($"OnChangeCheckbox()");

            // CheckBoxAreaのチェックボックス
            var checkBoxs = CheckBoxArea.Children.Where(x => x.GetType() == typeof(CheckBox));

            // チェックボックスをONにした場合、自分以外を全てチェックOFFにする。
            if(args.Value == true)
            {
                foreach (CheckBox other in checkBoxs)
                {
                    if (other != sender)
                    {
                        other.IsChecked = false;
                    }
                }
                return;
            }

            // 全てのチェックボックスにチェックが外れてしまったら
            // 自分自身をチェック状態に戻す。
            var checkeds = checkBoxs.Where(x =>
            {
                CheckBox cb = x as CheckBox;
                if (cb == null || cb.IsChecked == false) return false;
                return true;
            });
            if (checkeds.Count() == 0)
            {
                Debug.WriteLine("all not checked.");
                ((CheckBox)sender).IsChecked = true;
            }
            return;
        }
    }
}
