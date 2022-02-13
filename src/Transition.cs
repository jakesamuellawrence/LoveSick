using PixelVision8.Player;
using System;

public class Transition {

    private Point display;

    public Transition(CustomGameChip gameChip) {
        this.display = gameChip.Display();
    }
         

    public void Update(CustomGameChip gameChip, int timeDelta) {
        if (gameChip.Button(Buttons.A, InputState.Released, 0)) {
            if (gameChip.dayPhase == 4) {
                gameChip.dayPhase = 0;
                gameChip.currentDate++;
            }
            // Testing Code to show only the transition slides
            // else if (gameChip.dayPhase == 2) {
            //     gameChip.dayPhase = 4;
            // }
            else {
                gameChip.dayPhase++;
            }
        }
    }

    private void DrawLines(CustomGameChip gameChip, string messageLines, int x = 16, int initY = 128, int lineSpacing = 16) {
        var wrappedMessageLines = gameChip.WordWrap(messageLines, (display.X - x*2)/6);
        var splitMessageLines = gameChip.SplitLines(wrappedMessageLines);
        for (int i = 0; i < splitMessageLines.Length; i++) {
            gameChip.DrawText(splitMessageLines[i], x, initY + i*lineSpacing, DrawMode.Sprite, "large", 15, -2);
        }
    }

