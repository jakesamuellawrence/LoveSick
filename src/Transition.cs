using PixelVision8.Player;
using System;

public class Transition {

    private Point display;

    public Transition(CustomGameChip gameChip) {
        this.display = gameChip.Display();
    }
         

    public void Update(CustomGameChip gameChip, int timeDelta) {
        if (gameChip.Button(Buttons.A, InputState.Released, 0)) {
            if (gameChip.dayPhase == 2) {
                gameChip.dayPhase = 0;
                gameChip.currentDate++;
            }
            else {
                gameChip.dayPhase++;
            }
        }
    }

    private void DrawLines(CustomGameChip gameChip, string messageLines, int x = 16, int initY = 32, int lineSpacing = 16) {
        var wrappedMessageLines = gameChip.WordWrap(messageLines, (display.X - x)/6);
        var splitMessageLines = gameChip.SplitLines(wrappedMessageLines);
        for (int i = 0; i < splitMessageLines.Length; i++) {
            gameChip.DrawText(splitMessageLines[i], x, initY + i*lineSpacing, DrawMode.Sprite, "large", 15, -2);
        }
    }

    public void Draw(CustomGameChip gameChip) {
        // DrawText ( text, x, y, drawMode, font, colorOffset, spacing )
        string titleText = "Date " + gameChip.currentDate.ToString() + " - ";
        if (gameChip.dayPhase == 0) {
            titleText += "Entree";
            gameChip.DrawText(titleText, 16, 8, DrawMode.Sprite, "large", 15, -2);
            if (gameChip.currentDate == 1) {
                string message = "Spaghetti, meatballs, a glass of wine. You sit across from your first date in a long time. He has messy brown hair and a boyish grin that seems to stretch ear-to-ear.";
                DrawLines(gameChip, message);
            }
            else if (gameChip.currentDate == 2) {
                string message = "He’s having pizza, and you get a steak. He asks if you want to share half-and-half. His grin seems even wider than last time. It’s pretty cute.";
                DrawLines(gameChip, message);
            }
            else if (gameChip.currentDate == 3) {
                string message = "He’s having a burger, rare, and you have a plate of chips. You notice a stain on his shirt - it looks like his ketchup must have dripped.";
                DrawLines(gameChip, message);
            }
            else if (gameChip.currentDate == 4) {
                string message = "Mealworms, roaches, a splattering of brain. Maybe he’s right, and I’m going insane.";
                DrawLines(gameChip, message);
            }
            else if (gameChip.currentDate == 5) {
                string message = "You want to leave, but he convinces you to stay. Isn’t it kind of nice to feel wanted for once? It wouldn’t be fair to just let him starve after all he’s done for you, right?";
                DrawLines(gameChip, message);
            }
        }
        else if (gameChip.dayPhase == 2) {
            titleText += "Dessert";
            gameChip.DrawText(titleText, 16, 8, DrawMode.Sprite, "large", 15, -2);
            if (gameChip.currentDate == 1) {
                string message = "Today went well. He asked all the right questions. He seems to be a picky eater - he only ate the meatballs and left the spaghetti. You think it’s kind of cute. You agree to meet for another date in a few days";
                DrawLines(gameChip, message);
            }
            else if (gameChip.currentDate == 2) {
                string message = "You think you might be starting to get feelings for this guy. There’s definitely going to be a third date.";
                DrawLines(gameChip, message);
            }
            else if (gameChip.currentDate == 3) {
                string message = "He talked less today, and just spent most of the date staring at me. He took your phone from you and put a fourth date in your calendar.";
                DrawLines(gameChip, message);
            }
            else if (gameChip.currentDate == 4) {
                string message = "Today wasn’t as fun as your first date together and something really creeped you out. But it would be wrong to give up now after you’ve invested so much time already, right?";
                DrawLines(gameChip, message);
            }
            else if (gameChip.currentDate == 5) {
                string message = "Game over.";
                DrawLines(gameChip, message);
            }
        }
        gameChip.DrawText("Press the A button to continue.", 16, 206, DrawMode.Sprite, "large", 15, -1);
    }
}   
