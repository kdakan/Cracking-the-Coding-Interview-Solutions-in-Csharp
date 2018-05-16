using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using CrackingTheCodingInterview6thEd.Ch03_StacksAndQueues;

namespace Tests
{
    [TestClass]
    public class Ch03_StacksAndQueuesTests
    {
        [TestMethod]
        public void P3_1_ThreeInOne_Test()
        {
            var threeStacksInOne = new P3_1_ThreeInOne(5);
            threeStacksInOne.Push(1, 0);
            threeStacksInOne.Push(2, 0);
            threeStacksInOne.Push(3, 0);
            threeStacksInOne.Push(4, 0);
            threeStacksInOne.Push(5, 0);
            //threeStacksInOne.Push(6, 0);

            threeStacksInOne.Push(11, 1);
            threeStacksInOne.Push(22, 1);
            threeStacksInOne.Push(33, 1);
            threeStacksInOne.Push(44, 1);
            threeStacksInOne.Push(55, 1);

            threeStacksInOne.Push(111, 2);
            threeStacksInOne.Push(222, 2);
            threeStacksInOne.Push(333, 2);
            threeStacksInOne.Push(444, 2);
            threeStacksInOne.Push(555, 2);

            Assert.AreEqual(threeStacksInOne.Pop(0), 5);
            Assert.AreEqual(threeStacksInOne.Pop(0), 4);
            Assert.AreEqual(threeStacksInOne.Pop(0), 3);
            Assert.AreEqual(threeStacksInOne.Pop(0), 2);
            Assert.AreEqual(threeStacksInOne.Pop(0), 1);

            Assert.AreEqual(threeStacksInOne.Pop(1), 55);
            Assert.AreEqual(threeStacksInOne.Pop(1), 44);
            Assert.AreEqual(threeStacksInOne.Pop(1), 33);
            Assert.AreEqual(threeStacksInOne.Pop(1), 22);
            Assert.AreEqual(threeStacksInOne.Pop(1), 11);

            Assert.AreEqual(threeStacksInOne.Pop(2), 555);
            Assert.AreEqual(threeStacksInOne.Pop(2), 444);
            Assert.AreEqual(threeStacksInOne.Pop(2), 333);
            Assert.AreEqual(threeStacksInOne.Pop(2), 222);
            Assert.AreEqual(threeStacksInOne.Pop(2), 111);
        }

        [TestMethod]
        public void P3_2_StackMin_Test()
        {
            var stackWithMin = new P3_2_StackMin();
            stackWithMin.Push(5);
            Assert.AreEqual(stackWithMin.GetMin(), 5);
            stackWithMin.Push(6);
            Assert.AreEqual(stackWithMin.GetMin(), 5);
            stackWithMin.Push(3);
            Assert.AreEqual(stackWithMin.GetMin(), 3);
            stackWithMin.Push(7);
            Assert.AreEqual(stackWithMin.GetMin(), 3);
            stackWithMin.Pop();
            Assert.AreEqual(stackWithMin.GetMin(), 3);
            stackWithMin.Pop();
            Assert.AreEqual(stackWithMin.GetMin(), 5);
        }

        [TestMethod]
        public void P3_4_QueueWithStacks_Test()
        {
            var queueUsingTwoStacks = new P3_4_QueueWithStacks();
            queueUsingTwoStacks.Enqueue(1);
            queueUsingTwoStacks.Enqueue(2);
            queueUsingTwoStacks.Enqueue(3);
            queueUsingTwoStacks.Enqueue(4);
            Assert.AreEqual(queueUsingTwoStacks.Dequeue(), 1);
            Assert.AreEqual(queueUsingTwoStacks.Dequeue(), 2);
            Assert.AreEqual(queueUsingTwoStacks.Dequeue(), 3);
            Assert.AreEqual(queueUsingTwoStacks.Dequeue(), 4);
        }

        [TestMethod]
        public void P3_5_SortStack_Test()
        {
            var sortedStackUsingTwoStacks = new P3_5_SortStack();
            sortedStackUsingTwoStacks.Push(3);
            sortedStackUsingTwoStacks.Push(1);
            sortedStackUsingTwoStacks.Push(2);
            sortedStackUsingTwoStacks.Push(4);
            Assert.AreEqual(sortedStackUsingTwoStacks.Pop(), 1);
            Assert.AreEqual(sortedStackUsingTwoStacks.Pop(), 2);
            Assert.AreEqual(sortedStackUsingTwoStacks.Pop(), 3);
            Assert.AreEqual(sortedStackUsingTwoStacks.Pop(), 4);
        }

        [TestMethod]
        public void P3_6_AnimalShelter_Test()
        {
            var animalShelter = new P3_6_AnimalShelter();
            animalShelter.EnqueueCat("cat1");
            animalShelter.EnqueueCat("cat2");
            animalShelter.EnqueueDog("dog1");
            animalShelter.EnqueueCat("cat3");
            animalShelter.EnqueueDog("dog2");

            Assert.AreEqual(animalShelter.DequeueAnimal().Name, "cat1");
            Assert.AreEqual(animalShelter.DequeueAnimal().Name, "cat2");
            Assert.AreEqual(animalShelter.DequeueAnimal().Name, "dog1");
            Assert.AreEqual(animalShelter.DequeueAnimal().Name, "cat3");
            Assert.AreEqual(animalShelter.DequeueAnimal().Name, "dog2");

            animalShelter.EnqueueCat("cat1");
            animalShelter.EnqueueCat("cat2");
            animalShelter.EnqueueDog("dog1");
            animalShelter.EnqueueCat("cat3");
            animalShelter.EnqueueDog("dog2");

            Assert.AreEqual(animalShelter.DequeueDog().Name, "dog1");
            Assert.AreEqual(animalShelter.DequeueDog().Name, "dog2");

            Assert.AreEqual(animalShelter.DequeueCat().Name, "cat1");
            Assert.AreEqual(animalShelter.DequeueCat().Name, "cat2");
            Assert.AreEqual(animalShelter.DequeueCat().Name, "cat3");
        }
    }
}