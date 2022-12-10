using FinalProject;
using System.Runtime.CompilerServices;

namespace FinalProject
{
    public abstract class AbstractSandwich
    {
        private SandwichEnvIF env;

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
			this.env = env;
            this.env.setSandwich(this);
		}

		public SandwichEnvIF getSandwichEnv()
		{
			return env;
		}

        /*
        protected void addToPrice(double price)
        {
            this.price += price;
        }
        */

		public void addTopping(Topping t)
		{
			toppings.Append(t);
            //addToPrice(t.getPrice());
		}

        public void setBread(Bread bread)
        {
            this.bread = bread;
            //addToPrice(bread.getPrice());
        }

        public void addCheese(Cheese cheese)
        {
            this.cheese.Append(cheese);
            //addToPrice(cheese.getPrice());
        }

        public void addProtein(Protein protein)
        {
            this.protein.Append(protein);
            //addToPrice(protein.getPrice());
        }

        public bool getNeedsToasting()
        {
            return needsToasting;
        }

        public string getSandwichState()
        {
            return getSandwichEnv().getJobState().ToString();
        }

        public double getPrice()
        {
            return price;
        }

        public string getName()
        {
            return name;
        }

        public override string ToString() => $"{getName()} - ${getPrice()}";
    }
}
