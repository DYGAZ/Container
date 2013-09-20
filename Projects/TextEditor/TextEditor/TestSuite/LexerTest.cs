using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SyntaxHighlighter;

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

            var tokenTypes = lexer.Tokenize(input);

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var token in tokenTypes)
            {
                stringBuilder.Append(token.Type + ",");
            }
            Assert.AreEqual(stringBuilder.ToString(), "ProgramStructure,Null,");
            
        }
    }
}
