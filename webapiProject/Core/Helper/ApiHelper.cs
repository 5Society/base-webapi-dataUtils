using System.Net.Sockets;
using System.Net;

namespace webapiProject.Core.Helper;

/// <summary>
/// Api utilities 
/// </summary>
public static class ApiHelper
{
    /// <summary>
    /// Get hostname ip address
    /// </summary>
    /// <returns>Return ip v4 of the hostname, other case empty</returns>
    public static string GetIpAddress()
    {
        IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
            if (ip.AddressFamily.Equals(AddressFamily.InterNetwork))
                return ip.ToString();
        return string.Empty;
    }
}
