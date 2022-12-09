using FinalProject;
using System.Runtime.CompilerServices;

namespace FinalProject
{
    public abstract class AbstractSandwich
    {
        private SandwichEnvIF env;

		//protected variables
		protected int totalRuntime;
        protected bool needsToasting;
        protected Topping[] toppings = new Topping[] { };
        protected Bread bread;
        protected Protein[] protein = new Protein[] { };
        protected Cheese[] cheese = new Cheese[] { };
        public string name;
        public string description;
        public double price;
        protected const int secsInMin = 60;

		public abstract void start();

		public void setEnvironment(SandwichEnvIF env)
		{
			//set the environment
			this.env = env;
		}

		public SandwichEnvIF getSandwichEnv()
		{
			return env;
		}

		public void addTopping(Topping t)
		{
			toppings.Append(t);
		}

        public void setBread(Bread bread)
        {
            this.bread = bread;
        }

        public void addCheese(Cheese cheese)
        {
            this.cheese.Append(cheese);
        }

        public void addProtein(Protein protein)
        {
            this.protein.Append(protein);
        }

        public bool getNeedsToasting()
        {
            return needsToasting;
        }

        public string getSandwichState()
        {
            return getSandwichEnv().getJobState();
        }
    }
}
