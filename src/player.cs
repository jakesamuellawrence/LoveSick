using PixelVision8.Player;
using System;

public class PlayerCharacter {

    private int SPRITE_INDEX = 0;

    private Vector2D position;
    private float movespeed = 0.15f; // speed in pixels / milisecond (probably?)

    public PlayerCharacter(CustomGameChip gameChip) {
        Point display = gameChip.Display();
        position = new Vector2D(display.X/2-8/2, display.Y/2-8/2);
    }

    public void Update(CustomGameChip gameChip, int timeDelta) {
        Vector2D inputVec = getNormalizedMovementVector(gameChip);
        position = position + inputVec * movespeed * timeDelta;
        PlayArea.ForceInBounds(position, 8, 8);
    }

    private Vector2D getNormalizedMovementVector(CustomGameChip gameChip) {
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

    public void Draw(CustomGameChip gameChip) {
        gameChip.DrawSprite(SPRITE_INDEX, (int)(position.x), (int)(position.y));
    }
}   
