using PixelVision8.Player;
using System;

public class GameManager {

    private static int TIME_PER_DAY = 20000;
    private static int TIME_PER_LOVE_POINT = 500;
    private static int timeInDay = 0;

    private static int timeToNextFire = 1000;
    private static int minTimeToFire = 500;
    private static int maxTimeToFire = 2500;

    private static int minScatterNum = 2;
    private static int maxScatterNum = 4;

    private static string[] spawnerTexts = {
        "Babe",
        "Cutie",
        "Honey",
        "Sweetheart",
    };

    public static void Init(CustomGameChip gameChip) {
        UpdateParameters(gameChip);
        if (gameChip.currentDate == 5) {
            gameChip.hpMeter.enabled = true;
        }
    }


    public static void Update(CustomGameChip gameChip, int timeDelta) {
        Random rand = new Random();

        timeInDay += timeDelta;
        timeToNextFire -= timeDelta;
        if (timeToNextFire <= 0) {
            SpawnScatterSpawner(gameChip, rand);
            timeToNextFire = rand.Next(minTimeToFire, maxTimeToFire);
        }

        if (gameChip.currentDate == 5) {
            gameChip.loveMeter.loveValue = (TIME_PER_DAY - timeInDay) / TIME_PER_LOVE_POINT;
        }

        if (timeInDay >= TIME_PER_DAY) {
            gameChip.DayDone();
            timeInDay = 0;
        }
    }

    public static void UpdateParameters(CustomGameChip gameChip) {
        if (gameChip.currentDate == 2) {
            minTimeToFire = 400;
            maxTimeToFire = 2250;
            minScatterNum = 3;
            maxScatterNum = 5;
            spawnerTexts = new string[] {
                "Honey",
                "Snack",
                "Spider-Monkey",
                "Sweet",
                "Scrumptious"
            };
        } else if (gameChip.currentDate == 3) {
            minTimeToFire = 300;
            maxTimeToFire = 2000;
            minScatterNum = 3;
            maxScatterNum = 6;
            spawnerTexts = new string[] {
                "Snack",
                "Meal",
                "Tempting",
                "Plump"
            };
        } else if (gameChip.currentDate == 4) {
            minTimeToFire = 200;
            maxTimeToFire = 1750;
            minScatterNum = 4;
            maxScatterNum = 7;
            spawnerTexts = new string[] {
                "Hunger",
                "Hunting",
                "Desire",
                "Mine"
            };
        } else if (gameChip.currentDate == 5) {
            TIME_PER_DAY = gameChip.loveMeter.loveValue * TIME_PER_LOVE_POINT;
            minTimeToFire = 100;
            maxTimeToFire = 1500;
            minScatterNum = 4;
            maxScatterNum = 8;
            spawnerTexts = new string[] {
                "Mine"
            };
        }
    }

    public static void SpawnScatterSpawner(CustomGameChip gameChip, Random rand) {
        Vector2D spawnPoint = PlayArea.GenerateRandomSpawnerPoint();
        string text = spawnerTexts[rand.Next(spawnerTexts.Length)];
        int numBullets = rand.Next(minScatterNum, maxScatterNum);
        gameChip.AddBulletSpawner(new SpreadSpawner(spawnPoint, text, numBullets));
    }

}