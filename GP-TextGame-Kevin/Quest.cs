using System;

namespace GP_TextGame_Kevin
{
    internal class Quest
    {
        public string questName; // We print this on the screen
        public int goal;
        public int progress = 0;
        public bool completed = false;

        public Quest(string questName, int goal)
        {
            this.questName = questName;
            this.goal = goal;
        }

        public void AddProgress(int amount)
        {
            if (completed)
            {
                return;
            }

            progress += amount;
            if (progress >= goal)
            {
                progress = goal;
                completed = true;
            }
        }

        public void Reset(int newGoal)
        {
            goal = newGoal;
            progress = 0;
            completed = false;
        }

        public string QuestTextLine()
        {
            string status;

            if (completed)
            {
                status = "[DONE]  "; // extra spaces to overwrite [ACTIVE]
            }
            else
            {
                status = "[ACTIVE]";
            }

            return $"{status} {questName}: {progress}/{goal}";
        }
    }
}