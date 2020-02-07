using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AIT_LABO_002.LIB.Entities;
using AIT_LABO_002.LIB.Services;
using System.Net.NetworkInformation;

namespace AIT_LABO_002.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<NIC> mijnNics;

        public MainWindow()
        {
            InitializeComponent();
            mijnNics = NICService.getAllNics();
            lstNics.ItemsSource = mijnNics;

        }

        private void LstNics_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lblDescription.Content = "-";
            lblID.Content = "-";
            lblNetworkInterfaceType.Content = "-";
            lblOperationalStatus.Content = "-";
            lblSpeed.Content = "-";
            lblMac.Content = "-";
            lblIP4.Content = "-";
            lblIP6.Content = "-";
            lblOperationalStatus.Background = Brushes.Transparent;
            lblOperationalStatus.Foreground = Brushes.Black;

            if (lstNics.SelectedItem == null) return;

            NIC onderzoekKaart = (NIC)lstNics.SelectedItem;
            lblDescription.Content = onderzoekKaart.Description;
            lblID.Content = onderzoekKaart.ID;
            lblNetworkInterfaceType.Content = onderzoekKaart.NetworkInterfaceType;
            lblOperationalStatus.Content = onderzoekKaart.OperationalStatus;
            lblOperationalStatus.Foreground = Brushes.White;
            if (lblOperationalStatus.Content.ToString().ToUpper() == "DOWN")
                lblOperationalStatus.Background = Brushes.Tomato;
            else
                lblOperationalStatus.Background = Brushes.ForestGreen;
            lblSpeed.Content = onderzoekKaart.Speed + " Mb";
            lblMac.Content = onderzoekKaart.Mac;
            lblIP4.Content = onderzoekKaart.ip4;
            lblIP6.Content = onderzoekKaart.ip6;
        }
    }
}
