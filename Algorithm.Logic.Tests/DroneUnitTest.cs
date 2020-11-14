using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithm.Logic.Tests
{
    [TestClass]
    public class DroneUnitTest
    {
        #region Unchanged Standard Tests
        [TestMethod]
        public void Input_NNNNNLLLLL()
        {
            Assert.AreEqual("(5, 5)", Program.Evaluate("NNNNNLLLLL"));
        }

        [TestMethod]
        public void Input_NLNLNLNLNL()
        {
            Assert.AreEqual("(5, 5)", Program.Evaluate("NLNLNLNLNL"));
        }

        [TestMethod]
        public void Input_NNNNNXLLLLLX()
        {
            Assert.AreEqual("(4, 4)", Program.Evaluate("NNNNNXLLLLLX"));
        }

        [TestMethod]
        public void Input_SSSSSOOOOO()
        {
            Assert.AreEqual("(-5, -5)", Program.Evaluate("SSSSSOOOOO"));
        }

        [TestMethod]
        public void Input_S5O5()
        {
            Assert.AreEqual("(-5, -5)", Program.Evaluate("S5O5"));
        }

        [TestMethod]
        public void Input_NNX2()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate("NNX2"));
        }

        [TestMethod]
        public void Input_N123LSX()
        {
            Assert.AreEqual("(1, 123)", Program.Evaluate("N123LSX"));
        }

        [TestMethod]
        public void Input_NLS3X()
        {
            Assert.AreEqual("(1, 1)", Program.Evaluate("NLS3X"));
        }

        [TestMethod]
        public void Input_NNNXLLLXX()
        {
            Assert.AreEqual("(1, 2)", Program.Evaluate("NNNXLLLXX"));
        }

        [TestMethod]
        public void Input_N40L30S20O10NLSOXX()
        {
            Assert.AreEqual("(21, 21)", Program.Evaluate("N40L30S20O10NLSOXX"));
        }

        [TestMethod]
        public void Input_NLSOXXN40L30S20O10()
        {
            Assert.AreEqual("(21, 21)", Program.Evaluate("NLSOXXN40L30S20O10"));
        }

        [TestMethod]
        public void Input_NULL()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate(null)); // Entrada nula
        }

        [TestMethod]
        public void Input_EMPTY()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate("")); // Entrada vazia
        }

        [TestMethod]
        public void Input_WHITESPACE()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate("   ")); // Entrada espaço vazio
        }

        [TestMethod]
        public void Input_123()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate("123")); // Entrada inválida
        }

        [TestMethod]
        public void Input_123N()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate("123N")); // passos antes da direçao
        }

        [TestMethod]
        public void Input_N2147483647N()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate("N2147483647N")); // Overflow
        }

        [TestMethod]
        public void Input_NNI()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate("NNI")); // Commando inválido
        }

        [TestMethod]
        public void Input_N2147483647XN()
        {
            Assert.AreEqual("(0, 1)", Program.Evaluate("N2147483647XN")); // Overflow cancelado
        }

        [TestMethod]
        public void Input_BIGSTRING()
        {
            Assert.AreEqual("(500, 500)", Program.Evaluate(new string(
                Enumerable.Repeat('N', 1000).Concat(
                Enumerable.Repeat('S', 500)).Concat(
                Enumerable.Repeat('L', 1000)).Concat(
                Enumerable.Repeat('O', 500)).ToArray())));
        }
        #endregion

        #region Complementary Tests

        #region Basic Inputs

        #region North
        [TestMethod]
        public void Input_N()
        {
            Assert.AreEqual("(0, 1)", Program.Evaluate("N"));
        }

        [TestMethod]
        public void Input_N5()
        {
            Assert.AreEqual("(0, 5)", Program.Evaluate("N5"));
        }

        [TestMethod]
        public void Input_NNNNN()
        {
            Assert.AreEqual("(0, 5)", Program.Evaluate("NNNNN"));
        }

        [TestMethod]
        public void Input_NNX()
        {
            Assert.AreEqual("(0, 1)", Program.Evaluate("NNX"));
        }

        [TestMethod]
        public void Input_NN10X()
        {
            Assert.AreEqual("(0, 1)", Program.Evaluate("NN10X"));
        }
        #endregion

        #region South
        [TestMethod]
        public void Input_S()
        {
            Assert.AreEqual("(0, -1)", Program.Evaluate("S"));
        }

        [TestMethod]
        public void Input_S5()
        {
            Assert.AreEqual("(0, -5)", Program.Evaluate("S5"));
        }

        [TestMethod]
        public void Input_SSSSS()
        {
            Assert.AreEqual("(0, -5)", Program.Evaluate("SSSSS"));
        }

        [TestMethod]
        public void Input_SSX()
        {
            Assert.AreEqual("(0, -1)", Program.Evaluate("SSX"));
        }

        [TestMethod]
        public void Input_SS10X()
        {
            Assert.AreEqual("(0, -1)", Program.Evaluate("SS10X"));
        }
        #endregion

        #region East 
        [TestMethod]
        public void Input_L()
        {
            Assert.AreEqual("(1, 0)", Program.Evaluate("L"));
        }

        [TestMethod]
        public void Input_L5()
        {
            Assert.AreEqual("(5, 0)", Program.Evaluate("L5"));
        }

        [TestMethod]
        public void Input_LLLLL()
        {
            Assert.AreEqual("(5, 0)", Program.Evaluate("LLLLL"));
        }

        [TestMethod]
        public void Input_LLX()
        {
            Assert.AreEqual("(1, 0)", Program.Evaluate("LLX"));
        }

        [TestMethod]
        public void Input_LL10X()
        {
            Assert.AreEqual("(1, 0)", Program.Evaluate("LL10X"));
        }
        #endregion

        #region West
        [TestMethod]
        public void Input_O()
        {
            Assert.AreEqual("(-1, 0)", Program.Evaluate("O"));
        }

        [TestMethod]
        public void Input_O5()
        {
            Assert.AreEqual("(-5, 0)", Program.Evaluate("O5"));
        }

        [TestMethod]
        public void Input_OOOOO()
        {
            Assert.AreEqual("(-5, 0)", Program.Evaluate("OOOOO"));
        }

        [TestMethod]
        public void Input_OOX()
        {
            Assert.AreEqual("(-1, 0)", Program.Evaluate("OOX"));
        }

        [TestMethod]
        public void Input_OO10X()
        {
            Assert.AreEqual("(-1, 0)", Program.Evaluate("OO10X"));
        }
        #endregion

        [TestMethod]
        public void Input_NSLO()
        {
            Assert.AreEqual("(0, 0)", Program.Evaluate("NSLO"));
        }
        #endregion

        #region Invalid Characters
        [TestMethod]
        public void Input_STRING_NULL()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate("NULL")); // Possui caracteres inválidos [U]
        }

        [TestMethod]
        public void Input_STRING_TRUE()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate("TRUE")); /// Possui caracteres inválidos [TRUE]
        }

        [TestMethod]
        public void Input_STRING_WITH_OPERATOR()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate("N1+2")); // Possui caracter inválido [+]
        }

        [TestMethod]
        public void Input_STRING_WITH_WHITESPACE_START()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate(" NS")); // Possui caracter inválido [ ]
        }

        [TestMethod]
        public void Input_STRING_WITH_WHITESPACE_MIDDLE()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate("N S")); // Possui caracter inválido [ ]
        }

        [TestMethod]
        public void Input_STRING_WITH_WHITESPACE_END()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate("NS ")); // Possui caracter inválido [ ]
        }

        [TestMethod]
        public void Input_STRING_WITH_HYPHEN_START()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate("-NS")); // Possui caracter inválido [-]
        }

        [TestMethod]
        public void Input_STRING_WITH_HYPHEN_MIDDLE()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate("N-S")); // Possui caracter inválido [-]
        }

        [TestMethod]
        public void Input_STRING_WITH_HYPHEN_END()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate("NS-")); // Possui caracter inválido [-]
        }

        [TestMethod]
        public void Input_STRING_WITH_UNDERLINE()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate("N_S")); // Possui caracter inválido [_]
        }

        [TestMethod]
        public void Input_STRING_WITH_COMMA()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate("N,S")); // Possui caracter inválido [,]
        }

        [TestMethod]
        public void Input_STRING_WITH_FULL_STOP()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate("N.S")); // Possui caracter inválido [.]
        }

         [TestMethod]
        public void Input_STRING_WITH_SEMICOLON()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate("N;S")); // Possui caracter inválido [;]
        }

        [TestMethod]
        public void Input_STRING_WITH_ACCENTUATION()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate("NÓÔÕÒ")); // Possui caracteres inválidos [ÓÔÕÒ]
        }

        [TestMethod]
        public void Input_STRING_LOWER()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate("No")); // Possui caracter inválido [o]
        }
        #endregion

        #region Numeric
        [TestMethod]
        public void Input_NUMBER_OVEWFLOW()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate("N2147483648")); // Número fora do intervalo permitido [1-2147483647]
        }

        [TestMethod]
        public void Input_NUMBER_ZERO()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate("N0")); // Número fora do intervalo permitido [1-2147483647]
        }
        
        [TestMethod]
        public void Input_ZEROS_LEFT()
        {
            Assert.AreEqual("(1, 1)", Program.Evaluate("N000000000000000001L01")); //README
        }
        #endregion

        #region Cancel Operations
        [TestMethod]
        public void Input_START_X()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate("XN")); // Quantidade de ações a serem canceladas inexistentes
        }

        [TestMethod]
        public void Input_MANY_X()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate("NXX")); // Quantidade de ações a serem canceladas inexistentes
        }
        #endregion

        #region Temporary Overflow 
        //README
        [TestMethod]
        public void Input_X_NOT_OVERFLOW_MAX_VALUE_ANYTIME()
        {
            Assert.AreEqual("(2147483647, 0)", Program.Evaluate("L2147483647O2147483647L2147483647")); // Não Ocorre Overflow
        }

        [TestMethod]
        public void Input_X_NOT_OVERFLOW_MIN_VALUE_ANYTIME()
        {
            Assert.AreEqual("(-2147483648, 0)", Program.Evaluate("OO2147483647LL2147483647OO2147483647")); // Não Ocorre Overflow
        }

        [TestMethod]
        public void Input_Y_NOT_OVERFLOW_MAX_VALUE_ANYTIME()
        {
            Assert.AreEqual("(0, 2147483647)", Program.Evaluate("N2147483647S2147483647N2147483647")); // Não Ocorre Overflow
        }

        [TestMethod]
        public void Input_Y_NOT_OVERFLOW_MIN_VALUE_ANYTIME()
        {
            Assert.AreEqual("(0, -2147483648)", Program.Evaluate("SS2147483647NN2147483647SS2147483647")); // Não Ocorre Overflow
        }

        [TestMethod]
        public void Input_X_OVERFLOW_MAX_VALUE_SOME_TIME()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate("L2147483647LO2147483647")); // X Overflow MaxVlue [+2147483647]
        }

        [TestMethod]
        public void Input_X_OVERFLOW_MIN_VALUE_SOME_TIME()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate("O2147483647O2L2147483647")); // X Overflow MinVlue [-2147483648]
        }

        [TestMethod]
        public void Input_Y_OVERFLOW_MAX_VALUE_SOME_TIME()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate("N2147483647NS2147483647")); // Y Overflow MaxVlue [+2147483647]
        }

        [TestMethod]
        public void Input_Y_OVERFLOW_MIN_VALUE_SOME_TIME()
        {
            Assert.AreEqual("(999, 999)", Program.Evaluate("S2147483647S2N2147483647")); // Y Overflow MinVlue [-2147483648]
        }
        #endregion

        #endregion
    }
}
