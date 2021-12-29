using System;

namespace Clinic
{
    internal class Appointment
    {
        private string patientName;
        private DateOnly appointmentDate;
        private string testName;

        public DateOnly AppointmentDate { get { return appointmentDate; } set { appointmentDate = value; } }
        public string PatientName { get { return patientName; } set { patientName = value; } }

        public string TestName { get { return testName; } set { testName = value; } }
    }
}