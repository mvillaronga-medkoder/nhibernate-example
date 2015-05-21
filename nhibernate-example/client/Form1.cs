using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Ninject;

using domain;
using infrastructure.interfaces;

namespace client
{
    public partial class Form1 : Form
    {
        #region Members 

        IKernel _kernel = null;

        #endregion

        #region Constructor

        public Form1()
        {
            InitializeComponent();

            //run mapping and startup code
            _kernel = MappingDefinitions.CreateKernel();

        }

        #endregion

        #region View Payments

        private void btnCC_Click(object sender, EventArgs e)
        {
            showPaymentDetails(CreditCardPayment.DiscriminatorDefinition());
        }

        private void btnPaypal_Click(object sender, EventArgs e)
        {
            showPaymentDetails(PayPalPayment.DiscriminatorDefinition());
        }

        private void showPaymentDetails(string paymentType)
        {
            IRepositoryFactory repoFac = _kernel.Get<IRepositoryFactory>();

            using (IRepository repo = repoFac.getRepository())
            {
                Order order = repo.Query<Order>().Where(x => x.PaymentType == paymentType).FirstOrDefault();
                if (order != null)
                    MessageBox.Show(order.Payment.PaymentDetails());
                else
                    MessageBox.Show("No orders with " + paymentType + " payments exist!");
            }
        }

        #endregion

        #region View Lists

        private void btnPullAll_Click(object sender, EventArgs e)
        {
            IRepositoryFactory repoFac = _kernel.Get<IRepositoryFactory>();
            using (IRepository repo = repoFac.getRepository())
            {
                IList<Order> orders = repo.Query<Order>().ToList<Order>();

                StringBuilder txt = new StringBuilder("");
                foreach (Order order in orders)
                    txt = txt.AppendLine(order.showDetails());

                MessageBox.Show(txt.ToString());
            }
        }

        private void btnPullAllItems_Click(object sender, EventArgs e)
        {
            IRepositoryFactory repoFac = _kernel.Get<IRepositoryFactory>();
            using (IRepository repo = repoFac.getRepository())
            {
                IList<Item> items = repo.Query<Item>().ToList();

                StringBuilder txt = new StringBuilder("");
                foreach (Item item in items)
                    txt = txt.AppendLine(item.showDetails());

                MessageBox.Show(txt.ToString());
            }
        }

        #endregion

        #region Adds

        private void btnAddPayPal_Click(object sender, EventArgs e)
        {
            PayPalPayment pmt = new PayPalPayment() {
                AccountName = txtName.Text
            };

            createOrder(pmt);
        }

        private void btnAddCC_Click(object sender, EventArgs e)
        {
            CreditCardPayment pmt = new CreditCardPayment()
            {
                CardholderName = txtName.Text,
                CardNumber = "12345",
                CardType = "BlingBling",
                ExpiryDate = DateTime.Now
            };

            createOrder(pmt);
        }

        protected void createOrder(IPaymentType pmt)
        {
            Order order = new Order()
            {
                Payment = pmt,
                ReferenceNumber = int.Parse(txtOrderNumber.Text)  //living dangerously
            };

            IRepositoryFactory repoFac = _kernel.Get<IRepositoryFactory>();
            using (IRepository repo = repoFac.getRepository())
            {
                //add an existing item to the order
                OrderItem oi = new OrderItem() {
                    Order = order,
                    Item = repo.GetById<Item>(3),
                    Quantity = 7
                };
                order.Items.Add(oi);

                repo.Save(order);

                MessageBox.Show("Added");
            }
        }

        #endregion

        #region Deletes

        private void btnDeleteCC_Click(object sender, EventArgs e)
        {
            deleteOrder(CreditCardPayment.DiscriminatorDefinition());
        }

        private void btnDeletePP_Click(object sender, EventArgs e)
        {
            deleteOrder(PayPalPayment.DiscriminatorDefinition());
        }

        private void deleteOrder(string paymentType)
        {
            IRepositoryFactory repoFac = _kernel.Get<IRepositoryFactory>();
            using (IRepository repo = repoFac.getRepository())
            {
                //get the last one we added
                Order order = repo.Query<Order>()
                                    .Where(x => x.PaymentType == paymentType)
                                    .OrderByDescending(x => x.Id).FirstOrDefault();

                if (null != order)
                    repo.Delete(order);

                MessageBox.Show("Deleted");
            }
        }

        #endregion

        #region event handlers

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion
    }
}
