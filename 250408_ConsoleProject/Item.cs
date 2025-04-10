using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250408_ConsoleProject
{
	public abstract class Item
	{
		public abstract string Name { get; }
		public abstract void Use(Player player);
	}

	public class HealingPotion : Item
	{
		public override string Name => "회복 포션";
		public override void Use(Player player)
		{
			player.HP += 50;
		}
	}

}
