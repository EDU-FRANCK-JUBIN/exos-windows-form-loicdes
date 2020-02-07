using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaSuperWindowsForm
{
    public partial class Calculatrice : Form
    {
        private static List<string> Operators = new List<string>();
        private static List<string> Numbers = new List<string>() { "0" };
        private static double Result;
        private static int Step = 0;
        public Calculatrice()
        {
            InitializeComponent();
        }

        private void handleClick(object sender, EventArgs e)
        {
            dynamic senderObject = sender;
            switch (senderObject.Text)
            {
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case ",":
                    Numbers[Step] += senderObject.Text;
                    DisplayResult();
                    break;
                case "-":
                case "+":
                case "*":
                case "/":
                    Operators.Add(senderObject.Text);
                    Numbers.Add("");
                    Step++;
                    DisplayResult();
                    break;
                case "C":
                    Numbers.Clear();
                    Numbers.Add("0");
                    Step = 0;
                    Operators.Clear();
                    DisplayResult();
                    break;
                case "CE":
                    Numbers[Step] = "";
                    DisplayResult();
                    break;
                case "+-":
                    CalculateResult();
                    Result *= -1;
                    richTextBox1.Text = Result.ToString();
                    break;
                case "=":
                    CalculateResult();
                    richTextBox1.Text = Result.ToString();
                    break;
            }
        }
        private void DisplayResult()
        {
            richTextBox1.Text = "";
            for (var i = 0; i < Numbers.Count; i++)
            {
                richTextBox1.Text += Numbers[i] != "" ? Double.Parse(Numbers[i]).ToString() : "";
                richTextBox1.Text += i < Operators.Count ? Operators[i] : "";

            }
        }
        private void CalculateResult()
        {
            double temp;
            string tempOperator;
            Result = Double.Parse(Numbers[0]);
            for (var i = 0; i < Numbers.Count; i++)
            {
                temp = i+1 < Numbers.Count ? Double.Parse(Numbers[i+1]) : 0;
                tempOperator = i < Operators.Count ? Operators[i] : "";
                switch (tempOperator)
                {
                    case "-":
                        Result -= temp;
                        break;
                    case "+":
                        Result += temp;
                        break;
                    case "*":
                        Result *= temp;
                        break;
                    case "/":
                        Result /= temp;
                        break;
                    case "":
                        break;
                }
            }

        }
    }
}
