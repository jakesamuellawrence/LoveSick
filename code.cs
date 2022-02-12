using System.Collections.Generic;

/*
 For C# games, we need to put our main class inside of the 
 `PixelVision8.Player` namespace.
*/
namespace PixelVision8.Player
{
	
	/*
		Our main class also need to extend the `GameChip` class. This is how
		the C# engine knows which class to use as the main game class.
	*/
	public class CustomGameChip : GameChip
	{

		public PlayerCharacter player;
		Transition transition;
		public int currentDate = 1;
		public int dayPhase = 0;
		List<BulletSpawner> spawners;
		List<BulletSpawner> spawnersToRemove;
		List<WordBullet> bullets;
		List<WordBullet> bulletsToRemove;
		LoveMeter loveMeter;
		HPMeter hpMeter;

		int PLAY_MAX_TIME = 60000;
		int currTime = 0;

		/*
			The Init() method is part of the game's lifecycle and called a game
			starts. We are going to use this method to configure background
			color, ScreenBufferChip and draw a text box.
		*/
		public override void Init()
		{
			player = new PlayerCharacter(this);
			transition = new Transition(this);
			PlayArea.Setup(this);
			loveMeter = new LoveMeter();
			hpMeter = new HPMeter();
			bullets = new List<WordBullet>();
			bulletsToRemove = new List<WordBullet>();
			spawners = new List<BulletSpawner>();
			spawnersToRemove = new List<BulletSpawner>();
			BulletSpawner spawner1 = new SpreadSpawner(new Vector2D(120, 50), "Cute", 5);
			AddBulletSpawner(spawner1);
			// bullets.Add(new WordBullet(new Vector2D(120, 120), new Vector2D(0.15f, 0.15f)));
		}
		
		/*
			The Update() method is part of the game's life cycle. The engine 
			calls Update() on every frame before the Draw() method. It accepts 
			one argument, timeDelta, which is the difference in milliseconds 
			since the last frame.
		*/
		public override void Update(int timeDelta)
		{
			if (dayPhase == 1) {
				GameManager.Update(this, timeDelta);

				player.Update(this, timeDelta);

				foreach (WordBullet bullet in bullets) {
					bullet.Update(this, timeDelta);
				}
				foreach (WordBullet bullet in bulletsToRemove) {
					bullets.Remove(bullet);
				}

				foreach (BulletSpawner spawner in spawners) {
					spawner.Update(this, timeDelta);
				}
				foreach (BulletSpawner spawner in spawnersToRemove) {
					spawners.Remove(spawner);
				}
			}
			else {
				transition.Update(this, timeDelta);
			}
		}

		/* 
			The Draw() method is part of the game's life cycle. It is called 
			after Update() and is where all of our draw calls should go. We'll 
			be using this to render sprites to the display.
		*/
		public override void Draw()
		{
			Clear();
			if (dayPhase == 1) {
				PlayArea.Draw(this);
				player.Draw(this);
				foreach (WordBullet bullet in bullets) {
					bullet.Draw(this);
				}
				foreach (BulletSpawner spawner in spawners) {
					spawner.Draw(this);
				}
				loveMeter.Draw(this);
				hpMeter.Draw(this);
			}
			else {
				transition.Draw(this);
			}
		}

		public void AddBullet(WordBullet bullet) {
			bullets.Add(bullet);
		}

		public void RemoveBullet(WordBullet bullet) {
			bulletsToRemove.Add(bullet);
		}

		public void AddBulletSpawner(BulletSpawner spawner) {
			spawners.Add(spawner);
		}

		public void RemoveBulletSpawner(BulletSpawner spawner) {
			spawnersToRemove.Add(spawner);
		}

		public void PlayerHitBullet(WordBullet bullet) {
			loveMeter.gainLove(2);
			RemoveBullet(bullet);
		}
	}
}