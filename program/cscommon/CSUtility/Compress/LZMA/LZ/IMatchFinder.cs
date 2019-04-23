// IMatchFinder.cs

using System;

namespace SevenZip.Compression.LZ
{
    /// <summary>
    /// ������Ϣ��
    /// </summary>
	interface IInWindowStream
	{
        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="inStream">���������</param>
		void SetStream(System.IO.Stream inStream);
        /// <summary>
        /// �����ʼ��
        /// </summary>
		void Init();
        /// <summary>
        /// �Ƿ�������
        /// </summary>
		void ReleaseStream();
        /// <summary>
        /// ��ȡ��Ӧ����������ֵ���ֽ�
        /// </summary>
        /// <param name="index">����ֵ</param>
        /// <returns>���ض�Ӧ���ֽ�</returns>
		Byte GetIndexByte(Int32 index);
        /// <summary>
        /// ��ȡƥ��ĳ���
        /// </summary>
        /// <param name="index">����ֵ</param>
        /// <param name="distance">����</param>
        /// <param name="limit">�޶���Χ</param>
        /// <returns>����ƥ��ĳ���</returns>
		UInt32 GetMatchLen(Int32 index, UInt32 distance, UInt32 limit);
        /// <summary>
        /// ��ȡ���õ��ֽ�����
        /// </summary>
        /// <returns>���ؿ��õ��ֽ�����</returns>
		UInt32 GetNumAvailableBytes();
	}
    /// <summary>
    /// ���ϵķ����߽ӿ�
    /// </summary>
	interface IMatchFinder : IInWindowStream
	{
        /// <summary>
        /// �����ӿ�
        /// </summary>
        /// <param name="historySize">��ʷ�ߴ�</param>
        /// <param name="keepAddBufferBefore">���ּ���֮ǰ��ӻ�����</param>
        /// <param name="matchMaxLen">ƥ��ĳ���</param>
        /// <param name="keepAddBufferAfter">��������ӻ�����</param>
		void Create(UInt32 historySize, UInt32 keepAddBufferBefore,
				UInt32 matchMaxLen, UInt32 keepAddBufferAfter);
        /// <summary>
        /// ��ȡƥ�����
        /// </summary>
        /// <param name="distances">����</param>
        /// <returns>����ƥ��Ķ���</returns>
		UInt32 GetMatches(UInt32[] distances);
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="num">����</param>
		void Skip(UInt32 num);
	}
}
