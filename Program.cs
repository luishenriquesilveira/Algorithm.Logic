
namespace Algorithm.Logic
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Program
    {
        /// </summary>
        /// <param name="input">String no padrão "N1N2S3S4L5L6O7O8X"</param>
        /// <returns>String representando o ponto cartesiano após a execução dos comandos (X, Y)</returns>
        public static string Evaluate(string input)
        {
            try
            {
                //TODO: RNs

                return CalculateDronePosition(input);
            }
            catch
            {
                return "(999, 999)";
            }
        }

        private static string CalculateDronePosition(string input)
        {
            int x = 0;
            int y = 0;
            int cancelOperation = 0;

            MatchCollection operations = Regex.Matches(input, "[NSLOX](?>[0-9]*)");

            foreach (Match operation in operations.Cast<Match>().Reverse())
            {
                if (operation.Value.Substring(0, 1).Equals("X"))
                {
                    cancelOperation++;
                }
                else if (cancelOperation > 0)
                {
                    cancelOperation--;
                }
                else
                {
                    switch (operation.Value.Substring(0, 1))
                    {
                        case "N":
                            y =+ (operation.Value.Length > 1 ? Convert.ToInt32(operation.Value) : 0);
                            break;
                        case "S":
                            y =- (operation.Value.Length > 1 ? Convert.ToInt32(operation.Value) : 0);
                            break;
                        case "L":
                            x =+ (operation.Value.Length > 1 ? Convert.ToInt32(operation.Value) : 0);
                            break;
                        case "O":
                            x =- (operation.Value.Length > 1 ? Convert.ToInt32(operation.Value) : 0);
                            break;
                    }
                }
            }
            return String.Format("({0}, {1})", x, y);
        }
    }
}
