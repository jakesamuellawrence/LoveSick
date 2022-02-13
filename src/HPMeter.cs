using PixelVision8.Player;
using System;

public class HPMeter {

    public bool enabled = false;

    private const int textPositionX = 8;


    private const int positionX = 64;
    private const int positionY = 24;
    private const int width = 100;
    private const int height = 8;
    private const int frameColorIndex = 15;
    private const int fillColorIndex = 9;

    public int hpValue = width;

    public void loseHP(CustomGameChip gameChip, int value) {
        hpValue -= value;
        if (hpValue < 0) {
            hpValue = 0;
            gameChip.DayDone();
        }
    }

    public void Draw(CustomGameChip gameChip) {
        if (!enabled) return;
        
        gameChip.DrawText("HP:", textPositionX, positionY, DrawMode.UI, "large", 15, 0);
        gameChip.DrawRect(positionX-1, positionY-1, width+2, height+2, frameColorIndex, DrawMode.SpriteBelow);
        gameChip.DrawRect(positionX, positionY, width, height, 0, DrawMode.Sprite);
        gameChip.DrawRect(positionX, positionY, hpValue, height, fillColorIndex, DrawMode.SpriteAbove);
    }

}