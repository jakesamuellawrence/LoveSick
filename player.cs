using PixelVision8.Player;

public class PlayerCharacter {

    private int SPRITE_INDEX = 0;

    private int x;
    private int y;

    public PlayerCharacter(GameChip gameChip) {
        Point display = gameChip.Display();
        this.x = display.X/2;
        this.y = display.Y/2;
    }

    public void Update(GameChip gameChip, int timeDelta) {
        if (gameChip.Button(Buttons.Up, InputState.Down, 0)) {
            this.y -= 1;
        } else if (gameChip.Button(Buttons.Down, InputState.Down, 0)) {
            this.y += 1;
        }
    }

    public void Draw(GameChip gameChip) {
        gameChip.DrawSprite(SPRITE_INDEX, x, y);
    }
}   
