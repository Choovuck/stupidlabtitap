using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TILab1WPF.Model;
using TILab1WPF.ViewModel;

namespace TILab1WPF
{
    public class DecisionMaker
    {
        private UniverEntities _context;
        public List<NormalizedCriterion> Criterions { get; set; } 

        public DecisionMaker(UniverEntities context)
        {
            _context = context;
            Criterions = new List<NormalizedCriterion>();
            NormalizeCriterions();
        }

        public void NormalizeCriterions()
        {
            int n = _context.Criteria.Count();
            int total = 0;
            for (int i = 1; i <= n; i++)
            {
                total += i;
            }
            List<int> weightList = _context.Criteria.Select(c => c.CWeight).Distinct().ToList();
            decimal[] resultList = new decimal[n];
            int diff = (n - weightList.Count) + 1;
            for (int i = n, j = weightList.Max(); i > 0; i--,j--)
            {
                if (j < 1)
                {
                    int subtotal = 0;
                    for (int k = 1; k <= i; i++)
                    {
                        subtotal += k;
                    }
                    decimal res = Convert.ToDecimal(subtotal)/diff;
                    for (int k = 1; k <= i; k++)
                    {
                        resultList[k - 1] = res;
                    }
                    break;
                }
                resultList[i - 1] = i;
            }
            int index = 0;
            foreach (Criterion criterion in _context.Criteria.OrderBy(c=>c.CWeight))
            {
                Criterions.Add(new NormalizedCriterion {Criterion = criterion, NormWeight = resultList[index]/total});
            }
        }

        public void MakeDecision()
        {
            var marksByCriterion = new Dictionary<NormalizedCriterion, List<Alternative>>();
            foreach (NormalizedCriterion criterion in Criterions)
            {
                var alternatives = new List<Alternative>();
                var criterionMarks = _context.Marks.Where(m => m.CNum == criterion.Criterion.CNum).ToList();
                bool isRange = criterion.Criterion.ScaleType == ScaleTypes.наименований.ToString();
                var orderedMarks = isRange
                    ? criterionMarks.OrderBy(m => m.MRange)
                    : criterionMarks.OrderByDescending(m => m.NumMark);
                foreach (Mark mark in orderedMarks)
                {
                    alternatives.AddRange(mark.Vectors.Select(v => v.Alternative));
                }
                marksByCriterion.Add(criterion, alternatives);
            }
        }
    }
}
