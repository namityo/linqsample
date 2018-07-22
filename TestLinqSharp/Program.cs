﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLinqSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Data1 の LINQ
            var data1List = GenerateData1();
            var query = BuildQuery1(data1List);
            PrintData1(query);

            // Data2 の LINQ
            //var data2List = GenerateData2();
            //var query2 = from data2 in data2List
            //             from client in data2.Clients
            //             where client.Contains("ー")
            //             select client;
            //Console.WriteLine(String.Join(", ", query2));

            //// Data2 と結合
            //var data2List = GenerateData2();
            //var query2 = from data1 in data1List
            //             join data2 in data2List on data1.GroupId equals data2.GroupId
            //             select new
            //             {
            //                 Group = data1.Group,
            //                 Address = data2.Address,
            //                 Name = data1.Name,
            //                 Age = data1.Age
            //             };
            //foreach (var data in query2)
            //{
            //    Console.WriteLine(
            //        String.Format("{0}[{1}] : {2}({3})", data.Group, data.Address, data.Name, data.Age));
            //}
        }

        static List<Data1> GenerateData1()
        {
            return new List<Data1>
            {
                new Data1("総務", 0, "鈴木", 22),
                new Data1("総務", 0, "佐藤", 33),
                new Data1("人事", 1, "斎藤", 54),
                new Data1("営業", 2, "本田", 88),
                new Data1("開発", 3, "小林", 41),
            };
        }

        static void PrintData1(IEnumerable<Data1> data1s)
        {
            foreach (var data1 in data1s)
            {
                var line = String.Format("{0}({1}) : {2}({3})", data1.Group, data1.GroupId, data1.Name, data1.Age);
                Console.WriteLine(line);
            }
        }

        static void PrintData1(IEnumerable<IGrouping<int, Data1>> groups)
        {
            foreach (var group in groups)
            {
                Console.WriteLine(String.Format("---GroupId({0})---", group.Key));

                foreach (var data1 in group)
                {
                    Console.WriteLine(String.Format("{0}({1}) : {2}({3})", data1.Group, data1.GroupId, data1.Name, data1.Age));
                }
            }
        }

        static IEnumerable<Data1> BuildQuery1(IEnumerable<Data1> data1s)
        {
            return from data1 in data1s
                   where data1.Group.Equals("総務")
                   select data1;
        }

        static IEnumerable<Data1> BuildQuery2(IEnumerable<Data1> data1s)
        {
            return from data1 in data1s
                   orderby data1.Age
                   select data1;
        }

        static IEnumerable<IGrouping<int, Data1>> BuildQuery3(IEnumerable<Data1> data1s)
        {
            return from data1 in data1s
                   group data1 by data1.GroupId;
        }

        static IEnumerable<IGrouping<int, Data1>> BuildQuery4(IEnumerable<Data1> data1s)
        {
            return from data1 in data1s
                   group data1 by data1.GroupId into newGroup
                   orderby newGroup.Key descending
                   select newGroup;
        }

        static public List<Data2> GenerateData2()
        {
            return new List<Data2>
            {
                new Data2(0, "東京", new List<string>{ }),
                new Data2(1, "東京", new List<string>{ "ソラルート", "ビズブービー" }),
                new Data2(2, "新宿", new List<string>{ "夕日飲料", "ムーントリー" }),
            };
        }

        static IEnumerable<Data1> GenerateData1Iterator()
        {
            yield return new Data1("総務", 0, "鈴木", 22);
            yield return new Data1("総務", 0, "佐藤", 33);
            yield return new Data1("人事", 1, "斎藤", 54);
            yield return new Data1("営業", 2, "本田", 88);
            yield return new Data1("開発", 3, "小林", 41);
        }
    }
}
