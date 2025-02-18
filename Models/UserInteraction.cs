using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoomCounter.Models
{
    public static class UserInteraction
    {
        private static string[] positiveAnswers = {
            "yes",
            "yeah",
            "yep",
            "sure",
            "of course",
            "please do",
            "definitely",
            "absolutely",
            "go ahead",
            "why not",
            "unfortunately yes",
            "unfortunately, yes",
            "y",
            "yea"
        };

        private static string[] negativeAnswers = {
            "no",
            "nope",
            "nah",
            "not really",
            "I'd rather not",
            "please don't",
            "never",
            "absolutely not",
            "no way",
            "I'm afraid not",
            "n"
        };

        private static string[] randomMessages = {
            "The stapler has developed a sense of humor.",
            "The coffee mug now recognizes your grip.",
            "The printer begins to understand your frustration.",
            "The walls have become strangely more comforting.",
            "The overhead lights flicker in acknowledgment."
};

        public static bool IsAcceptedAnswer(string userAnswer)
        {
            return Array.Exists(positiveAnswers, ans => ans.Equals(userAnswer.Trim(), StringComparison.OrdinalIgnoreCase));
        }
        public static bool IsUnacceptedAnswer(string userAnswer)
        {
            return Array.Exists(negativeAnswers, ans => ans.Equals(userAnswer.Trim(), StringComparison.OrdinalIgnoreCase));
        }


        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static string GetUserInput()
        {
            string userAnswer = Console.ReadLine();
            return userAnswer;
        }

        public static void IncreaseCounterPrompt(int doomCounter)
        {
            string[] greetings = {
                $"Ah, you've returned. The doom counter is at {doomCounter}, shall we add another chapter to your inevitable descent?",
                $"Greetings... The shadows grow longer, and the doom counter is at {doomCounter}. Shall we add another step?",
                $"Welcome back. The doom counter is at {doomCounter}, as the days grow darker. Ready to add another one?",
                $"So, you've survived another day. The doom counter is at {doomCounter}, should we add one more for the abyss?",
                $"Well met. The doom counter sits at {doomCounter}. Shall we continue this journey into the unknown?"
            };
            Random random = new Random();
            int index = random.Next(greetings.Length);
            DisplayMessage(greetings[index]);
        }

        public static void DisplayInvalidAnswerMessage(string userAnswer)
        {
            DisplayMessage($"I can understand plenty of answers, but sadly \"{userAnswer}\" isn't one of them");
        }

        public static void ConverseWithUser()
        {
            string filePath = Path.Combine("E:\\Coding\\DoomCounter\\", "Data", "doomCounter.txt"); //change path for your computer
            bool isFirstAsk = true;
            string userAnswer = "";
            DoomCounterHandler doomCounter = new DoomCounterHandler(filePath);
            do
            {
                if (isFirstAsk)
                {
                    IncreaseCounterPrompt(doomCounter.GetCounter());
                }
                else
                {
                    DisplayInvalidAnswerMessage(userAnswer);
                }

                userAnswer = GetUserInput();
                isFirstAsk = false;

                if (IsAcceptedAnswer(userAnswer))
                {
                    doomCounter.IncrementCounter();
                    HandleDoomMessages(doomCounter.GetCounter());
                }
                else if (IsUnacceptedAnswer(userAnswer))
                {
                    Console.WriteLine("At long last, Oblivion!");
                }

            } while (!IsAcceptedAnswer(userAnswer) && !IsUnacceptedAnswer(userAnswer));
            Console.WriteLine("Press Enter to close the application...");
            Console.ReadLine();
        }

        static void HandleDoomMessages(int doomCounter)
        {
            string message = "";
            Random random = new Random();
            // Handle the doom messages based on the counter value
            switch (doomCounter)
            {
                case 1:
                    message = "Day 1: The journey begins. The walls are...closer than expected.";
                    break;
                case 2:
                    message = "Day 2: You’ve returned. The office chair creaks in cautious approval.";
                    break;
                case 5:
                    message = "Day 5: The walls have started whispering your name when you’re not looking.";
                    break;
                case 7:
                    message = "Day 7: A full week. The printer jams...just to test you.";
                    break;
                case 10:
                    message = "Day 10: The elevator dings too late, and the lights flicker just before you enter.";
                    break;
                case 14:
                    message = "Day 14: Two weeks in. The vending machine knows your favorite snack.";
                    break;
                case 20:
                    message = "Day 20: The air smells faintly of burned paper, though the fire extinguisher is untouched.";
                    break;
                case 21:
                    message = "Day 21: Three weeks. The clock ticks louder. It knows you're watching.";
                    break;
                case 30:
                    message = "Day 30: The coffee machine has learned your exact preferences.";
                    break;
                case 40:
                    message = "Day 40: The fluorescent lights hum, but they’re no longer a comfort.";
                    break;
                case 42:
                    message = "Day 42: The answer to life, the universe, and office survival: caffeine and calm rage.";
                    break;
                case 50:
                    message = "Day 50: Half a century of days. The stapler respects you now.";
                    break;
                case 60:
                    message = "Day 60: A shadow seems to follow you in the break room when no one’s there.";
                    break;
                case 75:
                    message = "Day 75: Seventy-five days. The break room whispers legends of your endurance.";
                    break;
                case 80:
                    message = "Day 80: The coffee machine now only offers cold, bitter silence when you approach.";
                    break;
                case 100:
                    message = "Day 100: You've mastered the art of the 'mute' button in meetings.";
                    break;
                case 120:
                    message = "Day 120: You could swear the clock has started ticking backwards when you're not watching.";
                    break;
                case 150:
                    message = "Day 150: You've achieved 'Meeting Survival Expert' status.";
                    break;
                case 180:
                    message = "Day 180: The printer now jams on days you need it most, but only after it stares at you.";
                    break;
                case 200:
                    message = "Day 200: The elevator buttons no longer fear your touch.";
                    break;
                case 250:
                    message = "Day 250: Two hundred and fifty days. The carpet pattern is etched into your soul.";
                    break;
                case 300:
                    message = "Day 300: Three hundred days. The water cooler gossip pauses when you pass.";
                    break;
                case 350:
                    message = "Day 350: The office chairs now seem to shift slightly when you leave them behind.";
                    break;
                case 365:
                    message = "Day 365: One year. The office plants recognize you as one of their own.";
                    break;
                case 400:
                    message = "Day 400: Your reflection in the glass windows looks a little too... aware.";
                    break;
                case 500:
                    message = "Day 500: The break room fridge has begun to hum your favorite tune, but it sounds wrong.";
                    break;
                case 666:
                    message = "Day 666: The temperature drops whenever you enter the hallway, though no windows are open.";
                    break;
                case 1000:
                    message = "Day 1000: The walls no longer feel like they’re holding up the ceiling—they feel like they’re closing in.";
                    break;
                default:
                    int randomIndex = random.Next(randomMessages.Length);
                    message = $"Day {doomCounter}: {randomMessages[randomIndex]}";
                    break;
            }
            DisplayMessage(message);
        }
    }
}
