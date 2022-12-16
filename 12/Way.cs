using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12
{
    internal class Way
    {
        public List<(int, int)> Path = new List<(int, int)>();
        public static char[,] Map;
        public bool Stopped = false;
        public bool Part2 = false;

        public Way()
        {
        }

        public void SetMap(char[,] map)
        {
            Map = map;
        }

        internal List<Way> Move()
        {
            if (Stopped)
            {
                return new List<Way>();
            }
            var getDirections = GetPossibleDirections(Path.Last());

            int i = 0;
            var lastPos = Path.Last();
            var newPath = new List<Way>();
            foreach (var direction in getDirections)
            {
                if (Path.Contains(direction))
                {
                    continue;
                }
                if (i == 0)
                {
                    Path.Add(direction);
                }
                else
                {
                    var way = new Way();
                    way.Path.AddRange(Path.Take(Path.Count() - 1));
                    way.Path.Add(direction);
                    way.Part2 = Part2;
                    newPath.Add(way);
                }
                i++;
            }

            if (Part2 && Path.Count() > 445)
            {
                Stopped = true;
            }
            if (Part2 && Map[Path.Last().Item1, Path.Last().Item2] == 'a')
            {
                Stopped = true;
            }
            if (lastPos == Path.Last() || Map[Path.Last().Item1, Path.Last().Item2] == 'E')
            {
                Stopped= true;
            }

            return newPath;
            //foreach (var path in newPath)
            //{
            //    path.Move();
            //}
        }

        private List<(int, int)> GetPossibleDirections((int, int) start)
        {
            var ways = new List<(int, int)>();
            if (start.Item1 - 1 >= 0)
            {
                if (CanGoHere(Map[start.Item1, start.Item2], Map[start.Item1 - 1, start.Item2]))
                {
                    ways.Add((start.Item1 - 1, start.Item2));
                }
            }
            if (start.Item2 + 1 < Map.GetLength(1))
            {
                if (CanGoHere(Map[start.Item1, start.Item2], Map[start.Item1, start.Item2 + 1]))
                {
                    ways.Add((start.Item1, start.Item2 + 1));
                }
            }
            if (start.Item1 + 1 < Map.GetLength(0))
            {
                if (CanGoHere(Map[start.Item1, start.Item2], Map[start.Item1 + 1, start.Item2]))
                {
                    ways.Add((start.Item1 + 1, start.Item2));
                }
            }
            if (start.Item2 - 1 >= 0)
            {
                if (CanGoHere(Map[start.Item1, start.Item2], Map[start.Item1, start.Item2 - 1]))
                {
                    ways.Add((start.Item1, start.Item2 - 1));
                }
            }
            return ways;
        }

        private bool CanGoHere(char from, char to)
        {
            if (from == 'S')
            {
                from = 'a';
            }
            if (to == 'E')
            {
                to = 'z';
            }
            //if (Part2)
            //{
            //    if (to == from || to - 1 == from)
            //    {
            //        return true;
            //    }
            //}
            //else
            {
                if (to <= from || to - 1 == from)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
