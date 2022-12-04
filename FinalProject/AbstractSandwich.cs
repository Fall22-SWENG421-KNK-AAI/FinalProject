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
        //protected variables
        protected int totalRuntime;
        protected Topping toppings;
        protected Bread bread;
        protected Protein protein;

        internal void setEnvironment(SandwichEnvIF c) 
        {
            //set the environment
            SandwichEnvIF env = new SandwichEnv();
        }

        public abstract void start();

    }
}
