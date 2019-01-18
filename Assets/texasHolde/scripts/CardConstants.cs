using System;
using UnityEngine.Networking;

public class CardConstants
{
   
	public enum Suite
	{
		Diamonds = 0,
		Clubs = 1,
		Hearts = 2,
		Spades = 3
	};
    public enum HandRank
    {
        none = 0,
        highCard = 1,
        onePair,
        twoPairs,
        threeOfaKind,
        stright,
        flush,
        fullHouse,
        fourOfAKind,
        strightFlush,
        royalFlush

    }
    public enum Card
	{
		Two,
		Three,
		Four,
		Five,
		Six,
		Seven,
		Eight,
		Nine,
		Ten,
		Jack,
		Queen,
		King,
		Ace,
		Joker
	};

	public static readonly Suite[] Suites =
	{
		Suite.Diamonds, Suite.Clubs, Suite.Hearts, Suite.Spades,
	};

	public static readonly Card[] Cards =
	{
		Card.Two,
		Card.Three,
		Card.Four,
		Card.Five,
		Card.Six,
		Card.Seven,
		Card.Eight,
		Card.Nine,
		Card.Ten,
		Card.Jack,
		Card.Queen,
		Card.King,
		Card.Ace
	};

	public static readonly int[] CardValues =
	{
		2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11,
	};

	public static readonly int[] CardValuesLowAce =
	{
		2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 1,
	};

	public enum GameTurnState
	{
		ShufflingDeck,
		WaitingForBets,
		DealingCards,
		PlayingPlayerHand,
        Flop,
        Turn,
        River,
		PlayingDealerHand,
		Complete
	};

	public class CardMessage : MessageBase
	{
		public NetworkInstanceId playerId;
		public CardId cardId;
	}

	public const short CardMsgId = 1000;

}
