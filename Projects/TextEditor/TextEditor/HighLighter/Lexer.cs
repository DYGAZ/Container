using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HighLighter
{
    public interface ILexer
    {
        void AddDefinition(String value,Token token);
        void CreateLexerMap(String fileName);
        IEnumerable<Token> Tokenize(string source);
    }
    public class Lexer : ILexer
    {   
        readonly Dictionary<String,Token> _tokenDefinitionDictionary = new Dictionary<String,Token>();

        readonly List<Token> _tokens = new List<Token>();

        public Lexer()
        {
        }

        public void CreateLexerMap(String fileName)
        {
            var file = new StreamReader(fileName);
            var sb = new StringBuilder();
            string line;
            

            while ((line = file.ReadLine())!=null)
            {
                var key = " ";
                line += " ";
                foreach (var c in line.ToCharArray())
                {
                    if (c == ' ' && sb.Length > 0)
                    {
                        if (key == " ")
                        {
                            key = sb.ToString();
                            sb.Length = 0;
                            continue;
                        }
                        _tokenDefinitionDictionary.Add(key,
                            new Token {Type = TokenMap.MapStringtoTokenType(sb.ToString())});
                        sb.Length = 0;
                    }
                    if(c!= ' ') sb.Append(c);
                }
            }
        }

        public void AddDefinition(String value, Token token)
        {
            _tokenDefinitionDictionary.Add(value,token);
        }

        public IEnumerable<Token> Tokenize(String source)
        {
            source += " ";
            var currentIndex = 0;
            var currentWordStart = 0;
            var currentWordEnd = 0;

            var stringBuilder = new StringBuilder();

            while (currentIndex < source.Length)
            {
                if (source[currentIndex] == ' ')
                {
                    if (stringBuilder.Length > 0)
                    {
                        _tokens.Add(
                            convertStringToToken(
                                stringBuilder.ToString(),
                                new TokenPosition
                                {
                                    EndIndex = currentWordEnd,
                                    StartIndex = currentWordStart
                                }
                            )
                        );
                        stringBuilder.Length = 0;                   //Reset stringbuilder
                    }
                    currentIndex++;
                    currentWordEnd = currentWordStart = currentIndex;
                    continue;
                }

                stringBuilder.Append(source[currentIndex]);
                currentWordEnd++;
                currentIndex++;
            }
            return _tokens;
        }

        Token convertStringToToken(string text,TokenPosition position)
        {
            if (_tokenDefinitionDictionary.ContainsKey(text))
                return new Token
                {
                    Type = _tokenDefinitionDictionary[text].Type,
                    IsIgnored = false,
                    Position = position
                };
            if (_tokens.Last().Type == SyntaxTokenType.Type)
            {
                return new Token
                {
                    Type = SyntaxTokenType.Basic,
                    IsIgnored = false,
                    Position = position,
                };
            }
            return new Token
            {
                Type = SyntaxTokenType.Null,
                IsIgnored = true,
                Position = position
            };
        }
    }
}
