using RobotClassLibrary;
internal static class Program
{
    [STAThread]
    static void Main()
    {
        // Latitude and Longitude holding variables used during validation.
        int width = 1;
        int length = 1;
        // Flag holding validation result. 
        bool isCorrect = false;
        // Variable using to change validation result message.
        string allert = "Set";
        // Variable holding  set input data by app user.
        string? input = null;
        /// <summary>
        /// Simple Mars plateau grid definition validation.<br />The maximum raster resolution is limited by the maximum integer variable value and is 2,147,483,647 x 2,147,483,647.<br />Input data are not sensitive to upper cases, can contain space, and comas as well.
        /// </summary>
        while (!isCorrect)
        {
            Console.WriteLine("{0} terrain width x length as a numbers between 1 and 2147483647" + Environment.NewLine + "such as 5x5, 3x4, etc.", allert);
            allert = "Input data error, please set again ";
            input = Console.ReadLine();
            if (input != null)
            {
                string[] surfeceArray = input.ToLower().Replace(" ","").Replace(",","").Split("x");
                if (surfeceArray.Length == 2)
                {
                    if (Int32.TryParse(surfeceArray[0], out _) && Int32.TryParse(surfeceArray[1], out _))
                    {
                        width = Convert.ToInt32(surfeceArray[0]);
                        length = Convert.ToInt32(surfeceArray[1]);
                        isCorrect = true;
                    }
                }
            }
        }
        // Validation variable reset, to start commands validation.
        isCorrect = false;
        allert = "Set";
        /// <summary>
        /// Simple commands validation.<br />As a commands we use sequence of letters:L,R,F.<br />Input data are not sensitive to upper cases, can contain space as well.
        /// </summary>
        while (!isCorrect)
        {
            Console.WriteLine("{0} commands build using three letters:" + Environment.NewLine + "L: Turn the robot left" + Environment.NewLine + "R: Turn the robot right" + Environment.NewLine + "F: Move forward on it's facing direction" + Environment.NewLine + "Sample command string: LFLRFLFF", allert);
            allert = "Input data error, please set again ";
            input = Console.ReadLine();

            if (input != null && input.Length > 0 && input.ToUpper().Replace("L", "").Replace("R", "").Replace("F", "").Replace(" ", "").Length == 0) isCorrect = true;
        }
#pragma warning disable CS8602 // Dereference of a possibly null reference. Because we use loop validation, visual studio not recognize situation that next step can be done only when input has value.
        string commands = input.ToUpper().Replace(" ", "");
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        /// <summary>
        /// We create instantiation of class MarsTerrain to keep defined grid.
        /// </summary>
        MarsTerrain terrain = new(width, length);
        /// <summary>
        /// We create instantiation of class MarsTerrain to keep defined grid.
        /// </summary>
        Robot robot = new();
        foreach (char command in commands)
        {
            robot = robot.Move(robot, terrain, command);
        }
        /// <summary>
        /// We printing print the final position.
        /// </summary>
        Console.WriteLine("{0},{1},{2}", robot.PositionX, robot.PositionY, robot.FacingDirection);
        /// <summary>
        /// This command stop app showing only final position, any other information are not showing to let user easer find a result.
        /// </summary>
        Console.ReadKey();
    }
}