using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _250408_ConsoleProject
{
	public class Region
	{
		public string Name { get; }
		public Monster? RegionBoss { get; }
		public Item? RewardItem { get; }

		public Region(string name, Monster? boss, Item? reward)
		{
			Name = name;
			RegionBoss = boss;
			RewardItem = reward;
		}

		public void Enter(Player player)
		{
			Console.WriteLine($"\n🌲 [{Name}] 지역에 입장했습니다!");
			if (RegionBoss != null)
			{
				Battle(player, RegionBoss);
			}
			if (RewardItem != null && player.HP > 0)
			{
				player.Inventory.Add(RewardItem);
				Console.WriteLine($"보상 아이템 {RewardItem.Name}을(를) 획득했습니다!");
			}
		}

		private void Battle(Player player, Monster monster)
		{
			Console.WriteLine($"⚔️ {monster.Name}과(와) 전투를 시작합니다!");

			bool defending = false;

			while (player.HP > 0 && monster.HP > 0)
			{
				Console.WriteLine($"\n🧍‍♂️ {player.Name} - HP: {player.HP}");
				Console.WriteLine($"👹 {monster.Name} - HP: {monster.HP}");
				Console.WriteLine("[1] 공격 [2] 방어 [3] 아이템 사용");
				string input = Console.ReadLine();

				switch (input)
				{
					case "1":
						int playerDamage = Math.Max(player.Attack - monster.Defense, 1);
						monster.HP -= playerDamage;
						Console.WriteLine($"{player.Name}의 공격! {monster.Name}에게 {playerDamage}의 피해!");
						break;
					case "2":
						defending = true;
						Console.WriteLine($"{player.Name}는 방어 태세를 취했습니다!");
						break;
					case "3":
						Console.Write("사용할 아이템 이름: ");
						string itemName = Console.ReadLine();
						player.UseItem(itemName);
						break;
					default:
						Console.WriteLine("잘못된 입력입니다.");
						break;
				}

				if (monster.HP <= 0)
				{
					Console.WriteLine($"\n🎉 {monster.Name}을(를) 물리쳤습니다!");
					break;
				}

				// 몬스터 턴
				int monsterDamage = Math.Max(monster.Attack - player.Defense, 1);
				if (defending)
				{
					monsterDamage /= 2;
					Console.WriteLine("방어로 인해 피해가 절반으로 감소했습니다!");
					defending = false;
				}
				player.HP -= monsterDamage;
				Console.WriteLine($"{monster.Name}의 공격! {player.Name}에게 {monsterDamage}의 피해!");

				if (player.HP <= 0)
				{
					Console.WriteLine("\n💀 전투에서 패배했습니다...");
				}
			}
		}
	}
}
