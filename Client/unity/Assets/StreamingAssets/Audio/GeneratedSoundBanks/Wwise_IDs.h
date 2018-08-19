/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID BATTLE_TEST = 3490917514U;
        static const AkUniqueID GAME_START = 733168346U;
        static const AkUniqueID MAIN_MENU = 2005704188U;
        static const AkUniqueID PLAYER_LOSE = 3845628650U;
        static const AkUniqueID PLAYER_MOVE = 2248092158U;
        static const AkUniqueID PLAYER_STOP = 3361170585U;
        static const AkUniqueID PLAYER_WIN = 1002342001U;
        static const AkUniqueID UI_CLICK = 2249769530U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace GAME_STATUS
        {
            static const AkUniqueID GROUP = 2453052416U;

            namespace STATE
            {
                static const AkUniqueID BATTLE = 2937832959U;
                static const AkUniqueID EXPLORE = 579523862U;
                static const AkUniqueID LOSE = 221232726U;
                static const AkUniqueID MENU = 2607556080U;
                static const AkUniqueID WIN = 979765101U;
            } // namespace STATE
        } // namespace GAME_STATUS

        namespace LEADING_PLAYER
        {
            static const AkUniqueID GROUP = 405984407U;

            namespace STATE
            {
                static const AkUniqueID BLUE = 1325827433U;
                static const AkUniqueID GREEN = 4147287986U;
                static const AkUniqueID RED = 980603538U;
            } // namespace STATE
        } // namespace LEADING_PLAYER

        namespace PLAYER_COLOR
        {
            static const AkUniqueID GROUP = 919992774U;

            namespace STATE
            {
                static const AkUniqueID BLUE = 1325827433U;
                static const AkUniqueID GREEN = 4147287986U;
                static const AkUniqueID RED = 980603538U;
            } // namespace STATE
        } // namespace PLAYER_COLOR

        namespace PLAYER_TRAILING
        {
            static const AkUniqueID GROUP = 3552156285U;

            namespace STATE
            {
                static const AkUniqueID NO = 1668749452U;
                static const AkUniqueID YES = 979470758U;
            } // namespace STATE
        } // namespace PLAYER_TRAILING

    } // namespace STATES

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID AUDIO = 1069811801U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID MUSIC = 3991942870U;
        static const AkUniqueID SFX = 393239870U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID COMMUNICATION = 530303819U;
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
