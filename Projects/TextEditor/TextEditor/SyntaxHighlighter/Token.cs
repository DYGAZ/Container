using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyntaxHighlighter
{
    public enum SyntaxTokenType
    {
        Basic = 0,              //Identifier,Literal,Variable
        ProgramStructure = 1,   //Namespace,Using
        Operator = 2,           //+,-,&,|,etc
        ControlStructure = 3,   //conditional,iteration,jump,exception
        Type = 4,               //Value,reference(array,classes,interface,delegates,events,
        Null = 5
    }

    public struct TokenPosition
    {
        public int StartIndex, EndIndex;
    }
    public struct Token
    {
        public SyntaxTokenType Type;
        public TokenPosition Position;
        public bool IsIgnored;
    }
}
