namespace Algorithm.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class ValidateOp
    {
        public bool validation; 
        public List<ValidOperations> list;
    }

    public class ValidOperations
    {
        public char direction;
        public Int32 steps;
    }

    public class Program
    {
        /// </summary>
        /// <param name="input">String no padrão "N1N2S3S4L5L6O7O8X"</param>
        /// <returns>String representando o ponto cartesiano após a execução dos comandos (X, Y)</returns>
        public static string Evaluate(string input)
        {
            try
            {
                //Input NULL
                if (input == null)
                {
                    return "(999, 999)";
                }
                //Input EMPTY/WHITESPACE
                if (input.Trim() == "")
                {
                    return "(999, 999)";
                }
                //Primeiro caractere do input deve ser uma direção [N, S, L, O]
                if (!ValidateFirstCharacter(input))
                {
                    return "(999, 999)";
                }
                //Input não deve possuir caracteres diferentes de [N, S, L, O, {0 - 9}]
                if (!ValidateCharacters(input))
                {
                    return "(999, 999)";
                }
                //Input não deve conter números maiores que o limite de um inteiro [2147483647]
                if (!ValidateIntegerLimit(input))
                {
                    return "(999, 999)";
                }
                //Input não deve conter o número zero [0] sozinho em nenhuma situação
                if (!ValidateNumberZero(input))
                {
                    return "(999, 999)";
                }
                //Input não deve conter repetições logo após um cancelamento [X123]
                if (!ValidateWrongRepeat(input))
                {
                    return "(999, 999)";
                }
                //Transforma input em um conjunto de operações
                MatchCollection operations = Regex.Matches(input, "[NSLOX](?>[0-9]*)");
                ValidateOp v = ValidateOperations(operations);
                if (!v.validation)
                {
                    return "(999, 999)";
                }
                return CalculateDronePosition(v.list);
            }
            catch
            {
                return "(999, 999)";
            }
        }

        private static string CalculateDronePosition(List<ValidOperations> operations)
        {
            Int32 x = 0;
            Int32 y = 0;

            foreach (ValidOperations operation in operations)
            {
                //Devido ao teste Input_N2147483647N, supõe-se que a posição do drone no plano cartesiano
                //não deve ultrapassar os limites de um inteiro em nenhum momento, então foi feita validação
                //para tal, sempre é validado o Overflow antes da operação
                //[Escolhi a forma que necessita de mais validações para me basear]
                //Obs.: Não faria sentido continuar com x/y Int32 devido a isso também.
                switch (operation.direction)
                {                    
                    case 'N':
                        if (!ValidateOverflow(y, operation.steps))
                        {
                            return "(999, 999)";
                        }
                        y += operation.steps;
                        break;
                    case 'S':
                        if (!ValidateOverflow(y, operation.steps * (-1)))
                        {
                            return "(999, 999)";
                        }
                        y -= operation.steps;
                        break;
                    case 'L':
                        if (!ValidateOverflow(x, operation.steps))
                        {
                            return "(999, 999)";
                        }
                        x += operation.steps;
                        break;
                    case 'O':
                        if (!ValidateOverflow(x, operation.steps  * (-1)))
                        {
                            return "(999, 999)";
                        }
                        x -= operation.steps;
                        break;
                }
            }
            return String.Format("({0}, {1})", x, y);
        }

        private static ValidateOp ValidateOperations(MatchCollection operations)
        {
            List<ValidOperations> validOperations = new List<ValidOperations>();

            foreach (Match operation in operations)
            {
                //O número de operações canceladas não deve ultrapassar o de operações existentes em nenhum momento
                if (operation.Value.Substring(0, 1).Equals("X") && validOperations.Count == 0)
                {
                    return new ValidateOp() { validation = false };
                }
                else if (operation.Value.Substring(0, 1).Equals("X") && validOperations.Count > 0)
                {
                    validOperations.RemoveAt(validOperations.Count - 1);
                }
                else
                {
                    validOperations.Add(new ValidOperations
                    {
                        direction = Convert.ToChar(operation.Value.Substring(0, 1)),
                        steps = operation.Value.Length > 1 ? Convert.ToInt32(operation.Value.Substring(1)) : 1
                    });
                }
            }
            //Retorno apenas com operações válidas
            return new ValidateOp()
            {
                validation = true,
                list = validOperations
            };
        }

        #region Business Rules
        private static bool ValidateFirstCharacter(string input)
        {
            Regex allowed = new Regex("[NSLO]");

            return allowed.IsMatch(input.Substring(0, 1));
        }

        private static bool ValidateCharacters(string input)
        {
            Regex allowed = new Regex("[NSLOX0-9]");

            return input.Length == allowed.Matches(input).Count;
        }

        private static bool ValidateIntegerLimit(string input)
        {
            Regex bigNumber = new Regex("[0-9]{10,}");

            MatchCollection bigNumbers = bigNumber.Matches(input);

            foreach (Match n in bigNumbers)
            {
                if (Convert.ToInt32(n.Value) > Int32.MaxValue)
                {
                    return false;
                }
            }
            return true;
        }

        private static bool ValidateNumberZero(string input)
        {
            Regex zero = new Regex("[NSLOX]+0([NSLOX]|$)");

            return !zero.IsMatch(input);
        }

        private static bool ValidateWrongRepeat(string input)
        {
            Regex wrongRepeat = new Regex("[X][0-9]");

            return !wrongRepeat.IsMatch(input);
        }

        private static bool ValidateOverflow(Int32 xy, Int32 steps)
        {
            Int64 overflow = Convert.ToInt64(xy) + Convert.ToInt64(steps);
            if (overflow > Int32.MaxValue || overflow < Int32.MinValue)
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
