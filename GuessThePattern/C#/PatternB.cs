namespace GuessThePattern {
    public abstract class SomeObject {
    }

    public class ConcreteSomeObject : SomeObject {
    }

    public abstract class PatternB {
        public abstract SomeObject Create();
    }

    public class ConcretePatternB : PatternB {
        public override SomeObject Create()
        {
            return new ConcreteSomeObject();
        }
    }
}

/* Write your answers and comments below this line

Abstract factory:
- Give an interface for creating families of related or dependent objects without specifying their concrete classes
- Basically making a bigger factory for creating factories.

Applications:
- Could be used in real life factories, where parts are similair but different
- Could be used for UI changes depending on the user acessing an application

Pros:
- Elements are designed to be used together, as they are enforced by the same constraints
- Promotes consistency among products, with them being grouped in families
- Isolate concrete classes from the client via encapsulation

Cons:
- Making new products are extensive as all its derived classes also must change

*/
