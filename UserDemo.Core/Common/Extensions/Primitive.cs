using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace UserDemo.Core.Common.Extensions
{
	public static class PrimitiveExtensions
	{
		public static int AsInt(this object value, int defaultValue = 0) {
			try {
				return Convert.ToInt32(value);
			}
			catch {
				return defaultValue;
			}
		}
		public static bool IsIn<T>(this T value, params T[] values) {
			return Array.Exists<T>(values, new Predicate<T>(delegate (T item) { return value.Equals(item); }));
		}
		public static bool IsNotIn<T>(this T value, params T[] values) {
			return !IsIn<T>(value, values);
		}
		public static bool IsNumeric(this string value) {
			if (String.IsNullOrEmpty(value)) { return false; }

			decimal convert;
			return decimal.TryParse(value, out convert);
		}
		public static int AsInt(this Enum value) {
			return Convert.ToInt32(value);
		}
		public static string AsXml(this object value) {
			if (value.GetType().IsSerializable) {
				using (MemoryStream stream = new MemoryStream()) {
					XmlSerializer serializer = new XmlSerializer(value.GetType());

					serializer.Serialize(stream, value);
					stream.Close();

					return Encoding.UTF8.GetString(stream.ToArray());
				}
			}

			return String.Empty;
		}
		public static string Left(this string value, int length) {
			if (String.IsNullOrEmpty(value)) { return string.Empty; }
			if (value.Length <= length) { return value; }

			return value.Substring(0, length);
		}
		public static string Right(this string value, int length) {
			if (String.IsNullOrEmpty(value)) { return string.Empty; }
			if (value.Length <= length) { return value; }

			return value.Substring(value.Length - length, length);
		}
		public static int ConvertToInt(this string value, int defaultValue = 0) {
			try {
				return Convert.ToInt32(value);
			}
			catch {
				return defaultValue;
			}
		}
		public static int ConvertToInt(this int? value, int defaultValue = 0) {
			try {
				return Convert.ToInt32(value);
			}
			catch {
				return defaultValue;
			}
		}
		public static bool ConvertToBool(this string value, bool defaultValue = false) {
			try {
				return Convert.ToBoolean(value);
			}
			catch {
				return defaultValue;
			}
		}
		public static List<T> ConvertToList<T>(this string value, char splitChar = ',') {
			try {
				List<string> splittedList = value.Split(splitChar).ToList();

				List<T> resultList = new List<T>();

				var converter = TypeDescriptor.GetConverter(typeof(T));

				foreach (string val in splittedList) {
					T result = (T)converter.ConvertFromString(val);

					resultList.Add(result);
				}

				return resultList;
			}
			catch {
				return new List<T>();
			}
		}
	}
}
