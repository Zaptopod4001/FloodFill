using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Eses.FloodTest
{

    // Copyright Sami S.

    // use of any kind without a written permission 
    // from the author is not allowed.

    // DO NOT:
    // Fork, clone, copy or use in any shape or form.


    // NOTE: 
    // This class contains the flood fill 
    // algorithm

    public class FloodFill
    {
        int[,] arr;

        public FloodFill(int[,] arr)
        {
            this.arr = arr;
        }

        public Dictionary<(int, int), Cell> FloodFillArea(Vector2Int start, int kind)
        {
            // tables
            Dictionary<(int, int), Cell> walked = new Dictionary<(int, int), Cell>();
            Stack<Cell> toCheck = new Stack<Cell>();

            // start
            var checkPos = start;

            while (true)
            {
                var neighbors = GetNeighborsOfKind(checkPos.x, checkPos.y, 0);

                if (neighbors.Count > 0)
                {
                    foreach (var c in neighbors)
                    {
                        if (!walked.ContainsKey((c.pos.x, c.pos.y)))
                        {
                            walked.Add((c.pos.x, c.pos.y), c);
                            toCheck.Push(c);
                        }
                    }
                }

                if (toCheck.Count > 0)
                {
                    checkPos = toCheck.Pop().pos;
                }
                else
                {
                    return walked;
                }
            }
        }

        List<Cell> GetNeighborsOfKind(int x, int y, int kind)
        {
            List<Cell> neighbors = new List<Cell>();

            var cn = GetCell(x, y + 1);
            var ce = GetCell(x + 1, y);
            var cs = GetCell(x, y - 1);
            var cw = GetCell(x - 1, y);
            if (cn != null && cn.kind == kind) neighbors.Add(cn);
            if (ce != null && ce.kind == kind) neighbors.Add(ce);
            if (cs != null && cs.kind == kind) neighbors.Add(cs);
            if (cw != null && cw.kind == kind) neighbors.Add(cw);

            return neighbors;
        }

        Cell GetCell(int x, int y)
        {
            if (x >= 0 && x < arr.GetLength(1) && y >= 0 && y < arr.GetLength(0))
            {
                return new Cell() { pos = new Vector2Int(x, y), kind = arr[y, x] };
            }

            return null;
        }

    }


    public class Cell
    {
        public Vector2Int pos;
        public int kind;
    }

}