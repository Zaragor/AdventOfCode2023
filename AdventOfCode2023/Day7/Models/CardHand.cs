namespace AdventOfCode2023.Day7.Models
{
    public class CardHand
    {
        public CardHand(string hand, long bet, bool jokersWildCard = false)
        {
            this.Hand = hand;
            this.Bet = bet;
            this.HandType = jokersWildCard ? GetTypeWildcard(hand) : GetType(hand);
        }

        public string Hand { get; set; }

        public long Bet { get; set; }

        public HandType HandType { get; set; }

        private HandType GetType(string hand)
        {
            var sets = hand.GroupBy(t => t);

            if (sets.Any(set => set.Count() == 5))
            {
                return HandType.FiveOfAKind;
            }
            else if (sets.Any(set => set.Count() == 4))
            {
                return HandType.FourOfAKind;
            }
            else if (sets.Any(set => set.Count() == 3))
            {
                if (sets.Any(set => set.Count() == 2))
                {
                    return HandType.FullHouse;
                }
                else
                {
                    return HandType.ThreeOfAKind;
                }
            }
            else if (sets.Any(set => set.Count() == 2))
            {
                if (sets.Count(set => set.Count() == 2) == 2)
                {
                    return HandType.TwoPairs;
                }
                else
                {
                    return HandType.OnePair;
                }
            }
            else
            {
                return HandType.HighCard;
            }
        }

        private HandType GetTypeWildcard(string hand)
        {
            var sets = hand.GroupBy(t => t);

            if (sets.Any(set => set.Count() == 5))
            {
                return HandType.FiveOfAKind;
            }
            else if (sets.Any(set => set.Count() == 4))
            {
                if (sets.Any(set => set.Key == 'J'))
                {
                    return HandType.FiveOfAKind;
                }

                return HandType.FourOfAKind;
            }
            else if (sets.Any(set => set.Count() == 3))
            {
                if (sets.Any(set => set.Count() == 2))
                {
                    if (sets.Any(set => set.Key == 'J'))
                    {
                        return HandType.FiveOfAKind;
                    }

                    return HandType.FullHouse;
                }
                else
                {
                    if (sets.First(set => set.Count() == 3).Key == 'J' || sets.Any(set => set.Count() == 1 && set.Key == 'J'))
                    {
                        return HandType.FourOfAKind;
                    }
                    return HandType.ThreeOfAKind;
                }
            }
            else if (sets.Any(set => set.Count() == 2))
            {
                if (sets.Count(set => set.Count() == 2) == 2)
                {
                    if (sets.Any(set => set.Count() == 2 && set.Key == 'J'))
                    {
                        return HandType.FourOfAKind;
                    }

                    if (sets.Any(set => set.Count() == 1 && set.Key == 'J'))
                    {
                        return HandType.FullHouse;
                    }

                    return HandType.TwoPairs;
                }
                else
                {
                    if (sets.Any(set => set.Count() == 2 && set.Key == 'J'))
                    {
                        return HandType.ThreeOfAKind;
                    }

                    if (sets.Any(set => set.Count() == 1 && set.Key == 'J'))
                    {
                        return HandType.ThreeOfAKind;
                    }

                    return HandType.OnePair;
                }
            }
            else
            {
                if (sets.Any(set => set.Key == 'J'))
                {
                    return HandType.OnePair;
                }

                return HandType.HighCard;
            }
        }

    }
}
