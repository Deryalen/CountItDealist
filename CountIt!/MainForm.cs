using System;
using System.Globalization;
using System.Windows.Forms;

namespace CountIt_
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (farePrice1.TextLength != 0
                    && farePrice2.TextLength != 0
                    && tfc1.TextLength != 0
                    && tfc2.TextLength != 0
                    && xp1.TextLength != 0
                    && xp2.TextLength != 0
                    && xp.TextLength != 0
                    && penalty.TextLength != 0
                    && upgrade.TextLength != 0)
                {
                    decimal b1 = decimal.Parse(farePrice1.Text);
                    decimal b2 = decimal.Parse(farePrice2.Text);
                    decimal t1 = decimal.Parse(tfc1.Text);
                    decimal t2 = decimal.Parse(tfc2.Text);
                    decimal x1 = decimal.Parse(xp1.Text);
                    decimal x2 = decimal.Parse(xp2.Text);
                    decimal x = decimal.Parse(xp.Text);
                    decimal p = decimal.Parse(penalty.Text);
                    decimal u = decimal.Parse(upgrade.Text);
                    decimal t;
                    if (infant.Checked)
                    {
                        decimal totalBase = (b2 - b1)*0.1m;
                        t = totalBase + x + p*0.1m + u*0.1m;
                    }
                    else if (child.Checked)
                    {
                        decimal d = decimal.Parse(discount.Text);
                        decimal totalTax = ((t2 - x2) - (t1 - x1))*d;
                        decimal totalBase = (b2 - b1) * d;
                        t = totalBase + x + p*d + u*d + totalTax;
                    }
                    else
                    {
                        decimal totalBase = b2 - b1;
                        decimal totalTax = (t2 - x2) - (t1 - x1);
                        t = totalTax + totalBase + x + p + u;
                    }

                    total.Text = t.ToString(CultureInfo.InvariantCulture);
                    Clipboard.SetText(t.ToString(CultureInfo.InvariantCulture));
                    message.Text = @"Copied to clipboard";
                }
                else
                {
                    MessageBox.Show(@"Fill all fields");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show(@"Use ',' not '.'");
            }
        }

        private void farePrice1_TextChanged(object sender, EventArgs e)
        {
            message.Text = "";
        }
    }
}