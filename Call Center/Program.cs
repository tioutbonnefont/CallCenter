using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Call_Center
{
    class Program
    {
        public class Call
        {
            public int ID { get; set; }
            public DateTime Calltime { get; set; }
            public DateTime Answertime { get; set; }
            public DateTime Endtime { get; set; }
            public int priority { get; set; }
        }

        public class Callcenter
        {
            public Queue<Call> Calls { get; set; }
            public int counter = 0;
            public string name;
            public Callcenter(string name)
            {
                this.Calls = new Queue<Call>();
                this.name = name;
            }
            public void Call(int ID,int priority)
            {
                Call call = new Call();
                call.Calltime = DateTime.Now;
                call.ID = ID;
                call.priority = priority;
                counter++;
                if (call.priority == 0)
                { this.Calls.Enqueue(call); }
                if(call.priority==1)
                {
                    Queue<Call> appels = new Queue<Call>();
                    List<Call> appelss = new List<Call>();
                    for(int i=0;i<this.Calls.Count;i++)
                    {
                        appelss.Add(this.Calls.Dequeue());
                    }
                    int j = 0;
                    while(appelss[j].priority==1)
                    {
                        appels.Enqueue(appelss[j]);
                        j++;
                    }
                    appels.Enqueue(call);
                    while(this.Calls.Count!=0)
                    {
                        appels.Enqueue(appelss[j]);
                        j++;
                    }
                    this.Calls = appels;
                }
                Console.WriteLine("["+call.Calltime+"]" +" ID : " + call.ID + ", is calling");
            }
            public void Answer()
            {
                Call call= Calls.Dequeue();
                call.Answertime = DateTime.Now;
                Console.WriteLine(this.name + " replied the client : " + call.ID + " at : " + call.Answertime);
            }
        }

        static void Main(string[] args)
        {
            Callcenter CL = new Callcenter("Martin");
            CL.Call(12,0);
            CL.Call(123,1);
            CL.Call(67,0);
            CL.Call(3456,0);
            CL.Call(097,1);
            Console.ReadLine();
            CL.Answer();
            Console.ReadLine();
            CL.Answer();
            Console.ReadLine();
            CL.Answer();
            Console.ReadLine();
            CL.Answer();
            Console.ReadLine();
            CL.Answer();
            Console.ReadKey();
        }
    }
}
