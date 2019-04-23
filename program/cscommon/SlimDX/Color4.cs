﻿using System;
using System.Globalization;

namespace SlimDX
{
    /// <summary>
    /// 带透明通道的颜色值
    /// </summary>
    [System.Serializable]
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    //[System.ComponentModel.TypeConverter( typeof(SlimDX.Design.Color4Converter) )]
	public struct Color4
    {
        /// <summary>
        /// 红色值
        /// </summary>
        public float Red;
        /// <summary>
        /// 绿色值
        /// </summary>
        public float Green;
        /// <summary>
        /// 蓝色值
        /// </summary>
        public float Blue;
        /// <summary>
        /// Alpha通道值
        /// </summary>
        public float Alpha;
        /// <summary>
        /// 带参构造函数
        /// </summary>
        /// <param name="alpha">Alpha通道值</param>
        /// <param name="red">红色值</param>
        /// <param name="green">绿色值</param>
        /// <param name="blue">蓝色值</param>
	    public Color4( float alpha, float red, float green, float blue )
	    {
		    Alpha = alpha;
		    Red = red;
		    Green = green;
		    Blue = blue;
	    }
        /// <summary>
        /// 带参构造函数
        /// </summary>
        /// <param name="red">红色值</param>
        /// <param name="green">绿色值</param>
        /// <param name="blue">蓝色值</param>
	    public Color4( float red, float green, float blue )
	    {
		    Alpha = 1.0f;
		    Red = red;
		    Green = green;
		    Blue = blue;
	    }
        /// <summary>
        /// 带参构造函数
        /// </summary>
        /// <param name="color">颜色</param>
        public Color4(CSUtility.Support.Color color)
	    {
		    Alpha = color.A / 255.0f;
		    Red = color.R / 255.0f;
		    Green = color.G / 255.0f;
		    Blue = color.B / 255.0f;
	    }
        /// <summary>
        /// 带参构造函数
        /// </summary>
        /// <param name="color">颜色对象</param>
	    public Color4( Color3 color )
	    {
		    Alpha = 1.0f;
		    Red = color.Red;
		    Green = color.Green;
		    Blue = color.Blue;
	    }
        /// <summary>
        /// 带参构造函数
        /// </summary>
        /// <param name="color">颜色值，使用Vector3表示</param>
	    public Color4( Vector3 color )
	    {
		    Alpha = 1.0f;
		    Red = color.X;
		    Green = color.Y;
		    Blue = color.Z;
	    }
        /// <summary>
        /// 带参构造函数
        /// </summary>
        /// <param name="color">颜色值，使用Vector4表示</param>
	    public Color4( Vector4 color )
	    {
		    Alpha = color.W;
		    Red = color.X;
		    Green = color.Y;
		    Blue = color.Z;
	    }
        /// <summary>
        /// 带参构造函数
        /// </summary>
        /// <param name="argb">使用int表示的颜色值</param>
	    public Color4( int argb )
	    {
		    Alpha = ( ( argb >> 24 ) & 255 ) / 255.0f;
		    Red = ( ( argb >> 16 ) & 255 ) / 255.0f;
		    Green = ( ( argb >> 8 ) & 255 ) / 255.0f;
		    Blue = ( argb & 255 ) / 255.0f;
	    }
        /// <summary>
        /// 颜色转换
        /// </summary>
        /// <returns>返回转换后的颜色</returns>
	    public CSUtility.Support.Color ToColor()
	    {
		    return CSUtility.Support.Color.FromArgb( (int)(Alpha * 255), (int)(Red * 255), (int)(Green * 255), (int)(Blue * 255) );
	    }
        /// <summary>
        /// 转换成不带Alpha通道值的颜色值
        /// </summary>
        /// <returns>返回转换后的颜色值</returns>
	    public Color3 ToColor3()
	    {
		    return new Color3( Red, Green, Blue );
	    }
        /// <summary>
        /// 转换成带Alpha通道值的颜色值
        /// </summary>
        /// <returns>返回转换后的颜色值</returns>
	    public int ToArgb()
	    {
		    UInt32 a, r, g, b;

		    a = (UInt32)(Alpha * 255.0f);
		    r = (UInt32)(Red * 255.0f);
		    g = (UInt32)(Green * 255.0f);
		    b = (UInt32)(Blue * 255.0f);

		    UInt32 value = b;
		    value += g << 8;
		    value += r << 16;
		    value += a << 24;

		    return (int)( value );
	    }
        /// <summary>
        /// 颜色值转换成Vector3
        /// </summary>
        /// <returns>返回转换后的Vector3</returns>
	    public Vector3 ToVector3()
	    {
            return new Vector3(Red, Green, Blue);
	    }
        /// <summary>
        /// 颜色值转换成Vector4
        /// </summary>
        /// <returns>返回转换后的Vector4</returns>
	    public Vector4 ToVector4()
	    {
            return new Vector4(Red, Green, Blue, Alpha);
	    }
        /// <summary>
        /// 两个颜色值相加
        /// </summary>
        /// <param name="color1">颜色1</param>
        /// <param name="color2">颜色2</param>
        /// <returns>返回相加后的颜色</returns>
	    public static Color4 Add( Color4 color1, Color4 color2 )
	    {
            return new Color4(color1.Alpha + color2.Alpha, color1.Red + color2.Red, color1.Green + color2.Green, color1.Blue + color2.Blue);
	    }
        /// <summary>
        /// 两个颜色值相加
        /// </summary>
        /// <param name="color1">颜色1</param>
        /// <param name="color2">颜色2</param>
        /// <param name="result">相加后的颜色</param>
	    public static void Add( ref Color4 color1, ref Color4 color2, out Color4 result )
	    {
            result = new Color4(color1.Alpha + color2.Alpha, color1.Red + color2.Red, color1.Green + color2.Green, color1.Blue + color2.Blue);
	    }
        /// <summary>
        /// 两个颜色相减
        /// </summary>
        /// <param name="color1">颜色1</param>
        /// <param name="color2">颜色2</param>
        /// <returns>返回相减后的颜色</returns>
	    public static Color4 Subtract( Color4 color1, Color4 color2 )
	    {
            return new Color4(color1.Alpha - color2.Alpha, color1.Red - color2.Red, color1.Green - color2.Green, color1.Blue - color2.Blue);
	    }
        /// <summary>
        /// 两个颜色相减
        /// </summary>
        /// <param name="color1">颜色1</param>
        /// <param name="color2">颜色2</param>
        /// <param name="result">相减后的颜色</param>
	    public static void Subtract( ref Color4 color1, ref Color4 color2, out Color4 result )
	    {
            result = new Color4(color1.Alpha - color2.Alpha, color1.Red - color2.Red, color1.Green - color2.Green, color1.Blue - color2.Blue);
	    }
        /// <summary>
        /// 两个颜色相乘
        /// </summary>
        /// <param name="color1">颜色1</param>
        /// <param name="color2">颜色2</param>
        /// <returns>返回相乘后的颜色</returns>
	    public static Color4 Modulate( Color4 color1, Color4 color2 )
	    {
            return new Color4(color1.Alpha * color2.Alpha, color1.Red * color2.Red, color1.Green * color2.Green, color1.Blue * color2.Blue);
	    }
        /// <summary>
        /// 两个颜色相乘
        /// </summary>
        /// <param name="color1">颜色1</param>
        /// <param name="color2">颜色2</param>
        /// <param name="result">相乘后的颜色</param>
	    public static void Modulate( ref Color4 color1, ref Color4 color2, out Color4 result )
	    {
            result = new Color4(color1.Alpha * color2.Alpha, color1.Red * color2.Red, color1.Green * color2.Green, color1.Blue * color2.Blue);
	    }
        /// <summary>
        /// 颜色的线性插值计算
        /// </summary>
        /// <param name="color1">颜色1</param>
        /// <param name="color2">颜色2</param>
        /// <param name="amount">插值</param>
        /// <returns>返回计算后的颜色</returns>
	    public static Color4 Lerp( Color4 color1, Color4 color2, float amount )
	    {
		    float a = color1.Alpha + amount * ( color2.Alpha - color1.Alpha );
		    float r = color1.Red + amount * ( color2.Red - color1.Red );
		    float g = color1.Green + amount * ( color2.Green - color1.Green );
		    float b = color1.Blue + amount * ( color2.Blue - color1.Blue );

            return new Color4(a, r, g, b);
	    }
        /// <summary>
        /// 颜色的线性插值计算
        /// </summary>
        /// <param name="color1">颜色1</param>
        /// <param name="color2">颜色2</param>
        /// <param name="amount">插值</param>
        /// <param name="result">计算后的颜色</param>
	    public static void Lerp( ref Color4 color1, ref Color4 color2, float amount, out Color4 result )
	    {
		    float a = color1.Alpha + amount * ( color2.Alpha - color1.Alpha );
		    float r = color1.Red + amount * ( color2.Red - color1.Red );
		    float g = color1.Green + amount * ( color2.Green - color1.Green );
		    float b = color1.Blue + amount * ( color2.Blue - color1.Blue );

            result = new Color4(a, r, g, b);
	    }
        /// <summary>
        /// 颜色的补植
        /// </summary>
        /// <param name="color">颜色对象</param>
        /// <returns>返回计算后的颜色</returns>
	    public static Color4 Negate( Color4 color )
	    {
            return new Color4(1.0f - color.Alpha, 1.0f - color.Red, 1.0f - color.Green, 1.0f - color.Blue);
	    }
        /// <summary>
        /// 颜色的补植
        /// </summary>
        /// <param name="color">颜色对象</param>
        /// <param name="result">计算后的颜色</param>
	    public static void Negate( ref Color4 color, out Color4 result )
	    {
            result = new Color4(1.0f - color.Alpha, 1.0f - color.Red, 1.0f - color.Green, 1.0f - color.Blue);
	    }
        /// <summary>
        /// 调整对比度
        /// </summary>
        /// <param name="color">颜色</param>
        /// <param name="contrast">对比度</param>
        /// <returns>返回调整后的颜色</returns>
	    public static Color4 AdjustContrast( Color4 color, float contrast )
	    {
		    float r = 0.5f + contrast * ( color.Red - 0.5f );
		    float g = 0.5f + contrast * ( color.Green - 0.5f );
		    float b = 0.5f + contrast * ( color.Blue - 0.5f );

            return new Color4(color.Alpha, r, g, b);
	    }
        /// <summary>
        /// 调整对比度
        /// </summary>
        /// <param name="color">颜色</param>
        /// <param name="contrast">对比度</param>
        /// <param name="result">调整后的颜色</param>
	    public static void AdjustContrast( ref Color4 color, float contrast, out Color4 result )
	    {
		    float r = 0.5f + contrast * ( color.Red - 0.5f );
		    float g = 0.5f + contrast * ( color.Green - 0.5f );
		    float b = 0.5f + contrast * ( color.Blue - 0.5f );

            result = new Color4(color.Alpha, r, g, b);
	    }
        /// <summary>
        /// 调整饱和度
        /// </summary>
        /// <param name="color">颜色值</param>
        /// <param name="saturation">饱和度</param>
        /// <returns>返回调整后的颜色值</returns>
	    public static Color4 AdjustSaturation( Color4 color, float saturation )
	    {
		    float grey = color.Red * 0.2125f + color.Green * 0.7154f + color.Blue * 0.0721f;
		    float r = grey + saturation * ( color.Red - grey );
		    float g = grey + saturation * ( color.Green - grey );
		    float b = grey + saturation * ( color.Blue - grey );

            return new Color4(color.Alpha, r, g, b);
	    }
        /// <summary>
        /// 调整饱和度
        /// </summary>
        /// <param name="color">颜色值</param>
        /// <param name="saturation">饱和度</param>
        /// <param name="result">调整后的颜色值</param>
	    public static void AdjustSaturation( ref Color4 color, float saturation, out Color4 result )
	    {
		    float grey = color.Red * 0.2125f + color.Green * 0.7154f + color.Blue * 0.0721f;
		    float r = grey + saturation * ( color.Red - grey );
		    float g = grey + saturation * ( color.Green - grey );
		    float b = grey + saturation * ( color.Blue - grey );

            result = new Color4(color.Alpha, r, g, b);
	    }
        /// <summary>
        /// 颜色值加深
        /// </summary>
        /// <param name="color">颜色值</param>
        /// <param name="scale">深度</param>
        /// <returns>返回计算后的颜色</returns>
	    public static Color4 Scale( Color4 color, float scale )
	    {
            return new Color4(color.Alpha, color.Red * scale, color.Green * scale, color.Blue * scale);
	    }
        /// <summary>
        /// 颜色值加深
        /// </summary>
        /// <param name="color">颜色值</param>
        /// <param name="scale">深度</param>
        /// <param name="result">计算后的颜色</param>
	    public static void Scale( ref Color4 color, float scale, out Color4 result )
	    {
            result = new Color4(color.Alpha, color.Red * scale, color.Green * scale, color.Blue * scale);
	    }
        /// <summary>
        /// 重载"+"号操作符
        /// </summary>
        /// <param name="color1">颜色值</param>
        /// <param name="color2">颜色值</param>
        /// <returns>返回计算后的颜色值</returns>
	    public static Color4 operator + ( Color4 color1, Color4 color2 )
	    {
            return new Color4(color1.Alpha + color2.Alpha, color1.Red + color2.Red, color1.Green + color2.Green, color1.Blue + color2.Blue);
	    }
        /// <summary>
        /// 重载"-"号操作符
        /// </summary>
        /// <param name="color1">颜色值</param>
        /// <param name="color2">颜色值</param>
        /// <returns>返回计算后的颜色值</returns>
	    public static Color4 operator - ( Color4 color1, Color4 color2 )
	    {
            return new Color4(color1.Alpha - color2.Alpha, color1.Red - color2.Red, color1.Green - color2.Green, color1.Blue - color2.Blue);
	    }
        /// <summary>
        /// 重载"-"号操作符
        /// </summary>
        /// <param name="color">颜色值</param>
        /// <returns>返回计算后的颜色值</returns>
	    public static Color4 operator - ( Color4 color )
	    {
            return new Color4(1.0f - color.Alpha, 1.0f - color.Red, 1.0f - color.Green, 1.0f - color.Blue);
	    }
        /// <summary>
        /// 重载"*"号操作符
        /// </summary>
        /// <param name="color1">颜色值</param>
        /// <param name="color2">颜色值</param>
        /// <returns>返回计算后的颜色值</returns>
	    public static Color4 operator * ( Color4 color1, Color4 color2 )
	    {
            return new Color4(color1.Alpha * color2.Alpha, color1.Red * color2.Red, color1.Green * color2.Green, color1.Blue * color2.Blue);
	    }
        /// <summary>
        /// 重载"*"号操作符
        /// </summary>
        /// <param name="color">颜色值</param>
        /// <param name="scale">放大倍数</param>
        /// <returns>返回计算后的颜色值</returns>
        public static Color4 operator *(Color4 color, float scale)
	    {
            return new Color4(color.Alpha, color.Red * scale, color.Green * scale, color.Blue * scale);
	    }
        /// <summary>
        /// 重载"*"号操作符
        /// </summary>
        /// <param name="scale">放大倍数</param>
        /// <param name="value">颜色值</param>
        /// <returns>返回计算后的颜色值</returns>
        public static Color4 operator * ( float scale, Color4 value )
	    {
		    return value * scale;
	    }
        /// <summary>
        /// 重载"=="号操作符
        /// </summary>
        /// <param name="left">颜色值</param>
        /// <param name="right">颜色值</param>
        /// <returns>两个颜色对象相等返回true，否则返回false</returns>
	    public static bool operator == ( Color4 left, Color4 right )
	    {
		    return Equals( left, right );
	    }
        /// <summary>
        /// 重载"!="号操作符
        /// </summary>
        /// <param name="left">颜色值</param>
        /// <param name="right">颜色值</param>
        /// <returns>两个颜色对象不相等返回true，否则返回false</returns>
	    public static bool operator != ( Color4 left, Color4 right )
	    {
		    return !Equals( left, right );
	    }
        /// <summary>
        /// 自定义int类型转换方式
        /// </summary>
        /// <param name="value">颜色对象</param>
	    public static implicit operator int( Color4 value )
	    {
		    return value.ToArgb();
	    }
        /// <summary>
        /// 自定义Color3类型转换方式
        /// </summary>
        /// <param name="value">颜色对象</param>
	    public static implicit operator Color3( Color4 value )
	    {
		    return value.ToColor3();
	    }
        /// <summary>
        /// 自定义CSUtility.Support.Color类型转换方式
        /// </summary>
        /// <param name="value">颜色对象</param>
	    public static implicit operator CSUtility.Support.Color( Color4 value )
	    {
		    return value.ToColor();
	    }
        /// <summary>
        /// 自定义Vector3类型转换方式
        /// </summary>
        /// <param name="value">颜色对象</param>
	    public static implicit operator Vector3( Color4 value )
	    {
		    return value.ToVector3();
	    }
        /// <summary>
        /// 自定义Vector4类型转换方式
        /// </summary>
        /// <param name="value">颜色对象</param>
	    public static implicit operator Vector4( Color4 value )
	    {
		    return value.ToVector4();
	    }
        /// <summary>
        /// 自定义Color4类型转换方式
        /// </summary>
        /// <param name="value">int类型的值</param>
	    public static implicit operator Color4( int value )
	    {
            return new Color4(value);
	    }
        /// <summary>
        /// 自定义Color4类型转换方式
        /// </summary>
        /// <param name="value">Color3类型的对象</param>
	    public static implicit operator Color4( Color3 value )
	    {
            return new Color4(value);
	    }
        /// <summary>
        /// 自定义Color4类型转换方式
        /// </summary>
        /// <param name="value">CSUtility.Support.Color类型的对象</param>
	    public static implicit operator Color4( CSUtility.Support.Color value )
	    {
            return new Color4(value);
	    }
        /// <summary>
        /// 自定义Color4类型转换方式
        /// </summary>
        /// <param name="value">Vector3类型的对象</param>
	    public static implicit operator Color4( Vector3 value )
	    {
            return new Color4(value);
	    }
        /// <summary>
        /// 自定义Color4类型转换方式
        /// </summary>
        /// <param name="value">Vector4类型的对象</param>
        public static implicit operator Color4(Vector4 value)
	    {
            return new Color4(value);
	    }
        /// <summary>
        /// 转换到字符串string类型
        /// </summary>
        /// <returns>返回转换后的string类型对象</returns>
	    public override string ToString()
	    {
		    return string.Format( CultureInfo.CurrentCulture, "A:{0} R:{1} G:{2} B:{3}", 
			    Alpha.ToString(CultureInfo.CurrentCulture), Red.ToString(CultureInfo.CurrentCulture), 
			    Green.ToString(CultureInfo.CurrentCulture), Blue.ToString(CultureInfo.CurrentCulture) );
	    }
        /// <summary>
        /// 获取该对象的哈希值
        /// </summary>
        /// <returns>返回该对象的哈希值</returns>
	    public override int GetHashCode()
	    {
		    return Alpha.GetHashCode() + Red.GetHashCode() + Green.GetHashCode() + Blue.GetHashCode();
	    }
        /// <summary>
        /// 判断是否相等
        /// </summary>
        /// <param name="value">实例对象</param>
        /// <returns>如果相等返回true，否则返回false</returns>
	    public override bool Equals( object value )
	    {
		    if( value == null )
			    return false;

		    if( value.GetType() != GetType() )
			    return false;

		    return Equals( (Color4)( value ) );
	    }
        /// <summary>
        /// 判断两个对象是否相等
        /// </summary>
        /// <param name="value">Color4实例对象</param>
        /// <returns>如果相等返回true，否则返回false</returns>
	    public bool Equals( Color4 value )
	    {
		    return ( Alpha == value.Alpha && Red == value.Red && Green == value.Green && Blue == value.Blue );
	    }
        /// <summary>
        /// 判断两个对象是否相等
        /// </summary>
        /// <param name="value1">Color4实例对象</param>
        /// <param name="value2">Color4实例对象</param>
        /// <returns>如果相等返回true，否则返回false</returns>
	    public static bool Equals( ref Color4 value1, ref Color4 value2 )
	    {
		    return ( value1.Alpha == value2.Alpha && value1.Red == value2.Red && value1.Green == value2.Green && value1.Blue == value2.Blue );
	    }
    }
}
