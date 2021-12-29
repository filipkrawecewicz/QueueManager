using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    internal class QueueManager
    {
        private SortedDictionary<DateOnly, List<Appointment>> queue;

        public void Add(Appointment appointment)
        {
            DateOnly date = appointment.AppointmentDate;
            var dayQueuePair = queue.FirstOrDefault(kv => kv.Key.Equals(date), KeyValuePair.Create(date, new List<Appointment>()));
            dayQueuePair.Value.Add(appointment);
        }
    }
}
