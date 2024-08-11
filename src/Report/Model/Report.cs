namespace WebApi.Report.Model;

public enum ReportState
{
    REPORTED,   // Started
    REJECTED,   // Finished (but not delivered)
    APPROVED,   // Waiting to be delivered
    DELIVERING, // In progress
    DELIVERED,  // Finished
}

public enum ReportType
{
    PROBLEM,
    SUGGESTION
}

public record Localization(int Latitude, int Longitude);

public class Report
{
    // Report unique identifier
    public Guid Id { get; private set; }
    // Reporter
    public int UserId { get; private set; }

    // Report information
    public ReportType Type { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Localization Localization { get; private set; }

    // Report state
    public ReportState State { get; private set; } = ReportState.REPORTED;
}

public class RejectedReport
{
    // Additional information
    public int ReportId { get; private set; }
    public string Reason { get; private set; }
}