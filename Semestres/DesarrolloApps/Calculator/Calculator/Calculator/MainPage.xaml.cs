using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        int result = 0;
        public MainPage()
        {
            InitializeComponent();
        }

        private void SumVals(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(firstNum.Text) || string.IsNullOrEmpty(secondNum.Text))
            {
                showError();
            }
            else
            {
                int first = Int32.Parse(firstNum.Text);
                int sec = Int32.Parse(secondNum.Text);
                result = first + sec;
                showRes("+", first, sec);
            }
           
        }
        private void SubVals(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(firstNum.Text) || string.IsNullOrEmpty(secondNum.Text))
            {
                showError();
            }
            else
            {
                int first = Int32.Parse(firstNum.Text);
                int sec = Int32.Parse(secondNum.Text);
                result = first - sec;
                showRes("-", first, sec);
            }
        }
        private void MulVals(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(firstNum.Text) || string.IsNullOrEmpty(secondNum.Text))
            {
                showError();
            }
            else
            {
                int first = Int32.Parse(firstNum.Text);
                int sec = Int32.Parse(secondNum.Text);
                result = first * sec;
                showRes("*", first, sec);
            }
        }
        private void DivVals(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(firstNum.Text) || string.IsNullOrEmpty(secondNum.Text))
            {
                showError();
            }
            else
            {
                int first = Int32.Parse(firstNum.Text);
                int sec = Int32.Parse(secondNum.Text);
                result = first / sec;
                showRes("/", first, sec);
            }
        }
        private void showError()
        {
            DisplayAlert("Error!!", "You must enter two numbers.", "Thanks!");
        }

        private void showRes(string op, int uno, int dos)
        {
            DisplayAlert("Result", uno.ToString() + " " + op + " " + dos.ToString() + " = " + result.ToString(), "Thanks!");
        }

    }
}
