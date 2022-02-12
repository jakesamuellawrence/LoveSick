using PixelVision8.Player;
using System;
public class WordBullet {

    private Vector2D position;
    private Vector2D velocity;
    private int WIDTH = 8;
    private int HEIGHT = 8;
    private int SPRITE_INDEX = 1;

    public WordBullet(Vector2D position, Vector2D velocity) {
        this.position = position;
        this.velocity = velocity;
    }

    public void Update(CustomGameChip gameChip, int timeDelta) {
        this.position = position + velocity * timeDelta;
        PlayerCharacter p = gameChip.player;
        if (p.getBoundingBox(gameChip).Intersects(this.getBoundingBox(gameChip))) {
            gameChip.PlayerHitBullet(this);
        }
    }

    public void Draw(CustomGameChip gameChip) {
        gameChip.DrawSprite(SPRITE_INDEX, (int)position.x - WIDTH/2, (int)position.y - HEIGHT/2, false, false, DrawMode.Sprite);
    }

    public Rectangle getBoundingBox(CustomGameChip gameChip){
        return gameChip.NewRect((int)position.x - WIDTH/2, (int)position.y - HEIGHT/2, WIDTH, HEIGHT);
    }
}