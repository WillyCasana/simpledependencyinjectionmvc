namespace WazeCredit.Service.LifeTimeExample;

public class ScopeService
{
    private readonly Guid guid;

    public ScopeService()
    {
        guid = Guid.NewGuid();
    }
    public string GetGuid() => guid.ToString();
}
