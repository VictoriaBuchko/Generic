using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    public class Patient
    {
        public string Name { get; }
        public int Priority { get; }

        public Patient(string name, int priority)
        {
            Name = name;
            Priority = priority;
        }
    }

    public class Clinic
    {
        private PriorityQueue<Patient, int> queue = new PriorityQueue<Patient, int>();
        private const int MaxQueueSize = 3;

        public void Run()
        {
            List<string> patientNames = new List<string> { "Анна", "Богдан", "Віктор", "Галина", "Денис" };

            foreach (string name in patientNames)
            {
                AddPatient(name);
                ServePatient();
            }

            Console.WriteLine("Усі пацієнти пройшли прийом.");
        }

        private void AddPatient(string name)
        {
            if (queue.Count < MaxQueueSize)
            {
                var patient = new Patient(name, queue.Count + 1);
                queue.Enqueue(patient, patient.Priority);
                Console.WriteLine($"{patient.Name} доданий до черги");
            }
            else
            {
                Console.WriteLine("Черга заповнена. Пацієнт потрапляє в кінець черги.");
                var patient = new Patient(name, MaxQueueSize + 1);
                queue.Enqueue(patient, patient.Priority);
            }
        }

        private void ServePatient()
        {
            if (queue.Count > 0)
            {
                var patient = queue.Dequeue();
                Console.WriteLine($"Лікар приймає пацієнта: {patient.Name}");
                Thread.Sleep(2000);
                Console.WriteLine($"Пацієнт {patient.Name} покинув лікаря");
            }
        }
    }
}