using PixelVision8.Player;
using System;

public class GameManager {

    private static int TIME_PER_DAY = 20000;
    private static int timeInDay = 0;

    private static int timeToNextFire = 1000;
    private static int minTimeToFire = 500;
    private static int maxTimeToFire = 2500;



    public static void Update(CustomGameChip gameChip, int timeDelta) {
        Random rand = new Random();

        timeInDay += timeDelta;
        timeToNextFire -= timeDelta;
        if (timeToNextFire <= 0) {
            Vector2D spawnPoint = PlayArea.GenerateRandomSpawnerPoint();
            gameChip.AddBulletSpawner(new SpreadSpawner(spawnPoint, "babe", 3));
            timeToNextFire = rand.Next(minTimeToFire, maxTimeToFire);
        }
    }

}