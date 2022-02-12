using PixelVision8.Player;

public class PlayerCharacter {

    private int SPRITE_INDEX = 0;

    private Vector2D position;
    private float movespeed = 0.1f; // speed in pixels / milisecond (probably?)

    public PlayerCharacter(GameChip gameChip) {
        Point display = gameChip.Display();
        position = new Vector2D(8, 8);
    }

    public void Update(GameChip gameChip, int timeDelta) {
        // Vector2D inputVec = getNormalizedMovementVector(gameChip);
        // position = position.add(inputVec.times(movespeed * timeDelta));
    }

    private Vector2D getNormalizedMovementVector(GameChip gameChip) {
        Vector2D inputVec = new Vector2D(0, 0);
        if (gameChip.Button(Buttons.Up, InputState.Down, 0)) {
            inputVec.y -= 1;
        }
        if (gameChip.Button(Buttons.Down, InputState.Down, 0)) {
            inputVec.y += 1;
        }
        if (gameChip.Button(Buttons.Left, InputState.Down, 0)) {
            inputVec.x -= 1;
        }
        if (gameChip.Button(Buttons.Right, InputState.Down, 0)) {
            inputVec.x += 1;
        }
        return inputVec.normalized();
    }

    public void Draw(GameChip gameChip) {
        gameChip.DrawSprite(SPRITE_INDEX, (int)(position.x), (int)(position.y));
    }
}   
