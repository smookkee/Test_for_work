using System;
using System.Collections.Generic;
using System.Text;

namespace Horns_n_legs_2
{

    abstract class Animal
    {
     
        public virtual int Legs()
        { return 0; }

        public virtual int Horns()
        { return 0; }

        public virtual int Weight()
        { return 0; }

        public virtual string Name()
        { return "animal"; }
    }

    class Chicken: Animal
    {
        public override int Weight()
        { return 1; }
        public override int Legs()
        { return 2; }

        public override int Horns()
        { return 0; }

        public override string Name()
        { return "Chicken"; }

    }

    class Rabbit : Animal
    {
        public override int Weight()
        { return 2; }
        public override int Legs()
        { return 4; }

        public override int Horns()
        { return 0; }

        public override string Name()
        { return "Rabbit"; }
    }

    class Goat : Animal
    {
        public override int Weight()
        { return 50; }
        public override int Legs()
        { return 4; }

        public override int Horns()
        { return 2; }

        public override string Name()
        { return "Goat"; }
    }

    class Cow : Animal
    {
        public override int Weight()
        { return 700; }
        public override int Legs()
        { return 4; }

        public override int Horns()
        { return 2; }

        public override string Name()
        { return "Cow"; }

    }


    class OneHornOneLeg : Animal
    {
        public override int Weight()
        { return 1; }
        public override int Legs()
        { return 1; }

        public override int Horns()
        { return 1; }

        public override string Name()
        { return "OneHornOneLeg"; }

    }
}
