using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection
{
    class Examples
    {
        public void QueueExample()
        {
            Queue<string> numbers = new Queue<string>();

            numbers.Enqueue("one");
            numbers.Enqueue("two");
            numbers.Enqueue("three");
            numbers.Enqueue("four");
            numbers.Enqueue("five");

            foreach (string number in numbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("\nDequeuing '{0}'", numbers.Dequeue());
            Console.WriteLine("Peek at next item to dequeue: {0}", numbers.Peek());
            Console.WriteLine("Dequeuing '{0}'", numbers.Dequeue());

            Queue<string> queueCopy = new Queue<string>(numbers);
            Console.WriteLine("\nContents of the first copy:");
            foreach (string number in queueCopy)
            {
                Console.WriteLine(number);
            }

            string[] queueArray = new string[numbers.Count * 2];

            numbers.CopyTo(queueArray, numbers.Count);

            Console.WriteLine("\nContents of the array:");
            int index = 0;
            foreach (string number in queueArray)
            {
                Console.WriteLine(index.ToString() + ": " + number);
                index++;
            }

            Queue<string> queueCopy2 = new Queue<string>(queueArray);

            Console.WriteLine("\nContents of the second copy:");
            index = 0;
            foreach (string number in queueCopy2)
            {
                Console.WriteLine(index.ToString() + ": " + number);
                index++;
            }

            Console.WriteLine("\nqueueCopy.Contains(\"four\") = {0}", queueCopy.Contains("four"));

            Console.WriteLine("\nqueueCopy.Clear()");
            queueCopy.Clear();
            Console.WriteLine("\nqueueCopy.Count = {0}", queueCopy.Count);

            Console.ReadLine();
        }

        public void StackExample()
        {
            Stack<string> numbers = new Stack<string>();

            numbers.Push("one");
            numbers.Push("two");
            numbers.Push("three");
            numbers.Push("four");
            numbers.Push("five");

            foreach (string number in numbers)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("\nPopping '{0}'", numbers.Pop());
            Console.WriteLine("Peek at next item to destack: {0}", numbers.Peek());
            Console.WriteLine("Popping '{0}'", numbers.Pop());

            Stack<string> stackCopy = new Stack<string>(numbers);

            Console.WriteLine("\nContents of the first copy:");
            foreach (string number in stackCopy)
            {
                Console.WriteLine(number);
            }

            string[] stackArray = new string[numbers.Count * 2];
            numbers.CopyTo(stackArray, numbers.Count);

            Console.WriteLine("\nContents of the array:");
            int index = 0;
            foreach (string number in stackArray)
            {
                Console.WriteLine(index.ToString() + ": " + number);
                index++;
            }

            Stack<string> stackCopy2 = new Stack<string>(stackArray);

            Console.WriteLine("\nContents of the second copy:");
            index = 0;
            foreach (string number in stackCopy2)
            {
                Console.WriteLine(index.ToString() + ": " + number);
                index++;
            }

            Console.WriteLine("\nstackCopy.Contains(\"four\") = {0}", stackCopy.Contains("four"));

            Console.WriteLine("\nstackCopy.Clear()");
            stackCopy.Clear();
            Console.WriteLine("\nstackCopy.Count = {0}", stackCopy.Count);

            Console.ReadLine();
        }

        public void DictionaryExample()
        {
            Dictionary<string, string> openWith = new Dictionary<string, string>();

            openWith.Add("txt", "notepad.exe");
            openWith.Add("bmp", "paint.exe");
            openWith.Add("dib", "paint.exe");
            openWith.Add("rtf", "wordpad.exe");

            try
            {
                openWith.Add("txt", "winword.exe");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("An element with Key = \"txt\" already exists.");
            }

            string ertek = openWith["rtf"];

            Console.WriteLine("For key = \"rtf\", value = {0}.", ertek);

            openWith["rtf"] = "winword.exe";

            Console.WriteLine("For key = \"rtf\", value = {0}, after we changed it.", openWith["rtf"]);

            openWith["doc"] = "winword.exe";
            openWith["tif"] = "winword.exe";

            try
            {
                Console.WriteLine("For key = \"tif\", value = {0}.", openWith["tif"]);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Key = \"tif\" is not found.");
            }

            string value = "";
            if (openWith.TryGetValue("tif", out value))
            {
                Console.WriteLine("For key = \"tif\", value = {0}.", value);
            }
            else
            {
                Console.WriteLine("Key = \"tif\" is not found.");
            }

            if (!openWith.ContainsKey("ht"))
            {
                openWith.Add("ht", "hypertrm.exe");
                Console.WriteLine("Value added for key = \"ht\": {0}", openWith["ht"]);
            }

            Console.WriteLine();
            foreach (KeyValuePair<string, string> kvp in openWith)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }

            Dictionary<string, string>.ValueCollection valueColl = openWith.Values;

            Console.WriteLine();
            foreach (string s in valueColl)
            {
                Console.WriteLine("Value = {0}", s);
            }

            Dictionary<string, string>.KeyCollection keyColl = openWith.Keys;

            Console.WriteLine();
            foreach (string s in keyColl)
            {
                Console.WriteLine("Key = {0}", s);
            }

            Console.WriteLine("\nRemove(\"doc\")");
            openWith.Remove("doc");

            foreach (KeyValuePair<string, string> ow in openWith)
            {
                Console.WriteLine("Key = {0}, Value = {1}", ow.Key, ow.Value);
            }

            if (!openWith.ContainsKey("doc"))
            {
                Console.WriteLine("Key \"doc\" is not found.");
            }

            Console.ReadLine();
        }

        public void HashSetExample()
        {
            HashSet<int> evenNumbers = new HashSet<int>();
            HashSet<int> oddNumbers = new HashSet<int>();

            for (int i = 0; i < 5; i++)
            {
                evenNumbers.Add(i * 2);
                oddNumbers.Add((i * 2) + 1);
            }

            evenNumbers.Add(2);

            Console.Write("evenNumbers contains {0} elements: ", evenNumbers.Count);
            Console.Write("{");
            foreach (int i in evenNumbers)
            {
                Console.Write(" {0}", i);
            }
            Console.WriteLine(" }\n");


            Console.Write("oddNumbers contains {0} elements: ", oddNumbers.Count);
            Console.Write("{");
            foreach (int i in oddNumbers)
            {
                Console.Write(" {0}", i);
            }
            Console.WriteLine(" }\n");

            HashSet<int> numbers = new HashSet<int>(evenNumbers);
            Console.WriteLine("numbers Union with oddNumbers:");
            numbers.UnionWith(oddNumbers);

            Console.Write("numbers contains {0} elements: ", numbers.Count);
            Console.Write("{");

            foreach (int i in numbers)
            {
                Console.Write(" {0}", i);
            }
            Console.WriteLine(" }");

            if (numbers.Contains(5))
            {
                numbers.Remove(5);
            }
            Console.Write("\nnumbers contains {0} elements: ", numbers.Count);
            Console.Write("{");

            foreach (int i in numbers)
            {
                Console.Write(" {0}", i);
            }
            Console.WriteLine(" }\n\n");

            string[] array = new string[] { "one", "one", "two", "two", "three", "three" };
            HashSet<string> hash = new HashSet<string>(array);

            foreach (var item in hash)
            {
                Console.Write(item + " ");
            }

            Console.ReadLine();
        }

        void DisplayHashSet(HashSet<int> set)
        {
            Console.Write("{");
            foreach (int i in set)
            {
                Console.Write(" {0}", i);
            }
            Console.WriteLine(" }");
        }

    }


}

