namespace AdventOfCode2023.Helpers
{
    public class MathHelpers
    {
        public static long LeastCommonMultiple(long a, long b)
        {
            return (a / gcf(a, b)) * b;
        }
        static long gcf(long a, long b)
        {
            while (b != 0)
            {
                var temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        public static int LeastCommonMultiple(List<int> numbers)
        {
            var numberPrimes = numbers.Select(PrimeDivisors).ToList();

            var allPrimes = new List<(int prime, int count)>();
            foreach (var primes in numberPrimes)
            {
                foreach (var prime in primes.GroupBy(p => p))
                {
                    var existing = allPrimes.FirstOrDefault(p => p.prime == prime.Key);
                    if (existing != default)
                    {
                        existing.count = Math.Max(existing.count, prime.Count());
                    }
                    else
                    {
                        allPrimes.Add((prime.Key, prime.Count()));
                    }
                }
            }
            return allPrimes.Aggregate(1, (a, b) => a * (int)Math.Pow(b.prime, b.count));
        }


        public static long LeastCommonMultiple(List<long> numbers)
        {
            var numberPrimes = numbers.Select(PrimeDivisors).ToList();

            var allPrimes = new List<(long prime, long count)>();
            foreach (var primes in numberPrimes)
            {
                foreach (var prime in primes.GroupBy(p => p))
                {
                    var existing = allPrimes.FirstOrDefault(p => p.prime == prime.Key);
                    if (existing != default)
                    {
                        existing.count = Math.Max(existing.count, prime.Count());
                    }
                    else
                    {
                        allPrimes.Add((prime.Key, prime.Count()));
                    }
                }
            }
            return allPrimes.Aggregate((long)1, (a, b) => a * (long)Math.Pow(b.prime, b.count));
        }

        public static IEnumerable<int> PrimeDivisors(int number)
        {

            var primes = new List<int>();

            var max = Math.Ceiling(Math.Sqrt(number));
            for (int div = 2; div <= number; div++)
                while (number % div == 0)
                {
                    primes.Add(div);
                    number = number / div;
                }

            return primes;
        }

        public static IEnumerable<long> PrimeDivisors(long number)
        {

            var primes = new List<long>();

            var max = Math.Ceiling(Math.Sqrt(number));
            for (long div = 2; div <= number; div++)
                while (number % div == 0)
                {
                    primes.Add(div);
                    number = number / div;
                }

            return primes;
        }

        public static IEnumerable<long> PrimeFactors(long number)
        {

            var primes = new List<long>();

            var max = Math.Ceiling(Math.Sqrt(number));
            for (long div = 2; div <= number; div++)
                while (number % div == 0)
                {
                    primes.Add(div);
                    number = number / div;
                }

            return primes;
        }

        public static int LeastCommonMultiple(int a, int b)
        {
            return (a / gcf(a, b)) * b;
        }

        static int gcf(int a, int b)
        {
            while (b != 0)
            {
                var temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}
