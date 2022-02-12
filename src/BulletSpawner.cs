using PixelVision8.Player;
using System;

public abstract class BulletSpawner {

    private Vector2D position;
    private String spawnerText;

    private float DEFAULT_BULLET_SPEED = 0.05f;

    private int LIFETIME = 1000;
    private int TIME_TO_FIRE = 500;
    private bool hasFired = false;
    private int timeSinceCreation = 0;

    public BulletSpawner(Vector2D position, string spawnerText) {
        this.position = position;
        this.spawnerText = spawnerText;
    }

    public void Update(CustomGameChip gameChip, int timeDelta) {
        timeSinceCreation += timeDelta;
        if (!hasFired && timeSinceCreation >= TIME_TO_FIRE) {
            Fire(gameChip);
            hasFired = true;
        } else if (timeSinceCreation >= LIFETIME) {
            gameChip.RemoveBulletSpawner(this);
        }
    }

    public abstract void Fire(CustomGameChip gameChip);

    public void FireAt(CustomGameChip gameChip, Vector2D target) {
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