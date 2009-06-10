﻿#region File Description & Usings
//-----------------------------------------------------------------------------
// OpCodes.cs
//
// Created by Poplicola
//-----------------------------------------------------------------------------
#endregion

namespace UndeadClient.Network
{
    public enum OpCodes
    {
        CMSG_SEED = -128,
        SMSG_STATUSINFO = 0x11,
        SMSG_WorldItem = 0x1A,
        SMSG_CHARLOCALE = 0x1B,
        SMSG_MOBILEUPDATE = 0x20,
        SMSG_PERSONALLIGHTLEVEL = 0x4E,
        SMSG_LIGHTLEVEL = 0x4F,
        CMSG_LOGINCHARACTER = 0x5D,
        SMSG_MobileIncoming = 0x78, 
        CMSG_ACCOUNTLOGINREQUEST = 0x80,
        SMSG_SERVER_REDIRECT = 0x8C,
        CMSG_GAMESERVER_LOGIN = 0x91, 
        CMSG_SERVERSELECT = 0xA0,
        SMSG_SERVERLIST = 0xA8, 
        SMSG_CHARACTERLIST = 0xA9,
        MSG_CHAT = 0xB3,
        SMSG_ENABLEFEATURES = 0xB9,
        SMSG_SEASONALINFORMATION = 0xBC,
        MSG_CLIENTVERSION = 0xBD,
        MSG_GENERALINFO = 0xBF,

        SMSG_SETWEATHER = 0x65,
        MSG_WARMODE = 0x72,
        SMSG_OBJECTPROPERTYLIST = 0xDC,
        SMSG_LOGINCOMPLETE = 0x55, 
        SMSG_THETIME = 0x5B,
        SMSG_UNICODEMESSAGE = 0xAE,
        SMSG_MobileAnimation = 0x6E,
        SMSG_DELETEOBJECT = 0x1D,
        SMSG_MobileMoving = 0x77,
        SMSG_SENDSPEECH = 0x1C,
        SMSG_DISPLAYDEATHACTION = 0xAF,
        CMSG_MOVEREQUEST = 0x02,
        SMSG_MOVEACK = 0x22,
        SMSG_MOVEREJ = 0x21,
        SMSG_PLAYSOUNDEFFECT = 0x54,
    }
}