using PixelVision8.Player;
using System;

public class LoveMeter {

    private const int textPositionX = 8;

    private const int positionX = 64;
    private const int positionY = 8;
    private const int width = 100;
    private const int height = 8;
    private const int frameColorIndex = 15;
    private const int fillColorIndex = 10;

    public float loveValue = 0;

    public void gainLove(float amount){
        loveValue += amount;
    }

    public void Draw(CustomGameChip gameChip) {
        gameChip.DrawText("LOVE:", textPositionX, positionY, DrawMode.UI, "large", 15, 0);
        gameChip.DrawRect(positionX-1, positionY-1, width+2, height+2, frameColorIndex, DrawMode.SpriteBelow);
        gameChip.DrawRect(positionX, positionY, width, height, 0, DrawMode.Sprite);
        gameChip.DrawRect(positionX, positionY, (int)loveValue, height, fillColorIndex, DrawMode.SpriteAbove);
    }

}