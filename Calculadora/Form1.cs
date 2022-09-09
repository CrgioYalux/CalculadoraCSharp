using System.CodeDom;

namespace Calculadora
{
    public partial class Form1 : Form
    {
        private List<string> operators = new List<string>();
        private double lastResult;
        private Calc calc = new Calc();

        public Form1()
        {
            InitializeComponent();
        }
        private void btnNumber_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            if (button != null)
            {
                if (button.Text == "CE")
                {
                    lblShow.Text = "";
                    lblResult.Text = "";
                }
                else
                {
                    double number = 0.0;
                        
                    if (double.TryParse(button.Text, out number))
                    {
                        calc.addNumber(number);
                        if (operators.ToArray().Length == 1)
                        {
                            if (calc.getCantNumbers() > 1)
                            {
                                calc.makeNumber();
                            }
                            double result = calc.operate(operators[0]);
                            lblResult.Text = result.ToString();
                            lastResult = result;
                        }
                    }
                    else
                    {
                        operators.Add(button.Text);
                        calc.makeNumber();
                    }

                    lblShow.Text += button.Text;
                }
            }
        }
    }
}