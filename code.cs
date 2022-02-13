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
		public Transition transition;
		public int currentDate = 1;
		public int dayPhase = 0;
		public List<BulletSpawner> spawners;
		public List<BulletSpawner> spawnersToRemove;
		public List<WordBullet> bullets;
		public List<WordBullet> bulletsToRemove;
		public LoveMeter loveMeter;
		public float lovePerBullet = 1f;
		public HPMeter hpMeter;

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

			GameManager.Init(this);
			// bullets.Add(new WordBullet(new Vector2D(120, 120), new Vector2D(0.15f, 0.15f)));

			PlaySong(1, true);
		}
		
		/*
			The Update() method is part of the game's life cycle. The engine 
			calls Update() on every frame before the Draw() method. It accepts 
			one argument, timeDelta, which is the difference in milliseconds 
			since the last frame.
		*/
		public override void Update(int timeDelta)
		{
			if (dayPhase == 3) {
				GameManager.Update(this, timeDelta);
				player.Update(this, timeDelta);

				foreach (WordBullet bullet in bullets) {
					bullet.Update(this, timeDelta);
					if (bullet.isOffscreen(this)) {
						RemoveBullet(bullet);
					}
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
			if (dayPhase == 3) {
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
			loveMeter.gainLove(lovePerBullet);
			UpdateLovePerBullet();
			if (currentDate == 5) {
				hpMeter.loseHP(this, 5);
				PlaySound(5, 1);
			}
			else {
				PlaySound(6, 1);
			}
			RemoveBullet(bullet);
		}

		public void UpdateLovePerBullet() {
			if (loveMeter.loveValue >= 20) {
				lovePerBullet = 0.8f;
			} else if (loveMeter.loveValue >= 40) {
				lovePerBullet = 0.6f;
			} else if (loveMeter.loveValue >= 60) {
				lovePerBullet = 0.4f;
			} else if (loveMeter.loveValue >= 80) {
				lovePerBullet = 0.2f;
			} else if (loveMeter.loveValue >= 100) {
				lovePerBullet = 0.1f;
			}
		}

		public void DayDone() {
			foreach (BulletSpawner spawner in spawners) {
				RemoveBulletSpawner(spawner);
			}
			foreach (WordBullet bullet in bullets) {
				RemoveBullet(bullet);
			}
			dayPhase += 1;
		}

		public void NextDay() {
			StopSong();
			currentDate++;
			if (currentDate < 4) {
				PlaySong(1, true);
			}
			else {
				PlaySong(0, true);
			}
			
			GameManager.Init(this);
		}

		public int getHP() {
			return hpMeter.hpValue;
		}
	}
}