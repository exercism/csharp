static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        var worksAt = department?.ToUpper() ?? "OWNER";

        if (id == null)
        {
            return $"{name} - {worksAt}";
        }

        return $"[{id}] {name} - {worksAt}";
    }
}
