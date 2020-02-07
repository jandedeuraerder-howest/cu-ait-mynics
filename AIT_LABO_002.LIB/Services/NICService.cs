using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using AIT_LABO_002.LIB.Entities;

namespace AIT_LABO_002.LIB.Services
{
    public class NICService
    {
        public static List<NIC> getAllNics()
        {
            List<NIC> nics = new List<NIC>();
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                NIC nwkaart = new NIC(nic);
                nics.Add(nwkaart);
                
            }
            return nics;
        }
    }
}
