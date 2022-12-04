using FinalProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    public abstract class AbstractSandwich
    {
        private SandwichEnvIF env;

		//protected variables
		protected int totalRuntime;
        protected bool needsToasting;
        protected Topping toppings;
        protected Bread bread;
        protected Protein protein;
        public string name;
        public string description;
        public double price;
        protected const int secsInMin = 60;

        public void setEnvironment(SandwichEnvIF env) 
        {
            //set the environment
            this.env = env;
        }

        protected SandwichEnvIF getSandwichEnv()
        {
            return env;
        }

        public abstract void start();

    }
}
