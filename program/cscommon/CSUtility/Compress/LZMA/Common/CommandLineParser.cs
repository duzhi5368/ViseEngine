// CommandLineParser.cs

using System;
using System.Collections;

namespace SevenZip.CommandLineParser
{
    /// <summary>
    /// ת������ö��
    /// </summary>
	internal enum SwitchType
	{
		Simple,
		PostMinus,
		LimitedPostString,
		UnLimitedPostString,
		PostChar
	}
    /// <summary>
    /// ת������
    /// </summary>
    internal class SwitchForm
	{
        /// <summary>
        /// ���ID
        /// </summary>
		public string IDString;
        /// <summary>
        /// ת������
        /// </summary>
		public SwitchType Type;
        /// <summary>
        /// �Ƿ����
        /// </summary>
		public bool Multi;
        /// <summary>
        /// ��С����
        /// </summary>
		public int MinLen;
        /// <summary>
        /// ��󳤶�
        /// </summary>
		public int MaxLen;
        /// <summary>
        /// ���͵��ַ�
        /// </summary>
		public string PostCharSet;
        /// <summary>
        /// ���ι��캯��
        /// </summary>
        /// <param name="idString">����ID</param>
        /// <param name="type">ת������</param>
        /// <param name="multi">�Ƿ����</param>
        /// <param name="minLen">��С����</param>
        /// <param name="maxLen">��󳤶�</param>
        /// <param name="postCharSet">���͵��ַ�</param>
		public SwitchForm(string idString, SwitchType type, bool multi,
			int minLen, int maxLen, string postCharSet)
		{
			IDString = idString;
			Type = type;
			Multi = multi;
			MinLen = minLen;
			MaxLen = maxLen;
			PostCharSet = postCharSet;
		}
        /// <summary>
        /// ���ι��캯��
        /// </summary>
        /// <param name="idString">ID�ַ�</param>
        /// <param name="type">�л�����</param>
        /// <param name="multi">�Ƿ����</param>
        /// <param name="minLen">��С����</param>
		public SwitchForm(string idString, SwitchType type, bool multi, int minLen):
			this(idString, type, multi, minLen, 0, "")
		{
		}
        /// <summary>
        /// ���ι��캯��
        /// </summary>
        /// <param name="idString">����ID</param>
        /// <param name="type">�л�����</param>
        /// <param name="multi">�Ƿ����</param>
		public SwitchForm(string idString, SwitchType type, bool multi):
			this(idString, type, multi, 0)
		{
		}
	}
    /// <summary>
    /// ת�������
    /// </summary>
    internal class SwitchResult
	{
        /// <summary>
        /// �Ƿ��н��
        /// </summary>
		public bool ThereIs;
        /// <summary>
        /// �Ƿ���������
        /// </summary>
		public bool WithMinus;
        /// <summary>
        /// ���͵��ַ�
        /// </summary>
		public ArrayList PostStrings = new ArrayList();
        /// <summary>
        /// �ַ�����
        /// </summary>
		public int PostCharIndex;
        /// <summary>
        /// ���캯��
        /// </summary>
		public SwitchResult()
		{
			ThereIs = false;
		}
	}
    /// <summary>
    /// ������
    /// </summary>
    internal class Parser
	{
        /// <summary>
        /// �յ�ת���ַ�
        /// </summary>
		public ArrayList NonSwitchStrings = new ArrayList();
		SwitchResult[] _switches;
        /// <summary>
        /// ���ι��캯��
        /// </summary>
        /// <param name="numSwitches">ת������</param>
		public Parser(int numSwitches)
		{
			_switches = new SwitchResult[numSwitches];
			for (int i = 0; i < numSwitches; i++)
				_switches[i] = new SwitchResult();
		}
        /// <summary>
        /// �����ַ�
        /// </summary>
        /// <param name="srcString">��Ҫ������Դ�ַ�</param>
        /// <param name="switchForms">ת�����</param>
        /// <returns>�����ɹ�����true�����򷵻�false</returns>
		bool ParseString(string srcString, SwitchForm[] switchForms)
		{
			int len = srcString.Length;
			if (len == 0)
				return false;
			int pos = 0;
			if (!IsItSwitchChar(srcString[pos]))
				return false;
			while (pos < len)
			{
				if (IsItSwitchChar(srcString[pos]))
					pos++;
				const int kNoLen = -1;
				int matchedSwitchIndex = 0;
				int maxLen = kNoLen;
				for (int switchIndex = 0; switchIndex < _switches.Length; switchIndex++)
				{
					int switchLen = switchForms[switchIndex].IDString.Length;
					if (switchLen <= maxLen || pos + switchLen > len)
						continue;
					if (String.Compare(switchForms[switchIndex].IDString, 0,
							srcString, pos, switchLen, true) == 0)
					{
						matchedSwitchIndex = switchIndex;
						maxLen = switchLen;
					}
				}
				if (maxLen == kNoLen)
					throw new Exception("maxLen == kNoLen");
				SwitchResult matchedSwitch = _switches[matchedSwitchIndex];
				SwitchForm switchForm = switchForms[matchedSwitchIndex];
				if ((!switchForm.Multi) && matchedSwitch.ThereIs)
					throw new Exception("switch must be single");
				matchedSwitch.ThereIs = true;
				pos += maxLen;
				int tailSize = len - pos;
				SwitchType type = switchForm.Type;
				switch (type)
				{
					case SwitchType.PostMinus:
						{
							if (tailSize == 0)
								matchedSwitch.WithMinus = false;
							else
							{
								matchedSwitch.WithMinus = (srcString[pos] == kSwitchMinus);
								if (matchedSwitch.WithMinus)
									pos++;
							}
							break;
						}
					case SwitchType.PostChar:
						{
							if (tailSize < switchForm.MinLen)
								throw new Exception("switch is not full");
							string charSet = switchForm.PostCharSet;
							const int kEmptyCharValue = -1;
							if (tailSize == 0)
								matchedSwitch.PostCharIndex = kEmptyCharValue;
							else
							{
								int index = charSet.IndexOf(srcString[pos]);
								if (index < 0)
									matchedSwitch.PostCharIndex = kEmptyCharValue;
								else
								{
									matchedSwitch.PostCharIndex = index;
									pos++;
								}
							}
							break;
						}
					case SwitchType.LimitedPostString:
					case SwitchType.UnLimitedPostString:
						{
							int minLen = switchForm.MinLen;
							if (tailSize < minLen)
								throw new Exception("switch is not full");
							if (type == SwitchType.UnLimitedPostString)
							{
								matchedSwitch.PostStrings.Add(srcString.Substring(pos));
								return true;
							}
							String stringSwitch = srcString.Substring(pos, minLen);
							pos += minLen;
							for (int i = minLen; i < switchForm.MaxLen && pos < len; i++, pos++)
							{
								char c = srcString[pos];
								if (IsItSwitchChar(c))
									break;
								stringSwitch += c;
							}
							matchedSwitch.PostStrings.Add(stringSwitch);
							break;
						}
				}
			}
			return true;

		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="switchForms"></param>
        /// <param name="commandStrings"></param>
		public void ParseStrings(SwitchForm[] switchForms, string[] commandStrings)
		{
			int numCommandStrings = commandStrings.Length;
			bool stopSwitch = false;
			for (int i = 0; i < numCommandStrings; i++)
			{
				string s = commandStrings[i];
				if (stopSwitch)
					NonSwitchStrings.Add(s);
				else
					if (s == kStopSwitchParsing)
					stopSwitch = true;
				else
					if (!ParseString(s, switchForms))
					NonSwitchStrings.Add(s);
			}
		}
        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="index">����ֵ</param>
        /// <returns>����ת�����</returns>
		public SwitchResult this[int index] { get { return _switches[index]; } }
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="commandForms">����ؼ�</param>
        /// <param name="commandString">�����ַ�</param>
        /// <param name="postString">������ַ�</param>
        /// <returns>��������ֵ</returns>
		public static int ParseCommand(CommandForm[] commandForms, string commandString,
			out string postString)
		{
			for (int i = 0; i < commandForms.Length; i++)
			{
				string id = commandForms[i].IDString;
				if (commandForms[i].PostStringMode)
				{
					if (commandString.IndexOf(id) == 0)
					{
						postString = commandString.Substring(id.Length);
						return i;
					}
				}
				else
					if (commandString == id)
				{
					postString = "";
					return i;
				}
			}
			postString = "";
			return -1;
		}

		static bool ParseSubCharsCommand(int numForms, CommandSubCharsSet[] forms,
			string commandString, ArrayList indices)
		{
			indices.Clear();
			int numUsedChars = 0;
			for (int i = 0; i < numForms; i++)
			{
				CommandSubCharsSet charsSet = forms[i];
				int currentIndex = -1;
				int len = charsSet.Chars.Length;
				for (int j = 0; j < len; j++)
				{
					char c = charsSet.Chars[j];
					int newIndex = commandString.IndexOf(c);
					if (newIndex >= 0)
					{
						if (currentIndex >= 0)
							return false;
						if (commandString.IndexOf(c, newIndex + 1) >= 0)
							return false;
						currentIndex = j;
						numUsedChars++;
					}
				}
				if (currentIndex == -1 && !charsSet.EmptyAllowed)
					return false;
				indices.Add(currentIndex);
			}
			return (numUsedChars == commandString.Length);
		}
		const char kSwitchID1 = '-';
		const char kSwitchID2 = '/';

		const char kSwitchMinus = '-';
		const string kStopSwitchParsing = "--";

		static bool IsItSwitchChar(char c)
		{
			return (c == kSwitchID1 || c == kSwitchID2);
		}
	}
    /// <summary>
    /// ����ؼ�
    /// </summary>
    internal class CommandForm
	{
        /// <summary>
        /// ����ID
        /// </summary>
		public string IDString = "";
        /// <summary>
        /// �Ƿ�����ַ�
        /// </summary>
		public bool PostStringMode = false;
        /// <summary>
        /// ���ι��캯��
        /// </summary>
        /// <param name="idString">����ID</param>
        /// <param name="postStringMode">�Ƿ�����ַ�</param>
		public CommandForm(string idString, bool postStringMode)
		{
			IDString = idString;
			PostStringMode = postStringMode;
		}
	}
    /// <summary>
    /// �����м��ַ�������
    /// </summary>
	class CommandSubCharsSet
	{
        /// <summary>
        /// �ַ���
        /// </summary>
		public string Chars = "";
        /// <summary>
        /// �Ƿ���ܿ��ַ�
        /// </summary>
		public bool EmptyAllowed = false;
	}
}