    public void Draw(CustomGameChip gameChip) {
        int initY = display.Y/2 - 32;
        int withPictureYOffset = 64;
        // DrawText ( text, x, y, drawMode, font, colorOffset, spacing )
        string titleText = "Date " + gameChip.currentDate.ToString() + " - ";
        bool drawContinueText = true;
        if (gameChip.currentDate == 1) {
            if (gameChip.dayPhase == 0) {
                titleText += "Entree (1/2)";
                string message = "Spaghetti, meatballs, a glass of wine. You sit across from your first date in a long time.";
                gameChip.DrawText(titleText, display.X/4, 4, DrawMode.Sprite, "large", 15, -2);
                DrawLines(gameChip, message, initY : initY + withPictureYOffset);
                gameChip.DrawMetaSprite("day1", display.X/2-64, 16);
            }
            else if (gameChip.dayPhase == 1) {
                titleText += "Entree (2/2)";
                string message = "He has messy brown hair and a boyish grin that seems to stretch ear-to-ear.";
                gameChip.DrawText(titleText, display.X/4, 4, DrawMode.Sprite, "large", 15, -2);
                DrawLines(gameChip, message, initY : initY);
            }
            else if (gameChip.dayPhase == 2) {
                titleText += "Instructions";
                string message = "Collect the emotions evoked by his words to fill up the Love Meter!";
                gameChip.DrawText(titleText, display.X/4, 4, DrawMode.Sprite, "large", 15, -2);
                DrawLines(gameChip, message, initY : initY);
            }
            else if (gameChip.dayPhase == 4) {
                titleText += "Dessert";
                string message = "Today went well. He asked all the right questions. He seems to be a picky eater - he only ate the meatballs and left the spaghetti. You think it's kind of cute. You agree to meet for another date in a few days.";
                gameChip.DrawText(titleText, display.X/4, 4, DrawMode.Sprite, "large", 15, -2);
                DrawLines(gameChip, message, initY : initY);
            }
        }
        else if (gameChip.currentDate == 2) {
            if (gameChip.dayPhase == 0) {
                titleText += "Entree (1/2)";
                string message = "He's having pizza, and you get a steak. He asks if you want to share half-and-half.";
                gameChip.DrawText(titleText, display.X/4, 4, DrawMode.Sprite, "large", 15, -2);
                DrawLines(gameChip, message, initY : initY + withPictureYOffset);
                gameChip.DrawMetaSprite("day1", display.X/2-64, 16);
            }
            else if (gameChip.dayPhase == 1) {
                titleText += "Entree (2/2)";
                string message = "His grin seems even wider than last time. It's pretty cute.";
                gameChip.DrawText(titleText, display.X/4, 4, DrawMode.Sprite, "large", 15, -2);
                DrawLines(gameChip, message, initY : initY);
            }
            else if (gameChip.dayPhase == 2) {
                titleText += "Instructions";
                string message = "Collect the emotions evoked by his words to fill up the Love Meter!";
                gameChip.DrawText(titleText, display.X/4, 4, DrawMode.Sprite, "large", 15, -2);
                DrawLines(gameChip, message, initY : initY);
            }
            else if (gameChip.dayPhase == 4) {
                titleText += "Dessert";
                string message = "You think you might be starting to get feelings for this guy. There's definitely going to be a third date.";
                gameChip.DrawText(titleText, display.X/4, 4, DrawMode.Sprite, "large", 15, -2);
                DrawLines(gameChip, message, initY : initY);
            }
        }
        else if (gameChip.currentDate == 3) {
            if (gameChip.dayPhase == 0) {
                titleText += "Entree (1/2)";
                string message = "He's having a burger, rare, and you have a plate of chips.";
                gameChip.DrawText(titleText, display.X/4, 4, DrawMode.Sprite, "large", 15, -2);
                DrawLines(gameChip, message, initY : initY + withPictureYOffset);
                gameChip.DrawMetaSprite("day1", display.X/2-64, 16);
            }
            else if (gameChip.dayPhase == 1) {
                titleText += "Entree (2/2)";
                string message = "You notice a stain on his shirt - it looks like his ketchup must have dripped.";
                gameChip.DrawText(titleText, display.X/4, 4, DrawMode.Sprite, "large", 15, -2);
                DrawLines(gameChip, message, initY : initY);
            }
            else if (gameChip.dayPhase == 2) {
                titleText += "Instructions";
                string message = "Collect the emotions evoked by his words to fill up the Love Meter!";
                gameChip.DrawText(titleText, display.X/4, 4, DrawMode.Sprite, "large", 15, -2);
                DrawLines(gameChip, message, initY : initY);
            }
            else if (gameChip.dayPhase == 4) {
                titleText += "Dessert";
                string message = "He talked less today, and just spent most of the date staring at you. He took your phone from you and put a fourth date in your calendar.";
                gameChip.DrawText(titleText, display.X/4, 4, DrawMode.Sprite, "large", 15, -2);
                DrawLines(gameChip, message, initY : initY);
            }
        }
        else if (gameChip.currentDate == 4) {
            //@TODO: Base desciptions off the image we have. Current descriptions are placeholders.
            if (gameChip.dayPhase == 0) {
                titleText += "Entree (1/2)";
                string message = "Spaghetti, meatballs, a glass of wine. You sit across from your first date in a long time.";
                gameChip.DrawText(titleText, display.X/4, 4, DrawMode.Sprite, "large", 15, -2);
                DrawLines(gameChip, message, initY : initY + withPictureYOffset);
                gameChip.DrawMetaSprite("day1", display.X/2-64, 16);
            }
            else if (gameChip.dayPhase == 1) {
                titleText += "Entree (2/2)";
                string message = "He has messy brown hair and a boyish grin that seems to stretch ear-to-ear.";
                gameChip.DrawText(titleText, display.X/4, 4, DrawMode.Sprite, "large", 15, -2);
                DrawLines(gameChip, message, initY : initY);
            }
            else if (gameChip.dayPhase == 2) {
                titleText += "Instructions";
                string message = "Collect the emotions evoked by his words to fill up the Love Meter!";
                gameChip.DrawText(titleText, display.X/4, 4, DrawMode.Sprite, "large", 15, -2);
                DrawLines(gameChip, message, initY : initY);
            }
            else if (gameChip.dayPhase == 4) {
                titleText += "Dessert";
                string message = "You're really unsure. You've invested so much already, maybe one more date to help decide?";
                gameChip.DrawText(titleText, display.X/4, 4, DrawMode.Sprite, "large", 15, -2);
                DrawLines(gameChip, message, initY : initY);
            }
        }
        else if (gameChip.currentDate == 5) {
            if (gameChip.dayPhase == 0) {
                titleText += "Entree (1/2)";
                string message = "You want to leave, but he convinces you to stay. Isn't it kind of nice to feel wanted for once?";
                gameChip.DrawText(titleText, display.X/4, 4, DrawMode.Sprite, "large", 15, -2);
                DrawLines(gameChip, message, initY : initY + withPictureYOffset);
                gameChip.DrawMetaSprite("day1", display.X/2-64, 16);
            }
            else if (gameChip.dayPhase == 1) {
                titleText += "Entree (2/2)";
                string message = "It wouldn't be fair to just let him starve after all he's done for you, right?";
                gameChip.DrawText(titleText, display.X/4, 4, DrawMode.Sprite, "large", 15, -2);
                DrawLines(gameChip, message, initY : initY);
            }
            else if (gameChip.dayPhase == 2) {
                titleText += "Instructions";
                string message = "Survive by avoiding his attacks until the Love Meter runs out!";
                gameChip.DrawText(titleText, display.X/4, 4, DrawMode.Sprite, "large", 15, -2);
                DrawLines(gameChip, message, initY : initY);
            }
            else if (gameChip.dayPhase == 4) {
                titleText += "The End";
                string message = "";
                if (gameChip.getHP() <= 0) {
                    message = "Love is hard to find in a radioactive wasteland. I guess your search won't go on any longer.";
                }
                else {
                    message = "Love is hard to find in a radioactive wasteland. Looks like your search will have to continue.";
                }
                gameChip.DrawText(titleText, display.X/4, 4, DrawMode.Sprite, "large", 15, -2);
                DrawLines(gameChip, message, initY : initY);
            }
        }
        else {
            string message = "Press ESC to exit.";
            DrawLines(gameChip, message, x : 64, initY : initY);
            drawContinueText = false;
        }
        if (drawContinueText) {
            gameChip.DrawText("Press the A button to continue.", 16, display.Y-16, DrawMode.Sprite, "large", 15, -1);
        }
    }
}   
