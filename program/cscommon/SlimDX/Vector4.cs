﻿using System;


namespace SlimDX
{
    /// <summary>
    /// 四维向量结构体
    /// </summary>
    [System.Serializable]
	[System.Runtime.InteropServices.StructLayout( System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 4 )]
    //[System.ComponentModel.TypeConverter( typeof(SlimDX.Design.Vector4Converter) )]
	public struct Vector4 : System.IEquatable<Vector4>
	{
        #region Member
        /// <summary>
        /// X的坐标
        /// </summary>
		public float X;
        /// <summary>
        /// Y的坐标
        /// </summary>
        public float Y;
        /// <summary>
        /// Z的坐标
        /// </summary>
        public float Z;
        /// <summary>
        /// W的值
        /// </summary>
        public float W;
        #endregion
        /// <summary>
        /// 按索引获取对象的值
        /// </summary>
        /// <param name="index">索引值</param>
        /// <returns>返回相应的对象值</returns>
        public float this[int index]
        {
            get
	        {
		        switch( index )
		        {
		        case 0:
			        return X;
		        case 1:
			        return Y;
		        case 2:
			        return Z;
		        case 3:
			        return W;
		        default:
			        throw new ArgumentOutOfRangeException( "index", "Indices for Vector4 run from 0 to 3, inclusive." );
		        }
	        }
	
	        set
	        {
		        switch( index )
		        {
		        case 0:
			        X = value;
			        break;
		        case 1:
			        Y = value;
			        break;
		        case 2:
			        Z = value;
			        break;
		        case 3:
			        W = value;
			        break;
		        default:
			        throw new ArgumentOutOfRangeException( "index", "Indices for Vector4 run from 0 to 3, inclusive." );
		        }
	        }
        }

        #region StaticMember
        /// <summary>
        /// 只读属性，0向量
        /// </summary>
        public static Vector4 Zero { get { return new Vector4(0, 0, 0, 0); } }
        /// <summary>
        /// 只读属性，X轴的方向向量
        /// </summary>
        public static Vector4 UnitX { get { return new Vector4(1, 0, 0, 0); } }
        /// <summary>
        /// 只读属性，Y轴的方向向量
        /// </summary>
        public static Vector4 UnitY { get { return new Vector4(0, 1, 0, 0); } }
        /// <summary>
        /// 只读属性，Z轴的方向向量
        /// </summary>
        public static Vector4 UnitZ { get { return new Vector4(0, 0, 1, 0); } }
        /// <summary>
        /// 只读属性，W轴的方向向量
        /// </summary>
        public static Vector4 UnitW { get { return new Vector4(0, 0, 0, 1); } }
        /// <summary>
        /// 只读属性，平面的方向向量
        /// </summary>
        public static Vector4 UnitXYZW { get { return new Vector4(1, 1, 1, 1); } }
        /// <summary>
        /// 只读属性，该对象的所占内存大小
        /// </summary>
        public static int SizeInBytes { get { return System.Runtime.InteropServices.Marshal.SizeOf(typeof(Vector4)); } }
        #endregion

        #region Constructure
        /// <summary>
        /// 带参构造函数
        /// </summary>
        /// <param name="value">Vector4对象</param>
        public Vector4(Vector4 value)
        {
            X = value.X;
            Y = value.Y;
            Z = value.Z;
            W = value.W;
        }
        /// <summary>
        /// 带参构造函数
        /// </summary>
        /// <param name="value">值</param>
        public Vector4( float value )
	    {
		    X = value;
		    Y = value;
		    Z = value;
		    W = value;
	    }

        //public Vector4( Vector2 value, float z, float w )
        //{
        //    X = value.X;
        //    Y = value.Y;
        //    Z = z;
        //    W = w;
        //}
        /// <summary>
        /// 带参构造函数
        /// </summary>
        /// <param name="value">Vector3对象</param>
        /// <param name="w">W值</param>
        public Vector4( Vector3 value, float w )
	    {
		    X = value.X;
		    Y = value.Y;
		    Z = value.Z;
		    W = w;
	    }
        /// <summary>
        /// 带参构造函数
        /// </summary>
        /// <param name="x">X值</param>
        /// <param name="y">Y值</param>
        /// <param name="z">Z值</param>
        /// <param name="w">W值</param>
        public Vector4( float x, float y, float z, float w )
	    {
		    X = x;
		    Y = y;
		    Z = z;
		    W = w;
	    }
        #endregion

