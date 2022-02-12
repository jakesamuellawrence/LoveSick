using PixelVision8.Player;
using System;

public class BulletSpawner {

    private Vector2D position;
    private String spawnerText;

    private float DEFAULT_BULLET_SPEED = 0.2f;

    public BulletSpawner(Vector2D position, String spawnerText) {
        this.position = position;
        this.spawnerText = spawnerText;
    }

    public void fireAt(CustomGameChip gameChip, Vector2D target) {
        Vector2D direction = (target - this.position).normalized();
        WordBullet bullet = new WordBullet(this.position, direction * DEFAULT_BULLET_SPEED);
        gameChip.AddBullet(bullet);
    }

    public void Draw(CustomGameChip gameChip) {
        int textSpacing = 0;
        int textWidth = spawnerText.Length * (8 + textSpacing);
        gameChip.DrawText(spawnerText, (int)position.x - textWidth/2, (int)position.y - 8/2, DrawMode.UI, "large", 15, textSpacing);
    }
}