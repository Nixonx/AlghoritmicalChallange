namespace AppLogic;

public class Solution : ISolution
{
    public decimal ArrayGame(decimal[] arr) //recurive with consloe log debugginig ;)
    {
        var solution = new List<(decimal myScore, decimal hisScore)>();
        Simulate(new List<decimal>(arr), 0, 0, new List<decimal>(), new List<decimal>(), solution, 0);
        Console.WriteLine($"Dsired solution: {solution[0].myScore}:{solution[0].hisScore}");
        return solution[0].myScore;
    }

    private void Simulate(List<decimal> arr, decimal myScore, decimal hisScore,
        List<decimal> steps, List<decimal> hisSteps, List<(decimal my, decimal opponent)> options, int iteration)
    {
        if (arr.Count == 0)
        {
            options.Add(new(myScore, hisScore));
            Console.WriteLine($"My steps: {steps.ItemsToString()} \n his steps: {hisSteps.ItemsToString()} \n leadst to: {myScore}:{hisScore}");
            return;
        }

        if (iteration % 2 == 0) //start from 0, my turn
        {
            var nextOptions = new List<(decimal my, decimal his)>();

            //choose first
            var nextSteps = new List<decimal>(steps);
            nextSteps.Add(arr[0]);
            var nextMyScore = myScore + arr[0];
            var nextArr = new List<decimal>(arr);
            nextArr.RemoveAt(0);

            Simulate(nextArr, nextMyScore, hisScore, nextSteps, hisSteps, nextOptions, iteration + 1);

            //choose last
            nextSteps = new List<decimal>(steps);
            nextSteps.Add(arr[^1]);
            nextMyScore = myScore + arr[^1];
            nextArr = new List<decimal>(arr);
            nextArr.RemoveAt(nextArr.Count - 1);

            Simulate(nextArr, nextMyScore, hisScore, nextSteps, hisSteps, nextOptions, iteration + 1);

            var betterOption = nextOptions[0].my > nextOptions[1].my ? nextOptions[0] : nextOptions[1];
            options.Add(betterOption);
        }
        else //his turn
        {
            var nextOptions = new List<(decimal my, decimal his)>();

            //choose first
            var nextHisSteps = new List<decimal>(hisSteps);
            nextHisSteps.Add(arr[0]);
            var nextHisScore = hisScore + arr[0];
            var nextArr = new List<decimal>(arr);
            nextArr.RemoveAt(0);

            Simulate(nextArr, myScore, nextHisScore, steps, nextHisSteps, nextOptions, iteration + 1);

            //choose last
            nextHisSteps = new List<decimal>(hisSteps);
            nextHisSteps.Add(arr[^1]);
            nextHisScore = hisScore + arr[^1];
            nextArr = new List<decimal>(arr);
            nextArr.RemoveAt(nextArr.Count - 1);

            Simulate(nextArr, myScore, nextHisScore, steps, nextHisSteps, nextOptions, iteration + 1);

            var betterOption = nextOptions[0].his > nextOptions[1].his ? nextOptions[0] : nextOptions[1];
            options.Add(betterOption);
        }
    }

    public decimal ArrayGame_LittleBrotherSolution(decimal[] arr)
    {
        decimal myScore = 0;
        decimal hisScore = 0;
        var list = new List<decimal>(arr);
        for (int i = 0; list.Count > 0; i++)
        {
            if (list.Count == 1)
            {
                hisScore += list[0];
                list.RemoveAt(0);
                continue;
            }

            var firstFactor = list[0] - list[1];
            var lastFactor = list[^1] - list[^2];
            decimal valueToAdd;
            if (firstFactor > lastFactor)
            {
                valueToAdd = list[0];
                list.RemoveAt(0);
            }
            else
            {
                valueToAdd = list[^1];
                list.RemoveAt(list.Count - 1);
            }

            if (i % 2 == 0)
                myScore += valueToAdd;
            else
                hisScore += valueToAdd;
        }
        return myScore;
    }

    public int SumMiddle(decimal[] arr)
    {
        if (arr.Length == 1)
            return 0;

        var sum = arr.Sum();
        decimal leftArrSum = 0;
        var rightArrSum = sum;
        for (int i = 0; i < arr.Length; i++)
        {
            rightArrSum -= arr[i];
            if (leftArrSum == rightArrSum)
                return i;

            leftArrSum += arr[i];
        }
        return -1;
    }

    public decimal[] ZigZagSort(decimal[] arr)
    {
        if (arr.Length < 3)
            return arr;

        var list = new List<decimal>() { arr[0], arr[1] };
        for (int i = 2; i < arr.Length; i++)
        {
            if (list[i - 2] > list[i - 1])
            {
                if (arr[i] > list[i - 1])
                {
                    list.Add(arr[i]);
                    continue;
                }
                list.Insert(i - 1, arr[i]);
                continue;
            }
            if (arr[i] < list[i - 1])
            {
                list.Add(arr[i]);
                continue;
            }
            list.Insert(i - 1, arr[i]);
        }

        return list.ToArray();
    }
}
