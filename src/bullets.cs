using PixelVision8.Player;
using System;
public class WordBullet {

    private Vector2D position;
    private Vector2D velocity;
    private int WIDTH = 8;
    private int HEIGHT = 8;
    private int SPRITE_INDEX = 1;

    public WordBullet(CustomGameChip gameChip, Vector2D position, Vector2D velocity) {
        this.position = position;
        this.velocity = velocity;
    }

    public void Update(CustomGameChip gameChip) {
        position = position.add(velocity);
    }

    public void Draw(CustomGameChip gameChip) {
        gameChip.DrawSprite(SPRITE_INDEX, (int)position.x - WIDTH/2, (int)position.y - HEIGHT/2, false, false, DrawMode.Sprite);
    }
}