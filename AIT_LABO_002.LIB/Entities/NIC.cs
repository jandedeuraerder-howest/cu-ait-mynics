using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Net;

namespace AIT_LABO_002.LIB.Entities
{
    public class NIC
    {
        public NetworkInterface Netwerkkaart
        {
            get;
            set;
        }
        public NIC(NetworkInterface nic)
        {
            Netwerkkaart = nic;
            nicip = nic.GetIPProperties();

        }
        public override string ToString()
        {
            return Netwerkkaart.Name;
        }
        public string Description {
            get {
                return Netwerkkaart.Description; }
        }
        public string ID
        {
            get
            {
                return Netwerkkaart.Id;
            }
        }
        public string NetworkInterfaceType
        {
            get
            {
                return Netwerkkaart.NetworkInterfaceType.ToString(); ;
            }
        }
        public string OperationalStatus
        {
            get
            {
                return Netwerkkaart.OperationalStatus.ToString();
            }
        }
        public string Speed
        {
            get
            {
                long lspeed = Netwerkkaart.Speed / 1000000;
                return lspeed.ToString("#,##0");
            }
        }
        public string Mac
        {
            get { return Netwerkkaart.GetPhysicalAddress().ToString(); }
        }

        private IPInterfaceProperties nicip;
        public IPInterfaceProperties nicIP
        {
            get { return nicip; }
        }
        public string ip4
        {
            get
            {
                string retour = "";
                IPv4InterfaceProperties ip4props = nicip.GetIPv4Properties();
                bool isDHCP = ip4props.IsDhcpEnabled;
                retour += $"DCHP enabled = {isDHCP} \n\n";

                foreach (UnicastIPAddressInformation ip in nicip.UnicastAddresses)
                {
                    if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {


                        retour += $"IP = {ip.Address.ToString()} \n";
                        retour += $"Subnet = {ip.IPv4Mask.ToString()} \n\n";

                    }
                }
                int gwCounter = 1;
                foreach (GatewayIPAddressInformation gwadres in nicip.GatewayAddresses)
                {
                    if (gwadres.Address.IsIPv4MappedToIPv6)
                        retour += $"DNS {gwCounter} = {gwadres.Address.MapToIPv4().ToString()} \n";
                    else
                        retour += $"DNS {gwCounter} = {gwadres.Address.ToString()} \n";
                    //retour += $"Gateway {gwCounter} = {gwadres.Address.ToString()} \n";
                    gwCounter++;
                }
                int dnsCounter = 1;
                foreach (IPAddress dnsadres in nicip.DnsAddresses)
                {
                    if (dnsadres.IsIPv4MappedToIPv6)
                        retour += $"DNS {dnsCounter} = {dnsadres.MapToIPv4().ToString()} \n";
                    else
                        retour += $"DNS {dnsCounter} = {dnsadres.ToString()} \n";
                    dnsCounter++;
                }
                int dhcpCounter = 1;
                foreach (IPAddress dhcpadres in nicip.DhcpServerAddresses)
                {
                    retour += $"DHCP {dhcpCounter} = {dhcpadres.ToString()} \n";
                    dhcpCounter++;
                }
                return retour;
            }
        }
        public string ip6
        {
            get
            {
                string retour = "-";
                if (Netwerkkaart.Supports(NetworkInterfaceComponent.IPv6))
                {
                    foreach (UnicastIPAddressInformation ip in nicip.UnicastAddresses)
                        //foreach (IPAddress ipadr in nicip.DnsAddresses)
                    {
                        if (ip.Address.AddressFamily ==   System.Net.Sockets.AddressFamily.InterNetworkV6)
                        {
                            retour += $"{ip.Address.ToString()} \n";
                        }
                    }
                }
                return retour;
            }
        }

}


}
