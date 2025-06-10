namespace gradeTracker.Models;

public class GradeEntry
{
    public int Id { get; set; }
    public string StudentName { get; set; }
    public string AssignmentName { get; set; }
    public double Score { get; set; }
    public double TotalPossible { get; set; }

    // This property is calculated (not manually entered)
    public double Percentage => TotalPossible > 0 ? (Score / TotalPossible) * 100 : 0;
}