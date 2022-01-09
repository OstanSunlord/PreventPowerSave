using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImNotAFK.CoreElements
{
    public class SchedulerCollection : List<SchedulerItem>
    {
        public SchedulerCollection()
        {

        }
        public void Load(string json)
        {
            if (!string.IsNullOrEmpty(json))
            {
                List<SchedulerItem> schedulers = JsonConvert.DeserializeObject<List<SchedulerItem>>(json);
                Clear();
                AddRange(schedulers);
            }
        }

        public string GetConfigString()
        {
            return JsonConvert.SerializeObject(this);
        }

        internal void Override(List<SchedulerItem> schedulerItems)
        {
            Clear();
            AddRange(schedulerItems);
        }

        internal SchedulerItem GetSchedule(int hour)
        {
            return Find(x => x.Start <= hour && x.End > hour && !x.Canceled);
        }
    }
}
