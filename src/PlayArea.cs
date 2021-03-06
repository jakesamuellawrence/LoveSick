using PixelVision8.Player;
using System;

public class PlayArea {

    public static Vector2D centre;
    public static int WIDTH = 100;
    public static int HEIGHT = 100;

    public static void Setup(CustomGameChip gameChip) {
        Point display = gameChip.Display();
        centre = new Vector2D(display.X/2, display.Y/2+20);
    }

    public static void Draw(CustomGameChip gameChip) {
        gameChip.DrawRect((int)centre.x - WIDTH/2, (int)centre.y - HEIGHT/2, WIDTH, HEIGHT, 5, DrawMode.SpriteBelow);
    }

    public static void ForceInBounds(Vector2D position, int width, int height) {
        int leftEdge = (int)centre.x - WIDTH/2;
        int rightEdge = (int)centre.x + WIDTH/2;
        int topEdge = (int)centre.y - HEIGHT/2;
        int bottomEdge = (int)centre.y + HEIGHT/2;
        
        if ((position.x - width/2) <= leftEdge) {
            position.x = leftEdge + width/2;
        } else if ((position.x + width/2) >= rightEdge) {
            position.x = rightEdge - width/2;
        }

        if ((position.y - height/2) <= topEdge) {
            position.y = topEdge + height/2;
        } else if ((position.y + height/2) >= bottomEdge) {
            position.y = bottomEdge - height/2;
        }
    }

    public static Vector2D GenerateRandomPoint() {
        Random rand = new Random();
        int xPos = rand.Next(WIDTH);
        int yPos = rand.Next(HEIGHT);
        return new Vector2D(centre.x - WIDTH/2 + xPos, centre.y - HEIGHT/2 + yPos);
    }

    public static Vector2D GenerateRandomSpawnerPoint() {
        Random rand= new Random();
        int maxRangeX = 35;
        int minDistX = 35;

        int maxRangeY = 25;
        int minDistY = 25;

        float xPos;
        float yPos;

        if (rand.Next(0, 2) == 0) {
            xPos = rand.Next((int)centre.x - WIDTH/2 - maxRangeX, (int)centre.x + WIDTH/2 + maxRangeX);
            int yOffset = rand.Next(minDistY, maxRangeY);
            if (rand.Next(0, 2) == 0) {
                yPos = centre.y - HEIGHT/2 - yOffset;
            } else {
                yPos = centre.y + HEIGHT/2 + yOffset;
            }
        } else {
            yPos= rand.Next((int)centre.y - HEIGHT/2 - maxRangeY, (int)centre.y + HEIGHT/2 + maxRangeY);
            int xOffset = rand.Next(minDistX, maxRangeX);
            if (rand.Next(0, 2) == 0) {
                xPos = centre.x - WIDTH/2 - xOffset;
            } else {
                xPos = centre.x + WIDTH/2 + xOffset;
            }
        }

        return new Vector2D(xPos, yPos);
    }

}