using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SuarezDiscountSystem
{
    public partial class Form1 : Form
    {
        Visit ctm;
        DateTime dt = DateTime.Now;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        public Form1()
        {
            InitializeComponent();
            ctm = new Visit(Name, dt);
            pnlLogin.BackColor = Color.FromArgb(100, 0, 0, 0);
            pnlNote.BackColor = Color.FromArgb(100, 0, 0, 0);
            pnlProduct.BackColor = Color.FromArgb(100, 0, 0, 0);
            pnlService.BackColor = Color.FromArgb(100, 0, 0, 0);
            pnlChoose.BackColor = Color.FromArgb(100, 0, 0, 0);
            pnlCustomer.BackColor = Color.FromArgb(100, 0, 0, 0);
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }
        //DropShadow
        private const int CS_DropShadow = 0x00020000;
        protected override CreateParams CreateParams
        {
            get {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DropShadow;
                return cp;
                }
        }

        private void txtNameClick(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtName.ForeColor = Color.Black;
        }

        private void lblExitClick(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to exit?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                DialogResult = DialogResult.No;
            }
        }

        private void txtName_Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ctm.Name = txtName.Text;
                lblNameDis.Text = ctm.Name;
                if (ctm.checkList(txtName.Text) == true)
                {
                    MessageBox.Show("Glad you're here! " + txtName.Text + ", We hope you brought pizza!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pnlLogin.Visible = false;
                    lblSign.Visible = true;
                    pnlNote.Visible = true;
                }
                else
                {
                    MessageBox.Show(txtName.Text + ", Joined the party!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pnlLogin.Visible = false;
                    pnlVerify.Visible = true;
                }
            }
        }

        private void tmrBePart_Tick(object sender, EventArgs e)
        {
            if(lblBePart.ForeColor == Color.Red)
            {
                lblBePart.ForeColor = Color.Yellow;
            }
            else if(lblBePart.ForeColor == Color.Yellow)
            {
                lblBePart.ForeColor = Color.Blue;
            }
            else
            {
                lblBePart.ForeColor = Color.Red;
            }
        }

        private void lblYes_Click(object sender, EventArgs e)
        {
            pnlNote.Visible = true;
            pnlVerify.Visible = false;
            ctm.listAdd(txtName.Text);
            ctm.isMember = true;  
        }

        private void btnAgree_Click(object sender, EventArgs e)
        {
            pnlProduct.Visible = true;
            pnlNote.Visible = false;
        }

        private void btnPPremium_Click(object sender, EventArgs e)
        {
            ctm.PMemberType = "Premium";
            ctm.ProductDiscountRate("Premium");
            lblProDis.Text = ctm.PMemberType;
            pnlService.Visible = true;
            pnlProduct.Visible = false;

        }

        private void btnPGold_Click(object sender, EventArgs e)
        {
            ctm.PMemberType = "Gold";
            ctm.ProductDiscountRate("Gold");
            lblProDis.Text = ctm.PMemberType;
            pnlService.Visible = true;
            pnlProduct.Visible = false;
        }

        private void btnPSilver_Click(object sender, EventArgs e)
        {
            ctm.PMemberType = "Silver";
            ctm.ProductDiscountRate("Silver");
            lblProDis.Text = ctm.PMemberType;
            pnlService.Visible = true;
            pnlProduct.Visible = false;
        }

        private void btnSPremium_Click(object sender, EventArgs e)
        {
            ctm.SMemberType = "Premium";
            ctm.ServiceDiscountRate("Premium");
            lblSerDis.Text = ctm.SMemberType;
            pnlService.Visible = false;
            pnlChoose.Visible = true;
            lblSign.Visible = true;
        }

        private void btnSGold_Click(object sender, EventArgs e)
        {
            ctm.SMemberType = "Gold";
            ctm.ServiceDiscountRate("Gold");
            lblSerDis.Text = ctm.SMemberType;
            pnlService.Visible = false;
            pnlChoose.Visible = true;
            lblSign.Visible = true;
        }

        private void btnSSilver_Click(object sender, EventArgs e)
        {
            ctm.SMemberType = "Silver";
            ctm.ServiceDiscountRate("Silver");
            lblSerDis.Text = ctm.SMemberType;
            pnlService.Visible = false;
            pnlChoose.Visible = true;
            lblSign.Visible = true;
        }

        private void picMenu_Click(object sender, EventArgs e)
        {
            pnlChoose.Visible = false;
            pnlMenu.Visible = true;
            lblBack.Visible = true;
        }

        private void lblBack_Click(object sender, EventArgs e)
        {
            pnlMenu.Visible = false;
            pnlCustomer.Visible = false;
            lblBack.Visible = false;
            pnlChoose.Visible = true;
        }

        private void lblSign_Click(object sender, EventArgs e)
        {
            lblSign.Visible = false;
            lblBack.Visible = false;
            pnlMenu.Visible = false;
            pnlChoose.Visible = false;
            pnlCustomer.Visible = false;
            pnlChooseSer.Visible = false;
            pnlLogin.Visible = true;
            txtName.Text = "";
            ctm.ServiceExpense = 0;
            ctm.ProductExpense = 0;
        }

        private void lblNo_Click(object sender, EventArgs e)
        {
            pnlChoose.Visible = true;
            pnlVerify.Visible = false;
            lblProDis.Text = "No Discount";
            lblSerDis.Text = "No Discount";
        }

        private void picCustomer_Click(object sender, EventArgs e)
        {
            pnlChoose.Visible = false;
            pnlCustomer.Visible = true;
            lblBack.Visible = true;
        }

        private void picBorgir_Click(object sender, EventArgs e)
        {
            lblBack.Visible = false;
            pnlMenu.Visible = false;
            pnlChooseSer.Visible = true;
            ctm.ProductExpense = 75.00;
        }

        private void picPizza_Click(object sender, EventArgs e)
        {
            pnlMenu.Visible = false;
            lblBack.Visible = false;
            pnlChooseSer.Visible = true;
            ctm.ProductExpense = 150.00;
        }

        private void picDine_Click(object sender, EventArgs e)
        {
            ctm.ServiceExpense = 20.00;
            pnlChooseSer.Visible = false;
            pnlTrans.Visible = true;
            lblSign.Visible = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            pnlChooseSer.Visible = true;
            pnlTrans.Visible = false;
            lblSign.Visible = true;
            ctm.ServiceExpense = 0;
            ctm.ProductExpense = 0;
            numQty.Text = "0";
            ctm.ProductDiscountRate("Null");
            ctm.ServiceDiscountRate("Null");
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            double a = int.Parse(numQty.Text);
            if(a < 1)
            {
                MessageBox.Show("Please input a valid amount!","",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            else
            {
                ctm.ProductExpense *= a;
                MessageBox.Show(ctm.toString(), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                pnlTrans.Visible = false;
                pnlChoose.Visible = true;
                numQty.Text = "";
            }
        }

        private void picTake_Click(object sender, EventArgs e)
        {
            ctm.ServiceExpense = 30.00;
            pnlChooseSer.Visible = false;
            pnlTrans.Visible = true;
            lblSign.Visible = false;
        }

        private void picDev_Click(object sender, EventArgs e)
        {
            ctm.ServiceExpense = 70.00;
            pnlChooseSer.Visible = false;
            pnlTrans.Visible = true;
            lblSign.Visible = false;
        }
    }
}
