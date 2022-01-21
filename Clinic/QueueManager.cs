using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic
{
    internal class QueueManager
    {
        private SortedDictionary<DateOnly, List<Appointment>> queue = new SortedDictionary<DateOnly, List<Appointment>>();

        public void Add(Appointment appointment)
        {
            DateOnly date = appointment.AppointmentDate;
            var dayQueuePair = queue.FirstOrDefault(kv => kv.Key.Equals(date), KeyValuePair.Create(date, new List<Appointment>()));
            dayQueuePair.Value.Add(appointment);
        }

        public void Insert(int position, Appointment appointment)
        {
            DateOnly date = appointment.AppointmentDate;
            var dayQueuePair = queue.FirstOrDefault(kv => kv.Key.Equals(date), KeyValuePair.Create(date, new List<Appointment>()));
            dayQueuePair.Value.Insert(position, appointment);
        }

        public void Remove(Appointment appointment)
        {
            DateOnly date = appointment.AppointmentDate;
            var dayQueuePair = queue.FirstOrDefault(kv => kv.Key.Equals(date), KeyValuePair.Create(date, new List<Appointment>()));
            dayQueuePair.Value.Remove(appointment);
        }

        public List<Appointment> GetQueueFor(DateOnly date)
        {
            var dayQueuePair = queue.FirstOrDefault(kv => kv.Key.Equals(date), KeyValuePair.Create(date, new List<Appointment>()));
            return dayQueuePair.Value;
        }
    }
}
