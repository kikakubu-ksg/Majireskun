using System;
using System.Collections.Generic;
using System.Text;

namespace Majireskun
{
    /// <summary>
    /// Queue用変数格納
    /// </summary>
    public class QueueContainer
    {
        private int _no; //通番
        private string _resname; //名前
        private string _resmail; //メアド
        private string _res; //内容
        private Const.QueueStatus _status; //ステータス
        private DateTime _rtime; //登録時刻
        private string _fingerprint; //MD5フィンガープリント 送信時に設定
        //private string _status_str; //ステータス文字列
        //private string _rtime_str; //登録時刻文字列
        private Const.ErrorStatus _err;

        private static int number = 0; //通番

        public QueueContainer(){ //使わない
            _no = 0;
            _res = null;
            _status = Const.QueueStatus.QUEUE_STATUS_NULL;
            _rtime = DateTime.MinValue;
            _fingerprint = null;
        }

        public QueueContainer(string resname, string resmail, string res)
        {
            _no = ++number;
            _resname = resname;
            _resmail = resmail;
            _res = res;
            _status = Const.QueueStatus.QUEUE_STATUS_WAIT;
            _rtime = DateTime.Now;
            _fingerprint = null;
            _err = Const.ErrorStatus.ERROR_STATUS_NULL;
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
        public string Resname
        {
            get
            {
                return _resname;
            }
            set
            {
                _resname = value;
            }
        }
        public string Resmail
        {
            get
            {
                return _resmail;
            }
            set
            {
                _resmail = value;
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
        public string StatusStr
        {
            get
            {
                switch(_status){
                    case Const.QueueStatus.QUEUE_STATUS_NULL:
                        return "QUEUE_STATUS_NULL";
                    case Const.QueueStatus.QUEUE_STATUS_WAIT:
                        return "送信待ち";
                    case Const.QueueStatus.QUEUE_STATUS_SENDING:
                        return "送信中";
                    case Const.QueueStatus.QUEUE_STATUS_SUCCEED:
                        return "送信成功";
                    case Const.QueueStatus.QUEUE_STATUS_ERROR:
                        return "送信失敗";
                    default:
                        return "";
                }
            }
        }
        public string RtimeStr
        {
            get
            {
                return _rtime.ToString();
            }
        }
        public string ErrStr
        {
            get
            {
                switch (_err)
                {
                    case Const.ErrorStatus.ERROR_STATUS_NULL:
                        return "なし";
                    case Const.ErrorStatus.ERROR_STATUS_SAMBA:
                        return "SAMBA規制";
                    case Const.ErrorStatus.ERROR_STATUS_BYESARU:
                        return "ばいさる";
                    case Const.ErrorStatus.ERROR_STATUS_RENTOU:
                        return "連投規制";
                    case Const.ErrorStatus.ERROR_STATUS_SAKURA:
                        return "さくら";
                    case Const.ErrorStatus.ERROR_STATUS_UNKNOWN:
                        return "不明";
                    default:
                        return "";
                }
            }
        }
    }
}
