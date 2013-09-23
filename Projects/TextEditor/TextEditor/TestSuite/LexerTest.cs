using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using HighLighter;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestSuite
{
    [TestClass]
    public class LexerTest
    { 
        IUnityContainer container = new UnityContainer();

        [TestMethod]
        public void LexerTest_LexBasic_ReturnCorrectToken()
        {
            container.RegisterType<ILexer, Lexer>();

            var input = "class Proops";

            var lexer = container.Resolve<ILexer>();

            lexer.CreateLexerMap("TestStringToTokenMap.txt");

            var tokenTypes = lexer.Tokenize(input);

            var stringBuilder = new StringBuilder();

            foreach (var token in tokenTypes)
            {
                stringBuilder.Append(token.Type + ",");
            }
            Assert.AreEqual("Type,Basic,",stringBuilder.ToString());
            
        }

        [TestMethod]
        public void LexerTest_ConstructFromText_CreatesValidMap()
        {
            container.RegisterType<ILexer, Lexer>();

            var input = "class struct while if boobs";

            var lexer = container.Resolve<ILexer>();

            lexer.CreateLexerMap("TestStringToTokenMap.txt");

            var tokenTypes = lexer.Tokenize(input);

            var stringBuilder = new StringBuilder();

            foreach (var token in tokenTypes)
            {
                stringBuilder.Append(token.Type + ",");
            }
            Assert.AreEqual("Type,Type,ControlStructure,ControlStructure,Null,",stringBuilder.ToString());
        }
    }
}
