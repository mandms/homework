using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.PortableExecutable;
using WebAppUI.Models;

namespace WebAppUI.Pages
{
    public class ResultModel : PageModel
    {
        public CalculatorModel Calculator { get; set; } = null!;
        public int MaxValue { get; private set; }
        public List<int> RemainderSumm { get; private set; } = new();
        public Dictionary<int, string> RemainderSubtraction { get; private set; } = new();
        public List<int> Result { get; private set; } = null!;
        public List<int> Value1 { get; private set; } = null!;
        public List<int> Value2 { get; private set; } = null!;
        public bool IsPositive { get; private set; } = true;
        private List<int> toListInt(int value) => value.ToString().Select(x => int.Parse(x.ToString())).Reverse().ToList();

        private void Summ(CalculatorModel calculator)
        {
            Value1 = toListInt(calculator.Value1);
            Value2 = toListInt(calculator.Value2);

            int biggest = Math.Max(Value1.Count, Value2.Count);

            for (int i = 0; i < biggest; i++)
            {
                int v1 = i < Value1.Count ? Value1[i] : 0;
                int v2 = i < Value2.Count ? Value2[i] : 0;
                int summ = (RemainderSumm.LastOrDefault() == i + 1) ? v1 + v2 + 1 : v1 + v2;
                if (summ > 9)
                {
                    RemainderSumm.Add(i + 2);
                }
            }
            Value1.Reverse();
            Value2.Reverse();

            if (Value1.Count < Value2.Count)
            {
                (Value1, Value2) = (Value2, Value1);
            }
            Result = (calculator.Value1 + calculator.Value2).ToString().Select(x => int.Parse(x.ToString())).ToList();
            MaxValue = Math.Max(biggest, Result.Count);
        }

        public void Subtraction(CalculatorModel calculator)
        {
            Value1 = toListInt(calculator.Value1);
            Value2 = toListInt(calculator.Value2);

            if (Value1.Count < Value2.Count || calculator.Value1 < calculator.Value2)
            {
                (Value1, Value2) = (Value2, Value1);
                (calculator.Value1, calculator.Value2) = (calculator.Value2, calculator.Value1);
                IsPositive = false;
            }

            MaxValue = Value1.Count;

            for (int i = 0; i < MaxValue; i++)
            {
                int v1 = i < Value1.Count ? Value1[i] : 0;
                int v2 = i < Value2.Count ? Value2[i] : 0;
                    if ((v1 < v2) && (i == 0 || RemainderSubtraction.Count == 0))
                    {
                        RemainderSubtraction.Add(i + 1, "10");
                    }
                    else if (v1 <= v2 && RemainderSubtraction.Count > 0 && RemainderSubtraction.Keys.Max() == i)
                    {
                        RemainderSubtraction.Add(i + 1, "9");
                    }
            }
            if (RemainderSubtraction.Count > 0)
            {
                int maxValue = RemainderSubtraction.Keys.Max();
                RemainderSubtraction.Add(maxValue + 1, ".");
            }

            Value1.Reverse();
            Value2.Reverse();

            Result = (calculator.Value1 - calculator.Value2).ToString().Select(x => int.Parse(x.ToString())).ToList();
        }

        public void OnGet(CalculatorModel calculator)
        {
            Calculator = calculator;
            switch (calculator.Operation)
            {
                case '+':
                    Summ(calculator);
                    break;
                case '-':
                    Subtraction(calculator);
                    break;
            }
        }
    }
}
