using System;

namespace GuessThePattern {
    public class PatternA {
        private static PatternA _instance;

        private PatternA()
        {
        }

        public static PatternA GetInstance()
        {
            if (_instance == null)
                _instance = new PatternA();

            return _instance;
        }

        public void DoWork()
        {
            throw new NotImplementedException();
        }
    }
}

/* Write your answers and comments below this line

Singelton:
- Makes sures that a class only have one instance, and simutanelousy provide a global access point to it.

Applications:
- Mainly used in cases where you need a refference points to things that can only have one instantiation
- This is common where a ressource is shared across a bunch of people
- This could be database refferences, Tokens to things such as API'sas Databases and APi's, 

Pros: 
- Ensure that there is only one instance.
- Acess it globally.

Cons:
- Goes against the Single-resposibility principle. 
- Can hide elements, making it harder to test.
- Multithreading can possibly break the pattern.

 */
