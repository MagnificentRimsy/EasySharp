using System;
using System.Collections.Generic;
using System.Text;

namespace EasySharp.Core.Helpers
{
    public static class Extension
    {
            //dto.ForEach(n =>
            //{
                //var command = Mapping.onMap<CarDto, CreateCarCommand>(n);
            //});
        /// <summary>
        /// Partten match - Each(myList, i => Console.WriteLine(i));
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="action"></param>
        public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            foreach (var item in sequence) action(item);
        }
    }
}
