using System;
using System.Collections.Generic;
using System.Linq;

namespace GunvorRecruitment
{
    public class DifferenceFinder<T> where T : IEquatable<T>
    {
        public Differences<T> FindDifferences(IEnumerable<T> first, IEnumerable<T> second)
        {
           var objectsMissingFirst = second.Except(first).ToList();
           var objectsMissingSecond = first.Except(second).ToList();

            return new Differences<T>
                       {
                           ObjectsMissingInFirstList = new List<T>(objectsMissingFirst),
                           ObjectsMissingInSecondList = new List<T>(objectsMissingSecond)
                       };
        }
    }

    public class Differences<T>
    {
        public IEnumerable<T> ObjectsMissingInFirstList;
        public IEnumerable<T> ObjectsMissingInSecondList;
    }
}
