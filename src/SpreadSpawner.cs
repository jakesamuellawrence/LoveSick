using PixelVision8.Player;

public class SpreadSpawner : BulletSpawner {

    private int numBullets;

    public SpreadSpawner(Vector2D position, string spawnerText, int numBullets) : base(position, spawnerText) {
        this.numBullets = numBullets;
    }

    public override void Fire(CustomGameChip gameChip){
        for(int i = 0; i < numBullets; i++) {
            Vector2D target = PlayArea.GenerateRandomPoint();
            FireAt(gameChip, target);
        }
        gameChip.PlaySound(7);
    }
}