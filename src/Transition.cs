using PixelVision8.Player;
using System;

public class Transition {

    const int TEXT_SPACING = -1;

    private Point display;

    public Transition(CustomGameChip gameChip) {
        this.display = gameChip.Display();
    }
         

    public void Update(CustomGameChip gameChip, int timeDelta) {
        if (gameChip.Button(Buttons.A, InputState.Released, 0)) {
            if (gameChip.dayPhase == 4) {
                gameChip.dayPhase = 0;
                gameChip.NextDay();
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
        var wrappedMessageLines = gameChip.WordWrap(messageLines, (display.X - x*2)/(8+TEXT_SPACING));
        var splitMessageLines = gameChip.SplitLines(wrappedMessageLines);
        for (int i = 0; i < splitMessageLines.Length; i++) {
            gameChip.DrawText(splitMessageLines[i], x, initY + i*lineSpacing, DrawMode.Sprite, "large", 15, TEXT_SPACING);
        }
    }

    private void DrawLogo(CustomGameChip gameChip) {
        int logoWidth = 88;
        // int logoHeight = 26;
        int logoHeight = 60;
        int xPos = display.X/2 - logoWidth/2;
        int yPos = display.Y/2 - logoHeight/2;
        gameChip.DrawMetaSprite("logo", xPos, yPos, drawMode: DrawMode.SpriteAbove);
    }

    public void DrawTitle(CustomGameChip gameChip, string text, int yPos=4) {
        int textWidth = text.Length * (8 + TEXT_SPACING);
        int xPos = display.X/2 - textWidth/2;
        gameChip.DrawText(text, xPos, yPos, DrawMode.Sprite, "large", 15, TEXT_SPACING);
    }

    public void Draw(CustomGameChip gameChip) {
        int initY = display.Y/2 - 32;
        int withPictureYOffset = 64;
        // DrawText ( text, x, y, drawMode, font, colorOffset, spacing )
        string titleText = "Date " + gameChip.currentDate.ToString() + " - ";
        bool drawContinueText = true;
        if (gameChip.currentDate == 1) {
            if (gameChip.dayPhase == -1) {
                DrawLogo(gameChip);
                DrawTitle(gameChip, "Love is hard to find...", display.Y/2 + 10);
            } 
            if (gameChip.dayPhase == 0) {
                titleText += "Entree (1/2)";
                string message = "Spaghetti, meatballs, and a glass of wine. You sit across from your first date in a long time.";
                DrawTitle(gameChip, titleText);
                DrawLines(gameChip, message, initY : initY + withPictureYOffset);
                gameChip.DrawMetaSprite("day1", display.X/2-64, 16);
            }
            else if (gameChip.dayPhase == 1) {
                titleText += "Entree (2/2)";
                string message = "He has messy brown hair and a boyish grin that seems to stretch ear-to-ear.";
                DrawTitle(gameChip, titleText);
                DrawLines(gameChip, message, initY : initY);
            }
            else if (gameChip.dayPhase == 2) {
                titleText += "Instructions";
                string message = "Collect the emotions evoked by his words to fill up the Love Meter!";
                DrawTitle(gameChip, titleText);
                DrawLines(gameChip, message, initY : initY);
            }
            else if (gameChip.dayPhase == 4) {
                titleText += "Dessert";
                string message = "Today went well. He asked all the right questions. He seems to be a picky eater - he only ate the meatballs and left the spaghetti. You think it's kind of cute. You agree to meet for another date in a few days.";
                DrawTitle(gameChip, titleText);
                DrawLines(gameChip, message, initY : initY);
            }
        }
        else if (gameChip.currentDate == 2) {
            if (gameChip.dayPhase == 0) {
                titleText += "Entree (1/2)";
                string message = "He's having pizza, and you get a steak. He eyes it up and asks if you want to share half-and-half.";
                DrawTitle(gameChip, titleText);
                DrawLines(gameChip, message, initY : initY + withPictureYOffset);
                gameChip.DrawMetaSprite("day2", display.X/2-64, 16);
            }
            else if (gameChip.dayPhase == 1) {
                titleText += "Entree (2/2)";
                string message = "His grin seems even wider than last time. It's pretty cute.";
                DrawTitle(gameChip, titleText);
                DrawLines(gameChip, message, initY : initY);
            }
            else if (gameChip.dayPhase == 2) {
                titleText += "Instructions";
                string message = "Collect the emotions evoked by his words to fill up the Love Meter!";
                DrawTitle(gameChip, titleText);
                DrawLines(gameChip, message, initY : initY);
            }
            else if (gameChip.dayPhase == 4) {
                titleText += "Dessert";
                string message = "You think you might be starting to get feelings for this guy. There's definitely going to be a third date.";
                DrawTitle(gameChip, titleText);
                DrawLines(gameChip, message, initY : initY);
            }
        }
        else if (gameChip.currentDate == 3) {
            if (gameChip.dayPhase == 0) {
                titleText += "Entree (1/2)";
                string message = "He's having a burger, rare, and you have a plate of chips.";
                DrawTitle(gameChip, titleText);
                DrawLines(gameChip, message, initY : initY + withPictureYOffset);
                gameChip.DrawMetaSprite("day3", display.X/2-64, 16);
            }
            else if (gameChip.dayPhase == 1) {
                titleText += "Entree (2/2)";
                string message = "You notice a stain on his shirt - it looks like his ketchup must have dripped.";
                DrawTitle(gameChip, titleText);
                DrawLines(gameChip, message, initY : initY);
            }
            else if (gameChip.dayPhase == 2) {
                titleText += "Instructions";
                string message = "Collect the emotions evoked by his words to fill up the Love Meter!";
                DrawTitle(gameChip, titleText);
                DrawLines(gameChip, message, initY : initY);
            }
            else if (gameChip.dayPhase == 4) {
                titleText += "Dessert";
                string message = "He talked less today, and just spent most of the date staring at you. He took your phone from you and put a fourth date in your calendar.";
                DrawTitle(gameChip, titleText);
                DrawLines(gameChip, message, initY : initY);
            }
        }
        else if (gameChip.currentDate == 4) {
            //@TODO: Base desciptions off the image we have. Current descriptions are placeholders.
            if (gameChip.dayPhase == 0) {
                titleText += "Entree (1/2)";
                string message = "You sit across from your first... boyfriend? in a long time.";
                DrawTitle(gameChip, titleText);
                DrawLines(gameChip, message, initY : initY + withPictureYOffset);
                gameChip.DrawMetaSprite("day4", display.X/2-64, 16);
            }
            else if (gameChip.dayPhase == 1) {
                titleText += "Entree (2/2)";
                string message = "He has untidy brown hair and a demonic grin that stretches past his ears.";
                DrawTitle(gameChip, titleText);
                DrawLines(gameChip, message, initY : initY);
            }
            else if (gameChip.dayPhase == 2) {
                titleText += "Instructions";
                string message = "Collect the emotions evoked by his words to fill up the Love Meter!";
                DrawTitle(gameChip, titleText);
                DrawLines(gameChip, message, initY : initY);
            }
            else if (gameChip.dayPhase == 4) {
                titleText += "Dessert";
                string message = "You didn't have much fun today. But you've invested so much time already, maybe one more date to help decide?";
                DrawTitle(gameChip, titleText);
                DrawLines(gameChip, message, initY : initY);
            }
        }
        else if (gameChip.currentDate == 5) {
            if (gameChip.dayPhase == 0) {
                titleText += "Entree (1/2)";
                string message = "Today, YOU are the entree";
                DrawTitle(gameChip, titleText);
                DrawLines(gameChip, message, initY : initY + withPictureYOffset);
                gameChip.DrawMetaSprite("day5", display.X/2-64, 16);
            }
            else if (gameChip.dayPhase == 1) {
                titleText += "Entree (2/2)";
                string message = "You want to leave, but he convinces you to stay. Isn't it kind of nice to feel wanted for once? It wouldn't be fair to just let him starve after all he's done for you, right?";
                DrawTitle(gameChip, titleText);
                DrawLines(gameChip, message, initY : initY);
            }
            else if (gameChip.dayPhase == 2) {
                titleText += "Instructions";
                string message = "Survive by avoiding his attacks until the Love Meter runs out!";
                DrawTitle(gameChip, titleText);
                DrawLines(gameChip, message, initY : initY);
            }
            else if (gameChip.dayPhase == 4) {
                string message = "";
                if (gameChip.getHP() <= 0) {
                    titleText += "Game Over";
                    message = "You call out for help...\n \n But nobody came";
                }
                else if (gameChip.isLoveLess) {
                    titleText += "The End";
                    message = "Your barely collected any love at all, didn't you? You successfully shut yourself from feeling anything at all. You win?";
                } else {
                    titleText += "Survival";
                    message = "You've survived another day. You sigh. Time to start the search for love all over again...";
                }
                DrawTitle(gameChip, titleText);
                DrawLines(gameChip, message, initY : initY);
            }
        }
        else {
            DrawLogo(gameChip);
            DrawTitle(gameChip, "Love is hard to find...", display.Y/2 + 10);
            DrawTitle(gameChip, "in an irradiated wasteland", display.Y/2+30);
            gameChip.DrawText("Press the ESC button to exit.", 16, display.Y-16, DrawMode.Sprite, "large", 15, TEXT_SPACING);

            // string message = "Press ESC to exit.";
            // DrawLines(gameChip, message, x : 64, initY : initY);
            drawContinueText = false;
        }
        if (drawContinueText) {
            gameChip.DrawText("Press the X button to continue.", 16, display.Y-16, DrawMode.Sprite, "large", 15, TEXT_SPACING);
        }
    }
}   
