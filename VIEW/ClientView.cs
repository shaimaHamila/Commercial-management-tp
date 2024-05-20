using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CONTROLLER;
using CONTROLLER.Controllers;
using MODEL;
namespace VIEW
{
    public partial class ClientView : Form
    {
        public ClientView()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClientController clientController = new ClientController();
            clientController.getClient();
            clientBindingSource.DataSource = clientController.liste;
        }

        private void addClient_Click(object sender, EventArgs e)
        {
            Client newClient = new Client();
            newClient = (Client)clientBindingSource.Current;
            ClientController clientController = new ClientController();
            clientController.saveClient(newClient);
        }
        private void reseteForm_Click(object sender, EventArgs e)
        {
            clientBindingSource.AddNew();
        }
        private void deleteClient_Click(object sender, EventArgs e)
        {
            Client newClient = new Client();
            newClient = (Client)clientBindingSource.Current;
            ClientController clientController = new ClientController();
            clientController.deleteClient(newClient);
        }
    }
}
