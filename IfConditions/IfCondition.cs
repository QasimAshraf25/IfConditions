using NCalc;
using System;
using System.Collections.Generic;

namespace IfConditions
{
    /// <summary>
    /// Condition Class for T (Generics) 
    /// </summary>
    /// <typeparam name="K">Key</typeparam>
    /// <typeparam name="V">Value</typeparam>
    public class Condition<K, V> : Dictionary<K, V>
    { }

    /// <summary>
    /// Condition Class For String DataType
    /// </summary>
    public class StringCondition : Dictionary<string, string>
    { }

    /// <summary>
    /// Condition Class For Double DataType
    /// </summary>
    public class DoubleCondition : Dictionary<double, double>
    { }

    /// <summary>
    /// Condition Class For Bool DataType
    /// </summary>
    public class BoolCondition : Dictionary<string, string>
    { }

    /// <summary>
    /// Condition Class For Int DataType
    /// </summary>
    public class IntCondition : Dictionary<int, int>
    { }

    /// <summary>
    /// Extension Helper Class
    /// </summary>
    public static class Extension
    {
        /// <summary>
        ///  Find Extension Function
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key">Key</param>
        /// <returns>Value</returns>
        public static V Find<K, V>(this Condition<K, V> dictionary, K key)
        {
            return dictionary.ContainsKey(key) ? dictionary[key] : default(V);
        }

        /// <summary>
        ///  Find Extension Function
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key">Key</param>
        /// <param name="ElseValue">Else Value</param>
        /// <returns>Value</returns>
        public static V Find<K, V>(this Condition<K, V> dictionary, K key, V ElseValue)
        {
            return dictionary.ContainsKey(key) ? dictionary[key] : ElseValue;
        }

        /// <summary>
        /// Find Extension Function
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key">Key</param>
        /// <returns>String</returns>
        public static string Find(this StringCondition dictionary, string key)
        {
            return dictionary.ContainsKey(key) ? dictionary[key] : "Key Not Found!";
        }

        /// <summary>
        /// Find Extension Function
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key">Key</param>
        /// <param name="ElseValue">Else Value</param>
        /// <returns>String</returns>
        public static string Find(this StringCondition dictionary, string key, string ElseValue)
        {
            return dictionary.ContainsKey(key) ? dictionary[key] : ElseValue;
        }

        /// <summary>
        /// Find Extension Function
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key">Key</param>
        /// <returns>String</returns>
        public static double Find(this DoubleCondition dictionary, double key)
        {
            return dictionary.ContainsKey(key) ? dictionary[key] : 0;
        }

        /// <summary>
        /// Find Extension Function
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <returns>Int</returns>
        public static int Find(this IntCondition dictionary, int key)
        {
            return dictionary.ContainsKey(key) ? dictionary[key] : 0;
        }


        /// <summary>
        /// Find Extension Function
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="ElseValue"></param>
        /// <returns>Int</returns>
        public static int Find(this IntCondition dictionary, int key, int ElseValue)
        {
            return dictionary.ContainsKey(key) ? dictionary[key] : ElseValue;
        }

        private static Expression expression;

        /// <summary>
        /// Find Extension Function
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="varaibleName">Name of Variable Use inside Expression</param>
        /// <param name="varaibleValue">Value to pass inside an Expression</param>
        /// <returns>String</returns>
        public static string Find(this BoolCondition dictionary, string varaibleName, double varaibleValue)
        {
            string value = default(string);
            foreach (KeyValuePair<string, string> item in dictionary)
            {
                expression = new Expression(item.Key);
                expression.Parameters[varaibleName] = varaibleValue;
                if (Convert.ToBoolean(Math.Floor(Convert.ToDouble(expression.Evaluate()))))
                {
                    value = dictionary[item.Key];
                    break;
                }
            }
            return value;
        }

        /// <summary>
        /// Find Extension Function
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="varaibleName1">Name of Variable Use inside Expression</param>
        /// <param name="varaibleName2">Name of Variable Use inside Expression</param>
        /// <param name="varaibleValue1">Value to pass inside an Expression</param>
        /// <param name="varaibleValue2">Value to pass inside an Expression</param>
        /// <returns>String</returns>
        public static string Find(this BoolCondition dictionary, string varaibleName1, string varaibleName2, double varaibleValue1, double varaibleValue2)
        {
            string value = default(string);
            foreach (KeyValuePair<string, string> item in dictionary)
            {
                expression = new Expression(item.Key);
                expression.Parameters[varaibleName1] = varaibleValue1;
                expression.Parameters[varaibleName2] = varaibleValue2;
                if (Convert.ToBoolean(Math.Floor(Convert.ToDouble(expression.Evaluate()))))
                {
                    value = dictionary[item.Key];
                    break;
                }
            }
            return value;
        }

        ///// <summary>
        ///// Find Extension Function
        ///// </summary>
        ///// <param name="dictionary"></param>
        ///// <param name="argument"></param>
        ///// <param name="argument2"></param>
        ///// <returns>String</returns>
        /*public static string Find(this BoolCondition dictionary, double argument, double argument2)
        {
            string value = default(string);
            foreach (KeyValuePair<string, string> item in dictionary)
            {
                Argument x = new Argument("x=" + argument);
                Argument y = new Argument("y=" + argument2);
                if (Convert.ToBoolean(Math.Floor(new Expression(item.Key, x, y).calculate())))
                {
                    value = dictionary[item.Key];
                    break;
                }
            }
            return value;
        }*/
    }
}
