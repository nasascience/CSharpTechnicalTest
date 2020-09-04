using System;
using System.Linq;
using GunvorRecruitment.Test.Repository;

using GunvorRecruitment.Repository;
namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //const string InputString = "Every other word in this sentence should be reversed";
            //const string ExpectedOutput = "Every rehto word ni this ecnetnes should eb reversed";

            //Console.WriteLine(ReverseEveryOtherWord(InputString));
            //Console.WriteLine(ReverseEveryOtherWord(InputString) == ExpectedOutput);
            LoadingNodeB_ShouldAlwaysReturnTheSameInstance();
        }

        public static void LoadingNodeB_ShouldAlwaysReturnTheSameInstance()
        {
            var nodeManager = new NodeManager(new FakeRepository());

            var nodeA = nodeManager.GetNodeAndImmediateChildren("Node A");
            var nodeB = nodeManager.GetNodeAndImmediateChildren("Node B");

            var nodeBFromNodeA = nodeA.ImmediateChildren.First(child => child.Name == "Node B");

            Console.WriteLine(nodeB.Name == nodeBFromNodeA.Name);
            Console.WriteLine(nodeB == nodeBFromNodeA);
            //Assert.AreEqual(nodeB.Name, nodeBFromNodeA.Name);
            //Assert.AreEqual(nodeB, nodeBFromNodeA);
        }

        public static string ReverseEveryOtherWord(string inputString)
        {
            //throw new System.NotImplementedException();
            var reversed = "";
            var stringArray = inputString.Split(' ');
            var skeep = true;
            foreach (var word in stringArray)
            {
                if (skeep)
                {
                    reversed += word + " ";
                }
                else
                {
                    var wordArray = word.ToCharArray().ToList();
                    wordArray.Reverse();
                    var newWord = String.Join("", wordArray);

                    reversed += newWord + " ";
                }
                skeep = !skeep;
            }
            return reversed.TrimEnd();
        }
    }
}
