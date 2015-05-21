using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Ninject;
using Ninject.Modules;
using Ninject.Parameters;
using infrastructure.interfaces;
using domain;

namespace client
{
    public partial class Form1 : Form
    {
        IKernel _kernel = null;

        public Form1()
        {
            InitializeComponent();

            //run mapping and startup code
            _kernel = MappingDefinitions.CreateKernel();

        }

        private void btnCC_Click(object sender, EventArgs e)
        {
            showPaymentDetails("Credit Card");
        }

        private void btnPaypal_Click(object sender, EventArgs e)
        {
            showPaymentDetails("PayPal");
        }

        private void showPaymentDetails(string paymentType)
        {
            var repoFac = _kernel.Get<IRepositoryFactory>();
            var repo = repoFac.getRepository();
            Order order = repo.Query<Order>().Where(x => x.Payment.Description == paymentType).FirstOrDefault();
            if (order != null)
                MessageBox.Show(order.Payment.PaymentDetails());
            else
                MessageBox.Show("No orders with " + paymentType + " payments exist!");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
