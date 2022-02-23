using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusalaGatewayProject.Helpers
{
    public static class Helper
    {
        public static bool IsValidIpv4(string ipString)
        {
            if (string.IsNullOrWhiteSpace(ipString))
            {
                return false;
            }

            string[] splitValues = ipString.Split('.');
            if (splitValues.Length != 4)
            {
                return false;
            }

            byte tempVar;
            return splitValues.All(r => byte.TryParse(r, out tempVar));
        }
    }
}
