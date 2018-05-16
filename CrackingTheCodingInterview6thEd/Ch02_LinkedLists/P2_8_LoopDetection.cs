using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch02_LinkedLists
{
    public class P2_8_LoopDetection
    {
        public static Node FindStartingNodeOfCircularLoop(Node head)
        {
            //normal and double speed pointers meet at a special node K,
            //beginning of loop is equal distance from head and the node K 
            var normalSpeed = head;
            var doubleSpeed = head;
            var started = false;
            Node nodeK = null;
            while (doubleSpeed != null)
            {
                if (normalSpeed == doubleSpeed && started)
                {
                    nodeK = normalSpeed;
                    break;
                }

                normalSpeed = normalSpeed.Next;

                doubleSpeed = doubleSpeed.Next;
                if (doubleSpeed != null)
                    doubleSpeed = doubleSpeed.Next;

                started = true;
            }

            if (nodeK == null)
                return null;

            //when the pointer starting from head and nodeK meet, 
            //it is the loop beginning node, because it is equal distance to both of them
            var nodeS = head;
            while (nodeK != nodeS)
            {
                nodeS = nodeS.Next;
                nodeK = nodeK.Next;
            }

            return nodeS;
        }
    }
}
