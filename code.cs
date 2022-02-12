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
		BulletSpawner spawner1;
		List<WordBullet> bullets;
		List<WordBullet> bulletsToRemove;
		LoveMeter loveMeter;
		HPMeter hpMeter;

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
			spawner1 = new SpreadSpawner(new Vector2D(120, 50), "Cute", 5);
			spawner1.Fire(this);
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
				spawner1.Draw(this);
				foreach (WordBullet bullet in bullets) {
					bullet.Draw(this);
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

		public void PlayerHitBullet(WordBullet bullet) {
			loveMeter.gainLove(2);
			RemoveBullet(bullet);
		}
	}
}