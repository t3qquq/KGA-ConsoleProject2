using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _250408_ConsoleProject
{
	public class Player
	{
		public string Name { get; } = "용사";
		public int HP { get; set; } = 100;
		public int Attack { get; } = 12;
		public int Defense { get; } = 6;
		//public List<Item> Inventory 

		public void UseItem(string itemName)
		{
		}

		public void ShowStatus()
		{
			Console.WriteLine($"\n🧍‍♂️ {Name} - HP: {HP}, ATK: {Attack}, DEF: {Defense}");
			Console.WriteLine("🎒 인벤토리:");
			//showInven
		}
	}

}
