using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;

class MainClass {
  public static void Main (string[] args) {
    bool playing = true;
    // Dictionary for player name and scores
    Dictionary<string, int> scores = new Dictionary<string, int>();
    // Initializes randomizer
    Random rand = new Random();
    // While player wants to play again...
    while (playing) {
      bool gameOver = false;
      int score = 0;
      int roll = 0;
      Write("Enter your player name: ");
      string playerName = ReadLine();
      // While game is not over...
      while (!gameOver) {
        WriteLine ("\nScore: {0}", score);
        Write("Want to risk a role? (Y/N): ");
        string wantRoll = ReadLine().ToLower();
        // If player wants to keep their score: adds their name and score to the dictionary, and leaves
        if (wantRoll == "n") {
          scores.Add(playerName, score);
          gameOver = true;
          break;
        }
        roll = rand.Next(1,7);
        WriteLine("You rolled: {0}", roll);
        score += roll;
        // If player rolls a 6: adds their name and score to the dictionary, and leaves
        if (roll == 6) {
          WriteLine("You lose all your points!");
          score = 0;
          scores.Add(playerName, score);
          gameOver = true;
          break;
        }
      }
      // Runs the method that prints the scoreboard
      PrintScoreboard(scores);
      // Prompt to play again
      Write("\n\nWant to play again? (Y/N): ");
      string again = ReadLine().ToLower();
      if (again == "y") {
        WriteLine("\n\n");
        continue;
      }
      playing = false;
    }
  }
  public static void PrintScoreboard(Dictionary<string, int> scores) {
    // Sorts the dictionary by its values in decending order
    var sortedScores = from score in scores orderby score.Value descending select score;
    WriteLine ("\n\n\n Scoreboard\n");
    // For each element in dictionary
    foreach (KeyValuePair<string, int> pair in sortedScores) {
      WriteLine("{0}: {1}", pair.Key, pair.Value);
    }
    WriteLine("\n");
  }
}