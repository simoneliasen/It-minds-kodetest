using System;

namespace VacationCost {

    public class VacationCostCalculator { 

        public double DistanceToDestination { get; set; }

        // refactoring this into a design pattern could be seem as being code obfusication, 
        // let's say theres 50 veichles, this would become a lot more code, for some code which is in some regard highly readable and maintable to begin with
        // Maybe i'm misunderstanding the task at hand, let's talk about it :-)

        public decimal? CostOfVacation(string transportMethod) => transportMethod switch
        {
            "car" => (decimal)(DistanceToDestination * 1),
            "plane" => (decimal)(DistanceToDestination * 2),
            "speedboat" => (decimal)(DistanceToDestination * 3),
            "tractor" => (decimal)(DistanceToDestination * 4),
            _ => null
        };
    }
}



