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
			Console.Clear();
			Console.WriteLine($"{Name} - HP: {HP}, ATK: {Attack}, DEF: {Defense}");
			Console.WriteLine("인벤토리:");
			foreach (var item in Inventory)
			{
				Console.WriteLine("- " + item.Name);
			}
			Console.ReadLine();
		}

		public void SelectAndUseItem()
		{
			if (Inventory.Count == 0)
			{
				Console.WriteLine("사용할 수 있는 아이템이 없습니다.");
				return;
			}

			Console.WriteLine("사용할 아이템을 선택하세요:");
			for (int i = 0; i < Inventory.Count; i++)
			{
				Console.WriteLine($"[{i + 1}] {Inventory[i].Name}");
			}
				Console.WriteLine($"[0] 취소");
			Console.Write("선택: ");

			if (int.TryParse(Console.ReadLine(), out int choice))
			{
				if (choice == 0)
				{
					Console.WriteLine("아이템 사용을 취소했습니다.");
					return;
				}
				if (choice >= 1 && choice <= Inventory.Count)
				{
					Item selectedItem = Inventory[choice - 1];
					selectedItem.Use(this);
					Inventory.RemoveAt(choice - 1);
				}
				else
				{
					Console.WriteLine("잘못된 선택입니다.");
				}
			}
			else
			{
				Console.WriteLine("숫자를 입력해주세요.");
			}
		}

	}

}
