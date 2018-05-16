using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch03_StacksAndQueues
{
    public class P3_6_AnimalShelter
    {
        //implement an animal shelter where there are only dogs and cats,
        //you can only request fifo animal, fifo cat or fifo dog,
        //use linked list to implement queue

        AnimalNode catListHead;
        AnimalNode dogListHead;
        long orderOfEntry = 0;

        public void EnqueueCat(string name)
        {
            if (catListHead == null)
            {
                catListHead = new AnimalNode() { Name = name, OrderOfEntry = orderOfEntry };
                orderOfEntry++;
                return;
            }

            var lastCat = catListHead;
            while (lastCat.Next != null)
                lastCat = lastCat.Next;

            lastCat.Next = new AnimalNode() { Name = name, OrderOfEntry = orderOfEntry };
            orderOfEntry++;
        }

        public void EnqueueDog(string name)
        {
            if (dogListHead == null)
            {
                dogListHead = new AnimalNode() { Name = name, OrderOfEntry = orderOfEntry };
                orderOfEntry++;
                return;
            }

            var lastDog = dogListHead;
            while (lastDog.Next != null)
                lastDog = lastDog.Next;

            lastDog.Next = new AnimalNode() { Name = name, OrderOfEntry = orderOfEntry };
            orderOfEntry++;
        }

        public AnimalNode DequeueAnimal()
        {
            if (catListHead == null)
                return DequeueDog();

            if (dogListHead == null)
                return DequeueCat();

            if (dogListHead.OrderOfEntry < catListHead.OrderOfEntry)
                return DequeueDog();
            
            return DequeueCat();
        }

        public AnimalNode DequeueCat()
        {
            if (catListHead == null)
                return null;

            var fifoAnimal = catListHead;
            catListHead = catListHead.Next;
            return fifoAnimal;
        }

        public AnimalNode DequeueDog()
        {
            if (dogListHead == null)
                return null;

            var fifoAnimal = dogListHead;
            dogListHead = dogListHead.Next;
            return fifoAnimal;
        }

    }

    public class AnimalNode
    {
        public string Name { get; set; }
        public long OrderOfEntry { get; set; }
        public AnimalNode Next { get; set; }
    }
}
