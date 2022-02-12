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
        int xOffset = rand.Next(10, 25);
        int yOffset = rand.Next(10, 25);

        Vector2D point = new Vector2D(0, 0);
        if (rand.Next(0, 2) == 0) {
            point.x = centre.x - WIDTH/2 - xOffset;
        } else {
            point.x = centre.x + WIDTH/2 + xOffset;
        }

        if (rand.Next(0, 2) == 0) {
            point.y = centre.y - HEIGHT/2 - yOffset;
        } else {
            point.y = centre.y + HEIGHT/2 + yOffset;
        }
        return point;
    }

}