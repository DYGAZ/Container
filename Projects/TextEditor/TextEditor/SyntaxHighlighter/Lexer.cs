using System;
using System.Collections.Generic;
using System.Text;

namespace SyntaxHighlighter
{
    public interface ILexer
    {
        void AddDefinition(String value,Token token);
        IEnumerable<Token> Tokenize(string source);
    }
    public class Lexer : ILexer
    {
        readonly Dictionary<String,Token> _tokenDefinitionDictionary = new Dictionary<String,Token>();

        public void AddDefinition(String value, Token token)
        {
            _tokenDefinitionDictionary.Add(value,token);
        }

        public IEnumerable<Token> Tokenize(String source)
        {
            var tokens = new List<Token>();
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
                        tokens.Add(
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
            return tokens;
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
            return new Token
            {
                Type = SyntaxTokenType.Null,
                IsIgnored = true,
                Position = position
            };
        }
    }
}
