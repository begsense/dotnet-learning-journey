namespace Assignment9_LINQ.Models;

public enum LogEntryStatus
{
    Success,
    Failed,
    Blocked
}

internal class NetworkLog
{
    public long LogId { get; set; }
    public DateTime Timestamp { get; set; }
    public string SourceIP { get; set; }
    public string DestinationIP { get; set; }
    public int Port { get; set; }
    public string Protocol { get; set; }
    public LogEntryStatus Status { get; set; }
    public int DataTransferredKB { get; set; }
    public List<string> ErrorCodes { get; set; }

    public NetworkLog(long logId, DateTime timestamp, string sourceIp, string destinationIp, int port, string protocol, LogEntryStatus status, int dataTransferredKb, List<string> errorCodes)
    {
        LogId = logId;
        Timestamp = timestamp;
        SourceIP = sourceIp;
        DestinationIP = destinationIp;
        Port = port;
        Protocol = protocol;
        Status = status;
        DataTransferredKB = dataTransferredKb;
        ErrorCodes = errorCodes;
    }
}
