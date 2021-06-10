using System;

namespace JavaToCSharp
{

    //----------------------------------
    class stackNode
    {
        public char data;
        public stackNode link;
    }
    //----------------------------------
    class LinkedStack
    {
        private stackNode top;

        public bool IsEmpty()
        {
            return (top == null);
        }
        public void push(char item)
        {
            stackNode newNode = new stackNode();
            newNode.data = item;
            newNode.link = top;
            top = newNode;
        }
        public char pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Deleting fail! Linked Stack is empty!!");
                return ' ';
            }
            else
            {
                char item = top.data;
                top = top.link;
                return item;
            }
        }
        public void delete()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Deleting fail! Linked Stack is empty!!");
            }
            else
            {
                top = top.link;
            }
        }
        public char peek()
        {
            if (IsEmpty())
            {
                Console.WriteLine("peeking fail! Linked Stack is empty!!");
                return ' ';
            }
            else return top.data;
        }
        public void printStack()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Linked Stack is empty!! %n %n");
            }
            else
            {
                stackNode temp = top;
                Console.WriteLine("Linked Stack>> ");
                while (temp != null)
                {
                    Console.WriteLine("\t %c \n", temp.data);
                    temp = temp.link;
                }
                Console.WriteLine();
            }
        }
    }
    class Program
    {
        private String exp;
        private int expSize;
        private char testCh, openPair;
        public bool testPair(String exp)
        {
            this.exp = exp;
            LinkedStack S = new LinkedStack();
            expSize = this.exp.Length;
            for (int i = 0; i < expSize; i++)
            {
                testCh = this.exp[i];
                switch (testCh)
                {
                    case '(':
                    case '{':
                    case '[':
                        S.push(testCh);
                        break;
                    case ')':
                    case '}':
                    case ']':
                        if (S.IsEmpty())
                            return false;
                        else
                        {
                            openPair = S.pop();
                            if ((openPair == '(' && testCh != ')') || (openPair == '{' && testCh != '}') || (openPair == '[' && testCh != ']'))
                                return false;
                            else
                                break;
                        }
                }
            }
            if (S.IsEmpty())
                return true;
            else
                return false;
            }
        }
    class BracketTest
    {
        static void Main(string[] args)
        {
            Program opt = new Program();
            String exp = "(3*5)-6/2)";

            Console.WriteLine(exp);

            if (opt.testPair(exp))
                Console.WriteLine("괄호 맞음");
            else
                Console.WriteLine("괄호 틀림");
        }
    }
}
    