        #region Equal Override
        /// <summary>
        /// 转换成string类型的字符串
        /// </summary>
        /// <returns>返回转换后的字符串</returns>
        public override string ToString()
	    {
		    return string.Format( System.Globalization.CultureInfo.CurrentCulture, "X:{0} Y:{1} Z:{2} W:{3}", 
                X.ToString(System.Globalization.CultureInfo.CurrentCulture), 
			    Y.ToString(System.Globalization.CultureInfo.CurrentCulture), 
                Z.ToString(System.Globalization.CultureInfo.CurrentCulture),
			    W.ToString(System.Globalization.CultureInfo.CurrentCulture) );
	    }
        /// <summary>
        /// 获取哈希值
        /// </summary>
        /// <returns>返回对象的哈希值</returns>
	    public override int GetHashCode()
	    {
		    return X.GetHashCode() + Y.GetHashCode() + Z.GetHashCode() + W.GetHashCode();
	    }
        /// <summary>
        /// 判断两个对象是否相等
        /// </summary>
        /// <param name="value">可转换成Vector4的对象</param>
        /// <returns>如果两个对象相等返回true，否则返回false</returns>
	    public override bool Equals( object value )
	    {
		    if( value == null )
			    return false;

		    if( value.GetType() != GetType() )
			    return false;

		    return Equals( (Vector4)( value ) );
	    }
        /// <summary>
        /// 判断两个对象是否相等
        /// </summary>
        /// <param name="value">Vector4对象</param>
        /// <returns>如果两个对象相等返回true，否则返回false</returns>
	    public bool Equals( Vector4 value )
	    {
		    return ( X == value.X && Y == value.Y && Z == value.Z && W == value.W );
	    }
        /// <summary>
        /// 判断两个对象是否相等
        /// </summary>
        /// <param name="value1">Vector4对象</param>
        /// <param name="value2">Vector4对象</param>
        /// <returns>如果两个对象相等返回true，否则返回false</returns>
	    public static bool Equals( ref Vector4 value1, ref Vector4 value2 )
	    {
		    return ( value1.X == value2.X && value1.Y == value2.Y && value1.Z == value2.Z && value1.W == value2.W );
	    }
        #endregion
        /// <summary>
        /// 对象的长度
        /// </summary>
        /// <returns>返回对象的长度</returns>
        public float Length()
	    {
		    return (float)( Math.Sqrt( (X * X) + (Y * Y) + (Z * Z) + (W * W) ) );
	    }
        /// <summary>
        /// 对象长度平方
        /// </summary>
        /// <returns>返回对象长度的平方</returns>
        public float LengthSquared()
        {
            return (X * X) + (Y * Y) + (Z * Z) + (W * W);
        }
        /// <summary>
        /// 对象的单位化
        /// </summary>
        public void Normalize()
        {
            float length = Length();
            if (length == 0)
                return;
            float num = 1 / length;
            X *= num;
            Y *= num;
            Z *= num;
            W *= num;
	    }
        /// <summary>
        /// 两个对象相加
        /// </summary>
        /// <param name="left">Vector4对象</param>
        /// <param name="right">Vector4对象</param>
        /// <returns>返回相加的结果</returns>
        public static Vector4 Add( Vector4 left, Vector4 right )
	    {
		    return new Vector4( left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W );
	    }
        /// <summary>
        /// 两个对象相加
        /// </summary>
        /// <param name="left">Vector4对象</param>
        /// <param name="right">Vector4对象</param>
        /// <param name="result">相加的结果</param>
        public static void Add( ref Vector4 left, ref Vector4 right, out Vector4 result )
	    {
		    result = new Vector4( left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W );
	    }
        /// <summary>
        /// 两个对象的差
        /// </summary>
        /// <param name="left">Vector4对象</param>
        /// <param name="right">Vector4对象</param>
        /// <returns>返回计算后的结果</returns>
        public static Vector4 Subtract( Vector4 left, Vector4 right )
	    {
		    return new Vector4( left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W );
	    }
        /// <summary>
        /// 两个对象的差
        /// </summary>
        /// <param name="left">Vector4对象</param>
        /// <param name="right">Vector4对象</param>
        /// <param name="result">计算后的结果</param>
        public static void Subtract( ref Vector4 left, ref Vector4 right, out Vector4 result )
	    {
            result = new Vector4(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W);
	    }
        /// <summary>
        /// 两个对象的积
        /// </summary>
        /// <param name="left">Vector4对象</param>
        /// <param name="right">Vector4对象</param>
        /// <returns>返回计算后的结果</returns>
        public static Vector4 Modulate( Vector4 left, Vector4 right )
	    {
            return new Vector4(left.X * right.X, left.Y * right.Y, left.Z * right.Z, left.W * right.W);
	    }
        /// <summary>
        /// 两个对象的积
        /// </summary>
        /// <param name="left">Vector4对象</param>
        /// <param name="right">Vector4对象</param>
        /// <param name="result">计算后的结果</param>
        public static void Modulate( ref Vector4 left, ref Vector4 right, out Vector4 result )
	    {
            result = new Vector4(left.X * right.X, left.Y * right.Y, left.Z * right.Z, left.W * right.W);
	    }
        /// <summary>
        /// 向量的数乘
        /// </summary>
        /// <param name="value">Vector4对象</param>
        /// <param name="scale">缩放值</param>
        /// <returns>返回计算后的结果</returns>
        public static Vector4 Multiply( Vector4 value, float scale )
	    {
            return new Vector4(value.X * scale, value.Y * scale, value.Z * scale, value.W * scale);
	    }
        /// <summary>
        /// 向量的数乘
        /// </summary>
        /// <param name="value">Vector4对象</param>
        /// <param name="scale">缩放值</param>
        /// <param name="result">计算后的结果</param>
        public static void Multiply( ref Vector4 value, float scale, out Vector4 result )
	    {
            result = new Vector4(value.X * scale, value.Y * scale, value.Z * scale, value.W * scale);
	    }
        /// <summary>
        /// 向量与常数的商
        /// </summary>
        /// <param name="value">Vector4对象</param>
        /// <param name="scale">缩放值</param>
        /// <returns>返回计算后的结果</returns>
        public static Vector4 Divide( Vector4 value, float scale )
	    {
            return new Vector4(value.X / scale, value.Y / scale, value.Z / scale, value.W / scale);
	    }
        /// <summary>
        /// 向量与常数的商
        /// </summary>
        /// <param name="value">Vector4对象</param>
        /// <param name="scale">缩放值</param>
        /// <param name="result">计算后的结果</param>
        public static void Divide( ref Vector4 value, float scale, out Vector4 result )
	    {
            result = new Vector4(value.X / scale, value.Y / scale, value.Z / scale, value.W / scale);
	    }
        /// <summary>
        /// 向量取反
        /// </summary>
        /// <param name="value">Vector4对象</param>
        /// <returns>返回计算后的结果</returns>
        public static Vector4 Negate( Vector4 value )
	    {
            return new Vector4(-value.X, -value.Y, -value.Z, -value.W);
	    }
        /// <summary>
        /// 向量取反
        /// </summary>
        /// <param name="value">Vector4对象</param>
        /// <param name="result">计算后的结果</param>
        public static void Negate( ref Vector4 value, out Vector4 result )
	    {
            result = new Vector4(-value.X, -value.Y, -value.Z, -value.W);
	    }
        /// <summary>
        /// 计算质心
        /// </summary>
        /// <param name="value1">Vector4对象坐标</param>
        /// <param name="value2">Vector4对象坐标</param>
        /// <param name="value3">Vector4对象坐标</param>
        /// <param name="amount1">参数</param>
        /// <param name="amount2">参数</param>
        /// <returns>返回计算后的结果</returns>
        public static Vector4 Barycentric( Vector4 value1, Vector4 value2, Vector4 value3, float amount1, float amount2 )
	    {
		    Vector4 vector = new Vector4();
		    vector.X = (value1.X + (amount1 * (value2.X - value1.X))) + (amount2 * (value3.X - value1.X));
		    vector.Y = (value1.Y + (amount1 * (value2.Y - value1.Y))) + (amount2 * (value3.Y - value1.Y));
		    vector.Z = (value1.Z + (amount1 * (value2.Z - value1.Z))) + (amount2 * (value3.Z - value1.Z));
		    vector.W = (value1.W + (amount1 * (value2.W - value1.W))) + (amount2 * (value3.W - value1.W));
		    return vector;
	    }
        /// <summary>
        /// 计算质心
        /// </summary>
        /// <param name="value1">Vector4对象坐标</param>
        /// <param name="value2">Vector4对象坐标</param>
        /// <param name="value3">Vector4对象坐标</param>
        /// <param name="amount1">参数</param>
        /// <param name="amount2">参数</param>
        /// <param name="result">计算后的结果</param>
        public static void Barycentric( ref Vector4 value1, ref Vector4 value2, ref Vector4 value3, float amount1, float amount2, out Vector4 result )
	    {
            result = new Vector4((value1.X + (amount1 * (value2.X - value1.X))) + (amount2 * (value3.X - value1.X)),
			    (value1.Y + (amount1 * (value2.Y - value1.Y))) + (amount2 * (value3.Y - value1.Y)),
			    (value1.Z + (amount1 * (value2.Z - value1.Z))) + (amount2 * (value3.Z - value1.Z)),
			    (value1.W + (amount1 * (value2.W - value1.W))) + (amount2 * (value3.W - value1.W)) );
	    }
        /// <summary>
        /// CatmullRom插值
        /// </summary>
        /// <param name="value1">Vector4对象坐标</param>
        /// <param name="value2">Vector4对象坐标</param>
        /// <param name="value3">Vector4对象坐标</param>
        /// <param name="value4">Vector4对象坐标</param>
        /// <param name="amount">参数</param>
        /// <returns>返回计算后的结果</returns>
        public static Vector4 CatmullRom( Vector4 value1, Vector4 value2, Vector4 value3, Vector4 value4, float amount )
	    {
		    Vector4 vector = new Vector4();
		    float squared = amount * amount;
		    float cubed = amount * squared;

		    vector.X = 0.5f * ((((2.0f * value2.X) + ((-value1.X + value3.X) * amount)) + 
			    (((((2.0f * value1.X) - (5.0f * value2.X)) + (4.0f * value3.X)) - value4.X) * squared)) + 
			    ((((-value1.X + (3.0f * value2.X)) - (3.0f * value3.X)) + value4.X) * cubed));

		    vector.Y = 0.5f * ((((2.0f * value2.Y) + ((-value1.Y + value3.Y) * amount)) + 
			    (((((2.0f * value1.Y) - (5.0f * value2.Y)) + (4.0f * value3.Y)) - value4.Y) * squared)) + 
			    ((((-value1.Y + (3.0f * value2.Y)) - (3.0f * value3.Y)) + value4.Y) * cubed));

		    vector.Z = 0.5f * ((((2.0f * value2.Z) + ((-value1.Z + value3.Z) * amount)) + 
			    (((((2.0f * value1.Z) - (5.0f * value2.Z)) + (4.0f * value3.Z)) - value4.Z) * squared)) + 
			    ((((-value1.Z + (3.0f * value2.Z)) - (3.0f * value3.Z)) + value4.Z) * cubed));

		    vector.W = 0.5f * ((((2.0f * value2.W) + ((-value1.W + value3.W) * amount)) + 
			    (((((2.0f * value1.W) - (5.0f * value2.W)) + (4.0f * value3.W)) - value4.W) * squared)) + 
			    ((((-value1.W + (3.0f * value2.W)) - (3.0f * value3.W)) + value4.W) * cubed));

		    return vector;
	    }
        /// <summary>
        /// CatmullRom插值
        /// </summary>
        /// <param name="value1">Vector4对象坐标</param>
        /// <param name="value2">Vector4对象坐标</param>
        /// <param name="value3">Vector4对象坐标</param>
        /// <param name="value4">Vector4对象坐标</param>
        /// <param name="amount">参数</param>
        /// <param name="result">计算后的结果</param>
        public static void CatmullRom( ref Vector4 value1, ref Vector4 value2, ref Vector4 value3, ref Vector4 value4, float amount, out Vector4 result )
	    {
		    float squared = amount * amount;
		    float cubed = amount * squared;
		
		    Vector4 r = new Vector4();

		    r.X = 0.5f * ((((2.0f * value2.X) + ((-value1.X + value3.X) * amount)) + 
			    (((((2.0f * value1.X) - (5.0f * value2.X)) + (4.0f * value3.X)) - value4.X) * squared)) + 
			    ((((-value1.X + (3.0f * value2.X)) - (3.0f * value3.X)) + value4.X) * cubed));

		    r.Y = 0.5f * ((((2.0f * value2.Y) + ((-value1.Y + value3.Y) * amount)) + 
			    (((((2.0f * value1.Y) - (5.0f * value2.Y)) + (4.0f * value3.Y)) - value4.Y) * squared)) + 
			    ((((-value1.Y + (3.0f * value2.Y)) - (3.0f * value3.Y)) + value4.Y) * cubed));

		    r.Z = 0.5f * ((((2.0f * value2.Z) + ((-value1.Z + value3.Z) * amount)) + 
			    (((((2.0f * value1.Z) - (5.0f * value2.Z)) + (4.0f * value3.Z)) - value4.Z) * squared)) + 
			    ((((-value1.Z + (3.0f * value2.Z)) - (3.0f * value3.Z)) + value4.Z) * cubed));

		    r.W = 0.5f * ((((2.0f * value2.W) + ((-value1.W + value3.W) * amount)) + 
			    (((((2.0f * value1.W) - (5.0f * value2.W)) + (4.0f * value3.W)) - value4.W) * squared)) + 
			    ((((-value1.W + (3.0f * value2.W)) - (3.0f * value3.W)) + value4.W) * cubed));

		    result = r;
	    }
        /// <summary>
        /// 载体计算
        /// </summary>
        /// <param name="value">Vector4对象坐标</param>
        /// <param name="min">Vector4对象的最小值</param>
        /// <param name="max">Vector4对象的最大值</param>
        /// <returns>返回计算后的结果</returns>
        public static Vector4 Clamp( Vector4 value, Vector4 min, Vector4 max )
	    {
		    float x = value.X;
		    x = (x > max.X) ? max.X : x;
		    x = (x < min.X) ? min.X : x;

		    float y = value.Y;
		    y = (y > max.Y) ? max.Y : y;
		    y = (y < min.Y) ? min.Y : y;

		    float z = value.Z;
		    z = (z > max.Z) ? max.Z : z;
		    z = (z < min.Z) ? min.Z : z;

		    float w = value.W;
		    w = (w > max.W) ? max.W : w;
		    w = (w < min.W) ? min.W : w;

            return new Vector4(x, y, z, w);
	    }
        /// <summary>
        /// 载体计算
        /// </summary>
        /// <param name="value">Vector4对象坐标</param>
        /// <param name="min">Vector4对象的最小值</param>
        /// <param name="max">Vector4对象的最大值</param>
        /// <param name="result">计算后的结果</param>
        public static void Clamp( ref Vector4 value, ref Vector4 min, ref Vector4 max, out Vector4 result )
	    {
		    float x = value.X;
		    x = (x > max.X) ? max.X : x;
		    x = (x < min.X) ? min.X : x;

		    float y = value.Y;
		    y = (y > max.Y) ? max.Y : y;
		    y = (y < min.Y) ? min.Y : y;

		    float z = value.Z;
		    z = (z > max.Z) ? max.Z : z;
		    z = (z < min.Z) ? min.Z : z;

		    float w = value.W;
		    w = (w > max.W) ? max.W : w;
		    w = (w < min.W) ? min.W : w;

            result = new Vector4(x, y, z, w);
	    }
        /// <summary>
        /// 艾米插值计算
        /// </summary>
        /// <param name="value1">Vector4对象</param>
        /// <param name="tangent1">Vector4对象的正切点坐标</param>
        /// <param name="value2">Vector4对象</param>
        /// <param name="tangent2">Vector4对象的正切点坐标</param>
        /// <param name="amount">插值</param>
        /// <returns>返回计算后的向量</returns>
        public static Vector4 Hermite( Vector4 value1, Vector4 tangent1, Vector4 value2, Vector4 tangent2, float amount )
	    {
		    Vector4 vector;
		    float squared = amount * amount;
		    float cubed = amount * squared;
		    float part1 = ((2.0f * cubed) - (3.0f * squared)) + 1.0f;
		    float part2 = (-2.0f * cubed) + (3.0f * squared);
		    float part3 = (cubed - (2.0f * squared)) + amount;
		    float part4 = cubed - squared;

		    vector.X = (((value1.X * part1) + (value2.X * part2)) + (tangent1.X * part3)) + (tangent2.X * part4);
		    vector.Y = (((value1.Y * part1) + (value2.Y * part2)) + (tangent1.Y * part3)) + (tangent2.Y * part4);
		    vector.Z = (((value1.Z * part1) + (value2.Z * part2)) + (tangent1.Z * part3)) + (tangent2.Z * part4);
		    vector.W = (((value1.W * part1) + (value2.W * part2)) + (tangent1.W * part3)) + (tangent2.W * part4);

		    return vector;
	    }
        /// <summary>
        /// 艾米插值计算
        /// </summary>
        /// <param name="value1">Vector4对象</param>
        /// <param name="tangent1">Vector4对象的正切点坐标</param>
        /// <param name="value2">Vector4对象</param>
        /// <param name="tangent2">Vector4对象的正切点坐标</param>
        /// <param name="amount">插值</param>
        /// <param name="result">计算后的向量</param>
        public static void Hermite( ref Vector4 value1, ref Vector4 tangent1, ref Vector4 value2, ref Vector4 tangent2, float amount, out Vector4 result )
	    {
		    float squared = amount * amount;
		    float cubed = amount * squared;
		    float part1 = ((2.0f * cubed) - (3.0f * squared)) + 1.0f;
		    float part2 = (-2.0f * cubed) + (3.0f * squared);
		    float part3 = (cubed - (2.0f * squared)) + amount;
		    float part4 = cubed - squared;

		    result.X = (((value1.X * part1) + (value2.X * part2)) + (tangent1.X * part3)) + (tangent2.X * part4);
		    result.Y = (((value1.Y * part1) + (value2.Y * part2)) + (tangent1.Y * part3)) + (tangent2.Y * part4);
		    result.Z = (((value1.Z * part1) + (value2.Z * part2)) + (tangent1.Z * part3)) + (tangent2.Z * part4);
		    result.W = (((value1.W * part1) + (value2.W * part2)) + (tangent1.W * part3)) + (tangent2.W * part4);
	    }
        /// <summary>
        /// 计算线性插值
        /// </summary>
        /// <param name="start">起点坐标</param>
        /// <param name="end">终点坐标</param>
        /// <param name="factor">插值因子</param>
        /// <returns>返回计算后的向量</returns>
        public static Vector4 Lerp( Vector4 start, Vector4 end, float factor )
	    {
		    Vector4 vector = new Vector4();

		    vector.X = start.X + ((end.X - start.X) * factor);
		    vector.Y = start.Y + ((end.Y - start.Y) * factor);
		    vector.Z = start.Z + ((end.Z - start.Z) * factor);
		    vector.W = start.W + ((end.W - start.W) * factor);

		    return vector;
	    }
        /// <summary>
        /// 计算线性插值
        /// </summary>
        /// <param name="start">起点坐标</param>
        /// <param name="end">终点坐标</param>
        /// <param name="factor">插值因子</param>
        /// <param name="result">计算后的向量</param>
        public static void Lerp( ref Vector4 start, ref Vector4 end, float factor, out Vector4 result )
	    {
		    result.X = start.X + ((end.X - start.X) * factor);
		    result.Y = start.Y + ((end.Y - start.Y) * factor);
		    result.Z = start.Z + ((end.Z - start.Z) * factor);
		    result.W = start.W + ((end.W - start.W) * factor);
	    }
        /// <summary>
        /// 平滑插值计算
        /// </summary>
        /// <param name="start">起点坐标</param>
        /// <param name="end">终点坐标</param>
        /// <param name="amount">插值因子</param>
        /// <returns>返回计算后的向量</returns>
        public static Vector4 SmoothStep( Vector4 start, Vector4 end, float amount )
	    {
		    Vector4 vector = new Vector4();

		    amount = (amount > 1.0f) ? 1.0f : ((amount < 0.0f) ? 0.0f : amount);
		    amount = (amount * amount) * (3.0f - (2.0f * amount));

		    vector.X = start.X + ((end.X - start.X) * amount);
		    vector.Y = start.Y + ((end.Y - start.Y) * amount);
		    vector.Z = start.Z + ((end.Z - start.Z) * amount);
		    vector.W = start.W + ((end.W - start.W) * amount);

		    return vector;
	    }
        /// <summary>
        /// 平滑插值计算
        /// </summary>
        /// <param name="start">起点坐标</param>
        /// <param name="end">终点坐标</param>
        /// <param name="amount">插值因子</param>
        /// <param name="result">计算后的向量</param>
        public static void SmoothStep( ref Vector4 start, ref Vector4 end, float amount, out Vector4 result )
	    {
		    amount = (amount > 1.0f) ? 1.0f : ((amount < 0.0f) ? 0.0f : amount);
		    amount = (amount * amount) * (3.0f - (2.0f * amount));

		    result.X = start.X + ((end.X - start.X) * amount);
		    result.Y = start.Y + ((end.Y - start.Y) * amount);
		    result.Z = start.Z + ((end.Z - start.Z) * amount);
		    result.W = start.W + ((end.W - start.W) * amount);
	    }
        /// <summary>
        /// 计算两点间的距离
        /// </summary>
        /// <param name="value1">坐标点</param>
        /// <param name="value2">坐标点</param>
        /// <returns>返回两点间的距离</returns>
        public static float Distance( Vector4 value1, Vector4 value2 )
	    {
		    float x = value1.X - value2.X;
		    float y = value1.Y - value2.Y;
		    float z = value1.Z - value2.Z;
		    float w = value1.W - value2.W;

		    return (float)( Math.Sqrt( (x * x) + (y * y) + (z * z) + (w * w) ) );
	    }
        /// <summary>
        /// 计算两点间的距离的平方
        /// </summary>
        /// <param name="value1">坐标点</param>
        /// <param name="value2">坐标点</param>
        /// <returns>返回两点间的距离的平方</returns>
        public static float DistanceSquared( Vector4 value1, Vector4 value2 )
	    {
		    float x = value1.X - value2.X;
		    float y = value1.Y - value2.Y;
		    float z = value1.Z - value2.Z;
		    float w = value1.W - value2.W;

		    return (x * x) + (y * y) + (z * z) + (w * w);
	    }
        /// <summary>
        /// 向量的点积
        /// </summary>
        /// <param name="left">向量对象</param>
        /// <param name="right">对象向量</param>
        /// <returns>返回点积值</returns>
        public static float Dot( Vector4 left, Vector4 right )
	    {
		    return (left.X * right.X + left.Y * right.Y + left.Z * right.Z + left.W * right.W);
	    }
        /// <summary>
        /// 向量的单位化
        /// </summary>
        /// <param name="vector">向量对象</param>
        /// <returns>返回单位向量</returns>
	    public static Vector4 Normalize( Vector4 vector )
	    {
		    vector.Normalize();
		    return vector;
	    }
        /// <summary>
        /// 向量的单位化
        /// </summary>
        /// <param name="vector">向量对象</param>
        /// <param name="result">单位向量</param>
        public static void Normalize( ref Vector4 vector, out Vector4 result )
	    {
            result = new Vector4(vector);
		    result.Normalize();
	    }
        /// <summary>
        /// 向量的坐标转换运算
        /// </summary>
        /// <param name="vector">向量对象</param>
        /// <param name="transform">转换矩阵</param>
        /// <returns>返回转换后的向量</returns>
        public static Vector4 Transform( Vector4 vector, Matrix transform )
	    {
		    Vector4 result = new Vector4();

		    result.X = (vector.X * transform.M11) + (vector.Y * transform.M21) + (vector.Z * transform.M31) + (vector.W * transform.M41);
		    result.Y = (vector.X * transform.M12) + (vector.Y * transform.M22) + (vector.Z * transform.M32) + (vector.W * transform.M42);
		    result.Z = (vector.X * transform.M13) + (vector.Y * transform.M23) + (vector.Z * transform.M33) + (vector.W * transform.M43);
		    result.W = (vector.X * transform.M14) + (vector.Y * transform.M24) + (vector.Z * transform.M34) + (vector.W * transform.M44);

		    return result;
	    }
        /// <summary>
        /// 向量的坐标转换运算
        /// </summary>
        /// <param name="vector">向量对象</param>
        /// <param name="transform">转换矩阵</param>
        /// <param name="result">转换后的向量</param>
        public static void Transform( ref Vector4 vector, ref Matrix transform, out Vector4 result )
	    {
            Vector4 r = new Vector4();
		    r.X = (vector.X * transform.M11) + (vector.Y * transform.M21) + (vector.Z * transform.M31) + (vector.W * transform.M41);
		    r.Y = (vector.X * transform.M12) + (vector.Y * transform.M22) + (vector.Z * transform.M32) + (vector.W * transform.M42);
		    r.Z = (vector.X * transform.M13) + (vector.Y * transform.M23) + (vector.Z * transform.M33) + (vector.W * transform.M43);
		    r.W = (vector.X * transform.M14) + (vector.Y * transform.M24) + (vector.Z * transform.M34) + (vector.W * transform.M44);
	
		    result = r;
	    }
        /// <summary>
        /// 向量的坐标转换运算
        /// </summary>
        /// <param name="vectors">向量对象列表</param>
        /// <param name="transform">转换矩阵</param>
        /// <returns>返回转换后的向量列表</returns>
        public static Vector4[] Transform( Vector4[] vectors, ref Matrix transform )
	    {
		    if( vectors == null )
			    throw new ArgumentNullException( "vectors" );

		    int count = vectors.Length;
		    Vector4[] results = new Vector4[ count ];

		    for( int i = 0; i < count; i++ )
		    {
			    Vector4 r;
			    r.X = (vectors[i].X * transform.M11) + (vectors[i].Y * transform.M21) + (vectors[i].Z * transform.M31) + (vectors[i].W * transform.M41);
			    r.Y = (vectors[i].X * transform.M12) + (vectors[i].Y * transform.M22) + (vectors[i].Z * transform.M32) + (vectors[i].W * transform.M42);
			    r.Z = (vectors[i].X * transform.M13) + (vectors[i].Y * transform.M23) + (vectors[i].Z * transform.M33) + (vectors[i].W * transform.M43);
			    r.W = (vectors[i].X * transform.M14) + (vectors[i].Y * transform.M24) + (vectors[i].Z * transform.M34) + (vectors[i].W * transform.M44);
		
			    results[i] = r;
		    }

		    return results;
	    }
        /// <summary>
        /// 向量的坐标转换运算
        /// </summary>
        /// <param name="value">向量对象</param>
        /// <param name="rotation">旋转四元数</param>
        /// <returns>返回转换后的向量</returns>
        public static Vector4 Transform( Vector4 value, Quaternion rotation )
	    {
		    Vector4 vector;
		    float x = rotation.X + rotation.X;
		    float y = rotation.Y + rotation.Y;
		    float z = rotation.Z + rotation.Z;
		    float wx = rotation.W * x;
		    float wy = rotation.W * y;
		    float wz = rotation.W * z;
		    float xx = rotation.X * x;
		    float xy = rotation.X * y;
		    float xz = rotation.X * z;
		    float yy = rotation.Y * y;
		    float yz = rotation.Y * z;
		    float zz = rotation.Z * z;

		    vector.X = ((value.X * ((1.0f - yy) - zz)) + (value.Y * (xy - wz))) + (value.Z * (xz + wy));
		    vector.Y = ((value.X * (xy + wz)) + (value.Y * ((1.0f - xx) - zz))) + (value.Z * (yz - wx));
		    vector.Z = ((value.X * (xz - wy)) + (value.Y * (yz + wx))) + (value.Z * ((1.0f - xx) - yy));
		    vector.W = value.W;

		    return vector;
	    }
        /// <summary>
        /// 向量的坐标转换运算
        /// </summary>
        /// <param name="value">向量对象</param>
        /// <param name="rotation">旋转四元数</param>
        /// <param name="result">转换后的向量</param>
        public static void Transform( ref Vector4 value, ref Quaternion rotation, out Vector4 result )
	    {
		    float x = rotation.X + rotation.X;
		    float y = rotation.Y + rotation.Y;
		    float z = rotation.Z + rotation.Z;
		    float wx = rotation.W * x;
		    float wy = rotation.W * y;
		    float wz = rotation.W * z;
		    float xx = rotation.X * x;
		    float xy = rotation.X * y;
		    float xz = rotation.X * z;
		    float yy = rotation.Y * y;
		    float yz = rotation.Y * z;
		    float zz = rotation.Z * z;

            Vector4 r = new Vector4();
		    r.X = ((value.X * ((1.0f - yy) - zz)) + (value.Y * (xy - wz))) + (value.Z * (xz + wy));
		    r.Y = ((value.X * (xy + wz)) + (value.Y * ((1.0f - xx) - zz))) + (value.Z * (yz - wx));
		    r.Z = ((value.X * (xz - wy)) + (value.Y * (yz + wx))) + (value.Z * ((1.0f - xx) - yy));
		    r.W = value.W;

		    result = r;
	    }
        /// <summary>
        /// 向量的坐标转换运算
        /// </summary>
        /// <param name="vectors">向量对象列表</param>
        /// <param name="rotation">旋转四元数</param>
        /// <returns>返回转换后的向量列表</returns>
        public static Vector4[] Transform( Vector4[] vectors, ref Quaternion rotation )
	    {
		    if( vectors == null )
			    throw new ArgumentNullException( "vectors" );

		    int count = vectors.Length;
            Vector4[] results = new Vector4[count];

		    float x = rotation.X + rotation.X;
		    float y = rotation.Y + rotation.Y;
		    float z = rotation.Z + rotation.Z;
		    float wx = rotation.W * x;
		    float wy = rotation.W * y;
		    float wz = rotation.W * z;
		    float xx = rotation.X * x;
		    float xy = rotation.X * y;
		    float xz = rotation.X * z;
		    float yy = rotation.Y * y;
		    float yz = rotation.Y * z;
		    float zz = rotation.Z * z;

		    for( int i = 0; i < count; i++ )
		    {
                Vector4 r = new Vector4();
			    r.X = ((vectors[i].X * ((1.0f - yy) - zz)) + (vectors[i].Y * (xy - wz))) + (vectors[i].Z * (xz + wy));
			    r.Y = ((vectors[i].X * (xy + wz)) + (vectors[i].Y * ((1.0f - xx) - zz))) + (vectors[i].Z * (yz - wx));
			    r.Z = ((vectors[i].X * (xz - wy)) + (vectors[i].Y * (yz + wx))) + (vectors[i].Z * ((1.0f - xx) - yy));
			    r.W = vectors[i].W;

			    results[i] = r;
		    }

		    return results;
	    }
        /// <summary>
        /// 最小化
        /// </summary>
        /// <param name="left">向量对象</param>
        /// <param name="right">向量对象</param>
        /// <returns>返回最小的向量</returns>
	    public static Vector4 Minimize( Vector4 left, Vector4 right )
	    {
            Vector4 vector = new Vector4();
		    vector.X = (left.X < right.X) ? left.X : right.X;
		    vector.Y = (left.Y < right.Y) ? left.Y : right.Y;
		    vector.Z = (left.Z < right.Z) ? left.Z : right.Z;
		    vector.W = (left.W < right.W) ? left.W : right.W;
		    return vector;
	    }
        /// <summary>
        /// 最小化
        /// </summary>
        /// <param name="left">向量对象</param>
        /// <param name="right">向量对象</param>
        /// <param name="result">最小的向量</param>
        public static void Minimize( ref Vector4 left, ref Vector4 right, out Vector4 result )
	    {
		    result.X = (left.X < right.X) ? left.X : right.X;
		    result.Y = (left.Y < right.Y) ? left.Y : right.Y;
		    result.Z = (left.Z < right.Z) ? left.Z : right.Z;
		    result.W = (left.W < right.W) ? left.W : right.W;
	    }
        /// <summary>
        /// 最大化
        /// </summary>
        /// <param name="left">向量对象</param>
        /// <param name="right">向量对象</param>
        /// <returns>返回最大的向量</returns>
	    public static Vector4 Maximize( Vector4 left, Vector4 right )
	    {
            Vector4 vector = new Vector4();
		    vector.X = (left.X > right.X) ? left.X : right.X;
		    vector.Y = (left.Y > right.Y) ? left.Y : right.Y;
		    vector.Z = (left.Z > right.Z) ? left.Z : right.Z;
		    vector.W = (left.W > right.W) ? left.W : right.W;
		    return vector;
	    }
        /// <summary>
        /// 最大化
        /// </summary>
        /// <param name="left">向量对象</param>
        /// <param name="right">向量对象</param>
        /// <param name="result">最大的向量</param>
        public static void Maximize( ref Vector4 left, ref Vector4 right, out Vector4 result )
	    {
		    result.X = (left.X > right.X) ? left.X : right.X;
		    result.Y = (left.Y > right.Y) ? left.Y : right.Y;
		    result.Z = (left.Z > right.Z) ? left.Z : right.Z;
		    result.W = (left.W > right.W) ? left.W : right.W;
	    }
        /// <summary>
        /// 重载"+"号运算符
        /// </summary>
        /// <param name="left">向量对象</param>
        /// <param name="right">向量对象</param>
        /// <returns>返回计算后的向量对象</returns>
	    public static Vector4 operator + ( Vector4 left, Vector4 right )
	    {
		    return new Vector4( left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.W + right.W );
	    }
        /// <summary>
        /// 重载"-"号运算符
        /// </summary>
        /// <param name="left">向量对象</param>
        /// <param name="right">向量对象</param>
        /// <returns>返回计算后的向量对象</returns>
        public static Vector4 operator - ( Vector4 left, Vector4 right )
	    {
		    return new Vector4( left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.W - right.W );
	    }
        /// <summary>
        /// 重载"-"号运算符，向量取反
        /// </summary>
        /// <param name="value">向量对象</param>
        /// <returns>返回计算后的向量对象</returns>
        public static Vector4 operator - ( Vector4 value )
	    {
		    return new Vector4( -value.X, -value.Y, -value.Z, -value.W );
	    }
        /// <summary>
        /// 重载"*"号运算符
        /// </summary>
        /// <param name="value">向量对象</param>
        /// <param name="scale">缩放常数</param>
        /// <returns>返回计算后的向量对象</returns>
        public static Vector4 operator * ( Vector4 value, float scale )
	    {
		    return new Vector4( value.X * scale, value.Y * scale, value.Z * scale, value.W * scale );
	    }
        /// <summary>
        /// 重载"*"号运算符
        /// </summary>
        /// <param name="scale">缩放常数</param>
        /// <param name="vec">向量对象</param>
        /// <returns>返回计算后的向量对象</returns>
        public static Vector4 operator * ( float scale, Vector4 vec )
	    {
		    return vec * scale;
	    }
        /// <summary>
        /// 重载"/"号运算符
        /// </summary>
        /// <param name="value">向量对象</param>
        /// <param name="scale">缩放常数</param>
        /// <returns>返回计算后的向量对象</returns>
        public static Vector4 operator / ( Vector4 value, float scale )
	    {
		    return new Vector4( value.X / scale, value.Y / scale, value.Z / scale, value.W / scale );
	    }
        /// <summary>
        /// 重载"=="号运算符
        /// </summary>
        /// <param name="left">向量对象</param>
        /// <param name="right">向量对象</param>
        /// <returns>如果两个向量相等返回true，否则返回false</returns>
	    public static bool operator == ( Vector4 left, Vector4 right )
	    {
		    return Equals( left, right );
	    }
        /// <summary>
        /// 重载"!="号运算符
        /// </summary>
        /// <param name="left">向量对象</param>
        /// <param name="right">向量对象</param>
        /// <returns>如果两个向量不相等返回true，否则返回false</returns>
	    public static bool operator != ( Vector4 left, Vector4 right )
	    {
		    return !Equals( left, right );
	    }
    }
}
