using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250408_ConsoleProject
{
	public class Monster
	{
		public string Name { get; }
		public int HP { get; set; }
		public int Attack { get; }
		public int Defense { get; }

		public Monster(string name, int hp, int atk, int def)
		{
			Name = name;
			HP = hp;
			Attack = atk;
			Defense = def;
		}
	}
}
