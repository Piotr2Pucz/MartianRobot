using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RobotClassLibrary.Tests
{
    /// <summary>
    /// A test Class responsible for testing Move function in Robot base class.
    /// </summary>
    [TestClass()]
    public class RobotTests
    {
        /// <summary>
        /// Default (start) position test.<br />The robot will always start at X: 1, Y: 1 facing NORTH.
        /// </summary>
        [TestMethod()]
        public void DefaultPositionTest()
        {
            Robot robot = new();
            Assert.AreEqual(robot.PositionX, 1);
            Assert.AreEqual(robot.PositionY, 1);
            Assert.AreEqual(robot.FacingDirection, "North");
        }


        /// <summary>
        /// Move Forward test.
        /// </summary>
        [TestMethod()]
        public void MoveForwardTest()
        {
            MarsTerrain terrain = new(5, 5);
            Robot robot = new();
            char charToCheck = char.Parse("F");
            robot = robot.Move(robot, terrain, charToCheck);
            Assert.AreEqual(robot.PositionX, 1);
            Assert.AreEqual(robot.PositionY, 2);
            Assert.AreEqual(robot.FacingDirection, "North");
        }

        /// <summary>
        /// Turn Right test.
        /// </summary>
        [TestMethod()]
        public void TurnRightTest()
        {
            MarsTerrain terrain = new(5, 5);
            Robot robot = new();
            char charToCheck = char.Parse("R");
            robot = robot.Move(robot, terrain, charToCheck);
            Assert.AreEqual(robot.PositionX, 1);
            Assert.AreEqual(robot.PositionY, 1);
            Assert.AreEqual(robot.FacingDirection, "East");
        }

        /// <summary>
        /// Turn Left test.
        /// </summary>
        [TestMethod()]
        public void TurnLeftTest()
        {
            MarsTerrain terrain = new(5, 5);
            Robot robot = new();
            char charToCheck = char.Parse("L");
            robot = robot.Move(robot, terrain, charToCheck);
            Assert.AreEqual(robot.PositionX, 1);
            Assert.AreEqual(robot.PositionY, 1);
            Assert.AreEqual(robot.FacingDirection, "West");
        }

        /// <summary>
        /// Test if robot ignore Longitude limit.
        /// </summary>
        [TestMethod()]
        public void IgnoreYLimitTest()
        {
            MarsTerrain terrain = new(5, 5);
            Robot robot = new();
            char charToCheck = char.Parse("F");
            for (int i = 0; i < 10; i++)
            {
                robot = robot.Move(robot, terrain, charToCheck);
            }
            Assert.AreEqual(robot.PositionX, 1);
            Assert.AreEqual(robot.PositionY, 5);
            Assert.AreEqual(robot.FacingDirection, "North");
        }

        /// <summary>
        /// Test if robot ignore Latitude limit.
        /// </summary>
        [TestMethod()]
        public void IgnoreXLimitTest()
        {
            MarsTerrain terrain = new(5, 5);
            Robot robot = new();
            char charToCheck = char.Parse("R");
            robot = robot.Move(robot, terrain, charToCheck);
            charToCheck = char.Parse("F");
            for (int i = 0; i < 10; i++)
            {
                robot = robot.Move(robot, terrain, charToCheck);
            }
            Assert.AreEqual(robot.PositionX, 5);
            Assert.AreEqual(robot.PositionY, 1);
            Assert.AreEqual(robot.FacingDirection, "East");
        }

        /// <summary>
        /// Test if robot fallow complex commands correctly.
        /// </summary>
        [TestMethod()]
        public void MultipleCommandsTest()
        {
            MarsTerrain terrain = new(5, 5);
            Robot robot = new();
            string multipleCommands = "FFRFLFLF";
            foreach (char command in multipleCommands)
            {
                robot = robot.Move(robot, terrain, command);
            }
            Assert.AreEqual(robot.PositionX, 1);
            Assert.AreEqual(robot.PositionY, 4);
            Assert.AreEqual(robot.FacingDirection, "West");
        }
        /// <summary>
        /// Test 360 degree rotation left and right.
        /// </summary>
        [TestMethod()]
        public void FullRottationTest()
        {
            MarsTerrain terrain = new(5, 5);
            Robot robot = new();
            string multipleCommands = "RRRRLLLL";
            foreach (char command in multipleCommands)
            {
                robot = robot.Move(robot, terrain, command);
            }
            Assert.AreEqual(robot.PositionX, 1);
            Assert.AreEqual(robot.PositionY, 1);
            Assert.AreEqual(robot.FacingDirection, "North");
        }
        /// <summary>
        /// Test Move Forward And Backward.
        /// After this test all possible cases are tested.
        /// </summary>
        [TestMethod()]
        public void MoveForwardAndBackwardTest()
        {
            MarsTerrain terrain = new(5, 5);
            Robot robot = new();
            string multipleCommands = "FFRRFFRRRFFLFFLLFFRFFR";
            foreach (char command in multipleCommands)
            {
                robot = robot.Move(robot, terrain, command);
            }
            Assert.AreEqual(robot.PositionX, 1);
            Assert.AreEqual(robot.PositionY, 1);
            Assert.AreEqual(robot.FacingDirection, "North");
        }
    }
}