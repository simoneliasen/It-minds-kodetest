using System.Collections.Generic;

namespace GuessThePattern {


    public abstract class Foo {
        private readonly List<Bar> _list = new List<Bar>();

        public void Attach(Bar bar)
        {
            _list.Add(bar);
        }

        public void Detach(Bar bar)
        {
            _list.Remove(bar);
        }

        public void Notify()
        {
            foreach (var o in _list)
            {
                o.Update();
            }
        }
    }

    public abstract class Bar {
        protected readonly Foo Foo;

        protected Bar(Foo foo)
        {
            Foo = foo;
        }

        public abstract void Update();
    }
}

/* Write your answers and comments below this line

Observer:
- Define a one-to-many relationship so that when one object changes, all its dependents are notified/changed/updated

Application:
- Could be used in any ERP or data hungry software, where the numbers provided in your excel-sheet or similair creates changes in calculations, graphs eg.
- Basically when a change somewhere needs to be translated to somewhere else automatically.
- Could also be used in subscription services, where an update in the system sends you a mail or a nortification

Pros:
- Less need to update data across multiple sites/platforms/entries

Cons:
- High dependability and unknowing dependability across application, could make for messy implementation
- You could end up with changes unkowing to you, if you're not clear about where the implementation is used.

*/
