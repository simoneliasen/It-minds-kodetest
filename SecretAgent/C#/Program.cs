using System;
using System.Collections.Generic;

namespace SecretAgent {
    internal class Program {
        private static void Main(string[] args)
        {
            //Add agentFinder instance
            var agentFinder = new FindSecretAgent();

            //Create list of Agents
            IEnumerable<int> agentLineup = new List<int> { 1, 3, 5, 6, 7, 8, 5, 22, 34 };

            //SecretAgentID stores the identity that the secret agent is imposing as + (added timing operation)
            var before = DateTime.Now;
            var secretAgentID = agentFinder.StartSearch(agentLineup);
            var after = DateTime.Now;
            Console.WriteLine($"One of the two Agents, who goes by number {secretAgentID} is working for the opposition!");
            Console.WriteLine("Found him in: " + (before - after));






            Console.ReadLine();
        }
    }
}
