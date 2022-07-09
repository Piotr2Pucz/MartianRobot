namespace RobotClassLibrary
{
    /// <summary>
    /// Base robot Class.
    /// </summary>
    public class Robot : IRobot
    {
        /// <summary>
        /// Robot current position Latitude.<br />The maximum resolution is limited by the maximum integer variable value and is 2,147,483,647.
        /// </summary>
        public int PositionX { get; set; } = 1;
        /// <summary>
        /// Robot current position Longitude.<br />The maximum resolution is limited by the maximum integer variable value and is 2,147,483,647.
        /// </summary>
        public int PositionY { get; set; } = 1;
        /// <summary>
        /// Robot current position Facing Direction.<br />Possible values: North, South, East, West
        /// </summary>
        public string FacingDirection { get; set; } = "North";
        /// <summary>
        /// Function responsible for robot movement.
        /// <param name="state">Instantiation of Class Robot contain current robot position.</param>
        /// <param name="marsTerrain">Instantiation of Class MarsTerrain, defined Mars terrain raster that the robot will navigate.</param>
        /// <param name="instruction">North, South, East, West</param>
        /// </summary>
        public Robot Move(Robot state, MarsTerrain marsTerrain, char instruction)
        {
            if (instruction.ToString() == "F")
            {
                if (state.FacingDirection == "North" && PositionY < marsTerrain.Y)
                {
                    state.PositionY++;
                }
                else if (state.FacingDirection == "South" && state.PositionY > 1)
                {
                    state.PositionY--;
                }
                else if (state.FacingDirection == "East" && PositionX < marsTerrain.X)
                {
                    state.PositionX++;
                }
                else if (state.FacingDirection == "West" && state.PositionX > 1)
                {
                    state.PositionX--;
                }
            }
            else if (instruction.ToString() == "L")
            {
                if (state.FacingDirection == "North")
                {
                    state.FacingDirection = "West";
                }
                else if (state.FacingDirection == "South")
                {
                    state.FacingDirection = "East";
                }
                else if (state.FacingDirection == "East")
                {
                    state.FacingDirection = "North";
                }
                else if (state.FacingDirection == "West")
                {
                    state.FacingDirection = "South";
                }
            }
            else if (instruction.ToString() == "R")
            {
                if (state.FacingDirection == "North")
                {
                    state.FacingDirection = "East";
                }
                else if (state.FacingDirection == "South")
                {
                    state.FacingDirection = "West";
                }
                else if (state.FacingDirection == "East")
                {
                    state.FacingDirection = "South";
                }
                else if (state.FacingDirection == "West")
                {
                    state.FacingDirection = "North";
                }
            }
            return state;
        }
    }
}