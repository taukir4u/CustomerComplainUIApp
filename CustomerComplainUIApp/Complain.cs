using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerComplainUIApp
{
    internal class Complain
    {
        public int serialNo;
        public string customerName;
        public string customerComplain;
    }

    class Complains
    {
        public int lastSerial = 1;
        public Queue<Complain> queCom = new Queue<Complain>();

        public void Add(Complain aComplain)
        {
            lastSerial++;
            queCom.Enqueue(aComplain);
        }
            
    }
}
