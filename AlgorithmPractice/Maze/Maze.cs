using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmPractice
{
    public class Maze
    {
        public static List<MazePosition> FindFirstShortestPathBreadthFirst(MazePosition start, MazePosition end, char[][] maze, MazePosition mazeMax)
        {
            if (maze[start.Y][start.X] != 'S')
                throw new Exception("Starting maze location should hold value of S.");

            if (maze[end.Y][end.X] != 'E')
                throw new Exception("Ending maze location should hold value of E.");

            List<MazePosition> firstFoundPath = null;
            var initialPathSoFar = new List<MazePosition>();
            //use breadth first search and return first found path
            var queueToVisit = new Queue<QueueItemToVisit>();
            queueToVisit.Enqueue(new QueueItemToVisit(new List<MazePosition>(initialPathSoFar), new MazePosition(start.X - 1, start.Y)));
            queueToVisit.Enqueue(new QueueItemToVisit(new List<MazePosition>(initialPathSoFar), new MazePosition(start.X + 1, start.Y)));
            queueToVisit.Enqueue(new QueueItemToVisit(new List<MazePosition>(initialPathSoFar), new MazePosition(start.X, start.Y - 1)));
            queueToVisit.Enqueue(new QueueItemToVisit(new List<MazePosition>(initialPathSoFar), new MazePosition(start.X, start.Y + 1)));

            while (queueToVisit.Count != 0 && firstFoundPath == null)
                visit(queueToVisit.Dequeue(), maze, mazeMax, queueToVisit, ref firstFoundPath);

            return firstFoundPath;
        }

        private static void visit(QueueItemToVisit queueItemToVisit, char[][] maze, MazePosition mazeMax, Queue<QueueItemToVisit> queueToVisit, ref List<MazePosition> firstFoundPath)
        {
            var pos = queueItemToVisit.PositionToVisit;
            var pathSoFar = queueItemToVisit.PathSoFar;

            if (pos.X < 0 || pos.Y < 0 || pos.X > mazeMax.X || pos.Y > mazeMax.Y)
                return;

            if (maze[pos.Y][pos.X] == 'E')//end
            {
                pathSoFar.Add(pos);
                firstFoundPath = pathSoFar;
                return;
            }

            if (maze[pos.Y][pos.X] != ' ')//empty
                return;

            maze[pos.Y][pos.X] = 'V';//mark visited
            pathSoFar.Add(pos);

            queueToVisit.Enqueue(new QueueItemToVisit(new List<MazePosition>(pathSoFar), new MazePosition(pos.X - 1, pos.Y)));
            queueToVisit.Enqueue(new QueueItemToVisit(new List<MazePosition>(pathSoFar), new MazePosition(pos.X + 1, pos.Y)));
            queueToVisit.Enqueue(new QueueItemToVisit(new List<MazePosition>(pathSoFar), new MazePosition(pos.X, pos.Y - 1)));
            queueToVisit.Enqueue(new QueueItemToVisit(new List<MazePosition>(pathSoFar), new MazePosition(pos.X, pos.Y + 1)));

        }



    }

    public class MazePosition
    {
        public int X { get; set; }
        public int Y { get; set; }

        public MazePosition(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class QueueItemToVisit
    {
        public List<MazePosition> PathSoFar { get; set; }
        public MazePosition PositionToVisit { get; set; }

        public QueueItemToVisit(List<MazePosition> pathSoFar, MazePosition positionToVisit)
        {
            PathSoFar = pathSoFar;
            PositionToVisit = positionToVisit;
        }
    }
}