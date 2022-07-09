namespace RobotClassLibrary
{
    /// <summary>
    /// An interface defines a Move robot function.
    /// </summary>
    // interface by default is public, but in this version (2022 vs) internal is using as a default access modifiers, this is a reason why if we want have access from unit-tests to this interface we need to put public before interface. When you delete it you will see only two reference to Move method instead 11 (9 references is to unit-tests).
    public interface IRobot
    {
        /// <summary>
        /// Function responsible for robot movement.
        /// <param name="state">Instantiation of Class Robot contain current robot position.</param>
        /// <param name="marsTerrain">Instantiation of Class MarsTerrain, defined Mars terrain raster that the robot will navigate.</param>
        /// <param name="instruction">North, South, East, West</param>
        /// </summary>
        Robot Move(Robot state, MarsTerrain marsTerrain, char instruction);
    }
}