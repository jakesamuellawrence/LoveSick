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

		PlayerCharacter player;

		/*
			The Init() method is part of the game's lifecycle and called a game
			starts. We are going to use this method to configure background
			color, ScreenBufferChip and draw a text box.
		*/
		public override void Init()
		{
			player = new PlayerCharacter(this);
			PlayArea.Setup(this);
		}
		
		/*
			The Update() method is part of the game's life cycle. The engine 
			calls Update() on every frame before the Draw() method. It accepts 
			one argument, timeDelta, which is the difference in milliseconds 
			since the last frame.
		*/
		public override void Update(int timeDelta)
		{

			player.Update(this, timeDelta);

		}

		/* 
			The Draw() method is part of the game's life cycle. It is called 
			after Update() and is where all of our draw calls should go. We'll 
			be using this to render sprites to the display.
		*/
		public override void Draw()
		{
			Clear();
			player.Draw(this);
			PlayArea.Draw(this);

		}
	}
}