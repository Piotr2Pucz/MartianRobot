using RobotClassLibrary;
internal static class Program
{
    [STAThread]
    static void Main()
    {
        int width = 1;
        int length = 1;
        bool isCorrect = false;
        string allert = "Set";
        string? input = null;
        while (!isCorrect)
        {
            Console.WriteLine("{0} terrain width x length as a numbers between 1 and 2147483647" + Environment.NewLine + "such as 5x5, 3x4, etc.", allert);
            allert = "Input data error, please set again ";
            input = Console.ReadLine();
            if (input != null)
            {
                string[] surfeceArray = input.Split("x");
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
        isCorrect = false;
        allert = "Set";
        while (!isCorrect)
        {
            Console.WriteLine("{0} commands build using three letters:" + Environment.NewLine + "L: Turn the robot left" + Environment.NewLine + "R: Turn the robot right" + Environment.NewLine + "F: Move forward on it's facing direction" + Environment.NewLine + "Sample command string: LFLRFLFF", allert);
            allert = "Input data error, please set again ";
            input = Console.ReadLine();

            if (input != null && input.Length > 0 && input.ToUpper().Replace("L", "").Replace("R", "").Replace("F", "").Replace(" ", "").Length == 0) isCorrect = true;
        }

#pragma warning disable CS8602 // Dereference of a possibly null reference.
        string commands = input.ToUpper().Replace(" ", "");
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        MarsTerrain terrain = new(width, length);
        Robot robot = new();
        foreach (char command in commands)
        {
            robot = robot.Move(robot, terrain, command);
        }
        Console.WriteLine("{0},{1},{2}", robot.PositionX, robot.PositionY, robot.FacingDirection);
        Console.ReadKey();
    }
}