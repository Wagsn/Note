namespace NoteCore
{
    /// <summary>
    /// 格式转换工具
    /// </summary>
    public class ConvertUtil
    {
        public class UnixTimestamp
        {
            private static readonly System.DateTime BEGIN_DATE = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);

            public static int FromDateTime(System.DateTime t)
            {
                return (int)t.ToUniversalTime().Subtract(BEGIN_DATE).TotalSeconds;
            }

            public static System.DateTime ToDateTime(int timestamp)
            {
                return BEGIN_DATE.AddSeconds((double)timestamp).ToLocalTime();
            }
        }

        public static string ToString(object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }
            if (obj is string)
            {
                return (string)obj;
            }
            return obj.ToString();
        }

        public static System.DateTime ToDateTime(object obj)
        {
            if (obj == null)
            {
                return System.DateTime.MinValue;
            }
            if (obj is System.DateTime)
            {
                return (System.DateTime)obj;
            }
            System.DateTime result;
            if (System.DateTime.TryParse(obj.ToString(), out result))
            {
                return result;
            }
            return System.DateTime.MinValue;
        }

        public static double ToDouble(object obj)
        {
            if (obj == null)
            {
                return 0.0;
            }
            if (obj is double)
            {
                return (double)obj;
            }
            double result;
            if (double.TryParse(obj.ToString(), out result))
            {
                return result;
            }
            try
            {
                return (double)System.Convert.ChangeType(obj, typeof(double));
            }
            catch
            {
            }
            return 0.0;
        }

        public static long ToInt64(object obj)
        {
            return (long)ToDouble(obj);
        }

        public static int ToInt32(object obj)
        {
            return (int)ToDouble(obj);
        }

        public static string Encode(string strEncode)
        {
            string text = "";
            if (!string.IsNullOrEmpty(strEncode))
            {
                char[] array = strEncode.ToCharArray();
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    text += ((short)array[i]).ToString("X4");
                }
            }
            return text;
        }

        public static string Decode(string strDecode)
        {
            string text = "";
            string text2 = "";
            if (!string.IsNullOrEmpty(strDecode))
            {
                for (int i = 0; i < strDecode.Length / 4; i++)
                {
                    text += (char)short.Parse(strDecode.Substring(i * 4, 4), System.Globalization.NumberStyles.HexNumber);
                }
                char[] array = text.ToCharArray();
                for (int j = array.Length - 1; j >= 0; j--)
                {
                    text2 += array[j].ToString();
                }
            }
            return text2;
        }
    }
}
