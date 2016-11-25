using Xunit;
using Graphs;
using System.Linq;
using System;
using System.Diagnostics;
using System.IO;
using DS.Utils;

namespace DSTests
{
    public class GraphTests
    {
        [Fact]
        public void Run_topologocal_sort()
        {
            var g = new DGraph<int>(6);
            g.AddEdge(2, 3);
            g.AddEdge(3, 1);
            g.AddEdge(5, 2);
            g.AddEdge(4, 0);
            g.AddEdge(4, 1);
            g.AddEdge(5, 0);
            
            var res = g.TopologicalSort();
            var str = string.Join(",", res);
            Debug.WriteLine(str);
            Assert.Equal(str, "4,5,0,2,3,1");
        }

        [Fact]
        public void Run_topological_sort_2()
        {
            var g = new DGraph<int>(8);
            g.AddEdge(5, 11);
            g.AddEdge(11, 2);
            g.AddEdge(11, 9);
            g.AddEdge(11, 10);
            g.AddEdge(7, 11);
            g.AddEdge(7, 8);
            g.AddEdge(8, 9);
            g.AddEdge(3, 8);
            g.AddEdge(3, 10);

            var res = g.TopologicalSort();
            var str = string.Join(",", res);
            Debug.WriteLine(str);
            Assert.Equal(str, "3,7,8,5,11,10,9,2");

        }

        [Fact]
        public void DGraph_has_cycle()
        {
            DGraph<int> g = null;
            using (var reader = File.OpenText(@"C:\rajiv\DSinCS\DataStructures\DSTests\graph1.txt"))
                while (!reader.EndOfStream)
                {
                    var V = uint.Parse(reader.ReadLine().Trim());
                    g = new DGraph<int>(V);
                    while (!reader.EndOfStream)
                    {
                        var inp = reader.ReadLine().Split(new char[] { ' ' }).Select(int.Parse).ToArray();
                        g.AddEdge(inp[0], inp[1]);
                    }
                }
            foreach (var e in g.BfsPathTo(0, 9))
            {
                Console.WriteLine($"{e} ");
            }
            foreach (var e in g.DfsPathTo(0, 4))
            {
                Console.WriteLine($"{e} ");
            }
            Console.WriteLine($"check cycle from a node 7 :{g.HasCycle(7)}");
            Console.WriteLine($"check cycle from a node 0 :{g.HasCycle(0)}");
            foreach (var e in g.DfsPathToNon(0, 4))
            {
                Console.WriteLine($"{e} ");
            }
        }

        [Fact]
        public void Find_shortest_path_in_graph()
        {
            
            using (var reader = File.OpenText(@"C:\rajiv\DSinCS\DataStructures\DSTests\Data\tinyEWD.txt"))
            {
                var V = uint.Parse(reader.ReadLine());
                var g = new DGraph<int>(V);
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if(line == null) { continue; }
                    var inp = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var u = int.Parse(inp[0]);
                    var v = int.Parse(inp[1]);
                    var w = float.Parse(inp[2]);
                    g.AddEdge(u, v, w);
                }
                var res = g.ShortestPathTree(0);
                Assert.Equal(res[0], 0);
                Assert.Equal(res[1], (float)1.05);
                Assert.Equal(res[2], (float)0.26);
                Assert.Equal(res[3], (float)0.99);
                Assert.Equal(res[4], (float)0.38);
                Assert.Equal(res[5], (float)0.73);
                Assert.Equal(res[6], (float)1.51);
                Assert.Equal(res[7], (float)0.6);

            }
        }

        [Fact]
        public void Find_connected_componenets()
        {
            UGraph<int> g;
            using (var sr = File.OpenText(@"C:\rajiv\DSinCS\DataStructures\DSTests\Data\tinyG.txt"))
            {
                var v = UInt32.Parse(sr.ReadLine());
                sr.ReadLine();
                g = new UGraph<int>(v);
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    if(line == null) { continue; }

                    var nums = line.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();
                    g.AddEdge(nums[0], nums[1]);
                }
            }
            var res = g.FindCC();
            Assert.Equal(res.Count, 3);
            Assert.Equal("0,1,2,3,4,5,6", string.Join(",", res[0].Sort()));
            Assert.Equal("7,8", string.Join(",", res[2].Sort()));
            Assert.Equal("9,10,11,12", string.Join(",", res[1].Sort()));
        }

        [Fact]
        public void MST_via_kruskals()
        {
            using (var reader = File.OpenText(@"C:\rajiv\DSinCS\DataStructures\DSTests\Data\tinyEWD.txt"))
            {
                var V = uint.Parse(reader.ReadLine());
                var g = new DGraph<int>(V);
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line == null) { continue; }
                    var inp = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var u = int.Parse(inp[0]);
                    var v = int.Parse(inp[1]);
                    var w = float.Parse(inp[2]);
                    g.AddEdge(u, v, w);
                }
                var res = g.MST_Kruskal();
                

            }
        }
    }
}
