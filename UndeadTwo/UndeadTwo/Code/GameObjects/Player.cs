﻿#region File Description & Usings
//-----------------------------------------------------------------------------
// Player.cs
//
// Created by Poplicola
//-----------------------------------------------------------------------------
using Microsoft.Xna.Framework;
#endregion

namespace UndeadClient.GameObjects
{
    class Player : UndeadClient.GameObjects.Unit
    {
        public int FlagsPlayer = 0;
        public int GuildID = 0, GuildRank = 0;
        public int ChosenTitle = 0;
        public int BytesPlayer0 = 0, BytesPlayer1 = 0, BytesPlayer2 = 0, BytesPlayer3 = 0;
        public int Experience = 0, ExperienceNextLevel = 0, PetExperience = 0, PetNextLevelExperience = 0;
        public int Coinage = 0;

        public int PartyID = 0;
        public int DuelOpponentGUID = 0;

        public int[] EquipSlots = new int[12];
        public int[] PackSlots = new int[20];
        public int[] BankSlots = new int[30];

        public PlayerQuest[] QuestLog = new PlayerQuest[20];

        public Player(int nGUID)
            : base(nGUID)
        {
            this.ObjectType = ObjectType.Player;
        }
    }
}