namespace com.github.bartimaeusnek.MyMilightLib;

using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

public class NetworkingThread
{
    private static readonly SemaphoreSlim SemaphoreSlim = new SemaphoreSlim(1, 1);
    private String _ip;
    private byte[] _payload;
    private int _port;

    private NetworkingThread(String ip, int port, byte[] payload)
    {
        _ip = ip;
        _port = port;
        _payload = payload;
    }

    public static async Task SendPayloadTo(String ip, int port, NetworkPayloadBuilder builder, CancellationToken cancellationToken = default)
    {
        await SemaphoreSlim.WaitAsync(cancellationToken);
        using var udp = new UdpClient();
        udp.Connect(ip, port);
#if NET6_0
        await udp.SendAsync(builder.Build(), cancellationToken);
#elif NETSTANDARD2_0
        byte[] build = builder.Build();
        await udp.SendAsync(build, build.Length);
#endif
        SemaphoreSlim.Release();
    }
}