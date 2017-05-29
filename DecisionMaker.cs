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

        public DecisionMaker(UniverEntities context)
        {
            _context = context;
        }

        public void MakeDecision()
        {
            _context.Results.AddRange(GetSortedDecisions());
        }

        public IEnumerable<Result> GetSortedDecisions()
        {
            var result = new List<KeyValuePair<Result, float>>();

            var criteriaToMulriplier = new Dictionary<Criterion, float>();
            foreach (var c in _context.Criteria)
            {
                var marks = _context.Marks.Where(m => m.CNum == c.CNum).ToList();
                float multiplier = 1 / marks.Sum(m => m.NumMark);

                criteriaToMulriplier[c] = multiplier;
            }

            foreach (var a in _context.Alternatives)
            {
                var vectors = _context.Vectors.Where(v => v.Alternative.AName == a.AName).ToList();

                float ranking = 0.0f;
                foreach (var v in vectors)
                    ranking += v.Mark.NumMark * criteriaToMulriplier[v.Mark.Criterion];

                var res = new Result();
                res.Alternative = a;
                res.LNum = 0;


                result.Add(new KeyValuePair<Result, float>(res, ranking));
            }

            var sortedResults = result.OrderBy(r => r.Value).Select(pair => pair.Key).ToList();

            return sortedResults;
        }
    }
}
