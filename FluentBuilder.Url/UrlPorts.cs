namespace FluentBuilder.Url;

internal static class UrlPorts
{
    private const ushort MinAllowed = 1;
    private const ushort MaxAllowed = 65535;

    public const ushort Http = 80;
    public const ushort Https = 443;

    public static ushort EnsurePortIsValid(this ushort port)
    {
        if (port is >= MinAllowed and <= MaxAllowed)
        {
            return port;
        }

        throw new ArgumentException($"Port should have value between {MinAllowed} and {MaxAllowed}");
    }
}