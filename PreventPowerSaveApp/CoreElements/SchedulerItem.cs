namespace PreventPowerSave.CoreElements
{
    public class SchedulerItem
    {
        public string Title { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public bool Canceled { get; set; } = false;

    }
}