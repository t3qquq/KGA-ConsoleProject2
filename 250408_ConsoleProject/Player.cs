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
		public string Name { get; } = "플레이어";
		public int HP { get; set; } = 100;
		public int Attack { get; } = 12;
		public int Defense { get; } = 6;
		public List<Item> Inventory { get; } = new List<Item> { new HealingPotion(), new HealingPotion() };

		public void UseItem(string itemName)
		{
			Item? item = Inventory.FirstOrDefault(i => i.Name == itemName);
			if (item != null)
			{
				item.Use(this);
				Inventory.Remove(item);
			}
			else
			{
				Console.WriteLine("해당 아이템이 없습니다.");
			}
		}

		public void ShowStatus()
		{
			Console.WriteLine($"\n🧍‍♂️ {Name} - HP: {HP}, ATK: {Attack}, DEF: {Defense}");
			Console.WriteLine("🎒 인벤토리:");
			foreach (var item in Inventory)
			{
				Console.WriteLine("- " + item.Name);
			}
		}
	}

}
