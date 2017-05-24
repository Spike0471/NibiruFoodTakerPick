using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using System.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NibiruOrderApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        static private ArrayList OvertimeNames = new ArrayList();
        static private ArrayList TakeRiceNames = new ArrayList();
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void SubmitButton_Click_TakeRice(object sender, RoutedEventArgs e){
            int number;
            TakeRiceNames.Clear();
            if (int.TryParse(Number.Text, out number)){
                if (number < OvertimeNames.Count && number > 0) {
                    Random rd = new Random();
                    for(int i = 0; i < number; i++) {
                        String LuckyDog = (String)OvertimeNames[rd.Next(0, OvertimeNames.Count - 1)];
                        if (TakeRiceNames.Contains(LuckyDog)) {
                            i--;
                            continue;
                        }
                        TakeRiceNames.Add(LuckyDog);
                    }
                    UpdateTakeRiceList();
                }
            }
        }
        private void SubmitButton_Click_Clear(object sender, RoutedEventArgs e) {
            OvertimeNames.Clear();
            TakeRiceNames.Clear();
            OvertimeList.Text = "";
            TakeRiceList.Text = "";
        }

        private void SubmitButton_Click_Plus(object sender, RoutedEventArgs e) {
            if (!OvertimeNames.Contains(PlusName.Text)) {
                OvertimeNames.Add(PlusName.Text);
                UpdateOvertimeList();
            }
            PlusName.Text = "";
        }

        private void SubmitButton_Click_Minus(object sender, RoutedEventArgs e){
            if (OvertimeNames.Contains(MinusName.Text)) {
                OvertimeNames.Remove(MinusName.Text);
                UpdateOvertimeList();
            }
            if (TakeRiceNames.Contains(MinusName.Text))
            {
                TakeRiceNames.Remove(MinusName.Text);
                UpdateTakeRiceList();
            }
            MinusName.Text = "";
        }

        private void Number_TextChanged(object sender, TextChangedEventArgs e){
            int number = 0;
            if (!int.TryParse(Number.Text, out number)) {
                Number.Text = "";
            }     
        }

        private void UpdateOvertimeList() {
            OvertimeList.Text = "";
            for (int i = 0; i < OvertimeNames.Count; i++)
            {
                if (i == 0) OvertimeList.Text += OvertimeNames[i];
                else
                {
                    OvertimeList.Text += ",";
                    OvertimeList.Text += OvertimeNames[i];
                }
            }
            OvertimeList.Text += "要加班。";
        }

        private void UpdateTakeRiceList()
        {
            TakeRiceList.Text = "";
            for (int i = 0; i < TakeRiceNames.Count; i++)
            {
                if (i == 0) TakeRiceList.Text += TakeRiceNames[i];
                else
                {
                    TakeRiceList.Text += ",";
                    TakeRiceList.Text += TakeRiceNames[i];
                }
            }
            TakeRiceList.Text += "拿外卖。";
        }
    }
}
