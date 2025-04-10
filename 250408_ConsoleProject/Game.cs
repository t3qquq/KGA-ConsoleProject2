namespace _250408_ConsoleProject
{
	public class Game
	{
		private Player player;
		private List<Region> regions;

		public void Start()
		{
			player = new Player();
			regions = CreateRegions();
			ShowMainMenu();
		}

		private void ShowMainMenu()
		{
			Console.WriteLine("\n🏰 메인 메뉴");
			Console.WriteLine("[1] 지역 탐험");
			Console.WriteLine("[2] 상태 보기");
			Console.WriteLine("[3] 아이템 사용");
			Console.WriteLine("[0] 종료");

			string input = Console.ReadLine();
			switch (input)
			{
				case "1":
					EnterRegion("숲");
					break;
				case "2":
					player.ShowStatus();
					break;
				case "3":
					Console.Write("사용할 아이템 이름: ");
					string itemName = Console.ReadLine();
					player.UseItem(itemName);
					break;
				case "0":
					Console.WriteLine("게임을 종료합니다.");
					return;
			}

			ShowMainMenu();
		}

		private void EnterRegion(string regionName)
		{
			Region? region = regions.FirstOrDefault(r => r.Name == regionName);
			region?.Enter(player);
		}

		private List<Region> CreateRegions()
		{
			return new List<Region>
			{
			new Region("숲", new Monster("고블린", 30, 10, 2), new HealingPotion())
		};
		}
	}
}
