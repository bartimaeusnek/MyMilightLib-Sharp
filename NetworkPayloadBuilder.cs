namespace com.github.bartimaeusnek.MyMilightLib;

using System;
using System.Collections.Generic;

public class NetworkPayloadBuilder
{
    private bool _commandWasAdded;
    private List<byte> _payload = new List<byte>();
    private byte[] _result = null!;
    
    public NetworkPayloadBuilder AddBasicCommand(BasicCommands command)
    {
        CheckIfWasBuild();
        _payload.Add((byte)command);
        _commandWasAdded = true;
        return this;
    }

    private void CheckIfWasBuild()
    {
        if (_result != null)
        {
            throw new Exception("Already Build!");
        }
    }

    public NetworkPayloadBuilder AddICommandValue(byte value)
    {
        CheckIfWasBuild();
        if (!_commandWasAdded)
            throw new Exception("You need to add a command fist!");
        _payload.Add(value);
        _commandWasAdded = false;
        return this;
    }

    public NetworkPayloadBuilder AddICommandValue<T>(T value) where T : Enum
    {
#if NET6_0
        return AddICommandValue(System.Runtime.CompilerServices.Unsafe.As<T, byte>(ref value));
#elif NETSTANDARD2_0
        return AddICommandValue((byte) (object) value);
#endif
    }

    public byte[] Build()
    {
        if (_commandWasAdded)
            AddICommandValue(CommandValue.None);

        if (_result != null)
            return _result;

        _result = _payload.ToArray();
        _payload = null;
        return _result;
    }
}