using System;
using System.Diagnostics;
using System.Windows.Input;
using MLKit.Models;
using Xamarin.Forms;

namespace MLKit.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
        }

        public ICommand StartButton
        {
            get
            {
                return new Command(() =>
                {
                    try
                    {
                        DependencyService.Get<ISpeechToText>().StartSpeechToText();
                    }
                    catch (Exception ex)
                    {
                        SetDebug(ex.ToString());
                    }
                });
            }
        }

        public void SetDebug(string message)
        {
            try
            {
                string datetime = DateTime.Now.ToLongTimeString();
                Debug.WriteLine($"{datetime} : {message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
