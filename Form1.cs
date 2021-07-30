using System;
using System.Text;
using System.Windows.Forms;

namespace Calculate
{
    public partial class Calculate : Form
    {
        public Calculate()
        {
            InitializeComponent();
        }

        private void Calculate_Load(object sender, EventArgs e) { }

        private void Proccess(object sender, EventArgs e)
        {
            if(sender is Button btn)
            {
                if (Equalss) btn_Clean_Click(this, e);
                if (Operand == default)
                {
                    if (btn.Text != "," && !lbl_Display.Text.EndsWith(","))
                        lbl_Display.Text = (LeftLiteral = decimal.Parse($"{LeftLiteral.ToString()}{btn.Text}")).ToString();
                    else
                    {
                        if (!lbl_Display.Text.Contains(",")) lbl_Display.Text += btn.Text;
                        else if (lbl_Display.Text.Contains(",") && btn.Text != ",")
                        {
                            LeftLiteral = decimal.Parse(lbl_Display.Text += btn.Text);
                        }
                    }
                }
                else
                {
                    if (btn.Text != "," && !lbl_Display.Text.EndsWith(","))
                        lbl_Display.Text = (RightLiteral = decimal.Parse($"{RightLiteral.ToString()}{btn.Text}")).ToString();
                    else
                    {
                        if (!lbl_Display.Text.Contains(",")) lbl_Display.Text += btn.Text;
                        else if (lbl_Display.Text.Contains(",") && btn.Text != ",")
                        {
                            RightLiteral = decimal.Parse(lbl_Display.Text += btn.Text);
                        }
                    }
                }
            }
        }

        private void btn_Plus_Click(object sender, EventArgs e)
        {
            lbl_MicroDisplay.Text = $"{LeftLiteral} {Operand = '+'}";
            if (LeftLiteral != 0 && RightLiteral != 0)
            {
                lbl_MicroDisplay.Text = $"{lbl_Display.Text = (LeftLiteral += RightLiteral).ToString()} +";
                RightLiteral = default;
            }
            else if (RightLiteral == 0)
            {
                lbl_Display.Text = $"{LeftLiteral}";
            }
        }

        private void btn_Minuse_Click(object sender, EventArgs e)
        {
            lbl_MicroDisplay.Text = $"{LeftLiteral} {Operand = '-'}";
            if (LeftLiteral != 0 && RightLiteral != 0)
            {
                lbl_MicroDisplay.Text = $"{lbl_Display.Text = (LeftLiteral -= RightLiteral).ToString()} -";
                RightLiteral = default;
            }
            else if (RightLiteral == 0)
            {
                lbl_Display.Text = $"{LeftLiteral}";
            }
        }

        private void btn_Multiply_Click(object sender, EventArgs e)
        {
            lbl_MicroDisplay.Text = $"{LeftLiteral} {Operand = 'x'}";
            if (LeftLiteral != 0 && RightLiteral != 0)
            {
                lbl_MicroDisplay.Text = $"{lbl_Display.Text = (LeftLiteral *= RightLiteral).ToString()} x";
                RightLiteral = default;
            }
        }

        private void btn_Division_Click(object sender, EventArgs e)
        {
            lbl_MicroDisplay.Text = $"{LeftLiteral} {Operand = '÷'}";
            if (LeftLiteral != 0 && RightLiteral != 0)
            {
                lbl_MicroDisplay.Text = $"{lbl_Display.Text = (LeftLiteral /= RightLiteral).ToString()} ÷";
                RightLiteral = default;
            }
        }

        private void btn_Percent_Click(object sender, EventArgs e)
        {
            if (LeftLiteral != 0 && RightLiteral != 0)
            {
                lbl_MicroDisplay.Text = $"{LeftLiteral} {Operand} {RightLiteral * RightLiteral / 100}";
                lbl_Display.Text = $"{RightLiteral * RightLiteral / 100}";
                RightLiteral = RightLiteral * RightLiteral / 100;
            }
        }

        private void btn_Equal_Click(object sender, EventArgs e)
        {
            if(RightLiteral != default)
            {
                lbl_MicroDisplay.Text = $" {LeftLiteral} {Operand} {RightLiteral} = ";
                if(Operand == '+') lbl_Display.Text = (LeftLiteral += RightLiteral).ToString();
                else if(Operand == '-') lbl_Display.Text = (LeftLiteral -= RightLiteral).ToString();
                else if(Operand == 'x') lbl_Display.Text = (LeftLiteral *= RightLiteral).ToString();
                else if(Operand == '÷') lbl_Display.Text = (LeftLiteral /= RightLiteral).ToString();
                RightLiteral = default;
                Operand = default;
                Equalss = true;
            }
        }

        private void btn_Clean_Click(object sender, EventArgs e)
        {
            lbl_Display.Text = "0";
            lbl_MicroDisplay.Text = "";
            LeftLiteral = RightLiteral = default;
            Operand = default;
            Equalss = false;
        }

        private void btn_CE_Click(object sender, EventArgs e)
        {
            if (Equalss)
            {
                lbl_Display.Text = "0";
                lbl_MicroDisplay.Text = "";
                LeftLiteral = RightLiteral = default;
                Operand = default;
                Equalss = false;
            }
            else
            {
                lbl_Display.Text = "0";
                RightLiteral = default;
            }
        }

        private void btn_Backspace_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if(LeftLiteral != 0 && RightLiteral == default)
            {
                if(LeftLiteral.ToString().Length > 1)
                {
                    for (int i = 0; i < LeftLiteral.ToString().Length - 1; i++)
                    {
                        sb.Append(LeftLiteral.ToString()[i]);
                    }
                    lbl_Display.Text = (LeftLiteral = decimal.Parse(sb.ToString())).ToString();
                }
                else
                {
                    lbl_Display.Text = (LeftLiteral = 0).ToString();
                }
            }
            else if (LeftLiteral != 0 && RightLiteral != 0)
            {
                if (RightLiteral.ToString().Length > 1)
                {
                    for (int i = 0; i < RightLiteral.ToString().Length - 1; i++)
                    {
                        sb.Append(RightLiteral.ToString()[i]);
                    }
                    lbl_Display.Text = (RightLiteral = decimal.Parse(sb.ToString())).ToString();
                }
                else
                {
                    lbl_Display.Text = (RightLiteral = 0).ToString();
                }
            }
        }

        private void btn_MinPlus_Click(object sender, EventArgs e)
        {
            if(LeftLiteral != 0 && RightLiteral == default)
            {
                LeftLiteral -= (LeftLiteral * 2);
                lbl_Display.Text = LeftLiteral.ToString();
            }
            else if(LeftLiteral < 0 && RightLiteral == default)
            {
                LeftLiteral += (LeftLiteral * 2);
                lbl_Display.Text = LeftLiteral.ToString();
            }
            else if(RightLiteral != 0 && RightLiteral != default)
            {
                RightLiteral -= (RightLiteral * 2);
                lbl_Display.Text = RightLiteral.ToString();
            }
            else if(RightLiteral < 0)
            {
                RightLiteral += (RightLiteral * 2);
                lbl_Display.Text = RightLiteral.ToString();
            }
        }

        public decimal LeftLiteral { get; set; }
        public decimal RightLiteral { get; set; }
        public char Operand { get; set; }
        public bool Equalss { get; set; }
    }
}