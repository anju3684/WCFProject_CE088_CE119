using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TMSService;

namespace TMSHost
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ServiceHost sh = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            Uri tcpa = new Uri("net.tcp://localhost:8000/TcpBinding");
            sh = new ServiceHost(typeof(TMSService.TMSServices), tcpa);
            NetTcpBinding tcpb = new NetTcpBinding();
            ServiceMetadataBehavior mbehave = new ServiceMetadataBehavior();
            sh.Description.Behaviors.Add(mbehave);
            sh.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), "mex");
            sh.AddServiceEndpoint(typeof(ITMSServices), tcpb, tcpa);
            sh.Open();
            label1.Text = "Service is running";
        }
    }
}
