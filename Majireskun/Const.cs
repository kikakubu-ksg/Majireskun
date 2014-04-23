using System;
using System.Collections.Generic;
using System.Text;

namespace Majireskun
{
    class Const
    {
        public const int BBS_2CH = 0; // 2ch
        public const int BBS_SHITARABA = 1; //したらば

        public const int TAB_RES = 0; // 安価人レスタブ
        public const int TAB_MEMO = 1; // メモ帳タブ

        public const int BOARD_MAIN = 0; // 板区分-本スレ
        public const int BOARD_HAVEN = 1;// 板区分-避難所

        internal static string NZ(string str)
        {
            if (str == null)
            {
                return "";
            }
            else { return str; }
        }

        public enum QueueStatus
        {
            QUEUE_STATUS_NULL = 0x0,
            QUEUE_STATUS_WAIT = 0x1,
            QUEUE_STATUS_SENDING = 0x2,
            QUEUE_STATUS_SUCCEED = 0x3,
            QUEUE_STATUS_ERROR = 0x4
        }
    }
}
