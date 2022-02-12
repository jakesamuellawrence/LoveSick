using PixelVision8.Player;
using System;

public class HPMeter {

    private const int textPositionX = 8;


    private const int positionX = 64;
    private const int positionY = 24;
    private const int width = 80;
    private const int height = 8;
    private const int frameColorIndex = 15;
    private const int fillColorIndex = 9;

    public int hpValue = width;

    public void loseHP(int value) {
        hpValue -= value;
    }

    public void Draw(CustomGameChip gameChip) {
        gameChip.DrawText("HP:", textPositionX, positionY, DrawMode.SpriteBelow, "large", 15, 0);
        gameChip.DrawRect(positionX-1, positionY-1, width+2, height+2, frameColorIndex, DrawMode.SpriteBelow);
        gameChip.DrawRect(positionX, positionY, width, height, 0, DrawMode.SpriteBelow);
        gameChip.DrawRect(positionX, positionY, hpValue, height, fillColorIndex, DrawMode.SpriteBelow);
    }

}