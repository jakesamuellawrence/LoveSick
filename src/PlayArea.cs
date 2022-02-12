using PixelVision8.Player;
using System;

public class PlayArea {

    public static Vector2D centre;
    public static int WIDTH = 100;
    public static int HEIGHT = 100;

    public static void Setup(GameChip gameChip) {
        Point display = gameChip.Display();
        centre = new Vector2D(display.X/2, display.Y/2);
    }

    public static void Draw(GameChip gameChip) {
        Console.WriteLine(DrawMode.SpriteBelow);
        gameChip.DrawRect((int)centre.x - WIDTH/2, (int)centre.y - HEIGHT/2, WIDTH, HEIGHT, 5, DrawMode.SpriteBelow);
    }

    public static void ForceInBounds(Vector2D position, int width, int height) {
        int leftEdge = (int)centre.x - WIDTH/2;
        int rightEdge = (int)centre.x + WIDTH/2;
        int topEdge = (int)centre.y - HEIGHT/2;
        int bottomEdge = (int)centre.y + HEIGHT/2;
        
        if ((position.x) <= leftEdge) {
            position.x = leftEdge;
        } else if ((position.x + width) >= rightEdge) {
            position.x = rightEdge - width;
        }

        if ((position.y) <= topEdge) {
            position.y = topEdge;
        } else if ((position.y + height) >= bottomEdge) {
            position.y = bottomEdge - height;
        }
    }

}