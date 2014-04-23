using System;
using System.Collections.Generic;
using System.Text;

namespace Majireskun
{
    /// <summary>
    /// Queue用変数格納
    /// </summary>
    class QueueContainer
    {
        private int _no; //通番
        private string _res; //内容
        private Const.QueueStatus _status; //ステータス
        private DateTime _rtime; //登録時刻
        private string _fingerprint; //MD5フィンガープリント 送信時に設定

        public QueueContainer(){
            _no = 0;
            _res = null;
            _status = Const.QueueStatus.QUEUE_STATUS_NULL;
            _rtime = DateTime.MinValue;
            _fingerprint = null;
        }

        public QueueContainer(int no, string text)
        {
            _no = no;
            _res = text;
            _status = Const.QueueStatus.QUEUE_STATUS_NULL;
            _rtime = DateTime.MinValue;
            _fingerprint = null;
        }
        public int No
        {
            get
            {
                return _no;
            }
            set
            {
                _no = value;
            }
        }
        public string Res
        {
            get
            {
                return _res;
            }
            set
            {
                _res = value;
            }
        }
        public int Status
        {
            get
            {
                return (int)_status;
            }
            set
            {
                _status = (Const.QueueStatus)value;
            }
        }
        public DateTime Rtime
        {
            get
            {
                return _rtime;
            }
            set
            {
                _rtime = value;
            }
        }
        public string FingerPrint
        {
            get
            {
                return _fingerprint;
            }
            set
            {
                _fingerprint = value;
            }
        }
    }
}
