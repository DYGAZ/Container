using System;
using System.Collections.Generic;

namespace HighLighter
{
    public enum SyntaxTokenType
    {
        Basic,              //Identifier,Literal,Variable
        ProgramStructure,   //Namespace,Using
        Operator,           //+,-,&,|,etc
        ControlStructure,   //conditional,iteration,jump,exception
        Type,               //Value,reference(array,classes,interface,delegates,events,
        Null
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

    public static class TokenMap
    {
        private static readonly Dictionary<String, SyntaxTokenType> StringToTokenMap = new Dictionary
            <string, SyntaxTokenType>()
        {
            {"Basic",SyntaxTokenType.Basic},
            {"ProgramStructure",SyntaxTokenType.ProgramStructure},
            {"Operator",SyntaxTokenType.Operator},
            {"ControlStructure",SyntaxTokenType.ControlStructure},
            {"Type",SyntaxTokenType.Type},
            {"Null",SyntaxTokenType.Null},
        };

        public static SyntaxTokenType MapStringtoTokenType(String key)
        {
            return StringToTokenMap[key];
        }
    }
}
