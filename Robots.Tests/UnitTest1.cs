using System;
using Xunit;
using Robots;

namespace Robots.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Grid g = new Grid(5, 3);
            Robot r = new Robot(1,1, Orientation.E);
            CommandSet c = new CommandSet("RFRFRFRF");
            r.Go(c.CommandList, g);
            Assert.Equal("1 1 E", r.GetResultString());
        }

        [Fact]
        public void Test2()
        {
            Grid g = new Grid(5, 3);
            Robot r = new Robot(1, 1, Orientation.E);
            CommandSet c = new CommandSet("RFRFRFRF");
            r.Go(c.CommandList, g);
            Assert.Equal("1 1 E", r.GetResultString());

            r = new Robot(3, 2, Orientation.N);
            c = new CommandSet("FRRFLLFFRRFLL");
            r.Go(c.CommandList, g);
            Assert.Equal("3 3 N LOST", r.GetResultString());

        }

        [Fact]
        public void Test3()
        {
            Grid g = new Grid(5, 3);
            Robot r = new Robot(1, 1, Orientation.E);
            CommandSet c = new CommandSet("RFRFRFRF");
            r.Go(c.CommandList, g);
            Assert.Equal("1 1 E", r.GetResultString());

            r = new Robot(3, 2, Orientation.N);
            c = new CommandSet("FRRFLLFFRRFLL");
            r.Go(c.CommandList, g);
            Assert.Equal("3 3 N LOST", r.GetResultString());

            r = new Robot(0, 3, Orientation.W);
            c = new CommandSet("LLFFFLFLFL");
            r.Go(c.CommandList, g);
            Assert.Equal("2 3 S", r.GetResultString());
        }

        [Fact]
        public void Test4()
        {

            Grid g = new Grid(1, 1);
            
            Robot r = new Robot(0, 0, Orientation.W);
            CommandSet c = new CommandSet("F");
            r.Go(c.CommandList, g);
            Assert.Equal("0 0 W LOST", r.GetResultString());

            r = new Robot(0, 0, Orientation.W);
            c = new CommandSet("LF");
            r.Go(c.CommandList, g);
            Assert.Equal("0 0 S", r.GetResultString());

        }
    }
}
