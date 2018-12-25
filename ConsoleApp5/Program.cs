using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Observable observable = new Observable();
            observable.addObservs(new MailSenderObserver());
            observable.addObservs(new FileLoggerObserver());
            observable.notify("Update");
        }
    }
    interface IObserver
    {
        void update(string info);
    }
    class FileLoggerObserver : IObserver
    {
        private const string path = "Log.txt";
        public void update(string info)
        {
            File.AppendAllText(path, info);
        }
    }
    class MailSenderObserver : IObserver
    {
        public void update(string info)
        {
            //send email
        }
    }
    class Observable
    {
        List<IObserver> observers = new List<IObserver>();
        public void addObservs(IObserver observer)
        {
            observers.Add(observer);
        }
        public void notify(string info)
        {
            foreach (var item in observers)
            {
                item.update(info);
            }
        }
    }
}