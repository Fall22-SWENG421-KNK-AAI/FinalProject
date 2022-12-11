/**
 * This abstract class acts as the superclass to the VeggieDelight, MeatLovers,
 * TheClassic, PlainSpicy and ForVegans classes.
 * 
 * @author Anthony Immekus, Keian Kaserman, and Kien Nguyen​
 * @date 12/11/2022
 * @version 1.0
 */
using FinalProject;
using System.Runtime.CompilerServices;

namespace FinalProject
{
    public abstract class AbstractSandwich
    {
        private SandwichEnvIF env;

		protected int toastTime;
        protected bool needsToasting;
        protected Topping[] toppings = new Topping[] { };
        protected Bread bread;
        protected Protein[] protein = new Protein[] { };
        protected Cheese[] cheese = new Cheese[] { };
        public string name;
        public string description;
        public double price;

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
