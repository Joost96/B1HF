using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaarlemFestival.Model
{
    public class SalesInfo
    {
        public string PageName { get; set; }

        public List<KeyValuePair<string, int[]>> AmountSold { get; set; }
        public List<KeyValuePair<string, int>> CountryCount { get; set; }
        public List<KeyValuePair<string, int>> ActivitySales { get; set; }
        public List<KeyValuePair<string, int>> Timeslots { get; set; }
        public List<KeyValuePair<string, int>> DailySales { get; set; }

        public SalesInfo() {
            AmountSold = new List<KeyValuePair<string, int[]>>();
            CountryCount = new List<KeyValuePair<string, int>>();
            ActivitySales = new List<KeyValuePair<string, int>>();
            Timeslots = new List<KeyValuePair<string, int>>();
            DailySales = new List<KeyValuePair<string, int>>();
        }

        public void AddOrReplace<K>(List<KeyValuePair<K,int>> list, KeyValuePair<K,int> kvp)
        {
            int index = list.FindIndex(x => x.Key.Equals(kvp.Key));
            if(index >= 0)
            {
                KeyValuePair<K,int> newKVP = new KeyValuePair<K,int>(kvp.Key, list[index].Value + kvp.Value);
                list[index] = newKVP;
            } else
            {
                list.Add(kvp);
            }
        }

        public void AddAmountSold(EventType eventType, int sold, int totalTickets)
        {
            AmountSold.Add(new KeyValuePair<string, int[]>(eventType.ToString(), new int[] { sold, totalTickets }));
        }

        public void AddCountry(string country, int amount)
        {
            AddOrReplace(CountryCount, new KeyValuePair<string, int>(country, amount));
            //if (CountryCount.Exists(c => c.Key==country))
            //{
            //    CountryCount[CountryCount.FindIndex(c => c.Key == country)].value += amount;
            //}
            //else
            //{
            //    CountryCount.Add(country, amount);
            //}
        }

        public void AddActivity(string activity, int amount)
        {
            AddOrReplace(ActivitySales, new KeyValuePair<string, int>(activity, amount));
            //if (ActivitySales.ContainsKey(activity))
            //{
            //    ActivitySales[activity] += amount;
            //}
            //else
            //{
            //    ActivitySales.Add(activity, amount);
            //}
        }

        public void AddDailySale(DateTime date, int amount)
        {
            AddOrReplace(DailySales, new KeyValuePair<string, int>(date.ToString("dd/MM/yy"), amount));
            //if (DailySales.ContainsKey(date.ToString()))
            //{
            //    DailySales[date.ToString()] += amount;
            //}
            //else
            //{
            //    DailySales.Add(date.ToString(), amount);
            //}
        }
        public void AddTimeslot(TimeSlot timeslot, int amount)
        {
            string timeslotstg = timeslot.Activity.Name + "<br>" + timeslot.StartTime.ToString("dd MMM HH:mm") + " - " + timeslot.EndTime.ToString("HH:mm");
            AddOrReplace(Timeslots, new KeyValuePair<string, int>(timeslotstg, amount));
            //if (Timeslots.ContainsKey(timeslotstg))
            //{
            //    Timeslots[timeslotstg] += amount;
            //}
            //else
            //{
            //    Timeslots.Add(timeslotstg, amount);
            //}
        }
        public void GetTop10()
        {
            if(CountryCount.Count >= 10)
                CountryCount = CountryCount.OrderByDescending(x => x.Value).ToList().GetRange(0,10);
            if (ActivitySales.Count >= 10)
                ActivitySales = ActivitySales.OrderByDescending(x => x.Value).ToList().GetRange(0, 10);
            if (Timeslots.Count >= 10)
                Timeslots = Timeslots.OrderByDescending(x => x.Value).ToList().GetRange(0, 10);
            if (DailySales.Count >= 14)
                DailySales = DailySales.ToList().GetRange(0, 14);
            DailySales.Reverse();
        }
    }
}