using System.Collections.Generic;
using System.Linq;

namespace SecretAgent {
    public class FindSecretAgent : IFindSecretAgent {

        // Hashsets gives us very good performance in regards to set operations, and won't store duplicate elements (perfect for this task)
        // This practically gives us a performance of O(n) which counts for the iteration over the original list. (space
        public int StartSearch(IEnumerable<int> ids)
        {
            //store unique ids
            HashSet<int> uniqueAgentIDs = new HashSet<int>();
            //store dublicate ids
            HashSet<int> dublicateAgentIDs = new HashSet<int>();

            //Add element to dublicateAgentIDs hashset, if .add isn't feasible for uniqueAgentIDs, thus serving us the traitor
            foreach (int agent in ids) // O(N) iteration
            {
                if (!uniqueAgentIDs.Add(agent)) // O(1) comparrison
                {
                    dublicateAgentIDs.Add(agent); // O(1) Add
                }
            }

            // Return result 
            return dublicateAgentIDs.First();  // O(1) Retrieve

        }
    }
}

