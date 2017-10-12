namespace P03.CalculateArithmeticExpression
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class CalculateArithmeticExpression
    {
        static void Main()
        {
            var arithmeticExpression = "1.5 - 2.5 * 2 * (-3)";
            var tokens = GetTokens(arithmeticExpression);
            var queue = GetPostfixNotation(tokens);
            var result = CalculatePostfixExpression(queue);

            Console.WriteLine(result);
        }

        private static double CalculatePostfixExpression(Queue<Token> queue)
        {
            var stack = new Stack<Token>();

            while (queue.Count != 0)
            {
                var nextToken = queue.Dequeue();
                if (nextToken.Type == TokenType.Number)
                {
                    stack.Push(nextToken);
                }
                else if (nextToken.Type == TokenType.Operator)
                {
                    var secondElement = double.Parse(stack.Pop().Value);
                    var firstElement = double.Parse(stack.Pop().Value);
                    var result = 0d;

                    switch (nextToken.Value)
                    {
                        case "+":
                            result = firstElement + secondElement;
                            stack.Push(new Token(result.ToString(), TokenType.Number));
                            break;
                        case "-":
                            result = firstElement - secondElement;
                            stack.Push(new Token(result.ToString(), TokenType.Number));
                            break;
                        case "*":
                            result = firstElement * secondElement;
                            stack.Push(new Token(result.ToString(), TokenType.Number));
                            break;
                        case "/":
                            result = firstElement / secondElement;
                            stack.Push(new Token(result.ToString(), TokenType.Number));
                            break;
                        default:
                            throw new InvalidOperationException("Invalid operator");
                    }
                }
            }

            return double.Parse(stack.Pop().Value);
        }

        private static Queue<Token> GetPostfixNotation(Token[] tokens)
        {
            Stack<Token> stack = new Stack<Token>();
            Queue<Token> queue = new Queue<Token>();

            foreach (var token in tokens)
            {
                if (token.Type == TokenType.Number)
                {
                    queue.Enqueue(token);
                }
                else if (token.Type == TokenType.Operator)
                {
                    while (stack.Count != 0 && IsOperatorWithGreaterPrecedenceOnTopOfStack(stack.Peek(), token))
                    {
                        queue.Enqueue(stack.Pop());
                    }

                    stack.Push(token);
                }
                else if (token.Type == TokenType.LeftBracket)
                {
                    stack.Push(token);
                }
                else if (token.Type == TokenType.RightBracket)
                {
                    while (stack.Peek().Type != TokenType.LeftBracket)
                    {
                        queue.Enqueue(stack.Pop());
                        if (stack.Count == 0)
                        {
                            throw new InvalidOperationException("Error. Expression was not valid.");
                        }
                    }

                    stack.Pop();
                }
            }

            while (stack.Count != 0)
            {
                queue.Enqueue(stack.Pop());
            }

            return queue;
        }

        private static bool IsOperatorWithGreaterPrecedenceOnTopOfStack(Token stackTopToken, Token token)
        {
            if (stackTopToken.Type != TokenType.Operator)
            {
                return false;
            }

            if (GetPrecedence(stackTopToken) < GetPrecedence(token))
            {
                return false;
            }

            return true;
        }

        private static int GetPrecedence(Token token)
        {
            int precedence = 0;

            if (token.Value.Equals("+") || token.Value.Equals("-"))
            {
                precedence = 1;
            }

            if (token.Value.Equals("*") || token.Value.Equals("/"))
            {
                precedence = 2;
            }

            return precedence;
        }

        private static Token[] GetTokens(string arithmeticExpression)
        {
            Regex regex = new Regex(@"([-]{0,1}[\d.]+)|([+\-*\/]{1})|([\(\)]{1})");
            List<Token> tokens = new List<Token>();

            Match match = regex.Match(arithmeticExpression);
            while (match.Success)
            {
                string value = match.Value;

                if (Regex.Match(value, @"[-]{0,1}[\d]+").Success)
                {
                    tokens.Add(new Token(value, TokenType.Number));
                }
                else if (Regex.Match(value, @"[+\-*\/]{1}").Success)
                {
                    tokens.Add(new Token(value, TokenType.Operator));
                }
                else if (value.Equals("("))
                {
                    tokens.Add(new Token(value, TokenType.LeftBracket));
                }
                else if (value.Equals(")"))
                {
                    tokens.Add(new Token(value, TokenType.RightBracket));
                }

                match = match.NextMatch();
            }

            return tokens.ToArray();
        }
    }
}
