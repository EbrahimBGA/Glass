﻿namespace Glass.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public static class Extensions
    {
        public static Stream FromUTF8ToStream(this string str)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(str));
        }

        public static string ToString(this IEnumerable items)
        {
            var builder = new StringBuilder();

            foreach (var xamlNodeType in items)
            {
                builder.Append(" ·" + xamlNodeType + "\n");
            }

            return builder.ToString();
        }

        public static void AddAll<T>(this IAdd<T> collection, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                collection.Add(item);
            }
        }

        public static Tuple<string, string> Dicotomize(this string str, char ch)
        {
            var indexOfChar = str.IndexOf(ch);

            if (indexOfChar < 0)
            {
                return new Tuple<string, string>(str, null);
            }

            var leftPart = str.Substring(0, indexOfChar);
            indexOfChar++;
            var rightPart = str.Substring(indexOfChar, str.Length - indexOfChar);

            return new Tuple<string, string>(leftPart, rightPart);
        }

        public static Stream ToStream(this string str)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(str));
        }

        public static void AddOrReplace<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key] = value;
            }
            else
            {
                dictionary.Add(key, value);
            }
        }


        public static IEnumerable<TResult> GatherAttributes<TAttribute, TResult>(this IEnumerable<Type> types, Func<Type, TAttribute, TResult> converter)
            where TAttribute : CustomAttributeData
        {
            return from type in types
                let att = type.GetTypeInfo().CustomAttributes.OfType<TAttribute>().First()
                where att != null
                select converter(type, att);
        }

        public static IEnumerable<TResult> GatherAttributesFromMembers<TAttribute, TResult>(this IEnumerable<Type> types,
            Func<PropertyInfo, TAttribute, TResult> converter)
            where TAttribute : CustomAttributeData
        {
            return from type in types
                from member in type.GetTypeInfo().GetProperties()
                let att = member.CustomAttributes.OfType<TAttribute>().First()
                where att != null
                select converter(member, att);
        }
    }
}