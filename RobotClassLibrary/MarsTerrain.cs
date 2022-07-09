namespace RobotClassLibrary
{
    /// <summary>
    /// A Class represent Mars terrain raster that the robot will navigate.<br />The maximum raster resolution is limited by the maximum integer variable value and is 2,147,483,647 x 2,147,483,647.
    /// </summary>
    public class MarsTerrain
    {
        /// <summary>
        /// Mars terrain Latitude.<br />The maximum resolution is limited by the maximum integer variable value and is 2,147,483,647.
        /// </summary>
        public int X { get; }
        /// <summary>
        /// Mars terrain Longitude.<br />The maximum resolution is limited by the maximum integer variable value and is 2,147,483,647.
        /// </summary>
        public int Y { get; }
        /// <summary>
        /// Mars terrain raster constructor.<br />The maximum raster resolution is limited by the maximum integer variable value and is 2,147,483,647 x 2,147,483,647.
        /// <param name="x">Mars terrain Longitude.<br />The maximum resolution is limited by the maximum integer variable value and is 2,147,483,647.</param>
        /// <param name="y">Mars terrain Longitude.<br />The maximum resolution is limited by the maximum integer variable value and is 2,147,483,647.</param>
        /// </summary>

        public MarsTerrain(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}